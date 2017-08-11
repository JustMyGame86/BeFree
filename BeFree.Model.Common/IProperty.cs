using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFree.Model.Common
{
    public interface IProperty
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Address { get; set; }
        decimal? Latitude { get; set; }
        decimal? Longitude { get; set; }
        Guid CategoryId { get; set; }
    }
}
