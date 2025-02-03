using StockTrackingSystemApp_BackEnd.Application.DTOs;
using StockTrackingSystemApp_BackEnd.Application.Interfaces;
using StockTrackingSystemApp_BackEnd.Application.Interfaces.Repositories;
using StockTrackingSystemApp_BackEnd.Domain.Entities;

namespace StockTrackingSystemApp_BackEnd.Application.Services
{
    public class DepotService : IDepotService
    {
        private readonly IDepotRepository _depotRepository;
        public DepotService(IDepotRepository depotRepository)
        {
            _depotRepository = depotRepository;
        }

        public async Task<IEnumerable<DepotDto>> GetAllDepotsAsync()
        {
            var depots = await _depotRepository.GetAllAsync();
            return depots.Select(d => new DepotDto
            {
                Id = d.Id,
                Name = d.Name,
                Location = d.Location,
                UserId = d.UserId
            });
        }

        public async Task<DepotDto> GetDepotByIdAsync(int id)
        {
            var depot = await _depotRepository.GetByIdAsync(id);
            if (depot == null)
                return null;
            return new DepotDto
            {
                Id = depot.Id,
                Name = depot.Name,
                Location = depot.Location,
                UserId = depot.UserId
            };
        }

        public async Task<DepotDto> CreateDepotAsync(DepotDto depotDto)
        {
            var depot = new Depot
            {
                Name = depotDto.Name,
                Location = depotDto.Location,
                UserId = depotDto.UserId
            };

            await _depotRepository.AddAsync(depot);
            depotDto.Id = depot.Id;
            return depotDto;
        }

        public async Task UpdateDepotAsync(DepotDto depotDto)
        {
            var depot = await _depotRepository.GetByIdAsync(depotDto.Id);
            if (depot == null)
                throw new Exception("Depot not found");
            depot.Name = depotDto.Name;
            depot.Location = depotDto.Location;
            depot.UserId = depotDto.UserId;
            await _depotRepository.UpdateAsync(depot);
        }

        public async Task DeleteDepotAsync(int id)
        {
            await _depotRepository.DeleteAsync(id);
        }
    }
}
