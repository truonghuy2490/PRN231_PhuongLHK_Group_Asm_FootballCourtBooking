using System;
using System.Collections.Generic;

namespace FBS.BusinessObjects.BusinessModels.RequestModels.UpdateModels;

public partial class PaymentUpdateModel
{
    public int PaymentId { get; set; }

    public int BookingId { get; set; }

    public decimal Amount { get; set; }

    public DateTime PaymentDate { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public string? TransactionId { get; set; }

}
