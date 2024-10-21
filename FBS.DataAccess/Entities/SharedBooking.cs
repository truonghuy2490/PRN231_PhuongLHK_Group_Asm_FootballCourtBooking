using System;
using System.Collections.Generic;

namespace FBS.Repositories.Entities;

public partial class SharedBooking
{
    public int SharedBookingId { get; set; }

    public int BookingId { get; set; }

    public int SharedByUserId { get; set; }

    public int? BookingSize { get; set; }

    public DateTime DateShared { get; set; }

    public string Status { get; set; } = null!;

    public virtual Booking Booking { get; set; } = null!;

    public virtual ICollection<SharedBookingMember> SharedBookingMembers { get; set; } = new List<SharedBookingMember>();

    public virtual User SharedByUser { get; set; } = null!;
}
