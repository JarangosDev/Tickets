using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using Tickets.API.Data;
using Tickets.Shared.Entites;

namespace Tickets.API.Controllers
{
    [ApiController]
    [Route("/api/tickets")]
    public class CountriesController : ControllerBase
    {
        private readonly DataContext _context;

        public CountriesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Tickets.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(x => x.Id == id);
            if (ticket is null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Ticket ticket)
        {
            _context.Update(ticket);
            await _context.SaveChangesAsync();
            return Ok(ticket);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await _context.Tickets
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            if (afectedRows == 0)
            {
                return NotFound();
            }

            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult> Post(Ticket ticket)
        {
            _context.Add(ticket);
            await _context.SaveChangesAsync();
            return Ok(ticket);
        }
    }

}
