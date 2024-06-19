using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string? ProductCode { get; set; }

    public string ProductCategory { get; set; } = null!;

    public string ProductBrand { get; set; } = null!;

    public decimal ProductPrice { get; set; }

    public int ProductQuantity { get; set; }

    public string? ProductDescription { get; set; }

    public string? ProductImage { get; set; }

    public string ProductStatus { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
