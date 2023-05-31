using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Repository
{
    public class ProductToClintDTO
    {
        public int ProductId { get; set; }

        public int Count { get; set; }

        public decimal FinalPrice { get; set; }
    }
}
