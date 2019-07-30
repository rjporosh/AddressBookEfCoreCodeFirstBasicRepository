using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AddressBookTask6.Migrations
{
    public partial class efcoreAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Person_personId",
                table: "Address");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Address_personId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "personId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "selectedIndex",
                table: "Address");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Address",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Address",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Address",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Address",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Address");

            migrationBuilder.AddColumn<int>(
                name: "personId",
                table: "Address",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "selectedIndex",
                table: "Address",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressBookId = table.Column<int>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Address_AddressBookId",
                        column: x => x.AddressBookId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_personId",
                table: "Address",
                column: "personId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_AddressBookId",
                table: "Person",
                column: "AddressBookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Person_personId",
                table: "Address",
                column: "personId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
