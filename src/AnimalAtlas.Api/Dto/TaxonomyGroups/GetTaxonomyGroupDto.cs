using AnimalAtlas.Infrastructure.Models;

namespace AnimalAtlas.Api.Dto.TaxonomyGroups
{
    public class GetTaxonomyGroupDto
    {
        public GetTaxonomyGroupDto()
        {
            TaxonomyGroupName = string.Empty;
        }

        public GetTaxonomyGroupDto(TaxonomyGroup model)
        {
            TaxonomyGroupId = model.TaxonomyGroupId;
            TaxonomyGroupName = model.TaxonomyGroupName;
        }

        public int TaxonomyGroupId { get; set; }
        public string TaxonomyGroupName { get; set; }
    }
}
