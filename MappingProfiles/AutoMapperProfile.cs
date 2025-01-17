using AutoMapper;
using ExpanseTracker.Data;
using ExpanseTracker.Models.Categories;

namespace ExpanseTracker.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, IndexVM>();
            //.ForMember(dest => dest.Days, opt => opt.MapFrom(src => src.NumberOfDays));
        }
    }
}
