using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPizza.DL.Entities;

[Table("_customer")]
public class Customer : BaseEntity
{
    //Les Attributs
    public string FullName { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public string Password { get; set; }
    
    public string Role { get; set; } = "Customer";
    
    //Les Relations
    public ICollection<Order> Orders { get; set; }
    
    public long PizzeriaId { get; set; }
    public Pizzeria Pizzeria { get; set; }

}