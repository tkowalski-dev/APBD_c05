using APBD_c05.Models;

namespace APBD_c05.Services;

public interface IClientService
{
    Task<bool> DeleteClient(Client trip);
}