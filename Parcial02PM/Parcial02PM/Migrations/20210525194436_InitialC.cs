using Microsoft.EntityFrameworkCore.Migrations;

namespace Parcial02PM.Migrations
{
    public partial class InitialC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    IdQ = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quest = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.IdQ);
                });

            migrationBuilder.CreateTable(
                name: "Specialities",
                columns: table => new
                {
                    IdS = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    S = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialities", x => x.IdS);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    CardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionIdQ = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.CardId);
                    table.ForeignKey(
                        name: "FK_Users_Questions_QuestionIdQ",
                        column: x => x.QuestionIdQ,
                        principalTable: "Questions",
                        principalColumn: "IdQ",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    IdR = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserCardId = table.Column<int>(type: "int", nullable: true),
                    SpecialityIdS = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.IdR);
                    table.ForeignKey(
                        name: "FK_Reservations_Specialities_SpecialityIdS",
                        column: x => x.SpecialityIdS,
                        principalTable: "Specialities",
                        principalColumn: "IdS",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_Users_UserCardId",
                        column: x => x.UserCardId,
                        principalTable: "Users",
                        principalColumn: "CardId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_SpecialityIdS",
                table: "Reservations",
                column: "SpecialityIdS");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserCardId",
                table: "Reservations",
                column: "UserCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_QuestionIdQ",
                table: "Users",
                column: "QuestionIdQ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Specialities");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
