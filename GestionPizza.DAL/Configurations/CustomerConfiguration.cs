using GestionPizza.DL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionPizza.DAL.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasIndex(c => c.FullName).IsUnique();
        builder.Property(c => c.FullName).IsRequired();
        builder.Property(c => c.FullName).HasMaxLength(50);
        
        builder.HasIndex(c => c.PhoneNumber).IsUnique();
        builder.Property(c => c.PhoneNumber).IsRequired();
        builder.Property(c => c.PhoneNumber).HasMaxLength(50);
        
        builder.Property(c => c.Password).IsRequired();
        
        builder.Property(c => c.Role).IsRequired();

    }
}