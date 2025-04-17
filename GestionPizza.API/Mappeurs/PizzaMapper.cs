using GestionPizza.DL.Entities;
using GestionPizza.Dtos.Ingredient;
using GestionPizza.Dtos.Pizza;

namespace GestionPizza.Mappeurs;

    public static class PizzaMapper
    {
        public static PizzaDetailsDto ToDetailsDto(Pizza pizza)
        {
            return new PizzaDetailsDto
            {
                Id = pizza.Id,
                PizzaName = pizza.PizzaName,
                Price = pizza.Price
            };
        }

        public static PizzaShortDto ToShortDto(Pizza pizza)
        {
            return new PizzaShortDto
            {
                PizzaName = pizza.PizzaName,
                Price = pizza.Price,
            };
        }

        public static Pizza ToEntity(PizzaFormDto dto)
        {
            return new Pizza
            {
                PizzaName = dto.PizzaName,
                Price = dto.Price
            };
        }

        public static void UpdateEntity(Pizza pizza, PizzaFormDto dto)
        {
            pizza.PizzaName = dto.PizzaName;
            pizza.Price = dto.Price;
        }

        public static PizzaWithIngredientDTO ToWithIngredientDto(Pizza pizza)
        {
            return new PizzaWithIngredientDTO()
            {
                Id = pizza.Id,
                PizzaName = pizza.PizzaName,
                Price = pizza.Price,
                Ingredients = pizza.Ingredients.Select(i => new IngredientShortDto
                {
                    Id = i.Id,
                    Name = i.Name

                }).ToList()
            };
        }
    }
