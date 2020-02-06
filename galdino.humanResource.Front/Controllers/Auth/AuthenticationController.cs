using AutoMapper;
using galdino.humanResource.domain.Exception.Access;
using galdino.humanResource.domain.Exception.Domain;
using galdino.humanResource.domain.Interfaeces.User;
using galdino.humanResource.Front.Controllers.Base;
using galdino.humanResource.Front.Models.ModelView;
using galdino.humanResource.Front.Models.ViewModel;
using galdino.humanResource.Front.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace galdino.humanResource.Front.Controllers.Auth
{
    [AllowAnonymous]
    public class AuthenticationController : BaseController
    {
        private readonly UserManager userManager;
        public AuthenticationController(IMapper mapper, IUserIntegration userIntegration, UserManager userManager) : base(mapper, userIntegration)
        {
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Auth(UserViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid) return View("Auth", Mapper.Map<UserModelView>(model));
            try
            {
                await userManager.SignOut(HttpContext);
                await userManager.SignIn(HttpContext, model);
            }
            catch (AccessDeniedDomainException ex)
            {
                ModelState.AddModelError("", "Usuário ou senha inválidos");
            }
            catch (DomainException ex)
            {
                ModelState.AddModelError("", "Usuário ou senha inválidos");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            if (ModelState.ErrorCount > 0) return View("Auth", Mapper.Map<UserModelView>(model));
            if (string.IsNullOrEmpty(returnUrl))
                return RedirectToActionPermanent("Index", "DashBoard");
            else
                return RedirectPermanent(returnUrl);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await userManager.SignOut(HttpContext);
            return RedirectToAction("Auth");
        }
    }
}