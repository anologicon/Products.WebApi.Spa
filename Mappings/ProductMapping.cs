using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.WebApi.Entities;

namespace Products.WebApi.Mappings
{
    public class ProductMapping: IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            
            builder.ToTable("product");

            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnName("id")
                .IsRequired();
            
            builder
                .Property(x => x.Name)
                .HasColumnName("name")
                .IsRequired();
            
            builder
                .Property(x => x.Price)
                .HasColumnName("price")
                .IsRequired();
            
            builder
                .Property(x => x.Stock)
                .HasColumnName("stock")
                .IsRequired();
        }
    }
}