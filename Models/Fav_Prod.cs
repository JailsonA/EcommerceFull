using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceFull.Models
{
    public class Fav_Prod
    {
        public int FavoritesID { get; set; }
        public FavoritesModel Favorite { get; set; }

        public int ProductID { get; set; }
        public ProductModel Product { get; set; }
    }
}
