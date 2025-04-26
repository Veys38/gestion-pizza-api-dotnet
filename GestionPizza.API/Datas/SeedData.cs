using GestionPizza.DAL.Context;
using GestionPizza.DL.Entities;
using Microsoft.Extensions.DependencyInjection;
using GestionPizza.BLL.Services.Interfaces;

namespace GestionPizza.API.Datas;

public static class SeedData
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        using var context = serviceProvider.GetRequiredService<LibraryDbContext>();
        var geocodingService = serviceProvider.GetRequiredService<IGeocodingService>();

        if (context.Pizzerias.Any() || context.Pizzas.Any() || context.Customers.Any() || context.Orders.Any())
        {
            Console.WriteLine("❗ Données déjà présentes. Seed annulé.");
            return;
        }

        // === Pizzerias ===
        var p1 = new Pizzeria { Name = "Sapori di Puglia", Address = "Rue Bureau 11, 4621 Fléron" };
        var p2 = new Pizzeria { Name = "Pizzeria Ciao Napoli", Address = "Rue St Paul 40, 4000 Liège" };
        var p3 = new Pizzeria { Name = "Pizzeria Chez Martino", Address = "Rue de la Clef 8, 4620 Fléron" };
        var p4 = new Pizzeria { Name = "Pizzeria Da Sergio", Address = "Rue de la Clef 115, 4621 Fléron" };
        var p5 = new Pizzeria { Name = "Pizzeria Amarena", Address = "Rue de la Bergerie 23, 4100 Seraing" };
        var p6 = new Pizzeria { Name = "Pizzeria Pino", Address = "Rte du Condroz 131, 4550 Nandrin" };

        var allPizzerias = new[] { p1, p2, p3, p4, p5, p6 };

        foreach (var pizzeria in allPizzerias)
        {
            var (lat, lon) = await geocodingService.GetCoordinatesFromAddressAsync(pizzeria.Address);
            pizzeria.Latitude = lat;
            pizzeria.Longitude = lon;
        }

        context.Pizzerias.AddRange(allPizzerias);
        await context.SaveChangesAsync();

        // === Ingrédients ===
        var ingredients = new List<Ingredient>
        {
            new() { Name = "Sauce Tomate", Price = 0.50m, TimeInSeconds = 10 },
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
        await context.SaveChangesAsync();

        // === Pizzas ===
        var margherita = new Pizza { PizzaName = "Margherita", Price = 8.50m, BasePreparationTime = 180, Pizzeria = p1 };
        var quatreFromages = new Pizza { PizzaName = "4 Fromages", Price = 10.00m, BasePreparationTime = 220, Pizzeria = p1 };
        var reine = new Pizza { PizzaName = "Reine", Price = 9.50m, BasePreparationTime = 200, Pizzeria = p1 };
        var hawaiienne = new Pizza { PizzaName = "Hawaïenne", Price = 9.90m, BasePreparationTime = 210, Pizzeria = p2 };
        var pepperoni = new Pizza { PizzaName = "Pepperoni", Price = 10.50m, BasePreparationTime = 190, Pizzeria = p2 };
        var vegetarienne = new Pizza { PizzaName = "Végétarienne", Price = 9.80m, BasePreparationTime = 200, Pizzeria = p2 };

        var pizzas = new List<Pizza>
        {
            margherita, quatreFromages, reine, hawaiienne, pepperoni, vegetarienne
        };

        context.Pizzas.AddRange(pizzas);
        await context.SaveChangesAsync();

        margherita.Ingredients = new List<Ingredient>
        {
            ingredients.First(i => i.Name == "Sauce Tomate"),
            ingredients.First(i => i.Name == "Mozzarella")
        };

        quatreFromages.Ingredients = new List<Ingredient>
        {
            ingredients.First(i => i.Name == "Mozzarella"),
            ingredients.First(i => i.Name == "Cheddar"),
            ingredients.First(i => i.Name == "Gorgonzola")
        };

        reine.Ingredients = new List<Ingredient>
        {
            ingredients.First(i => i.Name == "Sauce Tomate"),
            ingredients.First(i => i.Name == "Mozzarella"),
            ingredients.First(i => i.Name == "Jambon"),
            ingredients.First(i => i.Name == "Champignons")
        };

        hawaiienne.Ingredients = new List<Ingredient>
        {
            ingredients.First(i => i.Name == "Sauce Tomate"),
            ingredients.First(i => i.Name == "Mozzarella"),
            ingredients.First(i => i.Name == "Jambon"),
            ingredients.First(i => i.Name == "Ananas")
        };

        pepperoni.Ingredients = new List<Ingredient>
        {
            ingredients.First(i => i.Name == "Sauce Tomate"),
            ingredients.First(i => i.Name == "Mozzarella"),
            ingredients.First(i => i.Name == "Pepperoni")
        };

        vegetarienne.Ingredients = new List<Ingredient>
        {
            ingredients.First(i => i.Name == "Sauce Tomate"),
            ingredients.First(i => i.Name == "Mozzarella"),
            ingredients.First(i => i.Name == "Champignons"),
            ingredients.First(i => i.Name == "Oignons"),
            ingredients.First(i => i.Name == "Olives")
        };

        await context.SaveChangesAsync();
        Console.WriteLine("✅ Base initialisée avec succès !");
    }
}
