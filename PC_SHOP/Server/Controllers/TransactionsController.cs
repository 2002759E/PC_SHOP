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
    public class TransactionsController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;


        public TransactionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Transactions
        [HttpGet]

        public async Task<IActionResult> GetTransactions()
        {
            var Transactions = await _unitOfWork.Transactions.GetAll();
            return Ok(Transactions);
        }

        // GET: api/Transactions/5
        [HttpGet("{id}")]

        public async Task<IActionResult> GetTransaction(int id)
        {

            var Transaction = await _unitOfWork.Transactions.Get(q => q.Id == id);

            if (Transaction == null)
            {
                return NotFound();
            }

            return Ok(Transaction);
        }

        // PUT: api/Transactions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransaction(int id, Transaction Transaction)
        {
            if (id != Transaction.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Transactions.Update(Transaction);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await TransactionExists(id))
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

        // POST: api/Transactions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Transaction>> PostTransaction(Transaction Transaction)
        {
            await _unitOfWork.Transactions.Insert(Transaction);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetTransaction", new { id = Transaction.Id }, Transaction);
        }

        // DELETE: api/Transactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            var Transaction = await _unitOfWork.Transactions.Get(q => q.Id == id);
            if (Transaction == null)
            {
                return NotFound();
            }

            await _unitOfWork.Transactions.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> TransactionExists(int id)
        {
            var Transaction = await _unitOfWork.Transactions.Get(q => q.Id == id);
            return Transaction != null;
        }
    }
}
