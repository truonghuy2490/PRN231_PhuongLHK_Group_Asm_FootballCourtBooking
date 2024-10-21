using System;
using System.Collections.Generic;

namespace FBS.Repositories.Entities;

public partial class Court
{
    public int CourtId { get; set; }

    public int CourtGroupId { get; set; }

    public string CourtName { get; set; } = null!;

    public string Location { get; set; } = null!;

    public string? Address { get; set; }

    public bool Status { get; set; }

    public int MaxPlayers { get; set; }

    public decimal PricePerHour { get; set; }

    public bool IsActive { get; set; }

    public virtual CourtGroup CourtGroup { get; set; } = null!;

    public virtual ICollection<CourtSlot> CourtSlots { get; set; } = new List<CourtSlot>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
