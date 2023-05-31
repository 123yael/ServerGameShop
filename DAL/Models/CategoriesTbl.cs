using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class CategoriesTbl
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public bool IsDelete { get; set; }

    public virtual ICollection<ProductsTbl> ProductsTbls { get; } = new List<ProductsTbl>();
}
