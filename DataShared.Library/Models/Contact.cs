using System;
using System.Collections.Generic;

namespace DataShared.Library.Models;

public partial class Contact
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Subject { get; set; }

    public string Message { get; set; } = null!;

    public bool? IsResolved { get; set; }

    public DateTime? SentAt { get; set; }
}
