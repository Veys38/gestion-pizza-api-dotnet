namespace GestionPizza.DTOs.Order
{
    public class OrderFormDto
    {
        public DateTime OrderDateTime { get; set; }
        public long CustomerId { get; set; }
        public List<OrderPizzaFormItemDto> Pizzas { get; set; }
    }

    public class OrderPizzaFormItemDto
    {
        public long PizzaId { get; set; }
        public int Quantity { get; set; }
    }
}