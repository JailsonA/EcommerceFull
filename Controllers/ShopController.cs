using EcommerceFull.Data;
using EcommerceFull.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceFull.Controllers
{
    public class ShopController : Controller
    {
        private readonly DBLayer _dbLayer;

        public ShopController(DBLayer dbLayer)
        {
            _dbLayer = dbLayer;
        }
        public IActionResult Index()
        {
            List<ProductModel> product = _dbLayer.GetProducts();
            List<CategoryModel> categories = _dbLayer.GetCategory();

            ViewBag.Category = categories;

            return View(product);
        }
    }
}
