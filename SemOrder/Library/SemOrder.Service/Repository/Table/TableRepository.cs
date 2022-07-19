using SemOrder.Model.Context;
using SemOrder.Service.Repository.Base;
using EF = SemOrder.Model.Entities;

namespace SemOrder.Service.Repository.Table
{
    public class TableRepository : Repository<EF.Table>,ITableRepository
    {
        private readonly DataContext _dataContext;
        public TableRepository(DataContext dataContext)
            :base(dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
