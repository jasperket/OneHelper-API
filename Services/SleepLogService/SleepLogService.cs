using OneHelper.Repository.Interfaces;
using OneHelper.Models;
using OneHelper.Services.SleepLogService;

namespace OneHelper.Services.SleepLogService;

public class SleepLogService : ISleepLogService
{
    private readonly ISleepLogRepository _sleepLogRepository;

    public SleepLogService(ISleepLogRepository sleepLogRepository)
    {
        _sleepLogRepository = sleepLogRepository;
    }

    public async Task<IEnumerable<SleepLog>> GetAllSleepLogAsync()
    {
        return await _sleepLogRepository.GetAllAsync();
    }

    public async Task<SleepLog?> GetSleepLogByIdAsync(int id)
    {
        return await _sleepLogRepository.GetByIdAsync(id);
    }

    public async Task AddSleepLogAsync(SleepLog item)
    {
        await _sleepLogRepository.AddAsync(item);
    }

    public async Task UpdateSleepLogAsync(SleepLog item)
    {
        await _sleepLogRepository.UpdateAsync(item);
    }

    public async Task DeleteSleepLogAsync(int id)
    {
        await _sleepLogRepository.DeleteAsync(id);
    }
}