using SemOrder.Core.Repository;
using SemOrder.Model.Context;
using SemOrder.Service.Repository.Base;
using EF = SemOrder.Model.Entities;

namespace SemOrder.Service.Repository.User
{
    public interface IUserRepository : IRepository<EF.User>
    {
    }
}
