namespace AnimalAtlas.Infrastructure.Models;

public class TaxonomyItem : EntityBase
{
    public int TaxonomyItemId { get; set; }
    public required string TaxonomyItemName { get; set; }
    public int GroupId {  get; set; }
    public TaxonomyGroup? Group { get; set; }
    public int? ParentId { get; set; }
    public TaxonomyItem? Parent { get; set; }
}