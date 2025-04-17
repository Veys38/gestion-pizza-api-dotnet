namespace GestionPizza.DTOs.Order
{
    public class OrderDetailsDto
    {
        public long Id { get; set; }
        public DateTime OrderDateTime { get; set; }

        public long CustomerId { get; set; }
        public string CustomerName { get; set; }

        public List<OrderPizzaItemDto> Pizzas { get; set; }
    }

    public class OrderPizzaItemDto
    {
        public long PizzaId { get; set; }
        public string PizzaName { get; set; }
        public int Quantity { get; set; }
    }
}