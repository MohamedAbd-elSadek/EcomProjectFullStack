using EcomProject.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomProject.DAL.EntitiesConfiguration
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e=>e.ProductId);
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(80);
            builder.Property(e => e.Description)
                .HasMaxLength(400)
                .IsRequired();
            builder.Property(e => e.Price)
                .IsRequired();
            builder.Property(e=>e.ManufactureDate)
                .IsRequired();
            
            builder.HasOne(e => e.Category)
                .WithMany(e => e.Products)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(e => e.Photos)
                .WithOne(p => p.Product)
                .OnDelete(DeleteBehavior.Cascade);
                
        }
    }
}
