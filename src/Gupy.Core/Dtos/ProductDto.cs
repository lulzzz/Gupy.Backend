using System;

namespace Gupy.Core.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public bool IsAvailable { get; set; }
        public int CategoryId { get; set; }
        public string Photo { get; set; }
        public float? PromotionPrice { get; set; }
        public DateTime? PromotionEndDate { get; set; }
    }
}