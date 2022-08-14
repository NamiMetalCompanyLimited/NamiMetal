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

        #region Collection
        CreateMap<Collections.CollectionDto, Collections.Collection>().ReverseMap();
        CreateMap<Collections.CreateCollectionDto, Collections.Collection>().ReverseMap();
        CreateMap<Collections.UpdateCollectionDto, Collections.Collection>().ReverseMap();
        #endregion

        #region Attribute - AttributeOption
        CreateMap<Attributes.AttributeDto, Attributes.Attribute>()
            .ForMember(dts => dts.Childrens, opts => opts.MapFrom(src => src.Childrens))
            .ReverseMap()
            ;
        CreateMap<Attributes.CreateAttributeDto, Attributes.Attribute>().ReverseMap()
            .ForMember(dts => dts.Childrens, opts => opts.MapFrom(src => src.Childrens))
            .ReverseMap()
            ;
        CreateMap<Attributes.UpdateAttributeDto, Attributes.Attribute>().ReverseMap()
            .ForMember(dts => dts.Childrens, opts => opts.MapFrom(src => src.Childrens))
            .ReverseMap()
            ;


        CreateMap<AttributeOptions.AttributeOptionDto, AttributeOptions.AttributeOption>().ReverseMap();
        CreateMap<AttributeOptions.CreateAttributeOptionDto, AttributeOptions.AttributeOption>().ReverseMap();
        CreateMap<AttributeOptions.UpdateAttributeOptionDto, AttributeOptions.AttributeOption>().ReverseMap();

        #endregion
    }
}
