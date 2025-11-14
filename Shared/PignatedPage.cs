using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class PignatedPage<TEntity>
    {
        public PignatedPage(int PageIndex,int PageSize,int Count ,IEnumerable<TEntity> Date)
        {
            this.PageIndex = PageIndex;
            this.PageSize = PageSize;
            this.Count = Count;
            this.Date = Date;

        }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Count { set; get; }
        public IEnumerable<TEntity> Date { get; set; }
    }
}
