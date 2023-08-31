namespace EcommerceFull.Models
{
    public class Cart_Prod
    {
        public int CartID { get; set; }
        public CartModel Cart { get; set; }
        public int ProductID { get; set; }
        public ProductModel Product { get; set; }  
    }
}
