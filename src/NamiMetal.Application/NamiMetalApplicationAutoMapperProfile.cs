using AutoMapper;
using NamiMetal.Categories;
using System.Collections.Generic;

namespace NamiMetal;

public class NamiMetalApplicationAutoMapperProfile : Profile
{
    public NamiMetalApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Category, CategoryDto>()
            //.ForMember(dest => dest.Parent, opt => opt.Ignore())
            .ReverseMap()
            ;

        CreateMap<CreateCategoryDto, Category>()
            .ReverseMap()
            ;

        CreateMap<UpdateCategoryDto, Category>()
            .ReverseMap()
            ;
    }
}
