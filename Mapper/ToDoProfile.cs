using AutoMapper;
using OneHelper.Dto;
using OneHelper.Models;
namespace OneHelper.Mapper
{
    public class ToDoProfile : Profile
    {
        public ToDoProfile()
        {
            CreateMap<ToDoRequest, ToDo>();
            CreateMap<ToDoResponse, ToDo>();
            CreateMap<ToDo, ToDoResponse>();
            CreateMap<ToDoRequest, ValidatedToDoDto>();
            CreateMap<ValidatedToDoDto, ToDo>();
        }
    }
}
