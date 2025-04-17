using GestionPizza.Dtos.Ingredient;

namespace GestionPizza.Dtos.Pizza;

public class PizzaShortDto
{
    public string PizzaName { get; set; }
    public decimal Price { get; set; }
    
    public List<IngredientShortDto> Ingredients { get; set; } = new();

}