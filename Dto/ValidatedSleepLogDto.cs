namespace OneHelper.Dto
{
    public sealed record ValidatedSleepLog(DateTime StartTime, DateTime? EndTime,
        string? Notes)
    {
        public int UserId { get; init; }
    }
}
