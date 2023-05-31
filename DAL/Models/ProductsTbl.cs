using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class ProductsTbl
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal ProductPrice { get; set; }

    public string ProductPic { get; set; } = null!;

    public int QuantityInStock { get; set; }

    public bool IsDelete { get; set; }

    public int CategoryId { get; set; }

    public virtual ICollection<BuyingsDetailsTbl> BuyingsDetailsTbls { get; } = new List<BuyingsDetailsTbl>();

    public virtual CategoriesTbl Category { get; set; } = null!;
}
