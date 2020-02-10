using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASPNetCoreReactRedux_Persons.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriaContatos",
                columns: table => new
                {
                    CategoriaContatoId = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaContatos", x => x.CategoriaContatoId);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    UF = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.UF);
                });

            migrationBuilder.CreateTable(
                name: "Idiomas",
                columns: table => new
                {
                    IdiomaId = table.Column<int>(nullable: false),
                    LinguaIdioma = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idiomas", x => x.IdiomaId);
                });

            migrationBuilder.CreateTable(
                name: "TipoContatos",
                columns: table => new
                {
                    TipoContatoId = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoContatos", x => x.TipoContatoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoDocumento",
                columns: table => new
                {
                    TipoDocumentoId = table.Column<int>(nullable: false),
                    Documento = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDocumento", x => x.TipoDocumentoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoEnderecos",
                columns: table => new
                {
                    TipoEnderecoId = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEnderecos", x => x.TipoEnderecoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoRelacionamentos",
                columns: table => new
                {
                    TipoRelacionamentoId = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoRelacionamentos", x => x.TipoRelacionamentoId);
                });

            migrationBuilder.CreateTable(
                name: "Cidades",
                columns: table => new
                {
                    CidadeId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 155, nullable: false),
                    EstadoId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidades", x => x.CidadeId);
                    table.ForeignKey(
                        name: "FK_Cidades_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "UF",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contatos",
                columns: table => new
                {
                    ContatoId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(nullable: true),
                    CategoriaContatoId = table.Column<int>(nullable: false),
                    TipoContatoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatos", x => x.ContatoId);
                    table.ForeignKey(
                        name: "FK_Contatos_CategoriaContatos_CategoriaContatoId",
                        column: x => x.CategoriaContatoId,
                        principalTable: "CategoriaContatos",
                        principalColumn: "CategoriaContatoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contatos_TipoContatos_TipoContatoId",
                        column: x => x.TipoContatoId,
                        principalTable: "TipoContatos",
                        principalColumn: "TipoContatoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    EnderecoId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CEP = table.Column<string>(nullable: true),
                    TipoEnderecoId = table.Column<int>(nullable: false),
                    Logradouro = table.Column<string>(nullable: false),
                    Numero = table.Column<string>(maxLength: 5, nullable: true),
                    Bairro = table.Column<string>(nullable: true),
                    Complemento = table.Column<string>(nullable: true),
                    CidadeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.EnderecoId);
                    table.ForeignKey(
                        name: "FK_Enderecos_Cidades_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidades",
                        principalColumn: "CidadeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enderecos_TipoEnderecos_TipoEnderecoId",
                        column: x => x.TipoEnderecoId,
                        principalTable: "TipoEnderecos",
                        principalColumn: "TipoEnderecoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    PessoaId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataInclusao = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "GetDate()"),
                    DataEdicao = table.Column<DateTime>(nullable: false),
                    Ativado = table.Column<bool>(nullable: false, defaultValue: true),
                    Nome = table.Column<string>(nullable: false),
                    SobreNome = table.Column<string>(nullable: false),
                    Pseudonimo = table.Column<string>(nullable: true),
                    Sexo = table.Column<bool>(nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    DataObito = table.Column<DateTime>(nullable: false),
                    EnderecoId = table.Column<long>(nullable: false),
                    CelularId = table.Column<long>(nullable: false),
                    EmailId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.PessoaId);
                    table.ForeignKey(
                        name: "FK_Pessoas_Contatos_CelularId",
                        column: x => x.CelularId,
                        principalTable: "Contatos",
                        principalColumn: "ContatoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pessoas_Contatos_EmailId",
                        column: x => x.EmailId,
                        principalTable: "Contatos",
                        principalColumn: "ContatoId");
                    table.ForeignKey(
                        name: "FK_Pessoas_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "EnderecoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documentos",
                columns: table => new
                {
                    DocumentoId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PessoaId = table.Column<long>(nullable: false),
                    TipoDocumentoId = table.Column<int>(nullable: false),
                    NumeroDocumento = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentos", x => x.DocumentoId);
                    table.ForeignKey(
                        name: "FK_Documentos_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documentos_TipoDocumento_TipoDocumentoId",
                        column: x => x.TipoDocumentoId,
                        principalTable: "TipoDocumento",
                        principalColumn: "TipoDocumentoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PessoaIdioma",
                columns: table => new
                {
                    PessoaId = table.Column<long>(nullable: false),
                    IdiomaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaIdioma", x => new { x.PessoaId, x.IdiomaId });
                    table.ForeignKey(
                        name: "FK_PessoaIdioma_Idiomas_IdiomaId",
                        column: x => x.IdiomaId,
                        principalTable: "Idiomas",
                        principalColumn: "IdiomaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PessoaIdioma_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Relacionamentos",
                columns: table => new
                {
                    PessoaPropriaId = table.Column<long>(nullable: false),
                    PessoaRelacionadaId = table.Column<long>(nullable: false),
                    TipoRelacionamentoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relacionamentos", x => new { x.PessoaPropriaId, x.PessoaRelacionadaId });
                    table.ForeignKey(
                        name: "FK_Relacionamentos_Pessoas_PessoaPropriaId",
                        column: x => x.PessoaPropriaId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId");
                    table.ForeignKey(
                        name: "FK_Relacionamentos_Pessoas_PessoaRelacionadaId",
                        column: x => x.PessoaRelacionadaId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Relacionamentos_TipoRelacionamentos_TipoRelacionamentoId",
                        column: x => x.TipoRelacionamentoId,
                        principalTable: "TipoRelacionamentos",
                        principalColumn: "TipoRelacionamentoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CategoriaContatos",
                columns: new[] { "CategoriaContatoId", "Descricao" },
                values: new object[,]
                {
                    { 0, "Nenhum" },
                    { 1, "Desconhecido" },
                    { 3, "Residencia" },
                    { 2, "Comercio" }
                });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "UF", "Nome" },
                values: new object[,]
                {
                    { "PR", "Paraná" },
                    { "PE", "Pernambuco" },
                    { "PI", "Piauí" },
                    { "RJ", "Rio de Janeiro" },
                    { "RN", "Rio Grande do Norte" },
                    { "RO", "Rondônia" },
                    { "PB", "Paraíba" },
                    { "RR", "Roraima" },
                    { "SC", "Santa Catarina" },
                    { "SP", "São Paulo" },
                    { "SE", "Sergipe" },
                    { "RS", "Rio Grande do Sul" },
                    { "PA", "Pará" },
                    { "TO", "Tocantins" },
                    { "MS", "Mato Grosso do Sul" },
                    { "MG", "Minas Gerais" },
                    { "AL", "Alagoas" },
                    { "AP", "Amapá" },
                    { "AM", "Amazonas" },
                    { "BA", "Bahia" },
                    { "AC", "Acre" },
                    { "DF", "Distrito Federal" },
                    { "ES", "Espírito Santo" },
                    { "GO", "Goiás" },
                    { "MA", "Maranhão" },
                    { "MT", "Mato Grosso" },
                    { "CE", "Ceará" }
                });

            migrationBuilder.InsertData(
                table: "Idiomas",
                columns: new[] { "IdiomaId", "LinguaIdioma" },
                values: new object[,]
                {
                    { 7, "Japones" },
                    { 6, "Russo" },
                    { 5, "Chines" },
                    { 4, "Frances" },
                    { 2, "Portugues" },
                    { 1, "Desconhecido" },
                    { 0, "Nenhum" },
                    { 3, "Ingles" }
                });

            migrationBuilder.InsertData(
                table: "TipoContatos",
                columns: new[] { "TipoContatoId", "Descricao" },
                values: new object[,]
                {
                    { 5, "Telefone" },
                    { 4, "Rede Social" },
                    { 3, "E-Mail" },
                    { 0, "Nenhum" },
                    { 1, "Desconhecido" },
                    { 2, "Celular" }
                });

            migrationBuilder.InsertData(
                table: "TipoDocumento",
                columns: new[] { "TipoDocumentoId", "Documento" },
                values: new object[,]
                {
                    { 0, "Nenhum" },
                    { 1, "Desconhecido" },
                    { 2, "CPF" },
                    { 3, "RG" },
                    { 4, "RNE" }
                });

            migrationBuilder.InsertData(
                table: "TipoEnderecos",
                columns: new[] { "TipoEnderecoId", "Descricao" },
                values: new object[,]
                {
                    { 5, "Rural" },
                    { 4, "Industria" },
                    { 3, "Apartamento" },
                    { 2, "Casa" },
                    { 0, "Nenhum" },
                    { 1, "Desconhecido" }
                });

            migrationBuilder.InsertData(
                table: "TipoRelacionamentos",
                columns: new[] { "TipoRelacionamentoId", "Descricao" },
                values: new object[,]
                {
                    { 4, "Amizade" },
                    { 0, "Nenhum" },
                    { 1, "Desconhecido" },
                    { 2, "Familiar" },
                    { 3, "Amoroso" },
                    { 5, "Profissional" }
                });

            migrationBuilder.InsertData(
                table: "Cidades",
                columns: new[] { "CidadeId", "EstadoId", "Nome" },
                values: new object[,]
                {
                    { 10L, "PR", "Curitiba" },
                    { 9L, "RJ", "Rio de Janeiro" },
                    { 11L, "SC", "Florianópolis" },
                    { 12L, "SC", "Itajaí" },
                    { 13L, "SC", "Brusque" },
                    { 1L, "SP", "São José do Rio Preto" },
                    { 2L, "SP", "Mirassol" },
                    { 3L, "SP", "Bady Bassit" },
                    { 4L, "SP", "Cosmorama" },
                    { 5L, "SP", "Cedral" },
                    { 6L, "SP", "Ipigua" },
                    { 7L, "SP", "Barretos" },
                    { 8L, "SP", "Uchoa" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cidades_EstadoId",
                table: "Cidades",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_CategoriaContatoId",
                table: "Contatos",
                column: "CategoriaContatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_TipoContatoId",
                table: "Contatos",
                column: "TipoContatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_PessoaId",
                table: "Documentos",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_TipoDocumentoId",
                table: "Documentos",
                column: "TipoDocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_CidadeId",
                table: "Enderecos",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_TipoEnderecoId",
                table: "Enderecos",
                column: "TipoEnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaIdioma_IdiomaId",
                table: "PessoaIdioma",
                column: "IdiomaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_CelularId",
                table: "Pessoas",
                column: "CelularId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_EmailId",
                table: "Pessoas",
                column: "EmailId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_EnderecoId",
                table: "Pessoas",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Relacionamentos_PessoaRelacionadaId",
                table: "Relacionamentos",
                column: "PessoaRelacionadaId");

            migrationBuilder.CreateIndex(
                name: "IX_Relacionamentos_TipoRelacionamentoId",
                table: "Relacionamentos",
                column: "TipoRelacionamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documentos");

            migrationBuilder.DropTable(
                name: "PessoaIdioma");

            migrationBuilder.DropTable(
                name: "Relacionamentos");

            migrationBuilder.DropTable(
                name: "TipoDocumento");

            migrationBuilder.DropTable(
                name: "Idiomas");

            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "TipoRelacionamentos");

            migrationBuilder.DropTable(
                name: "Contatos");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "CategoriaContatos");

            migrationBuilder.DropTable(
                name: "TipoContatos");

            migrationBuilder.DropTable(
                name: "Cidades");

            migrationBuilder.DropTable(
                name: "TipoEnderecos");

            migrationBuilder.DropTable(
                name: "Estados");
        }
    }
}
