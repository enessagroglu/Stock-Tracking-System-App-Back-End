using StockTrackingSystemApp_BackEnd.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockTrackingSystemApp_BackEnd.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> RegisterUserAsync(UserRegistrationDto registrationDto);
        Task<UserDto> AuthenticateUserAsync(UserLoginDto loginDto);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserByIdAsync(int id);
    }
}