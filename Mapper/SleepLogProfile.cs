using AutoMapper;
using OneHelper.Models;
using OneHelper.Dto;
using System.Security.Claims;

namespace OneHelper.Mapper
{
    public class SleepLogProfile : Profile
    {
        public SleepLogProfile()
        {
            CreateMap<SleepLog, SleepRequest>();
            CreateMap<SleepLog, SleepResponse>();
            CreateMap<SleepRequest, SleepLog>();
            CreateMap<SleepResponse, SleepLog>();
            CreateMap<SleepRequest, ValidatedSleepLog>();
            CreateMap<ValidatedSleepLog, SleepLog>();
        }
    }
}
