using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PasswordManager.DAL.EFCore.Migrations
{
    public partial class initial_ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PasswordDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    PathToIcon = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    MasterPassword = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastAccessDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastChangeDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordDb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    PathToIcon = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastAccessDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastChangeDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PasswordDbId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_PasswordDb_PasswordDbId",
                        column: x => x.PasswordDbId,
                        principalTable: "PasswordDb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    UserLogin = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    UserPassword = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Url = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastAccessDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastChangeDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    GroupId = table.Column<int>(type: "integer", nullable: true),
                    PasswordDbId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entries_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Entries_PasswordDb_PasswordDbId",
                        column: x => x.PasswordDbId,
                        principalTable: "PasswordDb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entries_GroupId",
                table: "Entries",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_PasswordDbId",
                table: "Entries",
                column: "PasswordDbId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_PasswordDbId",
                table: "Groups",
                column: "PasswordDbId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entries");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "PasswordDb");
        }
    }
}
