using System.ComponentModel.DataAnnotations;

namespace GestionPizza.Dtos.Ingredient;

public class IngredientFormDto
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(5)]
    public decimal Price { get; set; }
}