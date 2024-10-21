using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FBS.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourtOwner",
                columns: table => new
                {
                    CourtOwnerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CourtOwnerName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CourtOwnerTaxCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(8000)", maxLength: 8000, nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(8000)", maxLength: 8000, nullable: false),
                    DateCreated = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CourtOwn__CCAAE33272F6190D", x => x.CourtOwnerID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(8000)", maxLength: 8000, nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(8000)", maxLength: 8000, nullable: false),
                    DateCreated = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__1788CCACE1135D5A", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "CourtGroup",
                columns: table => new
                {
                    CourtGroupID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourtOwnerID = table.Column<int>(type: "int", nullable: false),
                    CourtGroupName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CourtGro__8A8CCEA1D026C55E", x => x.CourtGroupID);
                    table.ForeignKey(
                        name: "FK__CourtGrou__Court__4D94879B",
                        column: x => x.CourtOwnerID,
                        principalTable: "CourtOwner",
                        principalColumn: "CourtOwnerID");
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Created_Id = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Teams__123AE7B9C1C7AF42", x => x.TeamID);
                    table.ForeignKey(
                        name: "FK__Teams__Created_I__3F466844",
                        column: x => x.Created_Id,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "UserFollower",
                columns: table => new
                {
                    follower_id = table.Column<int>(type: "int", nullable: false),
                    followered_id = table.Column<int>(type: "int", nullable: false),
                    follow_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserFoll__8BE0055814CE2158", x => new { x.follower_id, x.followered_id });
                    table.ForeignKey(
                        name: "FK__UserFollo__follo__02084FDA",
                        column: x => x.follower_id,
                        principalTable: "Users",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK__UserFollo__follo__02FC7413",
                        column: x => x.followered_id,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Courts",
                columns: table => new
                {
                    CourtID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourtGroupID = table.Column<int>(type: "int", nullable: false),
                    CourtName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    MaxPlayers = table.Column<int>(type: "int", nullable: false),
                    PricePerHour = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Courts__C3A67CFADA3DF21A", x => x.CourtID);
                    table.ForeignKey(
                        name: "FK__Courts__CourtGro__52593CB8",
                        column: x => x.CourtGroupID,
                        principalTable: "CourtGroup",
                        principalColumn: "CourtGroupID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamMembers",
                columns: table => new
                {
                    TeamMemberID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    DateJoined = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Team_Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TeamMemb__C7C092851ACC00C1", x => x.TeamMemberID);
                    table.ForeignKey(
                        name: "FK__TeamMembe__TeamI__4316F928",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__TeamMembe__UserI__440B1D61",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourtSlots",
                columns: table => new
                {
                    SlotID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourtID = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    EndTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    SlotStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CourtSlo__0A124A4FC9D02690", x => x.SlotID);
                    table.ForeignKey(
                        name: "FK__CourtSlot__Court__5812160E",
                        column: x => x.CourtID,
                        principalTable: "Courts",
                        principalColumn: "CourtID");
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookedID = table.Column<int>(type: "int", nullable: false),
                    SlotID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Bookings__73951ACD058AD9C1", x => x.BookingID);
                    table.ForeignKey(
                        name: "FK__Bookings__Booked__5CD6CB2B",
                        column: x => x.BookedID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK__Bookings__SlotID__5DCAEF64",
                        column: x => x.SlotID,
                        principalTable: "CourtSlots",
                        principalColumn: "SlotID");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    PaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TransactionID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Payments__9B556A58D191C5E3", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK__Payments__Bookin__6383C8BA",
                        column: x => x.BookingID,
                        principalTable: "Bookings",
                        principalColumn: "BookingID");
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    CourtID = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ReviewDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reviews__74BC79AEFC6277B3", x => x.ReviewID);
                    table.ForeignKey(
                        name: "FK__Reviews__Booking__693CA210",
                        column: x => x.BookingID,
                        principalTable: "Bookings",
                        principalColumn: "BookingID");
                    table.ForeignKey(
                        name: "FK__Reviews__CourtID__6B24EA82",
                        column: x => x.CourtID,
                        principalTable: "Courts",
                        principalColumn: "CourtID");
                    table.ForeignKey(
                        name: "FK__Reviews__UserID__6A30C649",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "SharedBookings",
                columns: table => new
                {
                    SharedBookingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingID = table.Column<int>(type: "int", nullable: false),
                    SharedByUserID = table.Column<int>(type: "int", nullable: false),
                    BookingSize = table.Column<int>(type: "int", nullable: true),
                    DateShared = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SharedBo__57D6B7FE7B57B275", x => x.SharedBookingID);
                    table.ForeignKey(
                        name: "FK__SharedBoo__Booki__75A278F5",
                        column: x => x.BookingID,
                        principalTable: "Bookings",
                        principalColumn: "BookingID");
                    table.ForeignKey(
                        name: "FK__SharedBoo__Share__76969D2E",
                        column: x => x.SharedByUserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "ReviewReplies",
                columns: table => new
                {
                    ReplyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReviewID = table.Column<int>(type: "int", nullable: false),
                    OwnerID = table.Column<int>(type: "int", nullable: false),
                    ReplyContent = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ReplyDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ReviewRe__C25E4629840B4DD5", x => x.ReplyID);
                    table.ForeignKey(
                        name: "FK__ReviewRep__Owner__70DDC3D8",
                        column: x => x.OwnerID,
                        principalTable: "CourtOwner",
                        principalColumn: "CourtOwnerID");
                    table.ForeignKey(
                        name: "FK__ReviewRep__Revie__6FE99F9F",
                        column: x => x.ReviewID,
                        principalTable: "Reviews",
                        principalColumn: "ReviewID");
                });

            migrationBuilder.CreateTable(
                name: "SharedBookingMembers",
                columns: table => new
                {
                    SharedBookingMemberID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SharedBookingID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    TeamID = table.Column<int>(type: "int", nullable: true),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false),
                    AccreptedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SharedBo__73E22CBE8705D671", x => x.SharedBookingMemberID);
                    table.ForeignKey(
                        name: "FK__SharedBoo__Share__7C4F7684",
                        column: x => x.SharedBookingID,
                        principalTable: "SharedBookings",
                        principalColumn: "SharedBookingID");
                    table.ForeignKey(
                        name: "FK__SharedBoo__TeamI__7E37BEF6",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID");
                    table.ForeignKey(
                        name: "FK__SharedBoo__UserI__7D439ABD",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BookedID",
                table: "Bookings",
                column: "BookedID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_SlotID",
                table: "Bookings",
                column: "SlotID");

            migrationBuilder.CreateIndex(
                name: "IX_CourtGroup_CourtOwnerID",
                table: "CourtGroup",
                column: "CourtOwnerID");

            migrationBuilder.CreateIndex(
                name: "UQ__CourtOwn__488C38F94F059137",
                table: "CourtOwner",
                column: "CourtOwnerName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__CourtOwn__A9D10534F3134894",
                table: "CourtOwner",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courts_CourtGroupID",
                table: "Courts",
                column: "CourtGroupID");

            migrationBuilder.CreateIndex(
                name: "UQ__CourtSlo__D8CD2323BD6E4106",
                table: "CourtSlots",
                columns: new[] { "CourtID", "Date", "StartTime" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_BookingID",
                table: "Payments",
                column: "BookingID");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewReplies_OwnerID",
                table: "ReviewReplies",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewReplies_ReviewID",
                table: "ReviewReplies",
                column: "ReviewID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BookingID",
                table: "Reviews",
                column: "BookingID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CourtID",
                table: "Reviews",
                column: "CourtID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserID",
                table: "Reviews",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_SharedBookingMembers_SharedBookingID",
                table: "SharedBookingMembers",
                column: "SharedBookingID");

            migrationBuilder.CreateIndex(
                name: "IX_SharedBookingMembers_TeamID",
                table: "SharedBookingMembers",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_SharedBookingMembers_UserID",
                table: "SharedBookingMembers",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_SharedBookings_BookingID",
                table: "SharedBookings",
                column: "BookingID");

            migrationBuilder.CreateIndex(
                name: "IX_SharedBookings_SharedByUserID",
                table: "SharedBookings",
                column: "SharedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_TeamID",
                table: "TeamMembers",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_UserID",
                table: "TeamMembers",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Created_Id",
                table: "Teams",
                column: "Created_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserFollower_followered_id",
                table: "UserFollower",
                column: "followered_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Users__A9D10534F17C8593",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Users__C9F284565D4442A0",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "ReviewReplies");

            migrationBuilder.DropTable(
                name: "SharedBookingMembers");

            migrationBuilder.DropTable(
                name: "TeamMembers");

            migrationBuilder.DropTable(
                name: "UserFollower");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "SharedBookings");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "CourtSlots");

            migrationBuilder.DropTable(
                name: "Courts");

            migrationBuilder.DropTable(
                name: "CourtGroup");

            migrationBuilder.DropTable(
                name: "CourtOwner");
        }
    }
}
