using BeFree.DAL.Model;
using BeFree.Model;
using BeFree.Model.Common;
using BeFreeAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeFreeAPI
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            //BeFree.Model.AutoMapperMaps.Initialize();

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<CategoryViewModel, ICategory>().ReverseMap();
                cfg.CreateMap<CategoryViewModel, CategoryPOCO>().ReverseMap();
                cfg.CreateMap<Category, CategoryPOCO>().ReverseMap();
                cfg.CreateMap<Category, ICategory>().ReverseMap();
                cfg.CreateMap<ICategory, CategoryPOCO>().ReverseMap();
            });

            Console.WriteLine(AutoMapper.Mapper.Configuration.GetAllTypeMaps());
        }
    }
}