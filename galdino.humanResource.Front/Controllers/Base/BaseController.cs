using AutoMapper;
using galdino.humanResource.domain.Interfaeces.User;
using galdino.humanResource.Front.Models.ModelView;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace galdino.humanResource.Front.Controllers.Base
{
    public abstract class BaseController : Controller
    {
        public int UsuarioId => Convert.ToInt32(User.FindFirst(JwtRegisteredClaimNames.Jti)?.Value);
        public string UsuarioNome => User.Identity.Name;
        public string IP => Request.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        public string Token => User.Claims.FirstOrDefault(x => x.Type == "Token")?.Value;

        protected readonly IMapper Mapper;

        protected readonly IUserIntegration userService;

       

        protected BaseController(IMapper mapper, IUserIntegration usuarioIntegration)
        {
            userService = usuarioIntegration;
            Mapper = mapper;
        }

        //public BaseController(IMapper mapper, IColaboradorIntegration colaboradorIntegration)
        //{
        //    Mapper = mapper;
        //    this.ColaboradorIntegration = colaboradorIntegration;
        //}

        public UserModelView UsuarioLogado => Mapper.Map<UserModelView>(userService.GetById(UsuarioId));

        public bool _isActive { set; get; }

        /// <summary>
        /// Redireciona para a pagina de login.
        /// </summary>
        public void VerifyAccess()
        {
            _isActive = true;
            //}
        }
    }
}
