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
    public class ItemsController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;


        public ItemsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Items
        [HttpGet]

        public async Task<IActionResult> GetItems()
        {
            var Items = await _unitOfWork.Items.GetAll(includes: q => q.Include(x => x.Category).Include(x => x.Brand));
            return Ok(Items);
        }

        // GET: api/Items/5
        [HttpGet("{id}")]

        public async Task<IActionResult> GetItem(int id)
        {

            var Item = await _unitOfWork.Items.Get(q => q.Id == id);

            if (Item == null)
            {
                return NotFound();
            }

            return Ok(Item);
        }

        // PUT: api/Items/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, Item Item)
        {
            if (id != Item.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Items.Update(Item);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ItemExists(id))
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

        // POST: api/Items
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(Item Item)
        {
            await _unitOfWork.Items.Insert(Item);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetItem", new { id = Item.Id }, Item);
        }

        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var Item = await _unitOfWork.Items.Get(q => q.Id == id);
            if (Item == null)
            {
                return NotFound();
            }

            await _unitOfWork.Items.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> ItemExists(int id)
        {
            var Item = await _unitOfWork.Items.Get(q => q.Id == id);
            return Item != null;
        }
    }
}
