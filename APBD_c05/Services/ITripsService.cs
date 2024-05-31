using APBD_c05.Models;

namespace APBD_c05.Services;

public interface ITripsService
{
    List<TripDTO> GetTrips();
}