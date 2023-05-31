using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Repository
{
    public class UsersDTO
    {
        public int UserId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? UserPhone { get; set; }

        public string UserEmail { get; set; } = null!;

        public string UserPassword { get; set; } = null!;

        public string? UserAddress { get; set; }
    }
}
