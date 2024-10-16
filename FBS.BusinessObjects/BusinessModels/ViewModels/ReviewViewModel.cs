using System;
using System.Collections.Generic;

namespace FBS.BusinessObjects.BusinessModels.ViewModels;

public partial class ReviewViewModel
{
    public int ReviewId { get; set; }

    public int BookingId { get; set; }

    public int UserId { get; set; }

    public int CourtId { get; set; }

    public decimal? Rating { get; set; }

    public string? Comment { get; set; }

    public DateTime ReviewDate { get; set; }

    public virtual ICollection<ReviewReplyViewModel> ReviewReplies { get; set; } = new List<ReviewReplyViewModel>();
}
