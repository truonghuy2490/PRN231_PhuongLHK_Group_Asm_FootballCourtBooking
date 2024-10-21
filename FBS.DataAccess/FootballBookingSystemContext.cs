using System;
using System.Collections.Generic;
using FBS.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FBS.Repositories;

public partial class FootballBookingSystemContext : DbContext
{
    public FootballBookingSystemContext()
    {
    }

    public FootballBookingSystemContext(DbContextOptions<FootballBookingSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Court> Courts { get; set; }

    public virtual DbSet<CourtGroup> CourtGroups { get; set; }

    public virtual DbSet<CourtOwner> CourtOwners { get; set; }

    public virtual DbSet<CourtSlot> CourtSlots { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<ReviewReply> ReviewReplies { get; set; }

    public virtual DbSet<SharedBooking> SharedBookings { get; set; }

    public virtual DbSet<SharedBookingMember> SharedBookingMembers { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<TeamMember> TeamMembers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserFollower> UserFollowers { get; set; }
    private string? GetConnectionString()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true).Build();
        return configuration["ConnectionStrings:DefaultConnectionString"];
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(GetConnectionString());
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__Bookings__73951ACD058AD9C1");

            entity.Property(e => e.BookingId).HasColumnName("BookingID");
            entity.Property(e => e.BookedId).HasColumnName("BookedID");
            entity.Property(e => e.BookingDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SlotId).HasColumnName("SlotID");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Booked).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.BookedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bookings__Booked__5CD6CB2B");

            entity.HasOne(d => d.Slot).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.SlotId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bookings__SlotID__5DCAEF64");
        });

        modelBuilder.Entity<Court>(entity =>
        {
            entity.HasKey(e => e.CourtId).HasName("PK__Courts__C3A67CFADA3DF21A");

            entity.Property(e => e.CourtId).HasColumnName("CourtID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.CourtGroupId).HasColumnName("CourtGroupID");
            entity.Property(e => e.CourtName).HasMaxLength(255);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.PricePerHour).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.CourtGroup).WithMany(p => p.Courts)
                .HasForeignKey(d => d.CourtGroupId)
                .HasConstraintName("FK__Courts__CourtGro__52593CB8");
        });

        modelBuilder.Entity<CourtGroup>(entity =>
        {
            entity.HasKey(e => e.CourtGroupId).HasName("PK__CourtGro__8A8CCEA1D026C55E");

            entity.ToTable("CourtGroup");

            entity.Property(e => e.CourtGroupId).HasColumnName("CourtGroupID");
            entity.Property(e => e.CourtGroupName).HasMaxLength(255);
            entity.Property(e => e.CourtOwnerId).HasColumnName("CourtOwnerID");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.CourtOwner).WithMany(p => p.CourtGroups)
                .HasForeignKey(d => d.CourtOwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CourtGrou__Court__4D94879B");
        });

        modelBuilder.Entity<CourtOwner>(entity =>
        {
            entity.HasKey(e => e.CourtOwnerId).HasName("PK__CourtOwn__CCAAE33272F6190D");

            entity.ToTable("CourtOwner");

            entity.HasIndex(e => e.CourtOwnerName, "UQ__CourtOwn__488C38F94F059137").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__CourtOwn__A9D10534F3134894").IsUnique();

            entity.Property(e => e.CourtOwnerId).HasColumnName("CourtOwnerID");
            entity.Property(e => e.CourtOwnerName).HasMaxLength(255);
            entity.Property(e => e.CourtOwnerTaxCode).HasMaxLength(50);
            entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FullName).HasMaxLength(255);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.PasswordHash).HasMaxLength(8000);
            entity.Property(e => e.PasswordSalt).HasMaxLength(8000);
            entity.Property(e => e.Phone).HasMaxLength(20);
        });

        modelBuilder.Entity<CourtSlot>(entity =>
        {
            entity.HasKey(e => e.SlotId).HasName("PK__CourtSlo__0A124A4FC9D02690");

            entity.HasIndex(e => new { e.CourtId, e.Date, e.StartTime }, "UQ__CourtSlo__D8CD2323BD6E4106").IsUnique();

            entity.Property(e => e.SlotId).HasColumnName("SlotID");
            entity.Property(e => e.CourtId).HasColumnName("CourtID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.SlotStatus).HasMaxLength(50);

            entity.HasOne(d => d.Court).WithMany(p => p.CourtSlots)
                .HasForeignKey(d => d.CourtId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CourtSlot__Court__5812160E");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payments__9B556A58D191C5E3");

            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.BookingId).HasColumnName("BookingID");
            entity.Property(e => e.PaymentDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TransactionId)
                .HasMaxLength(255)
                .HasColumnName("TransactionID");

            entity.HasOne(d => d.Booking).WithMany(p => p.Payments)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Payments__Bookin__6383C8BA");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Reviews__74BC79AEFC6277B3");

            entity.Property(e => e.ReviewId).HasColumnName("ReviewID");
            entity.Property(e => e.BookingId).HasColumnName("BookingID");
            entity.Property(e => e.Comment).HasMaxLength(500);
            entity.Property(e => e.CourtId).HasColumnName("CourtID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Rating).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ReviewDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Booking).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reviews__Booking__693CA210");

            entity.HasOne(d => d.Court).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.CourtId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reviews__CourtID__6B24EA82");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reviews__UserID__6A30C649");
        });

        modelBuilder.Entity<ReviewReply>(entity =>
        {
            entity.HasKey(e => e.ReplyId).HasName("PK__ReviewRe__C25E4629840B4DD5");

            entity.Property(e => e.ReplyId).HasColumnName("ReplyID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.OwnerId).HasColumnName("OwnerID");
            entity.Property(e => e.ReplyContent).HasMaxLength(500);
            entity.Property(e => e.ReplyDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ReviewId).HasColumnName("ReviewID");

            entity.HasOne(d => d.Owner).WithMany(p => p.ReviewReplies)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ReviewRep__Owner__70DDC3D8");

            entity.HasOne(d => d.Review).WithMany(p => p.ReviewReplies)
                .HasForeignKey(d => d.ReviewId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ReviewRep__Revie__6FE99F9F");
        });

        modelBuilder.Entity<SharedBooking>(entity =>
        {
            entity.HasKey(e => e.SharedBookingId).HasName("PK__SharedBo__57D6B7FE7B57B275");

            entity.Property(e => e.SharedBookingId).HasColumnName("SharedBookingID");
            entity.Property(e => e.BookingId).HasColumnName("BookingID");
            entity.Property(e => e.DateShared)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SharedByUserId).HasColumnName("SharedByUserID");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Booking).WithMany(p => p.SharedBookings)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SharedBoo__Booki__75A278F5");

            entity.HasOne(d => d.SharedByUser).WithMany(p => p.SharedBookings)
                .HasForeignKey(d => d.SharedByUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SharedBoo__Share__76969D2E");
        });

        modelBuilder.Entity<SharedBookingMember>(entity =>
        {
            entity.HasKey(e => e.SharedBookingMemberId).HasName("PK__SharedBo__73E22CBE8705D671");

            entity.Property(e => e.SharedBookingMemberId).HasColumnName("SharedBookingMemberID");
            entity.Property(e => e.AccreptedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.SharedBookingId).HasColumnName("SharedBookingID");
            entity.Property(e => e.TeamId).HasColumnName("TeamID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.SharedBooking).WithMany(p => p.SharedBookingMembers)
                .HasForeignKey(d => d.SharedBookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SharedBoo__Share__7C4F7684");

            entity.HasOne(d => d.Team).WithMany(p => p.SharedBookingMembers)
                .HasForeignKey(d => d.TeamId)
                .HasConstraintName("FK__SharedBoo__TeamI__7E37BEF6");

            entity.HasOne(d => d.User).WithMany(p => p.SharedBookingMembers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__SharedBoo__UserI__7D439ABD");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.TeamId).HasName("PK__Teams__123AE7B9C1C7AF42");

            entity.ToTable(tb => tb.HasTrigger("AddTeamCreatorToTeamMembers"));

            entity.Property(e => e.TeamId).HasColumnName("TeamID");
            entity.Property(e => e.CreatedId).HasColumnName("Created_Id");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.TeamName).HasMaxLength(255);

            entity.HasOne(d => d.Created).WithMany(p => p.Teams)
                .HasForeignKey(d => d.CreatedId)
                .HasConstraintName("FK__Teams__Created_I__3F466844");
        });

        modelBuilder.Entity<TeamMember>(entity =>
        {
            entity.HasKey(e => e.TeamMemberId).HasName("PK__TeamMemb__C7C092851ACC00C1");

            entity.Property(e => e.TeamMemberId).HasColumnName("TeamMemberID");
            entity.Property(e => e.DateJoined)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TeamId).HasColumnName("TeamID");
            entity.Property(e => e.TeamRole)
                .HasMaxLength(50)
                .HasColumnName("Team_Role");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Team).WithMany(p => p.TeamMembers)
                .HasForeignKey(d => d.TeamId)
                .HasConstraintName("FK__TeamMembe__TeamI__4316F928");

            entity.HasOne(d => d.User).WithMany(p => p.TeamMembers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__TeamMembe__UserI__440B1D61");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCACE1135D5A");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534F17C8593").IsUnique();

            entity.HasIndex(e => e.UserName, "UQ__Users__C9F284565D4442A0").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FullName).HasMaxLength(255);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.PasswordHash).HasMaxLength(8000);
            entity.Property(e => e.PasswordSalt).HasMaxLength(8000);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.UserName).HasMaxLength(255);
        });

        modelBuilder.Entity<UserFollower>(entity =>
        {
            entity.HasKey(e => new { e.FollowerId, e.FolloweredId }).HasName("PK__UserFoll__8BE0055814CE2158");

            entity.ToTable("UserFollower");

            entity.Property(e => e.FollowerId).HasColumnName("follower_id");
            entity.Property(e => e.FolloweredId).HasColumnName("followered_id");
            entity.Property(e => e.FollowDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("follow_date");

            entity.HasOne(d => d.Follower).WithMany(p => p.UserFollowerFollowers)
                .HasForeignKey(d => d.FollowerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserFollo__follo__02084FDA");

            entity.HasOne(d => d.Followered).WithMany(p => p.UserFollowerFollowereds)
                .HasForeignKey(d => d.FolloweredId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserFollo__follo__02FC7413");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
