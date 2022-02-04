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
    public class TransactionsHistoryController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;


        public TransactionsHistoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/TransactionsHistory
        [HttpGet]

        public async Task<IActionResult> GetTransactionsHistory()
        {
            var TransactionsHistory = await _unitOfWork.TransactionsHistory.GetAll();
            return Ok(TransactionsHistory);
        }

        // GET: api/TransactionsHistory/5
        [HttpGet("{id}")]

        public async Task<IActionResult> GetTransactionHistory(int id)
        {

            var TransactionHistory = await _unitOfWork.TransactionsHistory.Get(q => q.Id == id);

            if (TransactionHistory == null)
            {
                return NotFound();
            }

            return Ok(TransactionHistory);
        }

        // PUT: api/TransactionsHistory/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransactionHistory(int id, TransactionHistory TransactionHistory)
        {
            if (id != TransactionHistory.Id)
            {
                return BadRequest();
            }

            _unitOfWork.TransactionsHistory.Update(TransactionHistory);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await TransactionHistoryExists(id))
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

        // POST: api/TransactionsHistory
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TransactionHistory>> PostTransactionHistory(TransactionHistory TransactionHistory)
        {
            await _unitOfWork.TransactionsHistory.Insert(TransactionHistory);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetTransactionHistory", new { id = TransactionHistory.Id }, TransactionHistory);
        }

        // DELETE: api/TransactionsHistory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransactionHistory(int id)
        {
            var TransactionHistory = await _unitOfWork.TransactionsHistory.Get(q => q.Id == id);
            if (TransactionHistory == null)
            {
                return NotFound();
            }

            await _unitOfWork.TransactionsHistory.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> TransactionHistoryExists(int id)
        {
            var TransactionHistory = await _unitOfWork.TransactionsHistory.Get(q => q.Id == id);
            return TransactionHistory != null;
        }
    }
}
