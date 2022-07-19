using SemOrder.Core.Repository;
using EF = SemOrder.Model.Entities;

namespace SemOrder.Service.Repository.Order
{
    public interface IOrderRepository : IRepository<EF.Order>
    {
    }
}
