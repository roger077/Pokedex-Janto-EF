using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class initDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PokemonType",
                table: "PokemonType");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PokemonType",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PokemonType",
                table: "PokemonType",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonType_PokemonId",
                table: "PokemonType",
                column: "PokemonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PokemonType",
                table: "PokemonType");

            migrationBuilder.DropIndex(
                name: "IX_PokemonType_PokemonId",
                table: "PokemonType");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PokemonType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PokemonType",
                table: "PokemonType",
                columns: new[] { "PokemonId", "TypeId" });
        }
    }
}
