using OneHelper.Repository.Interfaces;
using OneHelper.Models;
using OneHelper.Services.SleepLogService;
using AutoMapper;
using OneHelper.Dto;

namespace OneHelper.Services.SleepLogService;

public class SleepLogService : ISleepLogService
{
    private readonly ISleepLogRepository _sleepLogRepository;
    private readonly IMapper _mapper;

    public SleepLogService(ISleepLogRepository sleepLogRepository, IMapper mapper)
    {
        _sleepLogRepository = sleepLogRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SleepResponse>> GetAllSleepLogAsync()
    {
        return _mapper.Map<IEnumerable<SleepResponse>>(await _sleepLogRepository.GetAllAsync()) ?? throw new Exception("Sleep log list is null");
    }

    public async Task<SleepResponse?> GetSleepLogByIdAsync(int id)
    {
        return _mapper.Map<SleepResponse>(await _sleepLogRepository.GetByIdAsync(id)) ?? throw new Exception("Sleep log not found");
    }

    public async Task AddSleepLogAsync(SleepRequest item)
    {
        await _sleepLogRepository.AddAsync(_mapper.Map<SleepLog>(item));
    }

    public async Task UpdateSleepLogAsync(int id, SleepRequest item)
    {
        var entity = await _sleepLogRepository.GetByIdAsync(id);
        if ( entity is null )
        {
            throw new Exception("User not found...");
        }
        _mapper.Map(item, entity);
        await _sleepLogRepository.UpdateAsync(entity);
    }

    public async Task DeleteSleepLogAsync(int id)
    {
        await _sleepLogRepository.DeleteAsync(id);
    }
}