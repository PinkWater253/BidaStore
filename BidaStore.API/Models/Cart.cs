using System;
using System.Collections.Generic;

namespace BidaStore.API.Models;

public partial class Cart
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? CreateAt { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Product? Product { get; set; }
}
