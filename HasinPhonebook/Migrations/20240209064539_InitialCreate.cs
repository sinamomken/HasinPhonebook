using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HasinPhonebook.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentificationCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Phonebooks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phonebooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phonebooks_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhonebookItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemTag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhonebookId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhonebookItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhonebookItems_Phonebooks_PhonebookId",
                        column: x => x.PhonebookId,
                        principalTable: "Phonebooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhonebookItems_PhonebookId",
                table: "PhonebookItems",
                column: "PhonebookId");

            migrationBuilder.CreateIndex(
                name: "IX_Phonebooks_CustomerId",
                table: "Phonebooks",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhonebookItems");

            migrationBuilder.DropTable(
                name: "Phonebooks");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
