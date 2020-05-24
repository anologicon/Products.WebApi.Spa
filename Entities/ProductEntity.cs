namespace Products.WebApi.Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public double Price { get; set; }
        
        public int Stock { get; set; }
    }
}