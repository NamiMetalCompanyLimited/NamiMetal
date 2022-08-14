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
    }
}
