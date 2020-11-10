using System;

namespace Gupy.Domain
{
    public class Product : ISoftDeletable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public float? PromotionPrice { get; set; }
        public DateTime? PromotionEndDate { get; set; }
        public string Photo { get; set; }
        public bool IsAvailable { get; set; }
        public bool SoftDeleted { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}