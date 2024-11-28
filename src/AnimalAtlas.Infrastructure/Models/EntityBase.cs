using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalAtlas.Infrastructure.Models
{
    public abstract class EntityBase
    {
        public DateTime CreatedUtc { get; set; }
        public required string CreatedBy { get; set; }
        public DateTime LastUpdatedUtc { get; set; }
        public required string LastUpdatedBy { get; set; }
        public DateTime DeletedUtc { get; set; }
    }
}
