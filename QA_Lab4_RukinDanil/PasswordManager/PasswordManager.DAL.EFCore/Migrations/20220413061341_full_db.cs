using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PasswordManager.DAL.EFCore.Migrations
{
    public partial class full_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DbAccessWay",
                table: "PasswordDb",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EncryptionAlgorithmId",
                table: "PasswordDb",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EncryptionAlgorithm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CodeName = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncryptionAlgorithm", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PasswordDb_EncryptionAlgorithmId",
                table: "PasswordDb",
                column: "EncryptionAlgorithmId");

            migrationBuilder.AddForeignKey(
                name: "FK_PasswordDb_EncryptionAlgorithm_EncryptionAlgorithmId",
                table: "PasswordDb",
                column: "EncryptionAlgorithmId",
                principalTable: "EncryptionAlgorithm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PasswordDb_EncryptionAlgorithm_EncryptionAlgorithmId",
                table: "PasswordDb");

            migrationBuilder.DropTable(
                name: "EncryptionAlgorithm");

            migrationBuilder.DropIndex(
                name: "IX_PasswordDb_EncryptionAlgorithmId",
                table: "PasswordDb");

            migrationBuilder.DropColumn(
                name: "DbAccessWay",
                table: "PasswordDb");

            migrationBuilder.DropColumn(
                name: "EncryptionAlgorithmId",
                table: "PasswordDb");
        }
    }
}
