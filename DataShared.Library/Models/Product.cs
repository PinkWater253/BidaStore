using System;
using System.Collections.Generic;

namespace DataShared.Library.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? ShortDescription { get; set; }

    public string? Img { get; set; }

    public int Price { get; set; }

    public double? Rating { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public int? CategoryId { get; set; }

    public int BrandId { get; set; }

    public virtual Brand Brand { get; set; } = null!;

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Category? Category { get; set; }

    public virtual ICollection<PaymentDetail> PaymentDetails { get; set; } = new List<PaymentDetail>();
}
