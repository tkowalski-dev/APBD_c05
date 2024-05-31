using System;
using System.Collections.Generic;

namespace APBD_c05.DTOs;

public class TripDTO
{
    // public int IdTrip { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime DateFrom { get; set; }

    public DateTime DateTo { get; set; }

    public int MaxPeople { get; set; }
    
    // public virtual ICollection<Country> IdCountries { get; set; } = new List<Country>();
    public ICollection<CountryDto> Countries { get; set; } = new List<CountryDto>();

    // public virtual ICollection<ClientTrip> ClientTrips { get; set; } = new List<ClientTrip>();
    public ICollection<ClientDto> Clients { get; set; } = new List<ClientDto>();


}
