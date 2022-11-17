using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Shared.SeedWorks
{
    public class PagingList<T>
    {
        public List<T> Items { get; set; }
        public int Count { get; set; }  
        public int PageSize { get; set; }
        public int CurrentPaging { get; set; }
        public int TotalPage { get; set; }
        public PagingList() { }
        public PagingList(List<T> items, int pageSize, int currentPaging, int count, int totalPage)
        {
            Items = items;
            PageSize = pageSize;
            CurrentPaging = currentPaging;
            TotalPage = totalPage;
            Count = count;
        }

    }
}
