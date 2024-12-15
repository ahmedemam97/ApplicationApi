using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class Paging<T, R>
    {
        public R DataReturn { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public Paging(R dataReturn, int totalpages, int currentPage, int pageSize, int totalItems)
        {
            DataReturn = dataReturn;
            TotalPages = totalpages;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalItems = totalItems;
        }
    }
}
