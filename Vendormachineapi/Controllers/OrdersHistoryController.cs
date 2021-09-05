using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vendormachineapi.Models;

namespace Vendormachineapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersHistoryController : ControllerBase
    {
        private readonly VendorDBContext _context;

        public OrdersHistoryController(VendorDBContext context)
        {
            _context = context;
        }

        // GET: api/OrdersHistory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdersHistory>>> GetOrdersHistory()
        {
            return await _context.OrdersHistory.ToListAsync();
        }

        // GET: api/OrdersHistory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdersHistory>> GetOrdersHistory(int id)
        {
            var ordersHistory = await _context.OrdersHistory.FindAsync(id);

            if (ordersHistory == null)
            {
                return NotFound();
            }

            return ordersHistory;
        }

        // PUT: api/OrdersHistory/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdersHistory(int id, OrdersHistory ordersHistory)
        {
            if (id != ordersHistory.Id)
            {
                return BadRequest();
            }

            _context.Entry(ordersHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdersHistoryExists(id))
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

        // POST: api/OrdersHistory
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OrdersHistory>> PostOrdersHistory(OrdersHistory ordersHistory)
        {
            _context.OrdersHistory.Add(ordersHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrdersHistory", new { id = ordersHistory.Id }, ordersHistory);
        }

        // DELETE: api/OrdersHistory/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrdersHistory>> DeleteOrdersHistory(int id)
        {
            var ordersHistory = await _context.OrdersHistory.FindAsync(id);
            if (ordersHistory == null)
            {
                return NotFound();
            }

            _context.OrdersHistory.Remove(ordersHistory);
            await _context.SaveChangesAsync();

            return ordersHistory;
        }

        private bool OrdersHistoryExists(int id)
        {
            return _context.OrdersHistory.Any(e => e.Id == id);
        }
    }
}
