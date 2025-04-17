using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPizza.DL.Entities;

[Table("_order_pizza")]
public class OrderPizza : BaseEntity
{
    [Required]
    public int Quantity { get; set; }

    // Les relations
    public long OrderId { get; set; }
    public Order Order { get; set; }

    public long PizzaId { get; set; }
    public Pizza Pizza { get; set; }
}