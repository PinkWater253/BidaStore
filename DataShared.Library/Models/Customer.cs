using System;
using System.Collections.Generic;

namespace DataShared.Library.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? Img { get; set; }

    public string Password { get; set; } = null!;

    public string? RandomKey { get; set; }

    public int? Role { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? RegisteredAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
