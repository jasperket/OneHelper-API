using OneHelper.Dto;
using OneHelper.Models;

namespace OneHelper.Services.SleepLogService
{
    public interface ISleepLogService
    {
        public Task<IEnumerable<SleepResponse>> GetAllSleepLogAsync(int userId);
        public Task<SleepResponse?> GetSleepLogByIdAsync(int id);
        public Task AddSleepLogAsync(SleepRequest item, int userId);
        public Task UpdateSleepLogAsync(int id, SleepRequest item);
        public Task DeleteSleepLogAsync(int id);
    }
}