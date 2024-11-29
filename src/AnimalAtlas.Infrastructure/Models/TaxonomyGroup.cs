using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalAtlas.Infrastructure.Models
{
    public class TaxonomyGroup : EntityBase
    {
        public TaxonomyGroup()
        {
        }

        public int TaxonomyGroupId { get; set; }
        public required string TaxonomyGroupName { get; set; }
    }
}
