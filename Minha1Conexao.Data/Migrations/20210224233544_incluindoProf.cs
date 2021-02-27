using Microsoft.EntityFrameworkCore.Migrations;

namespace Minha1Conexao.Data.Migrations
{
    public partial class incluindoProf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Professor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(150)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Turno = table.Column<int>(type: "int", nullable: false),
                    Banco = table.Column<string>(type: "varchar(50)", nullable: true),
                    Agencia = table.Column<string>(type: "varchar(10)", nullable: true),
                    Conta = table.Column<string>(type: "varchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Professor");
        }
    }
}
