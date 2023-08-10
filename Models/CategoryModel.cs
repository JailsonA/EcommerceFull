using System.ComponentModel.DataAnnotations;

namespace BibliotecaXPTO_MVC.Model
{
    public class CategoryModel
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public ICollection<ProductModel> Products { get; set; }
    }
}
