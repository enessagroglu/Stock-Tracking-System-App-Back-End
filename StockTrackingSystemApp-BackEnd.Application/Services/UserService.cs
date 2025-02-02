using StockTrackingSystemApp_BackEnd.Application.DTOs;
using StockTrackingSystemApp_BackEnd.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace StockTrackingSystemApp_BackEnd.Application.Services
{
    public class UserService : IUserService
    {
        public Task<UserDto> AuthenticateUserAsync(UserLoginDto loginDto)
        {
            // Gerçek iş mantığı burada uygulanacak
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<UserDto> GetUserByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserDto> RegisterUserAsync(UserRegistrationDto registrationDto)
        {
            throw new System.NotImplementedException();
        }
    }
}