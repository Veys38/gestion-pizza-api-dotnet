using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPizza.DL.Entities;

[Table("_pizzeria")]
public class Pizzeria : BaseEntity
{
    public string Name { get; set; }
    public string Address { get; set; }
    
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }


    // Relations
    public ICollection<Customer> Customers { get; set; }
    public ICollection<Pizza> Pizzas { get; set; }
}