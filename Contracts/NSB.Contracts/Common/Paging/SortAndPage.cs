using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WUBS.Contracts.Services.DataContracts;

namespace WUBS.Contracts.Common.Paging
{
    public class SortAndPage<T>
    {
        private LimitOrderSortColumn sortType;
        private LimitOrderBySort sortDirection;

        public SortAndPage(int pagesize, int currentpage, List<T> sorttype, SortDirection sortdirection, int? defaultpagesize)
        {
            PageSize = pagesize;
            CurrentPage = currentpage;
            SortType = sorttype;
            SortDirection = sortdirection;
            DefaultPageSize = defaultpagesize;
        }

        public SortAndPage(int pageSize, int currentPage, LimitOrderSortColumn sortType, LimitOrderBySort sortDirection, int defaultPageSize)
        {
            PageSize = pageSize;
            CurrentPage = currentPage;
            this.sortType = sortType;
            this.sortDirection = sortDirection;
            DefaultPageSize = defaultPageSize;
        }

        public int PageSize { get; private set; }
        public int CurrentPage { get; private set; }
        public List<T> SortType { get; private set; }
        public SortDirection SortDirection { get; private set; }
        public int? DefaultPageSize { get; private set; }
    }
}
