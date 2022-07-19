using AutoMapper;
using SemOrder.Common.DTOs.Food;
using SemOrder.Common.Extensions;
using SemOrder.Model.Entities;

namespace SemOrder.API.Infrastructor.Mapper
{
    public class FoodMapper : Profile
    {
        public FoodMapper()
        {
            CreateMap<Food, FoodRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Food, FoodResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option=>option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
