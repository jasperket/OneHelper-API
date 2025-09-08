using OneHelper.Repository.Interfaces;
using OneHelper.Models;
using OneHelper.Services.ToDoService;

namespace OneHelper.Services.ToDoService;

public class ToDoService : IToDoService
{
    private readonly ITodoRepository _toDoRepository;

    public ToDoService(ITodoRepository toDoRepository)
    {
        _toDoRepository = toDoRepository;
    }

    public async Task<IEnumerable<ToDo>> GetAllToDosAsync()
    {
        return await _toDoRepository.GetAllAsync();
    }

    public async Task<ToDo?> GetToDoByIdAsync(int id)
    {
        return await _toDoRepository.GetByIdAsync(id);
    }

    public async Task AddToDoAsync(ToDo item)
    {
        await _toDoRepository.AddAsync(item);
    }

    public async Task UpdateToDoAsync(ToDo item)
    {
        await _toDoRepository.UpdateAsync(item);
    }

    public async Task DeleteToDoAsync(int id)
    {
        await _toDoRepository.DeleteAsync(id);
    }
}