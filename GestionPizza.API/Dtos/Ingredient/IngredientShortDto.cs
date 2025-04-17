using System.ComponentModel.DataAnnotations;

namespace GestionPizza.Dtos.Ingredient;

public class IngredientShortDto
{
    public long Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    public decimal Price { get; set; }

}