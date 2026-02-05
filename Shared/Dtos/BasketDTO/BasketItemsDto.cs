using System.ComponentModel.DataAnnotations;

namespace Shared.Dtos.BasketDTO
{
    public record BasketItemsDto(int Id,string Name,string PictureUrl, decimal Price,[Range(1,100)]int Quantity);
    }