using BeFree.DAL.Model;
using BeFree.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFree.Model
{
    public static class AutoMapperMaps
    {
        public static void Initialize()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Category, CategoryPOCO>().ReverseMap();
                cfg.CreateMap<Category, ICategory>().ReverseMap();
                cfg.CreateMap<ICategory, CategoryPOCO>().ReverseMap();
            });
        }
    }

}
