using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentFinalAPI.Models;

namespace PaymentFinalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailsController : ControllerBase
    {
        private readonly PaymentDetailsContext _context;

        public PaymentDetailsController(PaymentDetailsContext context)
        {
            _context = context;
        }

        // GET: api/PaymentDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDetailsModel>>> GetPaymentDetails()
        {
            return await _context.PaymentDetails.ToListAsync();
        }

        // GET: api/PaymentDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDetailsModel>> GetPaymentDetailsModel(int id)
        {
            var paymentDetailsModel = await _context.PaymentDetails.FindAsync(id);

            if (paymentDetailsModel == null)
            {
                return NotFound();
            }

            return paymentDetailsModel;
        }

        // PUT: api/PaymentDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentDetailsModel(int id, PaymentDetailsModel paymentDetailsModel)
        {
            if (id != paymentDetailsModel.PaymentDetailId)
            {
                return BadRequest();
            }

            _context.Entry(paymentDetailsModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentDetailsModelExists(id))
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

        // POST: api/PaymentDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymentDetailsModel>> PostPaymentDetailsModel(PaymentDetailsModel paymentDetailsModel)
        {
            _context.PaymentDetails.Add(paymentDetailsModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentDetailsModel", new { id = paymentDetailsModel.PaymentDetailId }, paymentDetailsModel);
        }

        // DELETE: api/PaymentDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentDetailsModel(int id)
        {
            var paymentDetailsModel = await _context.PaymentDetails.FindAsync(id);
            if (paymentDetailsModel == null)
            {
                return NotFound();
            }

            _context.PaymentDetails.Remove(paymentDetailsModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentDetailsModelExists(int id)
        {
            return _context.PaymentDetails.Any(e => e.PaymentDetailId == id);
        }
    }
}
