using System.Collections.Generic;
using System.Threading.Tasks;
using StockTrackingSystemApp_BackEnd.Domain.Entities;

namespace StockTrackingSystemApp_BackEnd.Application.Interfaces.Repositories
{
    public interface IDepotRepository
    {
        Task<IEnumerable<Depot>> GetAllAsync();
        Task<Depot> GetByIdAsync(int id);
        Task AddAsync(Depot depot);
        Task UpdateAsync(Depot depot);
        Task DeleteAsync(int id);
    }
}