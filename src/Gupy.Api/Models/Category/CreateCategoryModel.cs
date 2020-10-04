using Microsoft.AspNetCore.Http;

namespace Gupy.Api.Models.Category
{
    public class CreateCategoryModel
    {
        public string Name { get; set; }
        public IFormFile Photo { get; set; }
    }
}