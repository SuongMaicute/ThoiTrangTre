﻿namespace API.ViewModels
{
    public class CreateCartItem
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
