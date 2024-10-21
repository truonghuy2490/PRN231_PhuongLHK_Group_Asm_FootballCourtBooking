using System;
using System.Collections.Generic;

namespace FBS.Repositories.Entities;

public partial class UserFollower
{
    public int FollowerId { get; set; }

    public int FolloweredId { get; set; }

    public DateTime FollowDate { get; set; }

    public virtual User Follower { get; set; } = null!;

    public virtual User Followered { get; set; } = null!;
}
