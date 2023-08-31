namespace EcommerceFull.Models
{
	public class CartProductInfoModel
	{
		public int ProductId { get; set; }
		public string Name { get; set; }
		public float Price { get; set; }
		public string ImgUrl { get; set; }
		public string CategoryName { get; set; }
		public int Quantity { get; set; }
    }
}
