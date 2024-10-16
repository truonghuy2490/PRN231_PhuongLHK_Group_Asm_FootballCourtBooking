using System;
using System.Collections.Generic;

namespace FBS.Repositories.Entities;

public partial class Court
{
    public int CourtId { get; set; }

    public int OwnerId { get; set; }

    public string CourtName { get; set; } = null!;

    public string Location { get; set; } = null!;

    public string? Address { get; set; }

    public bool Status { get; set; }

    public int Size { get; set; }

    public decimal PricePerHour { get; set; }

    public virtual ICollection<CourtSlot> CourtSlots { get; set; } = new List<CourtSlot>();

    public virtual User Owner { get; set; } = null!;

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
