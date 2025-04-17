using GestionPizza.DL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionPizza.DAL.Configurations;

public class PizzaConfiguration : IEntityTypeConfiguration<Pizza>
{
    public void Configure(EntityTypeBuilder<Pizza> builder)
    {
        builder.Property(p => p.PizzaName).IsRequired();
        builder.Property(p => p.PizzaName).HasMaxLength(50);
        
        builder.Property(p => p.Price).IsRequired();
        
        builder.Property(p => p.BasePreparationTime).IsRequired();
        
        builder.HasMany(p => p.Ingredients).WithMany(i => i.Pizzas);

        
    }

}

