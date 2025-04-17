using GestionPizza.DAL.Context;
using GestionPizza.DL.Entities;
using Microsoft.Extensions.DependencyInjection;


namespace GestionPizza.DAL.Datas;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = serviceProvider.GetRequiredService<LibraryDbContext>();

        if (context.Pizzerias.Any() || context.Pizzas.Any() || context.Customers.Any() || context.Orders.Any())
        {
            Console.WriteLine("❗ Données déjà présentes. Seed annulé.");
            return;
        }

        // === Pizzerias ===
        var p1 = new Pizzeria { Name = "Pizza Bella", Address = "Rue du Four 123, Liège" };
        var p2 = new Pizzeria { Name = "Napoli Express", Address = "Avenue de Rome 45, Bruxelles" };
        context.Pizzerias.AddRange(p1, p2);
        context.SaveChanges();

        // === Ingrédients ===
        var ingredients = new List<Ingredient>
        {
            new() { Name = "Tomate", Price = 0.50m, TimeInSeconds = 10 },
            new() { Name = "Mozzarella", Price = 0.70m, TimeInSeconds = 15 },
            new() { Name = "Cheddar", Price = 0.80m, TimeInSeconds = 20 },
            new() { Name = "Jambon", Price = 1.00m, TimeInSeconds = 25 },
            new() { Name = "Champignons", Price = 0.60m, TimeInSeconds = 15 },
            new() { Name = "Gorgonzola", Price = 0.90m, TimeInSeconds = 20 },
            new() { Name = "Ananas", Price = 0.75m, TimeInSeconds = 20 },
            new() { Name = "Oignons", Price = 0.40m, TimeInSeconds = 10 },
            new() { Name = "Olives", Price = 0.50m, TimeInSeconds = 10 },
            new() { Name = "Pepperoni", Price = 1.20m, TimeInSeconds = 25 }
        };
        context.Ingredients.AddRange(ingredients);
        context.SaveChanges();

        // === Pizzas ===
        var pizzas = new List<Pizza>
        {
            new() { PizzaName = "Margherita", Price = 8.50m, BasePreparationTime = 180, Pizzeria = p1 },
            new() { PizzaName = "4 Fromages", Price = 10.00m, BasePreparationTime = 220, Pizzeria = p1 },
            new() { PizzaName = "Reine", Price = 9.50m, BasePreparationTime = 200, Pizzeria = p1 },
            new() { PizzaName = "Hawaïenne", Price = 9.90m, BasePreparationTime = 210, Pizzeria = p2 },
            new() { PizzaName = "Pepperoni", Price = 10.50m, BasePreparationTime = 190, Pizzeria = p2 },
            new() { PizzaName = "Végétarienne", Price = 9.80m, BasePreparationTime = 200, Pizzeria = p2 }
        };
        context.Pizzas.AddRange(pizzas);
        context.SaveChanges();

        var margherita = pizzas.First(p => p.PizzaName == "Margherita");
        margherita.Ingredients.Add(ingredients.First(i => i.Name == "Tomate"));
        margherita.Ingredients.Add(ingredients.First(i => i.Name == "Mozzarella"));

        var quatreFromages = pizzas.First(p => p.PizzaName == "4 Fromages");
        quatreFromages.Ingredients.Add(ingredients.First(i => i.Name == "Mozzarella"));
        quatreFromages.Ingredients.Add(ingredients.First(i => i.Name == "Cheddar"));
        quatreFromages.Ingredients.Add(ingredients.First(i => i.Name == "Gorgonzola"));

        var reine = pizzas.First(p => p.PizzaName == "Reine");
        reine.Ingredients.Add(ingredients.First(i => i.Name == "Tomate"));
        reine.Ingredients.Add(ingredients.First(i => i.Name == "Mozzarella"));
        reine.Ingredients.Add(ingredients.First(i => i.Name == "Jambon"));
        reine.Ingredients.Add(ingredients.First(i => i.Name == "Champignons"));

        var hawaiienne = pizzas.First(p => p.PizzaName == "Hawaïenne");
        hawaiienne.Ingredients.Add(ingredients.First(i => i.Name == "Tomate"));
        hawaiienne.Ingredients.Add(ingredients.First(i => i.Name == "Mozzarella"));
        hawaiienne.Ingredients.Add(ingredients.First(i => i.Name == "Jambon"));
        hawaiienne.Ingredients.Add(ingredients.First(i => i.Name == "Ananas"));

        var pepperoni = pizzas.First(p => p.PizzaName == "Pepperoni");
        pepperoni.Ingredients.Add(ingredients.First(i => i.Name == "Tomate"));
        pepperoni.Ingredients.Add(ingredients.First(i => i.Name == "Mozzarella"));
        pepperoni.Ingredients.Add(ingredients.First(i => i.Name == "Pepperoni"));

        var vegetarienne = pizzas.First(p => p.PizzaName == "Végétarienne");
        vegetarienne.Ingredients.Add(ingredients.First(i => i.Name == "Tomate"));
        vegetarienne.Ingredients.Add(ingredients.First(i => i.Name == "Mozzarella"));
        vegetarienne.Ingredients.Add(ingredients.First(i => i.Name == "Champignons"));
        vegetarienne.Ingredients.Add(ingredients.First(i => i.Name == "Oignons"));
        vegetarienne.Ingredients.Add(ingredients.First(i => i.Name == "Olives"));

        context.SaveChanges();

        Console.WriteLine("✅ Base initialisée avec succès !");
    }
}
