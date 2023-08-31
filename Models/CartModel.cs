using System.ComponentModel.DataAnnotations;

namespace EcommerceFull.Models
{
    public class CartModel
    {
        [Key]
        public int CartID { get; set; }
        public int UserID { get; set; }
        public UserModel User { get; set; }
        public int Quantity { get; set; }

        public Cart_Prod CP { get; set; }

    }
}
