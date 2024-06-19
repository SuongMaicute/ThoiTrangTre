using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int OrderId { get; set; }

    public int UserId { get; set; }

    public string OrderPaymentMethod { get; set; } = null!;

    public string OrderStatus { get; set; } = null!;

    public string? OrderDetails { get; set; }

    public virtual Order Order { get; set; } = null!;
}
