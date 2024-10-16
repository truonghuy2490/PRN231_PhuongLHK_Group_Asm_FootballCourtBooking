using System;
using System.Collections.Generic;
using FBS.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FBS.Repositories;

public partial class FootballCourtBookingContext : DbContext
{
    public FootballCourtBookingContext()
    {
    }

    public FootballCourtBookingContext(DbContextOptions<FootballCourtBookingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Court> Courts { get; set; }

    public virtual DbSet<CourtSlot> CourtSlots { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<ReviewReply> ReviewReplies { get; set; }

    public virtual DbSet<User> Users { get; set; }
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
            entity.HasKey(e => e.BookingId).HasName("PK__Bookings__73951ACD315AF178");

            entity.Property(e => e.BookingId).HasColumnName("BookingID");
            entity.Property(e => e.BookingDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.SlotId).HasColumnName("SlotID");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Slot).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.SlotId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bookings__SlotID__4F7CD00D");

            entity.HasOne(d => d.User).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bookings__UserID__4E88ABD4");
        });

        modelBuilder.Entity<Court>(entity =>
        {
            entity.HasKey(e => e.CourtId).HasName("PK__Courts__C3A67CFAC4F4694F");

            entity.Property(e => e.CourtId).HasColumnName("CourtID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.CourtName).HasMaxLength(255);
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.OwnerId).HasColumnName("Owner_ID");
            entity.Property(e => e.PricePerHour).HasColumnType("money");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.Owner).WithMany(p => p.Courts)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("FK__Courts__Owner_ID__3F466844");
        });

        modelBuilder.Entity<CourtSlot>(entity =>
        {
            entity.HasKey(e => e.SlotId).HasName("PK__CourtSlo__0A124A4F2B1A6047");

            entity.HasIndex(e => new { e.CourtId, e.Date, e.StartTime }, "UQ__CourtSlo__D8CD2323DE5D7194").IsUnique();

            entity.Property(e => e.SlotId).HasColumnName("SlotID");
            entity.Property(e => e.CourtId).HasColumnName("CourtID");
            entity.Property(e => e.SlotStatus).HasMaxLength(50);

            entity.HasOne(d => d.Court).WithMany(p => p.CourtSlots)
                .HasForeignKey(d => d.CourtId)
                .HasConstraintName("FK__CourtSlot__Court__440B1D61");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payments__9B556A582F266537");

            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.BookingId).HasColumnName("BookingID");
            entity.Property(e => e.PaymentDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.TransactionId)
                .HasMaxLength(255)
                .HasColumnName("TransactionID");

            entity.HasOne(d => d.Booking).WithMany(p => p.Payments)
                .HasForeignKey(d => d.BookingId)
                .HasConstraintName("FK__Payments__Bookin__5441852A");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Reviews__74BC79AEF6CE928D");

            entity.Property(e => e.ReviewId).HasColumnName("ReviewID");
            entity.Property(e => e.BookingId).HasColumnName("BookingID");
            entity.Property(e => e.Comment).HasMaxLength(500);
            entity.Property(e => e.CourtId).HasColumnName("CourtID");
            entity.Property(e => e.Rating).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ReviewDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Booking).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.BookingId)
                .HasConstraintName("FK__Reviews__Booking__5FB337D6");

            entity.HasOne(d => d.Court).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.CourtId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reviews__CourtID__619B8048");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reviews__UserID__60A75C0F");
        });

        modelBuilder.Entity<ReviewReply>(entity =>
        {
            entity.HasKey(e => e.ReplyId).HasName("PK__ReviewRe__C25E462960CF9131");

            entity.Property(e => e.ReplyId).HasColumnName("ReplyID");
            entity.Property(e => e.OwnerId).HasColumnName("OwnerID");
            entity.Property(e => e.ReplyContent).HasMaxLength(500);
            entity.Property(e => e.ReplyDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ReviewId).HasColumnName("ReviewID");

            entity.HasOne(d => d.Owner).WithMany(p => p.ReviewReplies)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ReviewRep__Owner__66603565");

            entity.HasOne(d => d.Review).WithMany(p => p.ReviewReplies)
                .HasForeignKey(d => d.ReviewId)
                .HasConstraintName("FK__ReviewRep__Revie__656C112C");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC559D1B1E");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534CDCF9EF3").IsUnique();

            entity.HasIndex(e => e.UserName, "UQ__Users__C9F2845629DA2283").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FullName).HasMaxLength(255);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
