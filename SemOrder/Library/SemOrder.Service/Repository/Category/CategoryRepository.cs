using SemOrder.Model.Context;
using SemOrder.Service.Repository.Base;
using EF = SemOrder.Model.Entities;

namespace SemOrder.Service.Repository.Category
{
    public class CategoryRepository : Repository<EF.Category>, ICategoryRepository
    {
        private readonly DataContext _dataContext;
        public CategoryRepository(DataContext dataContext)
            :base(dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
