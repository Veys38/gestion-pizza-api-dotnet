namespace GestionPizza.Dtos.Customer;

public class CustomerTokenDto
{
    public string Token { get; set; } = null!;
    public CustomerDto Customer { get; set; } = null!;
}