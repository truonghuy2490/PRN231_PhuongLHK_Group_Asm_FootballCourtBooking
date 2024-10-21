using System;
using System.Collections.Generic;

namespace FBS.Repositories.Entities;

public partial class TeamMember
{
    public int TeamMemberId { get; set; }

    public int TeamId { get; set; }

    public int UserId { get; set; }

    public DateTime DateJoined { get; set; }

    public string? TeamRole { get; set; }

    public virtual Team Team { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
