using System;
using System.Collections.Generic;

namespace FBS.Repositories.Entities;

public partial class CourtOwner
{
    public int CourtOwnerId { get; set; }

    public string FullName { get; set; } = null!;

    public string CourtOwnerName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public string? CourtOwnerTaxCode { get; set; }

    public byte[] PasswordHash { get; set; } = null!;

    public byte[] PasswordSalt { get; set; } = null!;

    public DateOnly DateCreated { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<CourtGroup> CourtGroups { get; set; } = new List<CourtGroup>();

    public virtual ICollection<ReviewReply> ReviewReplies { get; set; } = new List<ReviewReply>();
}
