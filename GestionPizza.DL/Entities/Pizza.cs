using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPizza.DL.Entities;

[Table("_pizza")]
public class Pizza : BaseEntity
{
 
    public string PizzaName { get; set; }
    
    public decimal Price { get; set; }

    public int BasePreparationTime { get; set; } = 180;
    
    // Les relations
    public ICollection<OrderPizza> OrderPizzas { get; set; }
    public ICollection<Ingredient> Ingredients { get; set; } = [];
    
    public long PizzeriaId { get; set; }
    public Pizzeria Pizzeria { get; set; }

}