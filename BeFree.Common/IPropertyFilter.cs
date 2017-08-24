using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFree.Common
{
    public interface IPropertyFilter : IFilter
    {
        Guid PropertyId { get; set; }
    }
}
