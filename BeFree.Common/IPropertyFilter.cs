using System;

namespace BeFree.Common
{
    public interface IPropertyFilter : IFilter
    {
        Guid PropertyId { get; set; }
    }
}
