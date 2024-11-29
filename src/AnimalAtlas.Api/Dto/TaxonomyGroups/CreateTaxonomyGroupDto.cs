using AnimalAtlas.Infrastructure.Models;
using System.ComponentModel.DataAnnotations;

namespace AnimalAtlas.Api.Dto.TaxonomyGroups
{
    public class CreateTaxonomyGroupDto
    {
        [Required]
        public required string TaxonomyGroupName { get; set; }
    }
}
