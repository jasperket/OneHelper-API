using OneHelper.Models;
using OneHelper.Repository.Interfaces;

namespace OneHelper.Repository.UserRepository
{
    public class ToDoRepository : GenericRepository<ToDo>, ITodoRepository
    {
        public ToDoRepository(OneHelperContext context) : base(context)
        {

        }
    }
}
