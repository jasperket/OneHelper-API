using System.Reflection.Metadata.Ecma335;

namespace OneHelper.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public string? PhoneNumber { get; set; }

        public ICollection<SleepLog> SleepLogs { get; set; } = new List<SleepLog>();
        public ICollection<ToDo> Todos { get; set; } = new List<ToDo>();
    }
}
