using System;
using System.Collections.Generic;

namespace APBD_c05.DTOs;

public class ClientTripDto
{
    // public int IdClient { get; set; }
    //
    // public int IdTrip { get; set; }
    //
    // public DateTime RegisteredAt { get; set; }
    //
    // public DateTime? PaymentDate { get; set; }
    //
    // public virtual Client IdClientNavigation { get; set; } = null!;
    //
    // public virtual Trip IdTripNavigation { get; set; } = null!;
    
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public string Pesel { get; set; } = null!;

    public int IdTrip { get; set; }

    public string TripName { get; set; } = null!;

    public DateTime? PaymentDate { get; set; }
}
