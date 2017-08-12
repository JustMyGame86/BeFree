using AutoMapper;
using BeFree.DAL.Model;
using BeFree.Model.Common;

namespace BeFree.Model
{
    public class ModelProfile : Profile
    {
        public ModelProfile()
        {
            CreateMap<Category, CategoryPOCO>().ReverseMap();
            CreateMap<Category, ICategory>().ReverseMap();
            CreateMap<ICategory, CategoryPOCO>().ReverseMap();

            CreateMap<Property, PropertyPOCO>().ReverseMap();
            CreateMap<Property, IProperty>().ReverseMap();
            CreateMap<PropertyPOCO, IProperty>().ReverseMap();

            CreateMap<Review, ReviewPOCO>().ReverseMap();
            CreateMap<Review, IReview>().ReverseMap();
            CreateMap<IReview, ReviewPOCO>().ReverseMap();
        }
    }
}
