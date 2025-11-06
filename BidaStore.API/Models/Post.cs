using System;
using System.Collections.Generic;

namespace BidaStore.API.Models;

public partial class Post
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public string? Img { get; set; }

    public DateTime CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public int CustomerId { get; set; }

    public bool? IsApproved { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
