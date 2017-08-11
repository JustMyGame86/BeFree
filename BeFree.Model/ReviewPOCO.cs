using BeFree.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFree.Model
{
    public class ReviewPOCO : IReview
    {
        public Guid Id { get; set; }
        public Guid PropertyId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime RatedOn { get; set; }
    }
}
