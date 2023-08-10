using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaXPTO_MVC.Model
{
    public class ProductModel
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }

        public float Price { get; set; }

        public string ImgUrl { get; set; }

        // categoria relacionada ao produto
        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public CategoryModel Category { get; set; }

        // favoritos relacionados ao produto
        public Fav_Prod FP { get; set; }

        // Cart relacionados ao produto
        public Cart_Prod CP { get; set; }

        // Vendido relacionados ao produto
        public Sold_Prod SP { get; set; }


    }
}
