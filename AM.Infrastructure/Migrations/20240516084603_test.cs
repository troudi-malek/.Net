using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Laboratoire",
                columns: table => new
                {
                    LaboratoireId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Intitule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Localisation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratoire", x => x.LaboratoireId);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    CodePatient = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    EmailPatient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Informations = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomComplet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroTel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.CodePatient);
                });

            migrationBuilder.CreateTable(
                name: "Infirmier",
                columns: table => new
                {
                    InfirmierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomComplet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    specialite = table.Column<int>(type: "int", nullable: false),
                    LaboratoireId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infirmier", x => x.InfirmierId);
                    table.ForeignKey(
                        name: "FK_Infirmier_Laboratoire_LaboratoireId",
                        column: x => x.LaboratoireId,
                        principalTable: "Laboratoire",
                        principalColumn: "LaboratoireId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bilan",
                columns: table => new
                {
                    DatePrelevement = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodePatient = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    CodeInfirmier = table.Column<int>(type: "int", nullable: false),
                    EmailMedecin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Paye = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bilan", x => new { x.CodeInfirmier, x.CodePatient, x.DatePrelevement });
                    table.ForeignKey(
                        name: "FK_Bilan_Infirmier_CodeInfirmier",
                        column: x => x.CodeInfirmier,
                        principalTable: "Infirmier",
                        principalColumn: "InfirmierId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bilan_Patient_CodePatient",
                        column: x => x.CodePatient,
                        principalTable: "Patient",
                        principalColumn: "CodePatient",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Analyse",
                columns: table => new
                {
                    AnalyseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DureeResultat = table.Column<int>(type: "int", nullable: false),
                    PrixAnalyse = table.Column<double>(type: "float", nullable: false),
                    TypeAnalyse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValeurAnalyse = table.Column<float>(type: "real", nullable: false),
                    ValeurMaxNormal = table.Column<float>(type: "real", nullable: false),
                    ValeurMinNormal = table.Column<float>(type: "real", nullable: false),
                    bilanCodeInfirmier = table.Column<int>(type: "int", nullable: false),
                    bilanCodePatient = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    bilanDatePrelevement = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analyse", x => x.AnalyseId);
                    table.ForeignKey(
                        name: "FK_Analyse_Bilan_bilanCodeInfirmier_bilanCodePatient_bilanDatePrelevement",
                        columns: x => new { x.bilanCodeInfirmier, x.bilanCodePatient, x.bilanDatePrelevement },
                        principalTable: "Bilan",
                        principalColumns: new[] { "CodeInfirmier", "CodePatient", "DatePrelevement" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Analyse_bilanCodeInfirmier_bilanCodePatient_bilanDatePrelevement",
                table: "Analyse",
                columns: new[] { "bilanCodeInfirmier", "bilanCodePatient", "bilanDatePrelevement" });

            migrationBuilder.CreateIndex(
                name: "IX_Bilan_CodePatient",
                table: "Bilan",
                column: "CodePatient");

            migrationBuilder.CreateIndex(
                name: "IX_Infirmier_LaboratoireId",
                table: "Infirmier",
                column: "LaboratoireId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Analyse");

            migrationBuilder.DropTable(
                name: "Bilan");

            migrationBuilder.DropTable(
                name: "Infirmier");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Laboratoire");
        }
    }
}
