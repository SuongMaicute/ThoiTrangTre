namespace API.Services
{
    public class DiscountCodeDTO
    {
        public string DiscountCode1 { get; set; } = null!;

        public string DiscountName { get; set; } = null!;

        public string DiscountType { get; set; } = null!;

        public decimal DiscountValue { get; set; }

        public DateTime DiscountStartDate { get; set; }

        public DateTime DiscountEndDate { get; set; }

        public string? DiscountDescription { get; set; }

    }
}
