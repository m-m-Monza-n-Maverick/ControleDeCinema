using Microsoft.AspNetCore.Mvc;
namespace ControleDeCinema.WebApp.Controllers
{
    public class InicioController : Controller
    {
        public IActionResult Index() => View();
    }
}
