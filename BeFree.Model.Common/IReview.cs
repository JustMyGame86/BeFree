using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFree.Model.Common
{
    public interface IReview
    {
        Guid Id  { get; set; }
        Guid PropertyId { get; set; }
        int Rating { get; set; }
        string Comment { get; set; }
        DateTime RatedOn { get; set; }
        IProperty Property { get; set; }
    }
}
