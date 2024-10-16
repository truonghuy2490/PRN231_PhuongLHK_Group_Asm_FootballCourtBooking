using System;
using System.Collections.Generic;

namespace FBS.Repositories.Entities;

public partial class ReviewReply
{
    public int ReplyId { get; set; }

    public int ReviewId { get; set; }

    public int OwnerId { get; set; }

    public string? ReplyContent { get; set; }

    public DateTime ReplyDate { get; set; }

    public virtual User Owner { get; set; } = null!;

    public virtual Review Review { get; set; } = null!;
}
