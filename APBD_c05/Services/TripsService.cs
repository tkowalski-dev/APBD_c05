using APBD_c05.Context;
using APBD_c05.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace APBD_c05.Services;

public class TripsService : ITripsService
{
    private readonly MasterContext _context;

    public TripsService()
    {
        _context = new MasterContext();
    }

    public List<TripDTO> GetTrips()
    {
        // var trips = _context.Trips.OrderByDescending(t => t.DateFrom);

        var trips = _context.Trips
            .Include(t => t.IdCountries)
            // .Include(t => t.IdTrip)
            .Select(t => new TripDTO
            {
                Name = t.Name,
                Description = t.Description,
                DateFrom = t.DateFrom,
                DateTo = t.DateTo,
                MaxPeople = t.MaxPeople,
                Countries = t.IdCountries
                    .Select(c => new CountryDTO
                    {
                        Name = c.Name
                    })
                    .ToList(),
                Clients = t.ClientTrips
                    .Select(e => new ClientDTO
                    {
                        FirstName = e.IdClientNavigation.FirstName,
                        LastName = e.IdClientNavigation.LastName
                    })
                    .ToList()
            })
            .ToList();
        
        return trips;
    }
}