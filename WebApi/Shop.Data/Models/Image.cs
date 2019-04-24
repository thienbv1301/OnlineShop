﻿namespace Shop.Data.Models
{
    public class Image
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ImageUrl { get; set; }
        public bool IsPrimaryImage { get; set; }
        public virtual Product Product { get; set; }
    }
}
