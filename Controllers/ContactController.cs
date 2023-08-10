using Microsoft.AspNetCore.Mvc;

namespace EcommerceFull.Controllers
{
	public class ContactController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
