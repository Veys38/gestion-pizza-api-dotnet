using GestionPizza.DL.Entities;
using GestionPizza.DTOs.Order;

namespace GestionPizza.Mappeurs
{
    public static class OrderMapper
    {
        public static OrderShortDto ToShortDto(Order order)
        {
            return new OrderShortDto
            {
                Id = order.Id,
                OrderDateTime = order.OrderDateTime,
                CustomerName = order.Customer?.FullName ?? "Unknown"
            };
        }

        public static OrderDetailsDto ToDetailsDto(Order order)
        {
            return new OrderDetailsDto
            {
                Id = order.Id,
                OrderDateTime = order.OrderDateTime,
                CustomerId = order.CustomerId,
                CustomerName = order.Customer?.FullName ?? "Unknown",
                Pizzas = order.OrderPizzas?.Select(op => new OrderPizzaItemDto
                {
                    PizzaId = op.PizzaId,
                    PizzaName = op.Pizza?.PizzaName ?? "Unknown",
                    Quantity = op.Quantity
                }).ToList() ?? new List<OrderPizzaItemDto>()
            };
        }

        public static Order ToEntity(OrderFormDto dto)
        {
            var order = new Order
            {
                OrderDateTime = dto.OrderDateTime,
                CustomerId = dto.CustomerId,
                OrderPizzas = dto.Pizzas.Select(p => new OrderPizza
                {
                    PizzaId = p.PizzaId,
                    Quantity = p.Quantity
                }).ToList()
            };

            return order;
        }
    }
}