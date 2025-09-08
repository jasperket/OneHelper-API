namespace OneHelper.Dto
{
    public sealed record ToDoRequest(
        string title, string description,
        TimeSpan startTime, TimeSpan endTime,
        int priorityLevel, bool isCompleted,
        int userId
     );

    public sealed record ToDoResponse(
        int id, string title, string description, TimeSpan startTime,
        TimeSpan endTime, int priorityLevel, bool isCompleted, 
        int userId
     );
}
