using AutoMapper;
using ExpanseTracker.Data;
using ExpanseTracker.Models.Categories;
using ExpanseTracker.Models.Expenses;

namespace ExpanseTracker.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, CategoryReadOnlyVM>();
            //.ForMember(dest => dest.Days, opt => opt.MapFrom(src => src.NumberOfDays));
            CreateMap<CategoryCreateVM, Category>();
            CreateMap<CategoryEditVM, Category>().ReverseMap();

            CreateMap<Expense,ExpenseReadOnlyVM>();
            CreateMap<ExpenseCreateVM, Expense>();
            CreateMap<ExpenseEditVM, Expense>().ReverseMap();
        }
    }
}
