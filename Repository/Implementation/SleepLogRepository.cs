using OneHelper.Models;
using OneHelper.Repository.Interfaces;

namespace OneHelper.Repository.UserRepository
{
    public class SleepLogRepository : GenericRepository<SleepLog>, ISleepLogRepository
    {
        public SleepLogRepository(OneHelperContext context) : base(context)
        {

        }
    }
}
