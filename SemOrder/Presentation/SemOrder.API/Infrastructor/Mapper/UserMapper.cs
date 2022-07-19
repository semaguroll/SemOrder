using AutoMapper;
using SemOrder.Common.DTOs.User;
using SemOrder.Common.Extensions;
using SemOrder.Model.Entities;

namespace SemOrder.API.Infrastructor.Mapper
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, UserRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<User,UserResponse>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + ' ' + src.LastName))
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option=>option.Condition((src,dest,srcMember) => srcMember != null));
        }
    }
}
