using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeFreeAPI.ViewModels
{
    public class PropertyRatingViewModel : PropertyViewModel
    {
        public decimal AverageRating { get; set; }
        public decimal HighestRating { get; set; }
        public decimal LowestRating { get; set; }
        public decimal NumberOfReviews { get; set; }
    }
}