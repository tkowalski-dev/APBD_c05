using APBD_c05.Context;
using APBD_c05.Models;

namespace APBD_c05.Services;

public class ClientsService : IClientService
{
    private readonly MasterContext _context;

    public ClientsService()
    {
        _context = new MasterContext();
    }
    
    public async Task<bool> DeleteClient(Client client)
    {
        Trip? toDelete = await _context.Trips
            .FindAsync(client);
        if (toDelete is null)
        {
            return false;
        }

        if (!toDelete.ClientTrips.Any())
        {
            throw new ArgumentException("Cannot delete a client with a trip!");
        }

        _context.Trips.Remove(toDelete);
        await _context.SaveChangesAsync();
        return true;
    }
}