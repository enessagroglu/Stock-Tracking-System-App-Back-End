using StockTrackingSystemApp_BackEnd.Domain.Entities;

namespace StockTrackingSystemApp_BackEnd.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
        Task<User?> GetByUsernameAsync(string username);
    }
}