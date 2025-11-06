using System;
using System.Collections.Generic;

namespace BidaStore.API.Models;

public partial class Payment
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public DateTime? CreateAt { get; set; }

    public double? Total { get; set; }

    public virtual Customer? Customer { get; set; }
}
