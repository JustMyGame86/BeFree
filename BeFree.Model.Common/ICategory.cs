﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFree.Model.Common
{
    public interface ICategory
    {
        Guid Id { get; set; }
        string Name { get; set; }
    }
}
