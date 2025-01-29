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

            //CreateMap<Expense, ExpenseReadOnlyVM>()
            //    .ForMember(dest => dest.Date, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.Date)));

            //CreateMap<ExpenseCreateVM, Expense>()
            //    .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.ToDateTime(TimeOnly.MinValue)));

            //CreateMap<ExpenseEditVM, Expense>()
            //    .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.ToDateTime(TimeOnly.MinValue)))
            //    .ReverseMap()
            //    .ForMember(dest => dest.Date, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.Date)));
            
            CreateMap<Expense, ExpenseReadOnlyVM>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.Date)))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id));


            CreateMap<ExpenseCreateVM, Expense>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.ToDateTime(TimeOnly.MinValue)))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => new Category { Id = src.CategoryId }))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => new AppUser { Id = src.UserId }));


            CreateMap<ExpenseEditVM, Expense>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.ToDateTime(TimeOnly.MinValue)))
                //.ForMember(dest => dest.Category, opt => opt.MapFrom(src => new Category { Id = src.CategoryId }))
                //.ForMember(dest => dest.User, opt => opt.MapFrom(src => new AppUser { Id = src.UserId }))
                .ReverseMap()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.Date)))
                //.ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category.Id))
                //.ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id))
                .ReverseMap();
        }
    }
}
