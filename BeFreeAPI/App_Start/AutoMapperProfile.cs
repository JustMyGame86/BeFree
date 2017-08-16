using AutoMapper;
using BeFree.Model;
using BeFree.Model.Common;
using BeFreeAPI.ViewModels;

namespace BeFreeAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CategoryViewModel, ICategory>().ReverseMap();
            CreateMap<CategoryViewModel, CategoryPOCO>().ReverseMap();

            CreateMap<PropertyViewModel, IProperty>().ReverseMap();
            CreateMap<PropertyViewModel, PropertyPOCO>().ReverseMap();

            CreateMap<ReviewViewModel, IReview>().ReverseMap();
            CreateMap<ReviewViewModel, ReviewPOCO>().ReverseMap();

            CreateMap<PropertyRatingViewModel, IPropertyRating>().ReverseMap();
        }
    }
}