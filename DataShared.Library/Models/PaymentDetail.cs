using System;
using System.Collections.Generic;

namespace DataShared.Library.Models;

public partial class PaymentDetail
{
    public int ProductId { get; set; }

    public int PaymentId { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public decimal Total { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Payment Payment { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
