using System.ComponentModel.DataAnnotations;

namespace BibliotecaXPTO_MVC.Model
{
    public class UserModel
    {
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserPass { get; set; }
        public string UserEmail { get; set; }
        public string UserPhoto { get; set; }
        public string UserStatus { get; set; }
        public string UserType { get; set; }

        public ICollection<FavoritesModel> Favorites { get; set; }

        public CartModel Cart { get; set; }
    }
}
