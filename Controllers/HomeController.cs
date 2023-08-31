using EcommerceFull.Data;
using EcommerceFull.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace EcommerceFull.Controllers
{
    public class HomeController : Controller
    {
        private readonly DBLayer _dbLayer;
        public HomeController(DBLayer dbLayer)
        {
			_dbLayer = dbLayer;
		}
        public IActionResult Index()
        {
			int UserID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));
            List<ProductModel> product = _dbLayer.GetProducts();
			List<CategoryModel> categories = _dbLayer.GetCategory();

			ViewBag.Category = categories;

			if (UserID > 0)
			{
				List<CartProductInfoModel> cart = _dbLayer.GetCart(UserID);
				ViewBag.Cart = cart;
			}


			return View("Index", product);
        }

		[HttpPost]
		public IActionResult AddOrRemoveFavorite(int userId, int productId)
		{
			// Chame o método addFavorities do seu DBLayer para adicionar/remover favoritos
			_dbLayer.SetFavoritos(userId, productId);

			// Retorne uma resposta indicando o estado do favorito (por exemplo, se foi adicionado ou removido)
			bool isFavorite = _dbLayer.verFavorities(userId, productId);

			return Json(new { isFavorite });
		}

		public int getFavCount(int userId)
		{
			return _dbLayer.CountFavorities(userId);
		}

		public int CountCart(int userId)
		{
			return _dbLayer.CartCount(userId);
		}

		public IActionResult AddToCart(int userId, int productId, int quantidade)
		{
			// Chame o método AddToCart do seu DBLayer para adicionar o produto ao carrinho
		 	bool isAdd =  _dbLayer.SetCart(userId, productId, quantidade);
			
			return Json(new { success = isAdd });
		}


        public IActionResult Contact()
        {
            return View();
        }

    }
}