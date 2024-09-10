using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Context;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalanceServiceProvidersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BalanceServiceProvidersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/BalanceServiceProviders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BalanceServiceProviders>>> GetBalanceServiceProviders()
        {
            return await _context.BalanceServiceProviders.ToListAsync();
        }

        // GET: api/BalanceServiceProviders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BalanceServiceProviders>> GetBalanceServiceProviders(int id)
        {
            var balanceServiceProviders = await _context.BalanceServiceProviders.FindAsync(id);

            if (balanceServiceProviders == null)
            {
                return NotFound();
            }

            return balanceServiceProviders;
        }

        // PUT: api/BalanceServiceProviders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBalanceServiceProviders(int id, BalanceServiceProviders balanceServiceProviders)
        {
            if (id != balanceServiceProviders.Id)
            {
                return BadRequest();
            }

            _context.Entry(balanceServiceProviders).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BalanceServiceProvidersExists(id))
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

        // POST: api/BalanceServiceProviders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BalanceServiceProviders>> PostBalanceServiceProviders(BalanceServiceProviders balanceServiceProviders)
        {
            _context.BalanceServiceProviders.Add(balanceServiceProviders);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBalanceServiceProviders", new { id = balanceServiceProviders.Id }, balanceServiceProviders);
        }

        // DELETE: api/BalanceServiceProviders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBalanceServiceProviders(int id)
        {
            var balanceServiceProviders = await _context.BalanceServiceProviders.FindAsync(id);
            if (balanceServiceProviders == null)
            {
                return NotFound();
            }

            _context.BalanceServiceProviders.Remove(balanceServiceProviders);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BalanceServiceProvidersExists(int id)
        {
            return _context.BalanceServiceProviders.Any(e => e.Id == id);
        }
    }
}
