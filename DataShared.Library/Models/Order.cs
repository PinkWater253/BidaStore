using System;
using System.Collections.Generic;

namespace DataShared.Library.Models;

public partial class Order
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public string? ReceiverName { get; set; }

    public string? ReceiverPhone { get; set; }

    public string ShippingAddress { get; set; } = null!;

    public string? OrderNote { get; set; }

    public double TotalAmount { get; set; }

    public string? PaymentMethod { get; set; }

    public int? PaymentStatus { get; set; }

    public int? OrderStatus { get; set; }

    public string? TransactionId { get; set; }

    public DateTime? CreateAt { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
