using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeFreeAPI.ViewModels
{
    public class PropertyViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryViewModel Category { get; set; }
    }
}