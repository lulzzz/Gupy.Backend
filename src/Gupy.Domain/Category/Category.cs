using System.Collections.Generic;

namespace Gupy.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Photo Photo { get; set; }

        public int? PhotoId { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}