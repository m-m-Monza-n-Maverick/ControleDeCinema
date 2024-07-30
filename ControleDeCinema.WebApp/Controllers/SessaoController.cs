using Microsoft.AspNetCore.Mvc;

namespace ControleDeCinema.WebApp.Controllers
{
	public class SessaoController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
