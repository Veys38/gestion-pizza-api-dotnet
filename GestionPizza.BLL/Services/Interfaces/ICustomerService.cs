using GestionPizza.DL.Entities;

namespace GestionPizza.BLL.Services.Interfaces;

public interface ICustomerService
{
    void Register(Customer customer);
    Customer Login(string login, string password);
}