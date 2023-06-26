using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCliente.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "marca",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom_marca = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marca", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "flota",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo_flota = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    desc_flota = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    img_flota = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    marcaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flota", x => x.id);
                    table.ForeignKey(
                        name: "FK_flota_marca_marcaId",
                        column: x => x.marcaId,
                        principalTable: "marca",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cod_cliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nom_cliente = table.Column<int>(type: "int", nullable: false),
                    direc_cliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telef_cliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    correo_cliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    marcaId = table.Column<int>(type: "int", nullable: true),
                    flotaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.id);
                    table.ForeignKey(
                        name: "FK_cliente_flota_flotaId",
                        column: x => x.flotaId,
                        principalTable: "flota",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_cliente_marca_marcaId",
                        column: x => x.marcaId,
                        principalTable: "marca",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_cliente_flotaId",
                table: "cliente",
                column: "flotaId");

            migrationBuilder.CreateIndex(
                name: "IX_cliente_marcaId",
                table: "cliente",
                column: "marcaId");

            migrationBuilder.CreateIndex(
                name: "IX_flota_marcaId",
                table: "flota",
                column: "marcaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "flota");

            migrationBuilder.DropTable(
                name: "marca");
        }
    }
}
