using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceFull.Models
{
    public class FavoritesModel
    {
        [Key]
        public int FavoritesID { get; set; }

        public Fav_Prod  FP { get; set; }
        public int UserID { get; set; }
        public UserModel User { get; set; }
    }
}
