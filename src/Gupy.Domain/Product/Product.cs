namespace Gupy.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string Photo { get; set; }
        public bool IsAvailable { get; set; }
        
        public Category Category { get; set; }
        public int CategoryId { get; set; }

    }
}