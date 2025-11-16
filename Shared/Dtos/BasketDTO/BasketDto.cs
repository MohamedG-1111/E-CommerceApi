using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos.BasketDTO
{
   public record  BasketDto(string Id,ICollection<BasketItemsDto> Items);
   
}
