using System.ComponentModel.DataAnnotations;

namespace AnimalAtlas.Api.Dto.TaxonomyItems
{
    public class CreateTaxonomyItemDto
    {
        [Required]
        public required string TaxonomyItemName { get; set; }
        public int? ParentId { get; set; }
        [Required]
        public int GroupId { get; set; }
    }
}
