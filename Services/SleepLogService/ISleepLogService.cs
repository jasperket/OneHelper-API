using OneHelper.Dto;
using OneHelper.Models;

namespace OneHelper.Services.SleepLogService
{
    public interface ISleepLogService
    {
        public Task<IEnumerable<SleepResponse>> GetAllSleepLogAsync();
        public Task<SleepResponse?> GetSleepLogByIdAsync(int id);
        public Task AddSleepLogAsync(SleepRequest item);
        public Task UpdateSleepLogAsync(int id, SleepRequest item);
        public Task DeleteSleepLogAsync(int id);
    }
}