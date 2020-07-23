using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeMade.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IngredientName = table.Column<string>(nullable: true),
                    IngredientQuantity = table.Column<int>(nullable: false),
                    IngredientUnit = table.Column<string>(nullable: true),
                    IngredientEdibleYieldPercentage = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RecipeName = table.Column<string>(nullable: true),
                    RecipeClassification = table.Column<string>(nullable: true),
                    RecipeCost = table.Column<float>(nullable: true),
                    PortionCost = table.Column<float>(nullable: true),
                    RecipeStandardYield = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredient",
                columns: table => new
                {
                    RecipeId = table.Column<int>(nullable: false),
                    IngredientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredient", x => new { x.RecipeId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_RecipeIngredient_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredient_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "IngredientEdibleYieldPercentage", "IngredientName", "IngredientQuantity", "IngredientUnit" },
                values: new object[] { 1, 100f, "Bread", 2, "slices" });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "IngredientEdibleYieldPercentage", "IngredientName", "IngredientQuantity", "IngredientUnit" },
                values: new object[] { 2, 100f, "Peanut Butter", 2, "ounces" });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "IngredientEdibleYieldPercentage", "IngredientName", "IngredientQuantity", "IngredientUnit" },
                values: new object[] { 3, 66.67f, "Banana", 2, "ounces" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Nick" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "PortionCost", "RecipeClassification", "RecipeCost", "RecipeName", "RecipeStandardYield", "UserId" },
                values: new object[] { 1, null, "Lunch", null, "Peanut Butter Banana Sandwiches", null, 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredient",
                columns: new[] { "RecipeId", "IngredientId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredient",
                columns: new[] { "RecipeId", "IngredientId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredient",
                columns: new[] { "RecipeId", "IngredientId" },
                values: new object[] { 1, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredient_IngredientId",
                table: "RecipeIngredient",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_UserId",
                table: "Recipes",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeIngredient");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
