using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Common.Paging
{
    public interface IPage
    {
        Task<IEnumerable<T>> GetPagedAsync<T>(IQueryable<T> query, int page, int pageSize) where T : class;
    }
}
