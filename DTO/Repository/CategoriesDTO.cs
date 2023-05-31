using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Repository
{
    public class CategoriesDTO
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = null!;

        public bool IsDelete { get; set; }
    }
}
