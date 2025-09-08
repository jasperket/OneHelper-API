namespace OneHelper.Models
{
    public class SleepLog
    {
        public int Id { get; set; }
        public int Duration { get; set; } // this is setup for minutes 
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? Notes { get; set; } = string.Empty;
        public int UserId { get; set; }
        public User? User { get; set; }
    }
    
}
