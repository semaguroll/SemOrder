using AutoMapper;
using SemOrder.Common.DTOs.Booking;
using SemOrder.Common.Extensions;
using SemOrder.Model.Entities;

namespace SemOrder.API.Infrastructor.Mapper
{
    public class BookingMapper : Profile
    {
        public BookingMapper()
        {
            CreateMap<Booking, BookingRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Booking, BookingResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option=>option.Condition((src, dest, srcMember) => srcMember != null));
               
        }
    }
}
