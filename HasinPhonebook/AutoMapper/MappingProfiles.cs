using AutoMapper;
using HasinPhonebook.Dtos;
using HasinPhonebook.Entities;

namespace HasinPhonebook.AutoMapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<PhonebookItem, PhonebookItemDto>();
        }
    }
}
