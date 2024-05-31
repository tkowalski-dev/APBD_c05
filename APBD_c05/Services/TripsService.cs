using APBD_c05.Context;
using APBD_c05.DTOs;
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
                    .Select(c => new CountryDto
                    {
                        Name = c.Name
                    })
                    .ToList(),
                Clients = t.ClientTrips
                    .Select(e => new ClientDto
                    {
                        FirstName = e.IdClientNavigation.FirstName,
                        LastName = e.IdClientNavigation.LastName
                    })
                    .ToList()
            })
            .ToList();

        return trips;
    }

    public async Task AssignClient(ClientTripDto newClientTrip)
    {
        Client? client = _context.Clients
            .FirstOrDefault(c => c.Pesel == newClientTrip.Pesel);

        if (client is null)
        {
            client = new Client
            {
                IdClient = 0,
                FirstName = newClientTrip.FirstName,
                LastName = newClientTrip.LastName,
                Email = newClientTrip.Email,
                Telephone = newClientTrip.Telephone,
                Pesel = newClientTrip.Pesel,
                ClientTrips = new List<ClientTrip>()
            };
            // await _context.Clients.AddAsync(client);
        }

        Trip? trip = _context.Trips
            .FirstOrDefault(t => t.IdTrip == newClientTrip.IdTrip);

        if (trip is null)
        {
            throw new ArgumentException("the trip does not exists!");
        }

        ClientTrip? clientTrip = _context.ClientTrips
            .FirstOrDefault(ct => ct!.IdClient == client.IdClient && ct.IdTrip == trip.IdTrip);

        if (clientTrip is not null)
        {
            throw new ArgumentException("the client already assigned to the trip!");
        }
        
        clientTrip!.RegisteredAt = DateTime.Now;

        await _context.Clients.AddAsync(client);
        await _context.SaveChangesAsync();
    }
}