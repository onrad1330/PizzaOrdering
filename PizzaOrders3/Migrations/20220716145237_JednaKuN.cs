using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaOrders3.Migrations
{
    public partial class JednaKuN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PizzaOrders_ReservationTimes_ReservationTimeId",
                table: "PizzaOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_PizzaOrders_OrderId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_ReservationTimes_ReservationTimeId",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "ReservationTimes");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_OrderId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ReservationTimeId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_PizzaOrders_ReservationTimeId",
                table: "PizzaOrders");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReservationTimeId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReservationTimeId",
                table: "PizzaOrders");

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "Reservations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "PizzaOrders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PizzaOrders_ReservationId",
                table: "PizzaOrders",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaOrders_Reservations_ReservationId",
                table: "PizzaOrders",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PizzaOrders_Reservations_ReservationId",
                table: "PizzaOrders");

            migrationBuilder.DropIndex(
                name: "IX_PizzaOrders_ReservationId",
                table: "PizzaOrders");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "PizzaOrders");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReservationTimeId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReservationTimeId",
                table: "PizzaOrders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ReservationTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationTimes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_OrderId",
                table: "Reservations",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReservationTimeId",
                table: "Reservations",
                column: "ReservationTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaOrders_ReservationTimeId",
                table: "PizzaOrders",
                column: "ReservationTimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaOrders_ReservationTimes_ReservationTimeId",
                table: "PizzaOrders",
                column: "ReservationTimeId",
                principalTable: "ReservationTimes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_PizzaOrders_OrderId",
                table: "Reservations",
                column: "OrderId",
                principalTable: "PizzaOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_ReservationTimes_ReservationTimeId",
                table: "Reservations",
                column: "ReservationTimeId",
                principalTable: "ReservationTimes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
