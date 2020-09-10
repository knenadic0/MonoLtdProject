using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Common.Paging
{
    public interface IPage
    {
        Task<PagedResult<O>> GetPagedAsync<O>(IQueryable<O> query, int page, int pageSize) where O : class;
    }
}
