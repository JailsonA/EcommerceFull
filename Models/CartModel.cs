using System.ComponentModel.DataAnnotations;

namespace BibliotecaXPTO_MVC.Model
{
    public class CartModel
    {
        [Key]
        public int CartID { get; set; }
        public int ProductID { get; set; }
        public int UserID { get; set; }
        public UserModel User { get; set; }
        public int Quantity { get; set; }

        public Cart_Prod CP { get; set; }



    }
}
