using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.BasketModule
{
    public class CustomerBasket
    {
        public string Id { get; set; }
        public ICollection<BasketItems> Items { get; set; }= new List<BasketItems>();
    }
}
