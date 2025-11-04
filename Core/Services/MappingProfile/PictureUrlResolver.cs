using AutoMapper;
using Domain.Entities.ProductModule;
using Microsoft.Extensions.Configuration;
using Shared.Dtos;

public class ProductPictureUrlResolver : IValueResolver<Product, ProductDto, string>
{
    private readonly IConfiguration _configuration;

    public ProductPictureUrlResolver(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
    {
        if (string.IsNullOrEmpty(source.PictureUrl))
            return string.Empty;

        if (source.PictureUrl.StartsWith("http"))
            return source.PictureUrl;

        var BaseUrl = _configuration.GetSection("URLs")["BaseUrl"];
        if (string.IsNullOrEmpty(BaseUrl)) return string.Empty;
        var PicUrl = $"{BaseUrl}{source.PictureUrl}";
        return PicUrl;
    }
}