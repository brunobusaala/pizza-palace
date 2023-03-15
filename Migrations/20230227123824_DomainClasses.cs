using Microsoft.EntityFrameworkCore.Migrations;

namespace NewPizzaPalace.Migrations
{
    public partial class DomainClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    SizeID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.SizeID);
                });

            migrationBuilder.CreateTable(
                name: "BasicToppings",
                columns: table => new
                {
                    BasicTopppingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Cheese = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Pepperoni = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ham = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Pineapple = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicToppings", x => x.BasicTopppingID);
                    table.ForeignKey(
                        name: "FK_BasicToppings_Size_SizeID",
                        column: x => x.SizeID,
                        principalTable: "Size",
                        principalColumn: "SizeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeluxeToppings",
                columns: table => new
                {
                    DeluxeToppingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Sausage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FetaCheese = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tomatoes = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Olives = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeluxeToppings", x => x.DeluxeToppingID);
                    table.ForeignKey(
                        name: "FK_DeluxeToppings_Size_SizeID",
                        column: x => x.SizeID,
                        principalTable: "Size",
                        principalColumn: "SizeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Size",
                columns: new[] { "SizeID", "Price" },
                values: new object[] { "Small", 12m });

            migrationBuilder.InsertData(
                table: "Size",
                columns: new[] { "SizeID", "Price" },
                values: new object[] { "Medium", 14m });

            migrationBuilder.InsertData(
                table: "Size",
                columns: new[] { "SizeID", "Price" },
                values: new object[] { "Large", 16m });

            migrationBuilder.InsertData(
                table: "BasicToppings",
                columns: new[] { "BasicTopppingID", "Cheese", "Ham", "Pepperoni", "Pineapple", "SizeID" },
                values: new object[,]
                {
                    { 1, 0.5m, 0.5m, 0.5m, 0.5m, "Small" },
                    { 2, 0.75m, 0.75m, 0.75m, 0.75m, "Medium" },
                    { 3, 1m, 1m, 1m, 1m, "Large" }
                });

            migrationBuilder.InsertData(
                table: "DeluxeToppings",
                columns: new[] { "DeluxeToppingID", "FetaCheese", "Olives", "Sausage", "SizeID", "Tomatoes" },
                values: new object[,]
                {
                    { 1, 2m, 2m, 2m, "Small", 2m },
                    { 2, 3m, 3m, 3m, "Medium", 3m },
                    { 3, 4m, 4m, 4m, "Large", 4m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasicToppings_SizeID",
                table: "BasicToppings",
                column: "SizeID");

            migrationBuilder.CreateIndex(
                name: "IX_DeluxeToppings_SizeID",
                table: "DeluxeToppings",
                column: "SizeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasicToppings");

            migrationBuilder.DropTable(
                name: "DeluxeToppings");

            migrationBuilder.DropTable(
                name: "Size");
        }
    }
}
