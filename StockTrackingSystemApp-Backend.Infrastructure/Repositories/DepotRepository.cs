using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using StockTrackingSystemApp_BackEnd.Application.Interfaces.Repositories;
using StockTrackingSystemApp_BackEnd.Domain.Entities;
using StockTrackingSystemApp_BackEnd.Infrastructure.Data;

namespace StockTrackingSystemApp_BackEnd.Infrastructure.Repositories
{
    public class DepotRepository : IDepotRepository
    {
        private readonly ApplicationDbContext _context;

        public DepotRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Depot>> GetAllAsync()
        {
            return await _context.Depots.ToListAsync();
        }

        public async Task<Depot?> GetByIdAsync(int id)
        {
            return await _context.Depots.FindAsync(id);
        }

        public async Task AddAsync(Depot depot)
        {
            await _context.Depots.AddAsync(depot);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Depot depot)
        {
            _context.Depots.Update(depot);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var depot = await _context.Depots.FindAsync(id);
            if (depot != null)
            {
                _context.Depots.Remove(depot);
                await _context.SaveChangesAsync();
            }
        }
    }
}