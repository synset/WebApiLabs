using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeApiEntityFramework.Models;

namespace WeApiEntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalOrdersController : ControllerBase
    {
        private readonly ApiContext _context;

        public RentalOrdersController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/RentalOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentalOrders>>> GetRentalOrders()
        {
            return await _context.RentalOrders.ToListAsync();
        }

        // GET: api/RentalOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RentalOrders>> GetRentalOrders(int id)
        {
            var rentalOrders = await _context.RentalOrders.FindAsync(id);

            if (rentalOrders == null)
            {
                return NotFound();
            }

            return rentalOrders;
        }

        // PUT: api/RentalOrders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRentalOrders(int id, RentalOrders rentalOrders)
        {
            if (id != rentalOrders.Id)
            {
                return BadRequest();
            }

            _context.Entry(rentalOrders).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentalOrdersExists(id))
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

        // POST: api/RentalOrders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RentalOrders>> PostRentalOrders(RentalOrders rentalOrders)
        {
            _context.RentalOrders.Add(rentalOrders);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RentalOrdersExists(rentalOrders.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRentalOrders", new { id = rentalOrders.Id }, rentalOrders);
        }

        // DELETE: api/RentalOrders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RentalOrders>> DeleteRentalOrders(int id)
        {
            var rentalOrders = await _context.RentalOrders.FindAsync(id);
            if (rentalOrders == null)
            {
                return NotFound();
            }

            _context.RentalOrders.Remove(rentalOrders);
            await _context.SaveChangesAsync();

            return rentalOrders;
        }

        private bool RentalOrdersExists(int id)
        {
            return _context.RentalOrders.Any(e => e.Id == id);
        }
    }
}
