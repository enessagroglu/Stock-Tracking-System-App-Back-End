namespace StockTrackingSystemApp_BackEnd.Application.DTOs;

public class UserRegistrationDto
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}