namespace Ecommerce.UseCases.ProductUseCases.Query.GetProductsQueryUseCase;

public record GetProductsQuery(ISpecifications<Product> productSpecs) : IRequest<ICollection<ProductToReturnDto>> { }