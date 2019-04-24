using System.Collections.Generic;

namespace Shop.Data.Models
{
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
