/*using GestionPizza.DL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionPizza.DAL.Configurations;

public class PizzaIngredientConfiguration : IEntityTypeConfiguration<PizzaIngredient>
{
    public void Configure(EntityTypeBuilder<PizzaIngredient> builder)
    {
        builder.HasKey(pi => new { pi.IngredientId, pi.PizzaId });
        
        builder.HasOne(pi => pi.Pizza)
            .WithMany(p => p.PizzaIngredients)
            .HasForeignKey(pi => pi.PizzaId);
        
        builder.HasOne(pi => pi.Ingredient)
            .WithMany(i => i.PizzaIngredients)
            .HasForeignKey(pi => pi.IngredientId);
    }
}*/