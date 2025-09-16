namespace OneHelper.Dto
{
    public sealed record ToDoRequest(
        string Title, string? Description, string ToDoType,
        DateTime StartTime, DateTime EndTime,
        int PriorityLevel, bool IsCompleted
     );
        
    public sealed record ToDoResponse(
        int Id, string Title, string? Description, string ToDoType, 
        DateTime StartTime, DateTime EndTime, int PriorityLevel, bool IsCompleted
     );
}
