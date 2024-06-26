﻿namespace API.ViewModels
{
    public class OrderDTO
    {
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public int UserId { get; set; }

        public decimal OrderTotalAmount { get; set; }

        public string OrderStatus { get; set; } = null!;
    }
}
