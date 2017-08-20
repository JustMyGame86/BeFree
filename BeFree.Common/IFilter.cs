using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFree.Common
{
    public interface IFilter
    {
        string SearchTerm { get; set; }
        int Page { get; set; }
        int PageSize { get; set; }
        string Sort { get; set; }
    }
}
