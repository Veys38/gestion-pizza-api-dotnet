using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GestionPizza.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_ingredient",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "numeric", maxLength: 5, nullable: false),
                    TimeInSeconds = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ingredient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "_pizzeria",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__pizzeria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "_customer",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    PizzeriaId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK__customer__pizzeria_PizzeriaId",
                        column: x => x.PizzeriaId,
                        principalTable: "_pizzeria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_pizza",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PizzaName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    BasePreparationTime = table.Column<int>(type: "integer", nullable: false),
                    PizzeriaId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__pizza", x => x.Id);
                    table.ForeignKey(
                        name: "FK__pizza__pizzeria_PizzeriaId",
                        column: x => x.PizzeriaId,
                        principalTable: "_pizzeria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_order",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__order", x => x.Id);
                    table.ForeignKey(
                        name: "FK__order__customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "_customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngredientPizza",
                columns: table => new
                {
                    IngredientsId = table.Column<long>(type: "bigint", nullable: false),
                    PizzasId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientPizza", x => new { x.IngredientsId, x.PizzasId });
                    table.ForeignKey(
                        name: "FK_IngredientPizza__ingredient_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "_ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientPizza__pizza_PizzasId",
                        column: x => x.PizzasId,
                        principalTable: "_pizza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_order_pizza",
                columns: table => new
                {
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    PizzaId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<int>(type: "integer", maxLength: 2, nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__order_pizza", x => new { x.OrderId, x.PizzaId });
                    table.ForeignKey(
                        name: "FK__order_pizza__order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "_order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__order_pizza__pizza_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "_pizza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX__customer_FullName",
                table: "_customer",
                column: "FullName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX__customer_PhoneNumber",
                table: "_customer",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX__customer_PizzeriaId",
                table: "_customer",
                column: "PizzeriaId");

            migrationBuilder.CreateIndex(
                name: "IX__order_CustomerId",
                table: "_order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX__order_pizza_PizzaId",
                table: "_order_pizza",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX__pizza_PizzeriaId",
                table: "_pizza",
                column: "PizzeriaId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientPizza_PizzasId",
                table: "IngredientPizza",
                column: "PizzasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_order_pizza");

            migrationBuilder.DropTable(
                name: "IngredientPizza");

            migrationBuilder.DropTable(
                name: "_order");

            migrationBuilder.DropTable(
                name: "_ingredient");

            migrationBuilder.DropTable(
                name: "_pizza");

            migrationBuilder.DropTable(
                name: "_customer");

            migrationBuilder.DropTable(
                name: "_pizzeria");
        }
    }
}
