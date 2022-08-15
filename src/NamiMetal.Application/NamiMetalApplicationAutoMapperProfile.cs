using AutoMapper;
using NamiMetal.Categories;
using NamiMetal.Collections;
using System.Collections.Generic;

namespace NamiMetal;

public class NamiMetalApplicationAutoMapperProfile : Profile
{
    public NamiMetalApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Category, CategoryDto>();

        CreateMap<CreateCategoryDto, Category>();

        CreateMap<UpdateCategoryDto, Category>();

        CreateMap<Collection, CollectionDto>();

        CreateMap<CreateCollectionDto, Collection>();

        CreateMap<UpdateCollectionDto, Collection>();

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
        CreateMap<Attributes.AttributeDto, Attributes.UpdateAttributeDto>()
            .ForMember(dts => dts.Childrens, opts => opts.MapFrom(src => src.Childrens))
            .ReverseMap()
            ;
        CreateMap<Attributes.CreateAttributeDto, Attributes.Attribute>()
            .ForMember(dts => dts.Childrens, opts => opts.MapFrom(src => src.Childrens))
            .ReverseMap()
            ;
        CreateMap<Attributes.UpdateAttributeDto, Attributes.Attribute>()
            .ForMember(dts => dts.Childrens, opts => opts.MapFrom(src => src.Childrens))
            .ReverseMap()
            ;

        CreateMap<Attributes.UpdateAttributeDto, Attributes.UpdateAttributeDto>().ReverseMap()
            .ForMember(dts => dts.Childrens, opts => opts.Ignore())
            ;

        CreateMap<AttributeOptions.AttributeOption, AttributeOptions.AttributeOption>();
        CreateMap<AttributeOptions.AttributeOptionDto, AttributeOptions.AttributeOption>().ReverseMap();
        CreateMap<AttributeOptions.CreateAttributeOptionDto, AttributeOptions.AttributeOption>().ReverseMap();
        CreateMap<AttributeOptions.UpdateAttributeOptionDto, AttributeOptions.AttributeOptionDto>().ReverseMap();
        CreateMap<AttributeOptions.UpdateAttributeOptionDto, AttributeOptions.AttributeOption>().ReverseMap();
        CreateMap<AttributeOptions.UpdateAttributeOptionDto, AttributeOptions.UpdateAttributeOptionDto>().ReverseMap();
        CreateMap<AttributeOptions.UpdateAttributeOptionDto, AttributeOptions.CreateAttributeOptionDto>().ReverseMap();

        #endregion
    }
}
