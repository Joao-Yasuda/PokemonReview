using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pokemon_Review_App.Migrations
{
    /// <inheritdoc />
    public partial class FixPokemonCategoryFKs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokemonCategories_Categories_PokemonId",
                table: "PokemonCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonCategories_Pokemon_CategoryId",
                table: "PokemonCategories");

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonCategories_Categories_CategoryId",
                table: "PokemonCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonCategories_Pokemon_PokemonId",
                table: "PokemonCategories",
                column: "PokemonId",
                principalTable: "Pokemon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokemonCategories_Categories_CategoryId",
                table: "PokemonCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonCategories_Pokemon_PokemonId",
                table: "PokemonCategories");

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonCategories_Categories_PokemonId",
                table: "PokemonCategories",
                column: "PokemonId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonCategories_Pokemon_CategoryId",
                table: "PokemonCategories",
                column: "CategoryId",
                principalTable: "Pokemon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
