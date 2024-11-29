using AnimalAtlas.Infrastructure.Models;

namespace AnimalAtlas.Api.Dto.TaxonomyItems
{
    public class GetTaxonomyItemDto
    {
        public GetTaxonomyItemDto()
        {
            TaxonomyItemName = string.Empty;
        }

        public GetTaxonomyItemDto(TaxonomyItem model)
        {
            TaxonomyItemId = model.TaxonomyItemId;
            TaxonomyItemName = model.TaxonomyItemName;
            ParentId = model.ParentId;
            HasChildren = model.Children?.Any() ?? false;
        }

        public int TaxonomyItemId { get; private set; }
        public string TaxonomyItemName { get; private set; }
        public int? ParentId { get; private set; }
        public bool HasChildren { get; private set; }
    }
}
