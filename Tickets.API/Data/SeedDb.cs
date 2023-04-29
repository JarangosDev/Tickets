using Tickets.Shared.Entites;
using Tickets.API.Data;

namespace Tickets.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckTicketsAsync();
        }

        private async Task CheckTicketsAsync()
        {
            if (!_context.Tickets.Any())
            {
                for (int i = 0; i < 500; i++) {
                    _context.Tickets.Add(new Ticket { FechaUso = DateTime.Now, FueUsada = false, Porteria = null });
                }
                
            }

            await _context.SaveChangesAsync();
        }
    }
}
