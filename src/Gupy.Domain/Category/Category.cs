using System.Collections.Generic;

namespace Gupy.Domain
{
    public class Category : ISoftDeletable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public bool SoftDeleted { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}