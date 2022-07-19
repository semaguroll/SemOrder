using SemOrder.Model.Context;
using SemOrder.Service.Repository.Base;
using EF = SemOrder.Model.Entities;

namespace SemOrder.Service.Repository.Reservation
{
    public class ReservationRepository : Repository<EF.Reservation>, IReservationRepository
    {
        private readonly DataContext _dataContext;
        public ReservationRepository(DataContext dataContext)
            :base(dataContext)
        {
                _dataContext = dataContext;
        }
    }
}
