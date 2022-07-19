using SemOrder.Core.Repository;
using EF = SemOrder.Model.Entities;

namespace SemOrder.Service.Repository.Reservation
{
    public interface IReservationRepository : IRepository<EF.Reservation>
    {
    }
}
