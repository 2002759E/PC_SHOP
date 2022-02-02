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
    public class TradeRequestsController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;


        public TradeRequestsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/TradeRequests
        [HttpGet]

        public async Task<IActionResult> GetTradeRequests()
        {
            var TradeRequests = await _unitOfWork.TradeRequests.GetAll(includes: q => q.Include(x => x.Item).Include(x => x.ListItem).Include(x => x.ListItem.Item));
            return Ok(TradeRequests);
        }

        // GET: api/TradeRequests/5
        [HttpGet("{id}")]

        public async Task<IActionResult> GetTradeRequest(int id)
        {

            var TradeRequest = await _unitOfWork.TradeRequests.Get(q => q.Id == id);

            if (TradeRequest == null)
            {
                return NotFound();
            }

            return Ok(TradeRequest);
        }

        // PUT: api/TradeRequests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTradeRequest(int id, TradeRequest TradeRequest)
        {
            if (id != TradeRequest.Id)
            {
                return BadRequest();
            }

            _unitOfWork.TradeRequests.Update(TradeRequest);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await TradeRequestExists(id))
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

        // POST: api/TradeRequests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TradeRequest>> PostTradeRequest(TradeRequest TradeRequest)
        {
            await _unitOfWork.TradeRequests.Insert(TradeRequest);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetTradeRequest", new { id = TradeRequest.Id }, TradeRequest);
        }

        // DELETE: api/TradeRequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTradeRequest(int id)
        {
            var TradeRequest = await _unitOfWork.TradeRequests.Get(q => q.Id == id);
            if (TradeRequest == null)
            {
                return NotFound();
            }

            await _unitOfWork.TradeRequests.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> TradeRequestExists(int id)
        {
            var TradeRequest = await _unitOfWork.TradeRequests.Get(q => q.Id == id);
            return TradeRequest != null;
        }
    }
}
