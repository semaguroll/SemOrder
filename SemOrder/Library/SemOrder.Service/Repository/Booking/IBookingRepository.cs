using SemOrder.Core.Repository;
using EF = SemOrder.Model.Entities;

namespace SemOrder.Service.Repository.Booking
{
    public interface IBookingRepository : IRepository<EF.Booking>
    {
    }
}
