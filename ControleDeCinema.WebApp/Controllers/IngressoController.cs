using Microsoft.AspNetCore.Mvc;

namespace ControleDeCinema.WebApp.Controllers
{
	public class IngressoController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
