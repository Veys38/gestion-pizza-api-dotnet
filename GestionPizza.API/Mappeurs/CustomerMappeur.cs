using GestionPizza.DL.Entities;
using GestionPizza.Dtos.Customer;

namespace GestionPizza.Mappeurs;

public static class CustomerMappeur
{
    public static CustomerDto ToCustomerDto(this Customer customer)
    {
        return new CustomerDto
        {
            Id = customer.Id,
            FullName = customer.FullName,
            PhoneNumber = customer.PhoneNumber,
            Role = customer.Role
        };
    }

    public static Customer ToCustomer(this RegisterFormDto dto)
    {
        return new Customer
        {
            FullName = dto.FullName,
            PhoneNumber = dto.PhoneNumber,
            Password = dto.Password

        };
    }
}