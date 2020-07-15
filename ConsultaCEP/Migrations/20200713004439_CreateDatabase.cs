using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultaCEP.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cep",
                columns: table => new
                {
                    cep = table.Column<string>(nullable: false),
                    logradouro = table.Column<string>(nullable: true),
                    complemento = table.Column<string>(nullable: true),
                    bairro = table.Column<string>(nullable: true),
                    localidade = table.Column<string>(nullable: true),
                    uf = table.Column<string>(nullable: true),
                    unidade = table.Column<string>(nullable: true),
                    ibge = table.Column<string>(nullable: true),
                    gia = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cep", x => x.cep);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cep");
        }
    }
}
