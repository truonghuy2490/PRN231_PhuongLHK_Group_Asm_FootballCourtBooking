using System;
using System.Collections.Generic;

namespace FBS.BusinessObjects.BusinessModels.RequestModels.CreateModels;

public partial class CourtSlotCreateModel
{
    public int SlotId { get; set; }

    public int CourtId { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public string SlotStatus { get; set; } = null!;

    public DateOnly Date { get; set; }
}
