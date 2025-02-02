using StockTrackingSystemApp_BackEnd.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockTrackingSystemApp_BackEnd.Application.Interfaces
{
    public interface IDepotService
    {
        Task<IEnumerable<DepotDto>> GetAllDepotsAsync();
        Task<DepotDto> GetDepotByIdAsync(int id);
        Task<DepotDto> CreateDepotAsync(DepotDto depotDto);
        Task UpdateDepotAsync(DepotDto depotDto);
        Task DeleteDepotAsync(int id);
    }
}