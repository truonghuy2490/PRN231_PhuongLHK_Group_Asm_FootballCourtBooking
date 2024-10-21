using System;
using System.Collections.Generic;

namespace FBS.Repositories.Entities;

public partial class Team
{
    public int TeamId { get; set; }

    public string TeamName { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public int? CreatedId { get; set; }

    public bool IsActive { get; set; }

    public virtual User? Created { get; set; }

    public virtual ICollection<SharedBookingMember> SharedBookingMembers { get; set; } = new List<SharedBookingMember>();

    public virtual ICollection<TeamMember> TeamMembers { get; set; } = new List<TeamMember>();
}
