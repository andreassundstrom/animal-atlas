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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(p => p.ExternalId)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<TaxonomyItem> TaxonomyItems { get; set; }
        public virtual DbSet<TaxonomyGroup> TaxonomyGroups { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> Roles { get; set; }
    }
}
