namespace OneHelper.Models
{
    public class SleepLog
    {
        public required int Id { get; set; }
        public required TimeSpan Duration { get; set; }
        public required TimeSpan StartTime { get; set; }
        public required TimeSpan EndTime { get; set; }
        public string? Notes { get; set; } = string.Empty;
        public required DateOnly StartDate { get; set; }
        public required DateOnly EndDate { get; set; }
        public required int UserId { get; set; }
        public required User User { get; set; }
    }
}
