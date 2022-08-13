using AutoMapper;
using NamiMetal.ProductCategories;
using System.Collections.Generic;

namespace NamiMetal;

public class NamiMetalApplicationAutoMapperProfile : Profile
{
    public NamiMetalApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<ProductCategory, ProductCategoryDto>()
            //.ForMember(dest => dest.Parent, opt => opt.Ignore())
            .ReverseMap()
            ;

        CreateMap<CreateProductCategoryDto, ProductCategory>()
            .ReverseMap()
            ;

        CreateMap<UpdateProductCategoryDto, ProductCategory>()
            .ReverseMap()
            ;
    }
}
