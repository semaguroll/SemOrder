using AutoMapper;
using SemOrder.Common.DTOs.Table;
using SemOrder.Common.Extensions;
using SemOrder.Model.Entities;

namespace SemOrder.API.Infrastructor.Mapper
{
    public class TableMapper : Profile
    {
        public TableMapper()
        {
            CreateMap<Table, TableRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
