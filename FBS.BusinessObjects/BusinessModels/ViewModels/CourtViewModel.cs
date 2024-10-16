using System;
using System.Collections.Generic;
using FBS.BusinessObjects.BusinessModels.RequestModels;

namespace FBS.BusinessObjects.BusinessModels.ViewModels;

public partial class CourtViewModel
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
