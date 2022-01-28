using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC_SHOP.Server.Data;
using PC_SHOP.Server.IRepository;
using PC_SHOP.Shared.Domain;

namespace PC_SHOP.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListItemsController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;


        public ListItemsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/ListItems
        [HttpGet]

        public async Task<IActionResult> GetListItems()
        {
            var ListItems = await _unitOfWork.ListItems.GetAll(includes: q => q.Include(x => x.Item)); ;
            return Ok(ListItems);
        }

        // GET: api/ListItems/5
        [HttpGet("{id}")]

        public async Task<IActionResult> GetController(int id)
        {

            var ListItem = await _unitOfWork.ListItems.Get(q => q.Id == id);

            if (ListItem == null)
            {
                return NotFound();
            }

            return Ok(ListItem);
        }

        // PUT: api/ListItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutListItem(int id, ListItem ListItem)
        {
            if (id != ListItem.Id)
            {
                return BadRequest();
            }

            _unitOfWork.ListItems.Update(ListItem);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ListItemExists(id))
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

        // POST: api/ListItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ListItem>> PostListItem(ListItem ListItem)
        {
            await _unitOfWork.ListItems.Insert(ListItem);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetListItem", new { id = ListItem.Id }, ListItem);
        }

        // DELETE: api/ListItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteListItem(int id)
        {
            var ListItem = await _unitOfWork.ListItems.Get(q => q.Id == id);
            if (ListItem == null)
            {
                return NotFound();
            }

            await _unitOfWork.ListItems.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> ListItemExists(int id)
        {
            var ListItem = await _unitOfWork.ListItems.Get(q => q.Id == id);
            return ListItem != null;
        }
    }
}