using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class BuyingsDetailsTbl
{
    public int BuyingDetailesId { get; set; }

    public int ProductId { get; set; }

    public int OrderId { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public virtual OrdersTbl Order { get; set; } = null!;

    public virtual ProductsTbl Product { get; set; } = null!;
}
