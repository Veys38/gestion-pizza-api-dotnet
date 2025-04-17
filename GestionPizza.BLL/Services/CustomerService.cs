using GestionPizza.BLL.Services.Interfaces;
using GestionPizza.DAL.Repositories.Interfaces;
using GestionPizza.DL.Entities;
using Isopoh.Cryptography.Argon2;

namespace GestionPizza.BLL.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public Customer Login(string login, string password)
    {
        Customer? customer = _customerRepository.FindOne(c => c.PhoneNumber == login);
        if(customer is null)
        {
            throw new Exception("Customer doesn't exist");
        }
        if (!Argon2.Verify(customer.Password,password))
        {
            throw new Exception("Wrong password");
        }
        return customer;
    }

    public void Register(Customer customer)
    {
        if(_customerRepository
           .Any(c => c.PhoneNumber == customer.PhoneNumber))
        {
            throw new Exception($"Customer already exist");
        }
        
        customer.Role = "Customer";
        _customerRepository.Save(customer);


        customer.Password = Argon2.Hash(customer.Password);
        _customerRepository.Save(customer);
    }
}