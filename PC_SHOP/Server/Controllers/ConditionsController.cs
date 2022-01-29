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
    public class ConditionsController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;


        public ConditionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Conditions
        [HttpGet]

        public async Task<IActionResult> GetConditions()
        {
            var Conditions = await _unitOfWork.Conditions.GetAll();
            return Ok(Conditions);
        }

        // GET: api/Conditions/5
        [HttpGet("{id}")]

        public async Task<IActionResult> GetCondition(int id)
        {

            var Condition = await _unitOfWork.Conditions.Get(q => q.Id == id);

            if (Condition == null)
            {
                return NotFound();
            }

            return Ok(Condition);
        }

        // PUT: api/Conditions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCondition(int id, Condition Condition)
        {
            if (id != Condition.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Conditions.Update(Condition);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ConditionExists(id))
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

        // POST: api/Conditions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Condition>> PostCondition(Condition Condition)
        {
            await _unitOfWork.Conditions.Insert(Condition);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetCondition", new { id = Condition.Id }, Condition);
        }

        // DELETE: api/Conditions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCondition(int id)
        {
            var Condition = await _unitOfWork.Conditions.Get(q => q.Id == id);
            if (Condition == null)
            {
                return NotFound();
            }

            await _unitOfWork.Conditions.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> ConditionExists(int id)
        {
            var Condition = await _unitOfWork.Conditions.Get(q => q.Id == id);
            return Condition != null;
        }
    }
}
