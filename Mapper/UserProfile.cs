using AutoMapper;
using OneHelper.Dto;
using OneHelper.Models;

namespace OneHelper.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterDto, User>();
        }
    }
}
