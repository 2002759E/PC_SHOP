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
    public class OffersController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;


        public OffersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Offers
        [HttpGet]

        public async Task<IActionResult> GetOffers()
        {
            var Offers = await _unitOfWork.Offers.GetAll();
            return Ok(Offers);
        }

        // GET: api/Offers/5
        [HttpGet("{id}")]

        public async Task<IActionResult> GetController(int id)
        {

            var Offer = await _unitOfWork.Offers.Get(q => q.Id == id);

            if (Offer == null)
            {
                return NotFound();
            }

            return Ok(Offer);
        }

        // PUT: api/Offers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOffer(int id, Offer Offer)
        {
            if (id != Offer.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Offers.Update(Offer);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await OfferExists(id))
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

        // POST: api/Offers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Offer>> PostOffer(Offer Offer)
        {
            await _unitOfWork.Offers.Insert(Offer);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetOffer", new { id = Offer.Id }, Offer);
        }

        // DELETE: api/Offers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOffer(int id)
        {
            var Offer = await _unitOfWork.Offers.Get(q => q.Id == id);
            if (Offer == null)
            {
                return NotFound();
            }

            await _unitOfWork.Offers.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> OfferExists(int id)
        {
            var Offer = await _unitOfWork.Offers.Get(q => q.Id == id);
            return Offer != null;
        }
    }
}