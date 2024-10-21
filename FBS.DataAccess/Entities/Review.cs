using System;
using System.Collections.Generic;

namespace FBS.Repositories.Entities;

public partial class Review
{
    public int ReviewId { get; set; }

    public int BookingId { get; set; }

    public int UserId { get; set; }

    public int CourtId { get; set; }

    public decimal? Rating { get; set; }

    public string? Comment { get; set; }

    public DateTime ReviewDate { get; set; }

    public bool IsActive { get; set; }

    public virtual Booking Booking { get; set; } = null!;

    public virtual Court Court { get; set; } = null!;

    public virtual ICollection<ReviewReply> ReviewReplies { get; set; } = new List<ReviewReply>();

    public virtual User User { get; set; } = null!;
}
