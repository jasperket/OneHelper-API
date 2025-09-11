namespace OneHelper.Dto
{
    public record ValidatedToDoDto(string Title, string? Description, string ToDoType,
        DateTime StartTime, DateTime EndTime,
        int PriorityLevel, bool IsCompleted)
    {
        public int UserId { get; set; }
    }
}
