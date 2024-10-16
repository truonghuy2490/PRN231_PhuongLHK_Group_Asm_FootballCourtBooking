using System;
using System.Collections.Generic;

namespace FBS.BusinessObjects.BusinessModels.ViewModels;

public partial class BookingViewModel
{
    public int BookingId { get; set; }

    public int UserId { get; set; }

    public int SlotId { get; set; }

    public decimal Price { get; set; }

    public DateTime BookingDate { get; set; }

    public string Status { get; set; } = null!;
}
