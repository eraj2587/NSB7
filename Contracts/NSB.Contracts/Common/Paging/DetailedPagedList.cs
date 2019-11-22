using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WUBS.Contracts.Services.DataContracts;

namespace WUBS.Contracts.Common.Paging
{
    public class DetailedPagedList<T>
    {
        private IEnumerable<T> _list;
        private int? _pageSize;
        private int? _page;
        private readonly int? _defaultandmaxpageSize;

        protected DetailedPagedList(IEnumerable<T> list, int? defaultandmaxpageSize, int? page = null, int? pageSize = null)
        {
            _list = list;
            _page = page;
            _pageSize = pageSize;
            _defaultandmaxpageSize = defaultandmaxpageSize;
        }
        public DetailedPagedList() { }
        private int SetMaxPageSize()
        {
            if (!_defaultandmaxpageSize.HasValue)
                return _list.Count();
            return _list.Count() < (int)_defaultandmaxpageSize ? _list.Count() : (int)_defaultandmaxpageSize;
        }
        private static bool IsNullOrEmpty(IEnumerable<T> enumerable)
        {
            if (enumerable == null)
                return true;
            return !enumerable.Any();
        }
        public IList<T> Items
        {
            get
            {
                if (_list == null) return null;
                return _list.Skip((Page - 1) * PageSize).Take(PageSize).ToList();
            }
        }
        public int Page
        {
            get
            {
                if (!_page.HasValue || _page.Value == 0)
                    return 1;
                else
                    return _page.Value;
            }
        }
        public int PageSize
        {
            get
            {
                if (!_pageSize.HasValue || _pageSize.Value == 0)
                    return IsNullOrEmpty(_list) ? 0 : SetMaxPageSize();
                else
                    return SetMaxPageSize() < _pageSize.Value ? SetMaxPageSize() : _pageSize.Value;
            }
        }
        public int TotalItemCount
        {
            get { return IsNullOrEmpty(_list) ? 0 : _list.Count(); }
        }

        public int TotalPageCount
        {
            get { return IsNullOrEmpty(_list) ? 0 : (_list.Count() / PageSize) + ((_list.Count() % PageSize) > 0 ? 1 : 0); }
        }
        public DetailedPagedList<T> GetSortedandPagedList<TS>(SortAndPage<TS> sortAndPage, IList<T> list, string sortType)
        {
            IList<T> sortedList = new SortedList().GetSortedList(list, sortAndPage.SortDirection, sortType);
            DetailedPagedList<T> detailedPage = new DetailedPagedList<T>(sortedList, sortAndPage.DefaultPageSize, sortAndPage.CurrentPage, sortAndPage.PageSize);
            return detailedPage;
        }
    }
}
