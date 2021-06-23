using Microsoft.EntityFrameworkCore.Migrations;

namespace back_end.Migrations
{
    public partial class MigracionEspecie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EspecieItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<int>(nullable: false),
                    Kingdom = table.Column<string>(nullable: true),
                    ScientificName = table.Column<string>(nullable: true),
                    CanonicalName = table.Column<string>(nullable: true),
                    NameType = table.Column<string>(nullable: true),
                    Origin = table.Column<string>(nullable: true),
                    NumDescendants = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspecieItems", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EspecieItems");
        }
    }
}
