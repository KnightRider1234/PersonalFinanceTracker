using AutoMapper;
using PersonalFinanceTracker.API.Models;
using PersonalFinanceTracker.Shared.DTOs;

namespace PersonalFinanceTracker.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Entry, EntryDto>();
            CreateMap<EntryDto, Entry>();
        }
    }
}