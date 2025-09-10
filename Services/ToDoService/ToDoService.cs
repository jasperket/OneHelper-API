using OneHelper.Repository.Interfaces;
using OneHelper.Models;
using OneHelper.Services.ToDoService;
using AutoMapper;
using OneHelper.Dto;

namespace OneHelper.Services.ToDoService;

public class ToDoService : IToDoService
{
    private readonly ITodoRepository _toDoRepository;
    private readonly IMapper _mapper;

    public ToDoService(ITodoRepository toDoRepository, IMapper mapper)
    {
        _toDoRepository = toDoRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ToDoResponse>> GetAllToDosAsync()
    {
        return _mapper.Map<IEnumerable<ToDoResponse>>(await _toDoRepository.GetAllAsync());
    }

    public async Task<ToDoResponse?> GetToDoByIdAsync(int id)
    {
        var entity = _mapper.Map<ToDoResponse>(await _toDoRepository.GetByIdAsync(id));
        return entity is null ? throw new Exception("User not found...") : entity;
    }

    public async Task AddToDoAsync(ToDoRequest item)
    {
        await _toDoRepository.AddAsync(_mapper.Map<ToDo>(item));
    }
    
    public async Task UpdateToDoAsync(int id, ToDoRequest item)
    {
        var entity = await _toDoRepository.GetByIdAsync(id);
        if ( entity is not null )
        {
            _mapper.Map(item, entity);
            await _toDoRepository.UpdateAsync(entity);
            return;
        }
        throw new Exception($"User {id} is not found in the database....");
    }

    public async Task DeleteToDoAsync(int id)
    {
        await _toDoRepository.DeleteAsync(id);
    }
}