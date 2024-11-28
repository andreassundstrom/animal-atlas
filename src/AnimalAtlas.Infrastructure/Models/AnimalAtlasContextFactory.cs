using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AnimalAtlas.Infrastructure.Models
{
    internal class AnimalAtlasContextFactory : IDesignTimeDbContextFactory<AnimalAtlasContext>
    {
        public AnimalAtlasContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<AnimalAtlasContext>()
                .UseNpgsql($"Server=localhost;Password=password;Username=postgres;Database=animal-atlas")
                .Options;
            
            var animalAtlasContext = new AnimalAtlasContext(options);

            return animalAtlasContext;
        }
    }
}
