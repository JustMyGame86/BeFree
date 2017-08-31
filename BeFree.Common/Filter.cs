using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFree.Common
{
    public class Filter : IFilter
    {
        public string SearchTerm { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; }
        public bool OrderAsc { get; set; }
        public int Skip
        {
            get
            {
                return (Page - 1) * PageSize;
            }
            set { }
        }

        public Filter()
        {
            PageSize = 10;
        }
    }
}
