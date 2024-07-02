namespace API.ViewModels
{
    public class CreateCartItem
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public double? Price { get; set; }
    }
}
