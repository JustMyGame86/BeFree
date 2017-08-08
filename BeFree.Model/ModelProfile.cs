using AutoMapper;
using BeFree.DAL.Model;
using BeFree.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFree.Model
{
    public class ModelProfile : Profile
    {
        public ModelProfile()
        {
            CreateMap<Category, CategoryPOCO>().ReverseMap();
            CreateMap<Category, ICategory>().ReverseMap();
            CreateMap<ICategory, CategoryPOCO>().ReverseMap();
        }
    }
}
