﻿namespace API.ViewModels
{
    public class OrderItemDTO
    {
        public int OrderItemId { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public double? Price { get; set; }
    }
}
