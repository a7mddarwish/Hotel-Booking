using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBooking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImgsMechanism : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "roomImages");

            migrationBuilder.DropColumn(
                name: "DeleteIconUrl",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "DisplayIconUrl",
                table: "Amenities");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Amenities",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "SysImageID",
                table: "Amenities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "HotelRoomTypes",
                columns: table => new
                {
                    HotelsId = table.Column<int>(type: "int", nullable: false),
                    RoomTypesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelRoomTypes", x => new { x.HotelsId, x.RoomTypesId });
                    table.ForeignKey(
                        name: "FK_HotelRoomTypes_Hotels_HotelsId",
                        column: x => x.HotelsId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelRoomTypes_RoomTypes_RoomTypesId",
                        column: x => x.RoomTypesId,
                        principalTable: "RoomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    SysImageID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    DisplayURL = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DeletionURL = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.SysImageID);
                });

            migrationBuilder.CreateTable(
                name: "EntityImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    EntitySet = table.Column<string>(type: "VARCHAR(35)", maxLength: 35, nullable: false),
                    EntityID = table.Column<string>(type: "VARCHAR(36)", nullable: false),
                    ImageID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    SysImageID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityImages_Images_ImageID",
                        column: x => x.ImageID,
                        principalTable: "Images",
                        principalColumn: "SysImageID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntityImages_Images_SysImageID",
                        column: x => x.SysImageID,
                        principalTable: "Images",
                        principalColumn: "SysImageID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntityImages_ImageID",
                table: "EntityImages",
                column: "ImageID");

            migrationBuilder.CreateIndex(
                name: "IX_EntityImages_SysImageID",
                table: "EntityImages",
                column: "SysImageID");

            migrationBuilder.CreateIndex(
                name: "IX_HotelRoomTypes_RoomTypesId",
                table: "HotelRoomTypes",
                column: "RoomTypesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntityImages");

            migrationBuilder.DropTable(
                name: "HotelRoomTypes");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropColumn(
                name: "SysImageID",
                table: "Amenities");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Amenities",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "DeleteIconUrl",
                table: "Amenities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DisplayIconUrl",
                table: "Amenities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "roomImages",
                columns: table => new
                {
                    ImageURL = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoomTypeID = table.Column<int>(type: "int", nullable: false),
                    DeleteImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roomImages", x => x.ImageURL);
                    table.ForeignKey(
                        name: "FK_roomImages_RoomTypes_RoomTypeID",
                        column: x => x.RoomTypeID,
                        principalTable: "RoomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_roomImages_RoomTypeID",
                table: "roomImages",
                column: "RoomTypeID");
        }
    }
}
