using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimalAtlas.Infrastructure.Models;
using AnimalAtlas.Api.Dto.TaxonomyGroups;

namespace AnimalAtlas.Api.Controllers.v1
{
    [Route("api/v1/taxonomy-groups")]
    [ApiController]
    public class TaxonomyGroupsController : ControllerBase
    {
        private readonly AnimalAtlasContext _context;

        public TaxonomyGroupsController(AnimalAtlasContext context)
        {
            _context = context;
        }

        // GET: api/TaxonomyGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetTaxonomyGroupDto>>> GetTaxonomyGroups()
        {
            var models = await _context.TaxonomyGroups.ToListAsync();
            var dtos = models.Select(model => new GetTaxonomyGroupDto(model));
            return Ok(dtos);
        }

        // GET: api/TaxonomyGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetTaxonomyGroupDto>> GetTaxonomyGroup(int id)
        {
            var taxonomyGroupModel = await _context.TaxonomyGroups.FindAsync(id);

            if (taxonomyGroupModel == null)
            {
                return NotFound();
            }

            var taxonomyGroupDto = new GetTaxonomyGroupDto(taxonomyGroupModel);

            return taxonomyGroupDto;
        }

        // PUT: api/TaxonomyGroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaxonomyGroup(int id, CreateTaxonomyGroupDto taxonomyGroup)
        {
            var model = _context.TaxonomyGroups.Find(id);

            if(model is null)
            {
                return NotFound();
            }

            model.TaxonomyGroupName = taxonomyGroup.TaxonomyGroupName;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/TaxonomyGroups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GetTaxonomyGroupDto>> PostTaxonomyGroup(CreateTaxonomyGroupDto taxonomyGroup)
        {
            var model = new TaxonomyGroup()
            {
                TaxonomyGroupName = taxonomyGroup.TaxonomyGroupName,
                CreatedBy = User.Identity?.Name ?? "Unknown",
                CreatedUtc = DateTime.UtcNow,
                LastUpdatedBy = User.Identity?.Name ?? "Unknown",
                LastUpdatedUtc = DateTime.UtcNow,
            };

            _context.TaxonomyGroups.Add(model);

            await _context.SaveChangesAsync();

            var result = new GetTaxonomyGroupDto(model);

            return CreatedAtAction("GetTaxonomyGroup", new { id = model.TaxonomyGroupId }, result);
        }

        // DELETE: api/TaxonomyGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaxonomyGroup(int id)
        {
            var taxonomyGroup = await _context.TaxonomyGroups.FindAsync(id);

            if (taxonomyGroup == null)
            {
                return NotFound();
            }

            taxonomyGroup.Deleted = true;
            taxonomyGroup.DeletedUtc = DateTime.UtcNow;
            taxonomyGroup.LastUpdatedUtc = DateTime.UtcNow;
            taxonomyGroup.LastUpdatedBy = User.Identity?.Name ?? "Unknown";

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
