using System;
using System.Collections.Generic;

namespace FBS.BusinessObjects.BusinessModels.RequestModels.UpdateModels;

public partial class ReviewUpdateModel
{
    public int ReviewId { get; set; }

    public int BookingId { get; set; }

    public int UserId { get; set; }

    public int CourtId { get; set; }

    public decimal? Rating { get; set; }

    public string? Comment { get; set; }

    public DateTime ReviewDate { get; set; }
}
