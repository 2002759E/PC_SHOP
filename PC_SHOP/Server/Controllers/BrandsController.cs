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
    public class BrandsController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;


        public BrandsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Brands
        [HttpGet]

        public async Task<IActionResult> GetBrands()
        {           
            var Brands = await _unitOfWork.Brands.GetAll();
            return Ok(Brands);
        }

        // GET: api/Brands/5
        [HttpGet("{id}")]

        public async Task<IActionResult> GetBrand(int id)
        {

            var Brand = await _unitOfWork.Brands.Get(q => q.Id == id);

            if (Brand == null)
            {
                return NotFound();
            }

            return Ok(Brand);
        }

        // PUT: api/Brands/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrand(int id, Brand Brand)
        {
            if (id != Brand.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Brands.Update(Brand);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await BrandExists(id))
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

        // POST: api/Brands
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Brand>> PostBrand(Brand Brand)
        {
            await _unitOfWork.Brands.Insert(Brand);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetBrand", new { id = Brand.Id }, Brand);
        }

        // DELETE: api/Brands/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            var brand = await _unitOfWork.Brands.Get(q => q.Id == id);
            if (brand == null)
            {
                return NotFound();
            }

            await _unitOfWork.Brands.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> BrandExists(int id)
        {
            var Brand = await _unitOfWork.Brands.Get(q => q.Id == id);
            return Brand != null;
        }
    }
}
