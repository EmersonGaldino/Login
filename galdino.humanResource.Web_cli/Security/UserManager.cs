using AutoMapper;
using galdino.humanResource.domain.Entity.Authentication;
using galdino.humanResource.domain.Interfaeces.User;
using galdino.humanResource.Web_cli.Models.ModelView;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace galdino.humanResource.Web_cli.Security
{
    public class UserManager
    {
        private readonly IUserIntegration _usuarioIntegration;
        private readonly IMapper _mapper;

        public UserManager(IUserIntegration usuarioIntegration, IMapper mapper)
        {
            _usuarioIntegration = usuarioIntegration;
            _mapper = mapper;
        }


        public async Task SignIn(HttpContext httpContext, UserViewModel usuario)
        {
            var usrRetorno = await _usuarioIntegration.LoginAsync(new UserLogin
            {
                Login = usuario.Usuario,
                Password = usuario.Password,

            });
            if (usrRetorno?.Sucesso != null && (bool)usrRetorno?.Sucesso)
            {
                var identity = new ClaimsIdentity(GetUserClaims(_mapper.Map<TokenModelView>(usrRetorno.objetoDeRetorno)), "ApplicationCookie");
                var principal = new ClaimsPrincipal(identity);
                await httpContext.SignInAsync(principal, new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddDays(7) 
                });
                return;
            }
        }


        public async Task SignOut(HttpContext httpContext)
        {
            await httpContext.SignOutAsync();
        }

        private static IEnumerable<Claim> GetUserClaims(TokenModelView user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UsuarioId),
                new Claim(ClaimTypes.Name, user.Nome),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("Token", user.Token)
            };

            return claims;
        }
    }

}
