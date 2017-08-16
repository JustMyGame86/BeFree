using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeFreeAPI.ViewModels
{
    public class ReviewViewModel
    {
        public Guid Id { get; set; }
        public Guid PropertyId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime RatedOn { get; set; }
        public PropertyViewModel Property { get; set; }
    }
}