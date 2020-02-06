using AutoMapper;
using galdino.humanResource.domain.Entity.Authentication;
using galdino.humanResource.domain.Interfaeces.User;
using galdino.humanResource.Front.Models.Token;
using galdino.humanResource.Front.Models.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace galdino.humanResource.Front.Security
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
                Senha = usuario.Senha,

            });
            if (usrRetorno?.Success != null && (bool)usrRetorno?.Success)
            {
                var identity = new ClaimsIdentity(GetUserClaims(_mapper.Map<TokenModelView>(usrRetorno.ObjectReturn)), "ApplicationCookie");
                var principal = new ClaimsPrincipal(identity);
                await httpContext.SignInAsync(principal, new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddDays(7) // todo: configure this value
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
                new Claim(ClaimTypes.NameIdentifier, user.UserId),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Mail),
                new Claim("Token", user.Token)
            };

            return claims;
        }
    }
}
