using System;
using System.Collections.Generic;

namespace FBS.Repositories.Entities;

public partial class CourtSlot
{
    public int SlotId { get; set; }

    public int CourtId { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public string SlotStatus { get; set; } = null!;

    public DateOnly Date { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Court Court { get; set; } = null!;
}
