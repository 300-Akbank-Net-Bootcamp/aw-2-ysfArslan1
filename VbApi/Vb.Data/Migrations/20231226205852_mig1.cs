using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vb.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contact_Information_ContactType",
                schema: "dbo",
                table: "Contact");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Contact_Information_ContactType",
                schema: "dbo",
                table: "Contact",
                columns: new[] { "Information", "ContactType" },
                unique: true);
        }
    }
}
