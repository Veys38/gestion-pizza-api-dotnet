using System.ComponentModel.DataAnnotations;

namespace GestionPizza.Dtos.Customer;

public class LoginFormDto
{
    [Required]
    public string PhoneNumber { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;
}