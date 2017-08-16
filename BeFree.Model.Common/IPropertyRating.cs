using System;

namespace BeFree.Model.Common
{
    public interface IPropertyRating : IProperty
    {
        decimal AverageRating { get; set; }
        decimal HighestRating { get; set; }
        decimal LowestRating { get; set; }
        decimal NumberOfReviews { get; set; }
    }
}
