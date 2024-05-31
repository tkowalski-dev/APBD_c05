using System;
using System.Collections.Generic;

namespace APBD_c05.Models;

public partial class TripDTO
{
    // public int IdTrip { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime DateFrom { get; set; }

    public DateTime DateTo { get; set; }

    public int MaxPeople { get; set; }
    
    // public virtual ICollection<Country> IdCountries { get; set; } = new List<Country>();
    public virtual ICollection<CountryDTO> Countries { get; set; } = new List<CountryDTO>();

    // public virtual ICollection<ClientTrip> ClientTrips { get; set; } = new List<ClientTrip>();
    public virtual ICollection<ClientDTO> Clients { get; set; } = new List<ClientDTO>();


}
