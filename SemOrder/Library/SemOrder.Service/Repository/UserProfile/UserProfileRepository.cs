using SemOrder.Model.Context;
using SemOrder.Service.Repository.Base;
using EF = SemOrder.Model.Entities;

namespace SemOrder.Service.Repository.UserProfile
{
    public class UserProfileRepository : Repository<EF.UserProfile>, IUserProfileRepository
    {
        private readonly DataContext _dataContext;
        public UserProfileRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}
