namespace OneHelper.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public required string Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public required TimeSpan StartTime { get; set; }
        public required DateTime EndTime { get; set; }
        public required int PriorityLevel { get; set; }
        public bool? IsCompleted { get; set; }
        public required int UserId { get; set; }
        public required User User { get; set; }

    }
}
