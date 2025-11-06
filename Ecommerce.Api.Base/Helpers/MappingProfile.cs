global using Ecommerce.Domain.Entities.ProductEntities;
global using Ecommerce.Dtos.ProductDtos;
global using Ecommerce.UseCases.CategoryUseCases.Command.CreateCategory;
global using Ecommerce.Domain.Entities.CarouselEntity;
global using Ecommerce.Dtos.CarouselDtos;
using Ecommerce.Dtos.ProductDtos.ProductReviewDtos;

namespace Ecommerce.Api.Base.Helpers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateUserCommand, SignUpDto>().ReverseMap();
        CreateMap<SignUpDto, AppUser>();
        CreateMap<LoginDto, LoginCommand>().ReverseMap();
        CreateMap<CategoryDto, Category>().ReverseMap();
        CreateMap<CreateCategoryCommand, CategoryDto>().ReverseMap();
        CreateMap<Category,CategoryToReturnDto>();
        CreateMap<UpdatedCategoryDto, CategoryToReturnDto>();
        CreateMap<ProductDto, Product>()
            .ForMember(dest => dest.Images
            , src => src.Ignore())
            .ForMember(dest => dest.Reviews,
            src => src.Ignore())
            .ForMember(dest => dest.Variants,
            opt => opt.Ignore());

        CreateMap<ProductReview, ProductReviewsToReturnDto>();


        CreateMap<Product, ProductToReturnDto>()
            .ForMember(dest => dest.Images,
            src => src
            .MapFrom(p => p.Images!.Select(i => i.Url).ToList()))
            .ForMember(dest => dest.ProductReviews,
            src => src
            .MapFrom(p => p.Reviews))
            .ForMember(dest => dest.Variants,
            opt
            => opt.MapFrom(src => src.Variants));

        CreateMap<ProductAttribute, ProductAttributeToReturnDto>();

        CreateMap<ProductAttributeDto, ProductAttribute>()
          .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<ProductVariant, ProductVariantToReturnDto>()
               .ForMember(dest => dest.AttributeEnglishName,
               opt =>
               opt.MapFrom(src => src.ProductAttribute.EnglishName))
               .ForMember(dest => dest.AttributeArabicName,
               opt =>
               opt.MapFrom(src => src.ProductAttribute.ArabicName))
               .ForMember(dest => dest.AttributeId,
               src =>
               src.MapFrom(p => p.ProductAttributeId))
               .ForMember(dest => dest.AttributeArabicName,
               src =>
               src.MapFrom(p => p.ProductAttribute.ArabicName))
               .ForMember(dest => dest.AttributeEnglishName,
               src =>
               src.MapFrom(p => p.ProductAttribute.EnglishName));

        CreateMap<ProductAttributeValueDto, ProductVariant>()
                .ForMember(dest => dest.Product,
                opt => opt.Ignore())
                .ForMember(dest => dest.ProductAttribute,
                opt => opt.Ignore())
                .ForMember(dest => dest.ImageUrl,
                opt => opt.Ignore());


        CreateMap<CarouselDto, Carousel>();
        CreateMap<Carousel, CarouselToReturnDto>();
        CreateMap<ProductReviewDto, ProductReview>()
            .ForMember(dest => dest.Id,
            opt => opt.Ignore())
            .ForMember(dest => dest.Product,
            opt => opt.Ignore())
            .ForMember(dest => dest.User,
            opt => opt.Ignore());

        CreateMap<ProductReview, ProductReviewsToReturnDto>();

    }
}