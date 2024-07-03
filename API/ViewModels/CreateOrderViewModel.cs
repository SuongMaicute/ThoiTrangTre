namespace API.ViewModels
{
    public class CreateOrderViewModel
    {
        public int UserId { get; set; }
        public float Total { get; set; }
        public string? PaymentType { get; set; }
        public List<CreateCartItem> Items { get; set; }
    }
}
