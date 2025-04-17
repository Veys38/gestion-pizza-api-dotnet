using GestionPizza.DAL.Configurations;
using GestionPizza.DL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestionPizza.DAL.Context;

public class LibraryDbContext : DbContext
{
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Ingredient> Ingredients => Set<Ingredient>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderPizza> OrderPizzas => Set<OrderPizza>();
    public DbSet<Pizza> Pizzas => Set<Pizza>();
    public DbSet<Pizzeria> Pizzerias => Set<Pizzeria>();
    
    
    public LibraryDbContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=gestion_pizzeria;Username=postgres;Password=Test1234=");
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new CustomerConfiguration());
        builder.ApplyConfiguration(new IngredientConfiguration());
        builder.ApplyConfiguration(new OrderConfiguration());
        builder.ApplyConfiguration(new OrderPizzaConfiguration());
        builder.ApplyConfiguration(new PizzaConfiguration());
        //builder.ApplyConfiguration(new PizzaIngredientConfiguration());
        builder.ApplyConfiguration(new PizzeriaConfiguration());


    }
}