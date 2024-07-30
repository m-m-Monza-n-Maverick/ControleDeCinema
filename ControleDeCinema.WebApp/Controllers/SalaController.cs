using Microsoft.AspNetCore.Mvc;

namespace ControleDeCinema.WebApp.Controllers
{
	public class SalaController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
