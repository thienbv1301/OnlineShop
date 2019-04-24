using System.Collections.Generic;


namespace Shop.Service.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public List<ImageDto> Images { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
    }
}
