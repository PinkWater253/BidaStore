using System;
using System.Collections.Generic;

namespace DataShared.Library.Models;

public partial class Payment
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public DateTime CreatedAt { get; set; }

    public decimal Total { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<PaymentDetail> PaymentDetails { get; set; } = new List<PaymentDetail>();
}
