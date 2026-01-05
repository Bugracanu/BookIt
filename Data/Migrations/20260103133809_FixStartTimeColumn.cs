using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookIt.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixStartTimeColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StarTime",
                table: "Bookings",
                newName: "StartTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Bookings",
                newName: "StarTime");
        }
    }
}
