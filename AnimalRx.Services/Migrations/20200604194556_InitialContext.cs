using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AnimalRx.Services.Migrations
{
    public partial class InitialContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "patient",
                columns: table => new
                {
                    patient_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    diagnosis = table.Column<string>(nullable: true),
                    date_admitted = table.Column<DateTime>(nullable: true),
                    date_released = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_patient", x => x.patient_id);
                });

            migrationBuilder.CreateTable(
                name: "reminder",
                columns: table => new
                {
                    reminder_id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    due_date = table.Column<DateTime>(nullable: true),
                    type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_reminder", x => x.reminder_id);
                });

            migrationBuilder.CreateTable(
                name: "treatment",
                columns: table => new
                {
                    treatment_id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    patient_id = table.Column<long>(nullable: false),
                    date = table.Column<DateTime>(nullable: true),
                    treatment_and_dose = table.Column<string>(nullable: true),
                    patient_id1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_treatment", x => x.treatment_id);
                    table.ForeignKey(
                        name: "fk_treatment_patient_patient_id1",
                        column: x => x.patient_id1,
                        principalTable: "patient",
                        principalColumn: "patient_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "vaccine",
                columns: table => new
                {
                    vaccine_id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    patient_id = table.Column<long>(nullable: false),
                    type = table.Column<string>(nullable: false),
                    dose1target_date = table.Column<DateTime>(nullable: true),
                    dose2target_date = table.Column<DateTime>(nullable: true),
                    dose3target_date = table.Column<DateTime>(nullable: true),
                    dose1delivered_date = table.Column<DateTime>(nullable: true),
                    dose2delivered_date = table.Column<DateTime>(nullable: true),
                    dose3delivered_date = table.Column<DateTime>(nullable: true),
                    dose1delivered = table.Column<bool>(nullable: false),
                    dose1required = table.Column<bool>(nullable: false),
                    dose2delivered = table.Column<bool>(nullable: false),
                    dose2required = table.Column<bool>(nullable: false),
                    dose3delivered = table.Column<bool>(nullable: false),
                    dose3required = table.Column<bool>(nullable: false),
                    patient_id1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vaccine", x => x.vaccine_id);
                    table.ForeignKey(
                        name: "fk_vaccine_patient_patient_id1",
                        column: x => x.patient_id1,
                        principalTable: "patient",
                        principalColumn: "patient_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_treatment_patient_id1",
                table: "treatment",
                column: "patient_id1");

            migrationBuilder.CreateIndex(
                name: "ix_vaccine_patient_id1",
                table: "vaccine",
                column: "patient_id1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reminder");

            migrationBuilder.DropTable(
                name: "treatment");

            migrationBuilder.DropTable(
                name: "vaccine");

            migrationBuilder.DropTable(
                name: "patient");
        }
    }
}
