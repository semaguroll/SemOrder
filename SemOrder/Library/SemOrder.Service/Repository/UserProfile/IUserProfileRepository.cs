using SemOrder.Core.Repository;
using EF = SemOrder.Model.Entities;

namespace SemOrder.Service.Repository.UserProfile
{
    public interface IUserProfileRepository : IRepository<EF.UserProfile>
    {
    }
}
