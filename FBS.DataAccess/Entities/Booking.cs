using System;
using System.Collections.Generic;

namespace FBS.Repositories.Entities;

public partial class Booking
{
    public int BookingId { get; set; }

    public int BookedId { get; set; }

    public int SlotId { get; set; }

    public decimal Price { get; set; }

    public DateTime BookingDate { get; set; }

    public string Status { get; set; } = null!;

    public virtual User Booked { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<SharedBooking> SharedBookings { get; set; } = new List<SharedBooking>();

    public virtual CourtSlot Slot { get; set; } = null!;
}
