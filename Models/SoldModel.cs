using System.ComponentModel.DataAnnotations;

namespace EcommerceFull.Models
{
    public class SoldModel
    {
        [Key]
        public int SoldID { get; set; }
        public int Quantity { get; set; }
        public float Total { get; set; }

        public int UserID { get; set; }
        public UserModel User { get; set; }

        public Sold_Prod SP { get; set; }
    }
}
