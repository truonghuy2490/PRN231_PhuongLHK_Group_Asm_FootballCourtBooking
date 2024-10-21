using System;
using System.Collections.Generic;

namespace FBS.Repositories.Entities;

public partial class CourtGroup
{
    public int CourtGroupId { get; set; }

    public int CourtOwnerId { get; set; }

    public string CourtGroupName { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public virtual CourtOwner CourtOwner { get; set; } = null!;

    public virtual ICollection<Court> Courts { get; set; } = new List<Court>();
}
