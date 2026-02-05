using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ParamaterQuery
    {
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public string? Search { get; set; }
        private int _pageNumber = 1;

        public int PageNumber
        {
            get => _pageNumber;
            set => _pageNumber = (value < 1) ? 1 : value;
        }
    
        private const int PageDefault = 5;
        private const int MaxPageSize = 10;
        private int _pageSize = PageDefault;
        public int PageSize
        {
            get => _pageSize;
            set
            {
                if (value < 1)
                    _pageSize = PageDefault;
                else if (value > MaxPageSize)
                    _pageSize = MaxPageSize;
                else
                    _pageSize = value;
            }
        }

        public ProductSorting Sort { get; set; }

    }
}
