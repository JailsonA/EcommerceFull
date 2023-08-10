using Microsoft.AspNetCore.Mvc;

namespace EcommerceFull.Controllers
{
	public class ShopController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
