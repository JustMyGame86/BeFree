using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFree.Common
{
    public class PropertyFilter : IPropertyFilter
    {
        public Guid PropertyId { get; set; }
        public string SearchTerm { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string Sort { get; set; }
        public int Skip
        {
            get
            {
                return (Page - 1) * PageSize;
            }
            set { }
        }

        public PropertyFilter()
        {
            PageSize = 10;
        }
    }
}
