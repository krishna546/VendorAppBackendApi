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
    public class CoinsController : ControllerBase
    {
        private readonly VendorDBContext _context;

        public CoinsController(VendorDBContext context)
        {
            _context = context;
        }

        // GET: api/Coins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coins>>> GetCoins()
        {
            return await _context.Coins.ToListAsync();
        }

        // GET: api/Coins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Coins>> GetCoins(int id)
        {
            var coins = await _context.Coins.FindAsync(id);

            if (coins == null)
            {
                return NotFound();
            }

            return coins;
        }

        // PUT: api/Coins/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoins(int id, Coins coins)
        {
            if (id != coins.Id)
            {
                return BadRequest();
            }

            _context.Entry(coins).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoinsExists(id))
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

        // POST: api/Coins
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Coins>> PostCoins(Coins coins)
        {
            _context.Coins.Add(coins);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoins", new { id = coins.Id }, coins);
        }

        // DELETE: api/Coins/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Coins>> DeleteCoins(int id)
        {
            var coins = await _context.Coins.FindAsync(id);
            if (coins == null)
            {
                return NotFound();
            }

            _context.Coins.Remove(coins);
            await _context.SaveChangesAsync();

            return coins;
        }

        private bool CoinsExists(int id)
        {
            return _context.Coins.Any(e => e.Id == id);
        }
    }
}
