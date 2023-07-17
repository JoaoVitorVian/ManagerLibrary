using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manager.Infra.Migrations
{
    /// <inheritdoc />
    public partial class LibraryMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Library",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameBk = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    codeSerial = table.Column<long>(type: "BIGINT", maxLength: 10, nullable: false),
                    bkExists = table.Column<bool>(type: "BIT", maxLength: 180, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Library", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Library");
        }
    }
}
