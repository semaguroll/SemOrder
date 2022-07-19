using SemOrder.Core.Repository;
using EF = SemOrder.Model.Entities;

namespace SemOrder.Service.Repository.Food
{
    public interface IFoodRepository : IRepository<EF.Food>
    {
    }
}
