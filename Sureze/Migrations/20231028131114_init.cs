using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Sureze.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PrimaryProvider = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<int>(type: "integer", nullable: false),
                    Suffix = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    NatinalIdNumber = table.Column<string>(type: "text", nullable: false),
                    Birthdate = table.Column<DateOnly>(type: "date", nullable: false),
                    Sex = table.Column<int>(type: "integer", nullable: false),
                    Race = table.Column<int>(type: "integer", nullable: false),
                    profilepicture = table.Column<string>(type: "text", nullable: false),
                    RecordStatus = table.Column<byte>(type: "smallint", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ApiKey = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientAddresses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    address = table.Column<string>(type: "text", nullable: false),
                    country = table.Column<string>(type: "text", nullable: false),
                    phonenumber = table.Column<string>(type: "text", nullable: false),
                    postalCode = table.Column<string>(type: "text", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    RecordStatus = table.Column<byte>(type: "smallint", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ApiKey = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientAddresses_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientAddresses_PatientsId",
                table: "PatientAddresses",
                column: "PatientsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientAddresses");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
