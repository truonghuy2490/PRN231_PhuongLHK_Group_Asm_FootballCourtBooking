using System;
using System.Collections.Generic;

namespace FBS.BusinessObjects.BusinessModels.ViewModels;

public partial class ReviewReplyViewModel
{
    public int ReplyId { get; set; }

    public int ReviewId { get; set; }

    public int OwnerId { get; set; }

    public string? ReplyContent { get; set; }

    public DateTime ReplyDate { get; set; }
}
