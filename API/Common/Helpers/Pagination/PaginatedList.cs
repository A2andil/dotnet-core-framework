using System;
using System.Collections.Generic;
using System.Linq;
using ViewModels.Shared.Pagination;

namespace Common.Helpers.Pagination
{
    public class PaginatedList<T>
    {
        public PaginationMetaData MetaData { get; private set; } = new PaginationMetaData();
        public List<T> Entities { get; private set; }

        public PaginatedList(IQueryable<T> source, int pageIndex, int pageSize)
        {
            MetaData.PageNumber = pageIndex + 1;
            MetaData.PageSize = pageSize;
            MetaData.TotalCount = source.Count();
            MetaData.TotalPages = (int)Math.Ceiling(MetaData.TotalCount / (double)MetaData.PageSize);

            Entities = source.Skip(pageIndex * MetaData.PageSize).Take(MetaData.PageSize).ToList();
        }
    }
}
