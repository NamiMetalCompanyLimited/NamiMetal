using AutoMapper;
using NamiMetal.ProductCategories;

namespace NamiMetal;

public class NamiMetalApplicationAutoMapperProfile : Profile
{
    public NamiMetalApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<ProductCategory, ProductCategoryDto>().ReverseMap();
        CreateMap<CreateProductCategoryDto, ProductCategory>().ReverseMap();
    }
}
