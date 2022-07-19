using AutoMapper;
using SemOrder.Common.DTOs.Reservation;
using SemOrder.Common.Extensions;
using SemOrder.Model.Entities;

namespace SemOrder.API.Infrastructor.Mapper
{
    public class ReservationMapper : Profile
    {
        public ReservationMapper()
        {
            CreateMap<Reservation, ReservationRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Reservation, ReservationResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option=>option.Condition((src, dest, srcMember) => srcMember != null));
               
        }
    }
}
