using SemOrder.Model.Context;
using SemOrder.Service.Repository.Base;
using EF = SemOrder.Model.Entities;

namespace SemOrder.Service.Repository.Food
{
    public class FoodRepository : Repository<EF.Food>, IFoodRepository
    {
        private readonly DataContext _dataContext;
        public FoodRepository(DataContext dataContext)
            : base(dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
