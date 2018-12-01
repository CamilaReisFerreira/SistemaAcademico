using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaAcademico.DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cidade",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    UF = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidade", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Data_Inicio = table.Column<DateTime>(nullable: false),
                    Carga_Horaria = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Disciplina",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Valor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplina", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    Data_Nascimento = table.Column<DateTime>(nullable: false),
                    FK_Aluno_Cidade = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Aluno_Cidade_FK_Aluno_Cidade",
                        column: x => x.FK_Aluno_Cidade,
                        principalTable: "Cidade",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegistroAcademico",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Numero_Matricula = table.Column<int>(nullable: false),
                    Semestre = table.Column<string>(nullable: true),
                    FK_RA_Aluno = table.Column<int>(nullable: false),
                    FK_RA_Curso = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroAcademico", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_RegistroAcademico_Aluno_FK_RA_Aluno",
                        column: x => x.FK_RA_Aluno,
                        principalTable: "Aluno",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegistroAcademico_Curso_FK_RA_Curso",
                        column: x => x.FK_RA_Curso,
                        principalTable: "Curso",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Nota",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FK_Nota_RA = table.Column<int>(nullable: true),
                    FK_Nota_Disciplina = table.Column<int>(nullable: false),
                    Nota1 = table.Column<decimal>(nullable: false),
                    Nota2 = table.Column<decimal>(nullable: false),
                    Nota3 = table.Column<decimal>(nullable: false),
                    Media = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nota", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Nota_Disciplina_FK_Nota_Disciplina",
                        column: x => x.FK_Nota_Disciplina,
                        principalTable: "Disciplina",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nota_RegistroAcademico_FK_Nota_RA",
                        column: x => x.FK_Nota_RA,
                        principalTable: "RegistroAcademico",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegistroDisciplina",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FK_RD_RA = table.Column<int>(nullable: true),
                    FK_RD_Disciplina = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroDisciplina", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_RegistroDisciplina_Disciplina_FK_RD_Disciplina",
                        column: x => x.FK_RD_Disciplina,
                        principalTable: "Disciplina",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegistroDisciplina_RegistroAcademico_FK_RD_RA",
                        column: x => x.FK_RD_RA,
                        principalTable: "RegistroAcademico",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_FK_Aluno_Cidade",
                table: "Aluno",
                column: "FK_Aluno_Cidade");

            migrationBuilder.CreateIndex(
                name: "IX_Nota_FK_Nota_Disciplina",
                table: "Nota",
                column: "FK_Nota_Disciplina");

            migrationBuilder.CreateIndex(
                name: "IX_Nota_FK_Nota_RA",
                table: "Nota",
                column: "FK_Nota_RA");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroAcademico_FK_RA_Aluno",
                table: "RegistroAcademico",
                column: "FK_RA_Aluno");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroAcademico_FK_RA_Curso",
                table: "RegistroAcademico",
                column: "FK_RA_Curso");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroDisciplina_FK_RD_Disciplina",
                table: "RegistroDisciplina",
                column: "FK_RD_Disciplina");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroDisciplina_FK_RD_RA",
                table: "RegistroDisciplina",
                column: "FK_RD_RA");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nota");

            migrationBuilder.DropTable(
                name: "RegistroDisciplina");

            migrationBuilder.DropTable(
                name: "Disciplina");

            migrationBuilder.DropTable(
                name: "RegistroAcademico");

            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "Cidade");
        }
    }
}
