using GestionPizza.DL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionPizza.DAL.Configurations;

public class PizzeriaConfiguration : IEntityTypeConfiguration<Pizzeria>
{
    public void Configure(EntityTypeBuilder<Pizzeria> builder)
    {
        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.Address).HasMaxLength(50);
        
        builder.Property(p => p.Address).IsRequired();
        builder.Property(p => p.Address).HasMaxLength(200);
    }
}