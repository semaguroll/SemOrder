using SemOrder.Core.Repository;
using EF = SemOrder.Model.Entities;

namespace SemOrder.Service.Repository.Table
{
    public interface ITableRepository : IRepository<EF.Table>
    {
    }
}
