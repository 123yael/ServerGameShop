using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class OrdersTbl
{
    public int OrderId { get; set; }

    public DateTime OrderDate { get; set; }

    public int UserId { get; set; }

    public decimal FinalPrice { get; set; }

    public virtual ICollection<BuyingsDetailsTbl> BuyingsDetailsTbls { get; } = new List<BuyingsDetailsTbl>();

    public virtual UsersTbl User { get; set; } = null!;
}
