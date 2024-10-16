using System;
using System.Collections.Generic;

namespace FBS.BusinessObjects.BusinessModels.RequestModels.UpdateModels;

public partial class CourtUpdateModel
{
    public int CourtId { get; set; }

    public int OwnerId { get; set; }

    public string CourtName { get; set; } = null!;

    public string Location { get; set; } = null!;

    public string? Address { get; set; }

    public bool Status { get; set; }

    public int Size { get; set; }

    public decimal PricePerHour { get; set; }
}
