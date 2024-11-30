using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalAtlas.Infrastructure.Models
{
    public class User : EntityBase
    {
        public int UserId { get; set; }
        public required string ExternalId { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool UserProfileCompleted { get; set; } = false;
        public List<UserRole> Roles { get; set; } = [];
    }
}
