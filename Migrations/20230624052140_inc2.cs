using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCliente.Migrations
{
    public partial class inc2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ape_cliente",
                table: "cliente",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ape_cliente",
                table: "cliente");
        }
    }
}
