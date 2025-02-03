using System.Text.RegularExpressions;
using StockTrackingSystemApp_BackEnd.Application.DTOs;
using StockTrackingSystemApp_BackEnd.Application.Interfaces;
using StockTrackingSystemApp_BackEnd.Application.Interfaces.Repositories;
using StockTrackingSystemApp_BackEnd.Domain.Entities;

namespace StockTrackingSystemApp_BackEnd.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> RegisterUserAsync(UserRegistrationDto registrationDto)
        {
            // Temel validasyonlar
            if (string.IsNullOrWhiteSpace(registrationDto.Username) ||
                string.IsNullOrWhiteSpace(registrationDto.Email) ||
                string.IsNullOrWhiteSpace(registrationDto.Password))
            {
                throw new Exception("Username, email and password are required");
            }
            
            // Email formatı kontrolü (basit regex örneği)
            if (!Regex.IsMatch(registrationDto.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                throw new Exception("Enter valid email.");
            }
            
            // Aynı kullanıcı adının var olup olmadığını kontrol et
            var existingUser = await _userRepository.GetByUsernameAsync(registrationDto.Username);
            if (existingUser != null)
            {
                throw new Exception("This username is already taken.");
            }
            
            // Şifre hashleme (BCrypt kullanılarak)
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(registrationDto.Password);

            var user = new User
            {
                Username = registrationDto.Username,
                Email = registrationDto.Email,
                PasswordHash = hashedPassword,
                Role = UserRole.User // Varsayılan rol; admin eklemesi farklı bir mekanizma ile yapılabilir.
            };

            await _userRepository.AddAsync(user);

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role.RoleName
            };
        }

        public async Task<UserDto> AuthenticateUserAsync(UserLoginDto loginDto)
        {
            // Kullanıcı adını kullanarak veritabanında kullanıcıyı getir
            var user = await _userRepository.GetByUsernameAsync(loginDto.Username);
            if (user == null)
            {
                throw new Exception("Invalid username or password.");
            }

            // Girilen şifre ile veritabanındaki hash'in doğrulanması
            bool passwordValid = BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash);
            if (!passwordValid)
            {
                throw new Exception("Invalid username or password.");
            }

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role.RoleName
            };
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(u => new UserDto
            {
                Id = u.Id,
                Username = u.Username,
                Email = u.Email,
                Role = u.Role.RoleName
            });
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return null;
            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role.RoleName
            };
        }
    }
}
