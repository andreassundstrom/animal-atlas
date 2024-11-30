using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalAtlas.Infrastructure.Models
{
    public class UserRole
    {
        public int UserRoleId { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public UserAppRole RoleName { get; set; }
    }
}
