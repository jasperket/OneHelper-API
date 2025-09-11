namespace OneHelper.Dto
{

    public sealed record SleepRequest(
        DateTime StartTime, DateTime? EndTime,
        string? Notes);
    public sealed record SleepResponse(int Id,
        DateTime StartTime, DateTime? EndTime,
        string? Notes);
}
