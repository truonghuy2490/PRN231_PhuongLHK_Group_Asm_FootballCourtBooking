using System;
using System.Collections.Generic;

namespace FBS.Repositories.Entities;

public partial class SharedBookingMember
{
    public int SharedBookingMemberId { get; set; }

    public int SharedBookingId { get; set; }

    public int? UserId { get; set; }

    public int? TeamId { get; set; }

    public bool IsAccepted { get; set; }

    public DateTime AccreptedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual SharedBooking SharedBooking { get; set; } = null!;

    public virtual Team? Team { get; set; }

    public virtual User? User { get; set; }
}
