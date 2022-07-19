using SemOrder.Core.Repository;
using EF = SemOrder.Model.Entities;

namespace SemOrder.Service.Repository.Category
{
    public interface ICategoryRepository : IRepository<EF.Category>
    {
    }
}
