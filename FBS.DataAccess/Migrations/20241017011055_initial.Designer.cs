﻿// <auto-generated />
using System;
using FBS.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FBS.Repositories.Migrations
{
    [DbContext(typeof(FootballCourtBookingContext))]
    [Migration("20241017011055_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FBS.Repositories.Entities.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BookingID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingId"));

                    b.Property<DateTime>("BookingDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<int>("SlotId")
                        .HasColumnType("int")
                        .HasColumnName("SlotID");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.HasKey("BookingId")
                        .HasName("PK__Bookings__73951ACD16F6961B");

                    b.HasIndex("SlotId");

                    b.HasIndex("UserId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("FBS.Repositories.Entities.Court", b =>
                {
                    b.Property<int>("CourtId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CourtID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourtId"));

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("CourtName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int")
                        .HasColumnName("Owner_ID");

                    b.Property<decimal>("PricePerHour")
                        .HasColumnType("money");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("CourtId")
                        .HasName("PK__Courts__C3A67CFABF5B893E");

                    b.HasIndex("OwnerId");

                    b.ToTable("Courts");
                });

            modelBuilder.Entity("FBS.Repositories.Entities.CourtSlot", b =>
                {
                    b.Property<int>("SlotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SlotID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SlotId"));

                    b.Property<int>("CourtId")
                        .HasColumnType("int")
                        .HasColumnName("CourtID");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<TimeOnly>("EndTime")
                        .HasColumnType("time");

                    b.Property<string>("SlotStatus")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<TimeOnly>("StartTime")
                        .HasColumnType("time");

                    b.HasKey("SlotId")
                        .HasName("PK__CourtSlo__0A124A4FB0258D93");

                    b.HasIndex(new[] { "CourtId", "Date", "StartTime" }, "UQ__CourtSlo__D8CD23231E2C0647")
                        .IsUnique();

                    b.ToTable("CourtSlots");
                });

            modelBuilder.Entity("FBS.Repositories.Entities.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PaymentID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("BookingId")
                        .HasColumnType("int")
                        .HasColumnName("BookingID");

                    b.Property<DateTime>("PaymentDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TransactionId")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("TransactionID");

                    b.HasKey("PaymentId")
                        .HasName("PK__Payments__9B556A5819D944FB");

                    b.HasIndex("BookingId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("FBS.Repositories.Entities.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ReviewID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewId"));

                    b.Property<int>("BookingId")
                        .HasColumnType("int")
                        .HasColumnName("BookingID");

                    b.Property<string>("Comment")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("CourtId")
                        .HasColumnType("int")
                        .HasColumnName("CourtID");

                    b.Property<decimal?>("Rating")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<DateTime>("ReviewDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.HasKey("ReviewId")
                        .HasName("PK__Reviews__74BC79AE4A1C39B7");

                    b.HasIndex("BookingId");

                    b.HasIndex("CourtId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("FBS.Repositories.Entities.ReviewReply", b =>
                {
                    b.Property<int>("ReplyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ReplyID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReplyId"));

                    b.Property<int>("OwnerId")
                        .HasColumnType("int")
                        .HasColumnName("OwnerID");

                    b.Property<string>("ReplyContent")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("ReplyDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("ReviewId")
                        .HasColumnType("int")
                        .HasColumnName("ReviewID");

                    b.HasKey("ReplyId")
                        .HasName("PK__ReviewRe__C25E4629AC8BB398");

                    b.HasIndex("OwnerId");

                    b.HasIndex("ReviewId");

                    b.ToTable("ReviewReplies");
                });

            modelBuilder.Entity("FBS.Repositories.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<DateOnly>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("varbinary(512)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("varbinary(512)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("UserId")
                        .HasName("PK__Users__1788CCAC56F2B21D");

                    b.HasIndex(new[] { "Email" }, "UQ__Users__A9D10534A57D636B")
                        .IsUnique();

                    b.HasIndex(new[] { "UserName" }, "UQ__Users__C9F28456EF09110E")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FBS.Repositories.Entities.Booking", b =>
                {
                    b.HasOne("FBS.Repositories.Entities.CourtSlot", "Slot")
                        .WithMany("Bookings")
                        .HasForeignKey("SlotId")
                        .IsRequired()
                        .HasConstraintName("FK__Bookings__SlotID__49C3F6B7");

                    b.HasOne("FBS.Repositories.Entities.User", "User")
                        .WithMany("Bookings")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__Bookings__UserID__48CFD27E");

                    b.Navigation("Slot");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FBS.Repositories.Entities.Court", b =>
                {
                    b.HasOne("FBS.Repositories.Entities.User", "Owner")
                        .WithMany("Courts")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Courts__Owner_ID__3F466844");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("FBS.Repositories.Entities.CourtSlot", b =>
                {
                    b.HasOne("FBS.Repositories.Entities.Court", "Court")
                        .WithMany("CourtSlots")
                        .HasForeignKey("CourtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__CourtSlot__Court__440B1D61");

                    b.Navigation("Court");
                });

            modelBuilder.Entity("FBS.Repositories.Entities.Payment", b =>
                {
                    b.HasOne("FBS.Repositories.Entities.Booking", "Booking")
                        .WithMany("Payments")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Payments__Bookin__4E88ABD4");

                    b.Navigation("Booking");
                });

            modelBuilder.Entity("FBS.Repositories.Entities.Review", b =>
                {
                    b.HasOne("FBS.Repositories.Entities.Booking", "Booking")
                        .WithMany("Reviews")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Reviews__Booking__534D60F1");

                    b.HasOne("FBS.Repositories.Entities.Court", "Court")
                        .WithMany("Reviews")
                        .HasForeignKey("CourtId")
                        .IsRequired()
                        .HasConstraintName("FK__Reviews__CourtID__5535A963");

                    b.HasOne("FBS.Repositories.Entities.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__Reviews__UserID__5441852A");

                    b.Navigation("Booking");

                    b.Navigation("Court");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FBS.Repositories.Entities.ReviewReply", b =>
                {
                    b.HasOne("FBS.Repositories.Entities.User", "Owner")
                        .WithMany("ReviewReplies")
                        .HasForeignKey("OwnerId")
                        .IsRequired()
                        .HasConstraintName("FK__ReviewRep__Owner__59FA5E80");

                    b.HasOne("FBS.Repositories.Entities.Review", "Review")
                        .WithMany("ReviewReplies")
                        .HasForeignKey("ReviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__ReviewRep__Revie__59063A47");

                    b.Navigation("Owner");

                    b.Navigation("Review");
                });

            modelBuilder.Entity("FBS.Repositories.Entities.Booking", b =>
                {
                    b.Navigation("Payments");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("FBS.Repositories.Entities.Court", b =>
                {
                    b.Navigation("CourtSlots");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("FBS.Repositories.Entities.CourtSlot", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("FBS.Repositories.Entities.Review", b =>
                {
                    b.Navigation("ReviewReplies");
                });

            modelBuilder.Entity("FBS.Repositories.Entities.User", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Courts");

                    b.Navigation("ReviewReplies");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
