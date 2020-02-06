using AutoMapper;
using galdino.humanResource.domain.Interfaeces.User;
using galdino.humanResource.Web_cli.Controllers.Base;
using galdino.humanResource.Web_cli.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace galdino.humanResource.Web_cli.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IMapper mapper, IUserIntegration userIntegration) : base(mapper, userIntegration)
        {
        }
        public IActionResult Index()
        {
            ViewData["User"] = UsuarioLogado.Usuario;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
