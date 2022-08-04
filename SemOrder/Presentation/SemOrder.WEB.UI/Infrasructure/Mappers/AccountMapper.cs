using AutoMapper;
using SemOrder.Common.DTOs.Login;
using SemOrder.Common.Extensions;
using SemOrder.WEB.UI.Models.AccountViewModels;

namespace SemOrder.WEB.UI.Infrasructure.Mappers
{
    public class AccountMapper : Profile
    {
        public AccountMapper()
        {
            CreateMap<LoginViewModel, LoginRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

        }
    }
}
