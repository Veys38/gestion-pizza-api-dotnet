using GestionPizza.DL.Entities;
using GestionPizza.Dtos.Ingredient;

namespace GestionPizza.Mappeurs;

public static class IngredientMappeur
{
    public static IngredientShortDto ToShortDto(this Ingredient ingredient)
    {
        return new IngredientShortDto
        {
            Id = ingredient.Id,
            Name = ingredient.Name,
            Price = ingredient.Price
        };
    }

    public static IngredientDetailsDto ToIngredientDetailsDto(this Ingredient ingredient)
    {
        return new IngredientDetailsDto
        {
            Id = ingredient.Id,
            Name = ingredient.Name,
            Price = ingredient.Price
        };
    }

    public static Ingredient ToIngredient(this IngredientFormDto dto)
    {
        return new Ingredient
        {
            Name = dto.Name,
            Price = dto.Price
        };
    }
}