namespace Ecommerce.UseCases.ProductAttributeUseCases.Query.GetAttributeByIdUseCase;

public class GetAttributeByIdQueryValidator : AbstractValidator<GetAttributeByIdQuery>
{
    public GetAttributeByIdQueryValidator()
    {
        RuleFor(x => x.attributeId)
            .GreaterThan(0)
            .WithMessage("AttributeId must be greater than 0.");
    }
}