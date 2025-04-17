using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPizza.DL.Entities;

[Table("_order")]
public class Order : BaseEntity
{
    [Required]
    public DateTime OrderDateTime { get; set; }
    
    
    // Les relations
    [ForeignKey("Customer")]
    public long CustomerId { get; set; }
    
    public Customer Customer { get; set; }
    
    public ICollection<OrderPizza> OrderPizzas { get; set; }

}