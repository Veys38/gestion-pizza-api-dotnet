using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GestionPizza.DL.Entities;

[Table("_ingredient")]
public class Ingredient : BaseEntity
{ 
    public string Name { get; set; }
    
    public decimal Price { get; set; }
    
    public int TimeInSeconds { get; set; } = 15;
    
    [JsonIgnore]
    public ICollection<Pizza> Pizzas { get; set; } = [];
}