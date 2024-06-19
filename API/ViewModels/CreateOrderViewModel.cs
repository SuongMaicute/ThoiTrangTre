namespace API.ViewModels
{
    public class CreateOrderViewModel
    {
        public int UserId { get; set; }
        public List<OrderItemDTO> Items { get; set; }
    }
}
