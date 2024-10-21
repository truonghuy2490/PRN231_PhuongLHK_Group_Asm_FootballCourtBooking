using System;
using System.Collections.Generic;

namespace FBS.Repositories.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string FullName { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public byte[] PasswordHash { get; set; } = null!;

    public byte[] PasswordSalt { get; set; } = null!;

    public DateOnly DateCreated { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<SharedBookingMember> SharedBookingMembers { get; set; } = new List<SharedBookingMember>();

    public virtual ICollection<SharedBooking> SharedBookings { get; set; } = new List<SharedBooking>();

    public virtual ICollection<TeamMember> TeamMembers { get; set; } = new List<TeamMember>();

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();

    public virtual ICollection<UserFollower> UserFollowerFollowereds { get; set; } = new List<UserFollower>();

    public virtual ICollection<UserFollower> UserFollowerFollowers { get; set; } = new List<UserFollower>();
}
