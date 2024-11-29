using AnimalAtlas.Api.Dto.TaxonomyItems;
using AnimalAtlas.Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnimalAtlas.Api.Controllers.v1
{
    [Route("api/v1/taxonomy-items")]
    [ApiController]
    public class TaxonomyItemsController : ControllerBase
    {
        private readonly AnimalAtlasContext _animalAtlasContext;

        public TaxonomyItemsController(AnimalAtlasContext animalAtlasContext)
        {
            _animalAtlasContext = animalAtlasContext;
        }

        [HttpGet]
        public ActionResult GetTaxonomyItems(int? parentId = null)
        {
            var taxonomyItemModels = _animalAtlasContext.TaxonomyItems
                .Where(p => p.ParentId == parentId)
                .Include(p => p.Group).ToList()
                .ToList();

            var dtos = taxonomyItemModels.Select(p => new GetTaxonomyItemDto(p));

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> CreateTaxonomyItem(CreateTaxonomyItemDto taxonomyItemDto)
        {
            var model = new TaxonomyItem
            {
                TaxonomyItemName = taxonomyItemDto.TaxonomyItemName,
                ParentId = taxonomyItemDto.ParentId,
                CreatedBy = User.Identity?.Name ?? "Unknown",
                CreatedUtc = DateTime.UtcNow,
                LastUpdatedBy = User.Identity?.Name ?? "Unknown",
                LastUpdatedUtc = DateTime.UtcNow,
            };

            _animalAtlasContext.Add(model);

            await _animalAtlasContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
