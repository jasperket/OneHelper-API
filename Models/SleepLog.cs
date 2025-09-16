namespace OneHelper.Models
{
    public class SleepLog : Entity
    {
        public override int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string? Notes { get; set; } = string.Empty;
        public int UserId { get; set; }
        public User? User { get; set; }
    }
    
}
