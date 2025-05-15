using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionaleFatturaPA.Model.DTOs
{
    public class PaginatedResult<T>
    {
        public List<T> Items { get; set; }
        public int TotalCount { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
		
	}

    public class PaginatedRequest
    {
		public int PageIndex { get; set; }
		public int PageSize { get; set; }
		public string? SortOrder { get; set; }
        public List<FieldFilter>? FieldFilters { get; set; } = new List<FieldFilter>();

    }
    public class FieldFilter
    {
        public string Field { get; set; } = string.Empty;
        public string? Operator { get; set; }
        public string Value { get; set; } = string.Empty;
    }

    public class FilterQueryResult<T>
    {
        public IQueryable<T> Query { get; set; }
        public int TotalCount { get; set; }

        public FilterQueryResult(IQueryable<T> query, int totalCount)
        {
            Query = query;
            TotalCount = totalCount;
        }
    }
}
