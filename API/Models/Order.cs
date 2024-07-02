using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public DateTime? OrderDate { get; set; }

    public int? UserId { get; set; }

    public double? OrderTotalAmount { get; set; }

    public string? OrderStatus { get; set; }
}
