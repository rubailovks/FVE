using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVE.Infrastructure.Queries
{
    public interface IOrderItemsQueries
    {
        Task<IEnumerable<int>> GetNotExistsItemNumbers(IEnumerable<int> itemNumbers);
    }
}
