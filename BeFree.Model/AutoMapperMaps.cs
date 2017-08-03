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
            //AutoMapper.Mapper.CreateMap<Category, CategoryPOCO>().ReverseMap();
            //AutoMapper.Mapper.CreateMap<Category, ICategory>().ReverseMap();
            //AutoMapper.Mapper.CreateMap<ICategory, CategoryPOCO>().ReverseMap();

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Category, CategoryPOCO>().ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.id)).ReverseMap();
                cfg.CreateMap<Category, ICategory>().ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.id)).ReverseMap();
                cfg.CreateMap<ICategory, CategoryPOCO>().ReverseMap();
            });
        }
    }

}
