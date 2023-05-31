using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Repository
{
    public class ProductsDTO
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public decimal ProductPrice { get; set; }

        public string ProductPic { get; set; } = null!;

        public int QuantityInStock { get; set; }

        public bool IsDelete { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = null!;
    }
}
