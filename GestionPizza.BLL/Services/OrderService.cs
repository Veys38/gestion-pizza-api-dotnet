using GestionPizza.BLL.Services.Interfaces;
using GestionPizza.DAL.Repositories.Interfaces;
using GestionPizza.DL.Entities;

namespace GestionPizza.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IEnumerable<Order> FindAll()
        {
            return _orderRepository.FindMany();
        }

        public Order FindById(Guid id)
        {
            var order = _orderRepository.FindOne(id);
            if (order == null)
                throw new Exception($"Order with id {id} doesn't exist");
            return order;
        }

        public Order Save(Order order)
        {
            return _orderRepository.Save(order);
        }

        public void Update(Guid id, Order order)
        {
            var existing = _orderRepository.FindOne(id);
            if (existing == null)
                throw new Exception($"Order with id {id} doesn't exist");

            existing.OrderDateTime = order.OrderDateTime;
            existing.CustomerId = order.CustomerId;
            // Tu pourras aussi gérer les pizzas plus tard

            _orderRepository.Update(existing);
        }

        public void Delete(Guid id)
        {
            var order = _orderRepository.FindOne(id);
            if (order == null)
                throw new Exception($"Order with id {id} doesn't exist");

            _orderRepository.Delete(order);
        }
    }
}