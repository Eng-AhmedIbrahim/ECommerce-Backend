namespace Ecommerce.Api.Base.Helpers;

public class GenericPicturesUrlResolver<TSource, TDestination>:
    IValueResolver<TSource, TDestination, List<string>>
     where TSource : BaseEntityWithPictures
{
    private readonly IConfiguration _configuration;

    public GenericPicturesUrlResolver(IConfiguration configuration)
     =>   _configuration = configuration;

    public List<string> Resolve(TSource source, TDestination destination, List<string> destMember, ResolutionContext context)
    {
        if (source.PictureUrls is null || !source.PictureUrls.Any())
            return new List<string>();

        var baseUrl =Guard.Against.NullOrWhiteSpace(_configuration["ApiBaseUrl"]);
        
        return source.PictureUrls
                     .Select(url => $"{baseUrl}/{url}")
                     .ToList();
    }
}
