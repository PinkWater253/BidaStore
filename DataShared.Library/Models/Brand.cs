using System;
using System.Collections.Generic;

namespace DataShared.Library.Models;

public partial class Brand
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public bool? Active { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
