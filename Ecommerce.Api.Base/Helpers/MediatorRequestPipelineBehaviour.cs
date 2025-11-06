namespace Ecommerce.Api.Base.Helpers;

public class MediatorRequestPipelineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public MediatorRequestPipelineBehaviour(IEnumerable<IValidator<TRequest>> validators) =>
        _validators = validators;

    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);
        var failers = _validators.Select(validation => validation.Validate(context))
                                                .SelectMany(o => o.Errors)
                                                .Where(oc => oc != null)
                                                .ToList();

        if (failers.Any())
            throw new ValidationException(failers);

        return next();
    }
}