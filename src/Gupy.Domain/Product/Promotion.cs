namespace Gupy.Domain
{
    public class Promotion
    {
        public int Id { get; set; }
        public float Price { get; set; }
        public string Message { get; set; }

        public Product Product { get; set; }
    }
}