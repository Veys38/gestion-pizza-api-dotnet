using GestionPizza.DL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionPizza.DAL.Configurations;

public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
{
    public void Configure(EntityTypeBuilder<Ingredient> builder)
    {
        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.Name).HasMaxLength(50);
        
        builder.Property(p => p.Price).IsRequired();
        builder.Property(p => p.Price).HasMaxLength(5);
        
        builder.Property(p => p.TimeInSeconds).IsRequired();
        
       // builder.HasMany(i => i.Pizzas).WithMany(p => p.Ingredients);
    }
}