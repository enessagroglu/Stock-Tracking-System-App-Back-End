using StockTrackingSystemApp_BackEnd.Application.DTOs;
using StockTrackingSystemApp_BackEnd.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace StockTrackingSystemApp_BackEnd.Application.Services
{
    public class DepotService : IDepotService
    {
        public Task<DepotDto> CreateDepotAsync(DepotDto depotDto)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteDepotAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<DepotDto>> GetAllDepotsAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<DepotDto> GetDepotByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateDepotAsync(DepotDto depotDto)
        {
            throw new System.NotImplementedException();
        }
    }
}