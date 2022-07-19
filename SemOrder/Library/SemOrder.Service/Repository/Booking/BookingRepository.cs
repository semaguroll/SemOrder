using SemOrder.Model.Context;
using SemOrder.Service.Repository.Base;
using EF = SemOrder.Model.Entities;

namespace SemOrder.Service.Repository.Booking
{
    public class BookingRepository : Repository<EF.Booking>, IBookingRepository
    {
        private readonly DataContext _dataContext;
        public BookingRepository(DataContext dataContext)
            :base(dataContext)
        {
                _dataContext = dataContext;
        }
    }
}
