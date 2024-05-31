using APBD_c05.Models;
using APBD_c05.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_c05.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase 
{
    private readonly IClientService _clientService;

    public ClientsController(IClientService clientService)
    {
        _clientService = clientService;
    }
    
    [HttpDelete("{id::int}")]
    public IActionResult DeleteClient(Client client)
    {
        var result = _clientService.DeleteClient(client);
        return NoContent();
    }
}