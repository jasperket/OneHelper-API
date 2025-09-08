using OneHelper.Models;

namespace OneHelper.Services.SleepLogService
{
    public interface ISleepLogService
    {
        public Task<IEnumerable<SleepLog>> GetAllSleepLogAsync();
        public Task<SleepLog?> GetSleepLogByIdAsync(int id);
        public Task AddSleepLogAsync(SleepLog item);
        public Task UpdateSleepLogAsync(SleepLog item);
        public Task DeleteSleepLogAsync(int id);
    }
}