using System.ComponentModel.DataAnnotations;

namespace OneHelper.Models
{
    public class ToDo : Entity
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string ToDoType { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int PriorityLevel { get; set; }
        public bool? IsCompleted { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; } 

    }
}
