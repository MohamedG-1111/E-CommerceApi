using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities.BasketModule;
using Shared.Dtos.BasketDTO;

namespace Services.MappingProfile
{
    public class BasketMapping:Profile
    {
        public BasketMapping()
        {
            CreateMap<BasketDto,CustomerBasket>().ReverseMap();
            CreateMap<BasketItems,BasketItemsDto>().ReverseMap();   
        }
    }
}
