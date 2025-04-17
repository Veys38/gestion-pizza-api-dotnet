namespace GestionPizza.DTOs.Order
{
    public class OrderShortDto
    {
        public long Id { get; set; }
        public DateTime OrderDateTime { get; set; }
        public string CustomerName { get; set; }
    }
}