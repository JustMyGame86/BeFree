using BeFree.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BeFree.Model
{
    //[KnownType(typeof(CategoryPOCO))]
    public class CategoryPOCO : ICategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
