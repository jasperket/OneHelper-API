using OneHelper.Models;
using OneHelper.Repository.Interfaces;

namespace OneHelper.Services.ToDoService
{
    public interface IToDoService
    {

        public Task<IEnumerable<ToDo>> GetAllToDosAsync();

        public Task<ToDo?> GetToDoByIdAsync(int id);

        public Task AddToDoAsync(ToDo item);
        public Task UpdateToDoAsync(ToDo item);
        public Task DeleteToDoAsync(int id);
    }
}
