using System;
using Microsoft.AspNetCore.Http;

namespace Gupy.Api.Models.Product
{
    public class UpdateProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public bool IsAvailable { get; set; }
        public int CategoryId { get; set; }
        public float? PromotionPrice { get; set; }
        public DateTime? PromotionEndDate { get; set; }
        public IFormFile Photo { get; set; }
    }
}