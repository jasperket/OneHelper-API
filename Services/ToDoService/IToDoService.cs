using OneHelper.Dto;
using OneHelper.Models;

namespace OneHelper.Services.ToDoService
{
    public interface IToDoService
    {

        public Task<IEnumerable<ToDoResponse>> GetAllToDosAsync(int userId);

        public Task<ToDoResponse?> GetToDoByIdAsync(int id);

        public Task AddToDoAsync(ToDoRequest item, int userId);
        public Task UpdateToDoAsync(int id,ToDoRequest item);
        public Task DeleteToDoAsync(int id);
    }
}
