using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalAtlas.Infrastructure.Models
{
    public class AnimalAtlasContext : DbContext
    {
        public AnimalAtlasContext(DbContextOptions<AnimalAtlasContext> options) : base(options)
        {
        }

        public virtual DbSet<TaxonomyItem> TaxonomyItems { get; set; }
        public virtual DbSet<TaxonomyGroup> TaxonomyGroups { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> Roles { get; set; }
    }
}
