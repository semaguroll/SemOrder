using AutoMapper;
using SemOrder.Common.DTOs.Reservation;
using SemOrder.Common.Extensions;
using SemOrder.WEB.UI.Areas.Admin.Models.ReservationViewModels;

namespace SemOrder.WEB.UI.Infrasructure.Mappers
{
    public class ReservationMapperProfile : Profile
    {
        public ReservationMapperProfile()
        {
            CreateMap<ReservationViewModel, ReservationRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<ReservationViewModel, ReservationResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreateReservationViewModel, ReservationRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreateReservationViewModel, ReservationResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateReservationViewModel, ReservationRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateReservationViewModel, ReservationResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
