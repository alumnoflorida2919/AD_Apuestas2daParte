using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlaceMyBet.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Evento",
                columns: table => new
                {
                    EventoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EquipoLocal = table.Column<string>(nullable: true),
                    EquipoVisitante = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evento", x => x.EventoId);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    edad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Mercado",
                columns: table => new
                {
                    MercadoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OverUnder = table.Column<double>(nullable: false),
                    CuotaOver = table.Column<double>(nullable: false),
                    CuotaUnder = table.Column<double>(nullable: false),
                    DineroApostadoOver = table.Column<double>(nullable: false),
                    DineroApostadoUnder = table.Column<double>(nullable: false),
                    EventosId = table.Column<int>(nullable: false),
                    EventoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mercado", x => x.MercadoId);
                    table.ForeignKey(
                        name: "FK_Mercado_Evento_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Evento",
                        principalColumn: "EventoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cuenta",
                columns: table => new
                {
                    CuentaId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreBanco = table.Column<string>(nullable: true),
                    Saldo = table.Column<double>(nullable: false),
                    UsuarioEmail = table.Column<string>(nullable: true),
                    UsuarioId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuenta", x => x.CuentaId);
                    table.ForeignKey(
                        name: "FK_Cuenta_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Apuesta",
                columns: table => new
                {
                    ApuestaId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MercadoOverUnder = table.Column<double>(nullable: false),
                    TipoOverUnder = table.Column<string>(nullable: true),
                    Cuota = table.Column<double>(nullable: false),
                    DineroApostado = table.Column<double>(nullable: false),
                    fecha = table.Column<DateTime>(nullable: false),
                    Mercado_id_mercado = table.Column<int>(nullable: false),
                    Usuario_Email = table.Column<string>(nullable: true),
                    UsuarioId = table.Column<string>(nullable: true),
                    MercadoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apuesta", x => x.ApuestaId);
                    table.ForeignKey(
                        name: "FK_Apuesta_Mercado_MercadoId",
                        column: x => x.MercadoId,
                        principalTable: "Mercado",
                        principalColumn: "MercadoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Apuesta_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apuesta_MercadoId",
                table: "Apuesta",
                column: "MercadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Apuesta_UsuarioId",
                table: "Apuesta",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Cuenta_UsuarioId",
                table: "Cuenta",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mercado_EventoId",
                table: "Mercado",
                column: "EventoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apuesta");

            migrationBuilder.DropTable(
                name: "Cuenta");

            migrationBuilder.DropTable(
                name: "Mercado");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Evento");
        }
    }
}
