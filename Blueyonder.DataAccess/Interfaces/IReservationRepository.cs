using Blueyonder.Entities;

namespace Blueyonder.DataAccess.Interfaces
{
    public interface IReservationRepository : ISingleKeyEntityRepository<Reservation, int>
    {
    }
}
