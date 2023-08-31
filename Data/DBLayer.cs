using EcommerceFull.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Common;

namespace EcommerceFull.Data
{
    public class DBLayer
    {
        private readonly DBContext _context;

        public DBLayer(DBContext context)
        {
            _context = context;
        }


        // get al products
        public List<ProductModel> GetProducts()
        {
            return _context.Products.ToList();
        }

        // get all by category
        public List<CategoryModel> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        // get all category unique by product
        public List<CategoryModel> GetCategory()
        {
            List<ProductModel> products = GetProducts();
            List<CategoryModel> categories = GetAllCategories();

            List<CategoryModel> distinctCategories = products
                .Join(categories,
                      product => product.CategoryID,
                      category => category.CategoryID,
                      (product, category) => category)
                .DistinctBy(category => category.CategoryID)
                .ToList();

            return distinctCategories;
        }


        // get all products on the cart
        public List<CartProductInfoModel> GetCart(int userId)
        {
            var cartProducts = _context.Carts
                .Where(cart => cart.UserID == userId)
                .Include(cart => cart.CP)
                .ThenInclude(cp => cp.Product)
                .ThenInclude(product => product.Category)
                .Select(cart => new CartProductInfoModel
                {
                    ProductId = cart.CP.Product.ProductId,
                    Name = cart.CP.Product.Name,
                    Price = cart.CP.Product.Price,
                    ImgUrl = cart.CP.Product.ImgUrl,
                    CategoryName = cart.CP.Product.Category.CategoryName,
                    Quantity = cart.Quantity
                })
                .ToList();

            return cartProducts;
        }

        // count all products on the cart
        public int CartCount(int userId)
        {
            int itemCount = _context.Carts
                .Where(cart => cart.UserID == userId)
                .Sum(cart => cart.Quantity);

            return itemCount;
        }

        // count all products on the Favorites
        public int CountFavorities(int userID)
        {
            int count = _context.Favorites
                .Where(favorite => favorite.UserID == userID)
                .Count();

            return count;
        }

        // verify if the product is on the favorites by user
        public bool verFavorities(int userID, int productID)
        {
            var favoritoExistente = _context.Favorites
                    .Include(f => f.FP)
                    .FirstOrDefault(f => f.FP.ProductID == productID && f.UserID == userID);

            if (favoritoExistente != null)
            {
                return true;
            }
            return false;
        }

        // set favorites by user
        public int SetFavoritos(int Cliente_id, int productID)
        {
            try
            {
                var favoritoExistente = _context.Favorites
                    .Include(f => f.FP)
                    .FirstOrDefault(f => f.FP.ProductID == productID && f.UserID == Cliente_id);

                if (favoritoExistente != null)
                {
                    // Existe um favorito igual na base de dados, então vamos apagar
                    _context.Favorites.Remove(favoritoExistente);
                }
                else
                {
                    // Não existe um favorito igual na base de dados, então vamos adicionar
                    var novoFavorito = new FavoritesModel
                    {
                        UserID = Cliente_id
                    };
                    _context.Favorites.Add(novoFavorito);

                    var novoFav_Prod = new Fav_Prod
                    {
                        Favorite = novoFavorito,
                        ProductID = productID
                    };
                    _context.Fav_Prods.Add(novoFav_Prod);
                }

                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool SetCart(int userID, int productID, int quantidade)
        {
            bool result = false;
            var transaction = _context.Database.BeginTransaction();

            try
            {
                var user = _context.Users.Find(userID);
                var product = _context.Products.Find(productID);
                if (user == null || product == null) { return false; }

                var cartItem = _context.Carts
                    .Include(c => c.CP)
                    .FirstOrDefault(c => c.CP.ProductID == productID && c.UserID == userID);

                if (cartItem != null)
                {
                    if (quantidade > 0)
                    {
                        // Atualiza a quantidade
                        cartItem.Quantity += quantidade;
                    }
                    else
                    {
                        // Remove o item do carrinho e o relacionamento Cart_Prod
                        _context.Carts.Remove(cartItem);
                        _context.Cart_Prods.Remove(cartItem.CP);
                    }
                }
                else if (quantidade > 0)
                {
                    // Adiciona um novo item ao carrinho
                    var newCartItem = new CartModel
                    {
                        UserID = userID,
                        Quantity = quantidade,
                        CP = new Cart_Prod
                        {
                            ProductID = productID
                        }
                    };
                    _context.Carts.Add(newCartItem);
                }

                _context.SaveChanges();
                transaction.Commit();
                result = true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool SetSold(int userID)
        {
            bool result = false;
            var transaction = _context.Database.BeginTransaction();

            try
            {
                var user = _context.Users.Find(userID);
                if (user == null) { return false; }

                var cart = _context.Carts
                 .Include(c => c.CP)
                 .Where(c => c.UserID == userID)
                 .ToList();

                // Create a new sold item for each cart item
                foreach (var cartItem in cart)
                {
                    var soldItem = new SoldModel
                    {
                        UserID = userID,
                        Quantity = cartItem.Quantity,
                        Total = cartItem.Quantity * _context.Products.FirstOrDefault(p => p.ProductId == cartItem.CP.ProductID)?.Price ?? 0
                    };

                    // Add the sold item to the context
                    _context.Solds.Add(soldItem);

                    // Now you can access the generated SoldID
                    var soldProduct = new Sold_Prod
                    {
                        Sold = soldItem,
                        Product = _context.Products.FirstOrDefault(p => p.ProductId == cartItem.CP.ProductID)
                    };
                    _context.Sold_Prods.Add(soldProduct);

                    // Remove the cart item from the context
                    _context.Carts.Remove(cartItem);
                    _context.Cart_Prods.Remove(cartItem.CP);
                }

                // Save changes to the database
                _context.SaveChanges();
                transaction.Commit();
                result = true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception(ex.Message);
            }

            return result;
        }

    }
}
