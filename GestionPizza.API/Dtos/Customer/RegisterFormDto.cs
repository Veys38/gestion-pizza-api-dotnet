using System.ComponentModel.DataAnnotations;

namespace GestionPizza.Dtos.Customer;

public class RegisterFormDto
{
   
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
}