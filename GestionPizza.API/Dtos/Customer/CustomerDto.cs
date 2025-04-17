namespace GestionPizza.Dtos.Customer;

public class CustomerDto
{
    public long Id { get; set; }
    public string FullName { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public required string Role { get; set; } 

}