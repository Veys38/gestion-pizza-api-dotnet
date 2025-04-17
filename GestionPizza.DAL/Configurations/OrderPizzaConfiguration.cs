using GestionPizza.DL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionPizza.DAL.Configurations;

public class OrderPizzaConfiguration : IEntityTypeConfiguration<OrderPizza>
{
    public void Configure(EntityTypeBuilder<OrderPizza> builder)
    {
        builder.HasKey(op => new { op.OrderId, op.PizzaId });
        
        builder.Property(op => op.Quantity).IsRequired();
        builder.Property(op => op.Quantity).HasMaxLength(2);
        
        builder.HasOne(op => op.Order)
            .WithMany(o => o.OrderPizzas)
            .HasForeignKey(op => op.OrderId);
        
        builder.HasOne(op => op.Pizza)
            .WithMany(p => p.OrderPizzas)
            .HasForeignKey(op => op.PizzaId);
    }
}