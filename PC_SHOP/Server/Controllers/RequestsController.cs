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
    public class RequestsController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;


        public RequestsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Requests
        [HttpGet]

        public async Task<IActionResult> GetRequests()
        {
            var Requests = await _unitOfWork.Requests.GetAll(includes: q => q.Include(x => x.Offer).Include(x => x.Payment).Include(x => x.Item).Include(x => x.ListItem));
            return Ok(Requests);
        }

        // GET: api/Requests/5
        [HttpGet("{id}")]

        public async Task<IActionResult> GetRequest(int id)
        {

            var Request = await _unitOfWork.Requests.Get(q => q.Id == id);

            if (Request == null)
            {
                return NotFound();
            }

            return Ok(Request);
        }

        // PUT: api/Requests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequest(int id, Request Request)
        {
            if (id != Request.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Requests.Update(Request);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await RequestExists(id))
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

        // POST: api/Requests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Request>> PostRequest(Request Request)
        {
            await _unitOfWork.Requests.Insert(Request);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetRequest", new { id = Request.Id }, Request);
        }

        // DELETE: api/Requests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequest(int id)
        {
            var Request = await _unitOfWork.Requests.Get(q => q.Id == id);
            if (Request == null)
            {
                return NotFound();
            }

            await _unitOfWork.Requests.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> RequestExists(int id)
        {
            var Request = await _unitOfWork.Requests.Get(q => q.Id == id);
            return Request != null;
        }
    }
}
