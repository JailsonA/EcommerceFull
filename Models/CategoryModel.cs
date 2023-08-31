using System.ComponentModel.DataAnnotations;

namespace EcommerceFull.Models
{
    public class CategoryModel
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public ICollection<ProductModel> Products { get; set; }
    }
}
