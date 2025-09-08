namespace OneHelper.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int PriorityLevel { get; set; }
        public bool? IsCompleted { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; } 

    }
}
