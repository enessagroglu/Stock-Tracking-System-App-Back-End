
namespace StockTrackingSystemApp_BackEnd.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        
        public string Username { get; set; } = string.Empty;
        
        public string Email { get; set; } = string.Empty;
        
        public string PasswordHash { get; set; } = string.Empty;
        
        public UserRole Role { get; set; } = new UserRole();
        
        // Kullanıcıya ait depolar
        public ICollection<Depot> Depots { get; set; } = new List<Depot>();
    }
}
