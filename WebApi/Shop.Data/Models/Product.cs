using System.Collections.Generic;

namespace Shop.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
        public int CategoryId { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; } 
        public virtual Category Category { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual Color Color { get; set; }
        public virtual Size Size { get; set; }
    }
}
