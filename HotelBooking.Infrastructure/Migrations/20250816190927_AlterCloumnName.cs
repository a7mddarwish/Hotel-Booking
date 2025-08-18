using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBooking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterCloumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropForeignKey(
                name: "FK_EntityImages_Images_SysImageID",
                table: "EntityImages");

            migrationBuilder.DropIndex(
                name: "IX_EntityImages_SysImageID",
                table: "EntityImages");

            migrationBuilder.DropColumn(
        name: "SysImageID",
        table: "EntityImages");

            migrationBuilder.RenameColumn(
                name: "SysImageID",
                table: "Images",
                newName: "ImageID");


            migrationBuilder.AddForeignKey(
                name: "FK_EntityImages_Images_SysImageImageID",
                table: "EntityImages",
                column: "ImageID",
                principalTable: "Images",
                principalColumn: "ImageID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntityImages_Images_SysImageImageID",
                table: "EntityImages");

            migrationBuilder.RenameColumn(
                name: "ImageID",
                table: "Images",
                newName: "SysImageID");

            migrationBuilder.RenameColumn(
                name: "SysImageImageID",
                table: "EntityImages",
                newName: "SysImageID");

            migrationBuilder.RenameIndex(
                name: "IX_EntityImages_SysImageImageID",
                table: "EntityImages",
                newName: "IX_EntityImages_SysImageID");

            migrationBuilder.AddForeignKey(
                name: "FK_EntityImages_Images_SysImageID",
                table: "EntityImages",
                column: "SysImageID",
                principalTable: "Images",
                principalColumn: "SysImageID");
        }
    }
}
