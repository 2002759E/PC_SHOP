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
    public class PurchaseRequestsController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;


        public PurchaseRequestsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/PurchaseRequests
        [HttpGet]

        public async Task<IActionResult> GetPurchaseRequests()
        {
            var PurchaseRequests = await _unitOfWork.PurchaseRequests.GetAll(includes: q => q.Include(x => x.Payment).Include(x => x.ListItem).Include(x => x.ListItem.Item));
            return Ok(PurchaseRequests);
        }

        // GET: api/PurchaseRequests/5
        [HttpGet("{id}")]

        public async Task<IActionResult> GetPurchaseRequest(int id)
        {

            var PurchaseRequest = await _unitOfWork.PurchaseRequests.Get(q => q.Id == id);

            //var PurchaseRequest = await _unitOfWork.PurchaseRequests.Get(includes: q => q.Include(x => x.Payment).Include(x => x.ListItem).Include(x => x.ListItem.Item));

            if (PurchaseRequest == null)
            {
                return NotFound();
            }

            return Ok(PurchaseRequest);
        }

        // PUT: api/PurchaseRequests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchaseRequest(int id, PurchaseRequest PurchaseRequest)
        {
            if (id != PurchaseRequest.Id)
            {
                return BadRequest();
            }

            _unitOfWork.PurchaseRequests.Update(PurchaseRequest);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await PurchaseRequestExists(id))
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

        // POST: api/PurchaseRequests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PurchaseRequest>> PostPurchaseRequest(PurchaseRequest PurchaseRequest)
        {
            await _unitOfWork.PurchaseRequests.Insert(PurchaseRequest);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetPurchaseRequest", new { id = PurchaseRequest.Id }, PurchaseRequest);
        }

        // DELETE: api/PurchaseRequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchaseRequest(int id)
        {
            var PurchaseRequest = await _unitOfWork.PurchaseRequests.Get(q => q.Id == id);
            if (PurchaseRequest == null)
            {
                return NotFound();
            }

            await _unitOfWork.PurchaseRequests.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> PurchaseRequestExists(int id)
        {
            var PurchaseRequest = await _unitOfWork.PurchaseRequests.Get(q => q.Id == id);
            return PurchaseRequest != null;
        }
    }
}