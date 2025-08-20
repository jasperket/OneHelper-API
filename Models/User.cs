using System.Reflection.Metadata.Ecma335;

namespace OneHelper.Models
{
    public class User
    {
        public required int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Gender { get; set; }
        public required DateOnly DateOfBirth { get; set; }
        public required string Email { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required decimal Height { get; set; }
        public required decimal Weight { get; set; }
        public string? PhoneNumber { get; set; }

        public ICollection<SleepLog> SleepLogs { get; set; } = new List<SleepLog>();
        public ICollection<ToDo> Todos { get; set; } = new List<ToDo>();
    }
}
