using System;
using System.Collections.Generic;

namespace FBS.BusinessObjects.BusinessModels.RequestModels.UpdateModels;

public partial class ReviewReplyUpdateModel
{
    public int ReplyId { get; set; }

    public int ReviewId { get; set; }

    public int OwnerId { get; set; }

    public string? ReplyContent { get; set; }

    public DateTime ReplyDate { get; set; }
}
