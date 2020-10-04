using Microsoft.AspNetCore.Http;

namespace Gupy.Api.Models.Category
{
    public class UpdateCategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile Photo { get; set; }
    }
}