using GestionPizza.DL.Entities;

namespace GestionPizza.BLL.Services.Interfaces;

public interface IOrderService
{
    IEnumerable<Order> FindAll();
    Order FindById(Guid id);
    Order Save(Order order);
    void Update(Guid id, Order order);
    void Delete(Guid id);
}