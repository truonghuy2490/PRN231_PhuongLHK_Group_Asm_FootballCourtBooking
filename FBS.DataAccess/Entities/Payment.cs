﻿using System;
using System.Collections.Generic;

namespace FBS.Repositories.Entities;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int BookingId { get; set; }

    public decimal Amount { get; set; }

    public DateTime PaymentDate { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public string? TransactionId { get; set; }

    public virtual Booking Booking { get; set; } = null!;
}
