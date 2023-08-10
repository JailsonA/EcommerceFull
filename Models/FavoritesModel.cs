using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaXPTO_MVC.Model
{
    public class FavoritesModel
    {
        [Key]
        public int FavoritesID { get; set; }

        public Fav_Prod  FP { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }
        public UserModel User { get; set; }
    }
}
