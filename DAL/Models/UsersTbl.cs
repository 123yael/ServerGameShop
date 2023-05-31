using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class UsersTbl
{
    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? UserPhone { get; set; }

    public string UserEmail { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public string? UserAddress { get; set; }

    public virtual ICollection<OrdersTbl> OrdersTbls { get; } = new List<OrdersTbl>();
}
