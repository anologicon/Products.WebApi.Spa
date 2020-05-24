using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Products.WebApi.Entities;
using Products.WebApi.Mappings;

namespace Products.WebApi.Config
{
    public class ProductsApiDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
       
        public DbSet<ProductEntity> ProductEntitie { get; set; }

        public ProductsApiDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("ProductsApiConnection");
            optionsBuilder.UseNpgsql(connectionString);
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("product");
            modelBuilder.ApplyConfiguration(new ProductMapping());
        }
    }
    
  
    
}