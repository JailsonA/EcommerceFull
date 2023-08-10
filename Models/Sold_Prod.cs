namespace BibliotecaXPTO_MVC.Model
{
    public class Sold_Prod
    {
        public int SoldID { get; set; }
        public SoldModel Sold { get; set; }
        public int ProductID { get; set; }
        public ProductModel Product { get; set; }
    }
}
