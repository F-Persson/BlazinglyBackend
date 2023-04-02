using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIBackend.Models.Entities;
using APIBackend.Models;
//using Microsoft.AspNetCore.Authorization;

namespace APIBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagItemsController : ControllerBase
    {
        private readonly APIContext _context;
        private readonly TagItemService tagItemService;

        public TagItemsController(APIContext context, TagItemService tagItemService)
        {
            _context = context;
            this.tagItemService = tagItemService;
        }

        // GET: api/TagItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InputModel>>> GetTagItems()
        {
            var tagItem = await _context.TagItems.Include(ti => ti.Tags).ToListAsync();

            InputModel outputModel = new InputModel();

            return tagItem.Select(ti => new InputModel
            {
                Id = ti.Id,
                Time = ti.Time,
                Selection = ti.Selection,
                Url = ti.Url,
                Title = ti.Title,
                MetaDescription = ti.MetaDescription,
                Tags = ti.Tags.Select(t => t.TagName).ToList()
            }).ToList();
        }

        // GET: api/TagItems/5
        //[Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<TagItem>> GetTagItem(int id)
        {
            TagItem tagItem = await _context.TagItems.Include(ti => ti.Tags).SingleOrDefaultAsync(ti => ti.Id == id);

            if (tagItem == null)
            {
                return NotFound();
            }

            return tagItem;
        }

        // PUT: api/TagItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTagItem(int id, InputModel inputModel)
        {
            if (id != inputModel.Id)
            {
                return BadRequest();
            }

            TagItem originalTagItem = await _context.TagItems.Include(ti => ti.Tags).SingleOrDefaultAsync(ti => ti.Id == id);
            TagItem newTagItem = tagItemService.CreateOrUpdate(originalTagItem, inputModel);

            _context.Entry(newTagItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TagItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TagItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TagItem>> PostTagItem(InputModel inputModel)
        {
            TagItem tagItem = tagItemService.CreateOrUpdate(new TagItem(), inputModel);

            _context.TagItems.Add(tagItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTagItem), new { id = tagItem.Id }, tagItem);
        }

        // DELETE: api/TagItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTagItem(int id)
        {
            var tagItem = await _context.TagItems.FindAsync(id);
            if (tagItem == null)
            {
                return NotFound();
            }

            var tags = _context.Tags.Where(t => t.TagItemId == id);
            _context.Tags.RemoveRange(tags);

            _context.TagItems.Remove(tagItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TagItemExists(int id)
        {
            return _context.TagItems.Any(e => e.Id == id);
        }
    }
}
