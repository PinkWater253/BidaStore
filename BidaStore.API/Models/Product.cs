using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BidaStore.API.Models;

public partial class Product
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public string? Img { get; set; }
    public int? Price { get; set; }
    public double? Rate { get; set; }
    public DateTime? CreateAt { get; set; }
    public DateTime? UpdateAt { get; set; }
    public int? CategoryId { get; set; }
    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
    public virtual Category? Category { get; set; }
}
