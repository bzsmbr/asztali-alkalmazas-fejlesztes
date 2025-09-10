using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solution.Database.Migrations
{
    /// <inheritdoc />
    public partial class MotorcycleTypeEntity_fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycle_Type_MotorcycleTypeEntityId",
                table: "Motorcycle");

            migrationBuilder.DropIndex(
                name: "IX_Motorcycle_MotorcycleTypeEntityId",
                table: "Motorcycle");

            migrationBuilder.DropColumn(
                name: "MotorcycleTypeEntityId",
                table: "Motorcycle");

            migrationBuilder.AddColumn<long>(
                name: "TypeId",
                table: "Motorcycle",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Motorcycle_TypeId",
                table: "Motorcycle",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Motorcycle_Type_TypeId",
                table: "Motorcycle",
                column: "TypeId",
                principalTable: "Type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycle_Type_TypeId",
                table: "Motorcycle");

            migrationBuilder.DropIndex(
                name: "IX_Motorcycle_TypeId",
                table: "Motorcycle");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Motorcycle");

            migrationBuilder.AddColumn<long>(
                name: "MotorcycleTypeEntityId",
                table: "Motorcycle",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Motorcycle_MotorcycleTypeEntityId",
                table: "Motorcycle",
                column: "MotorcycleTypeEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Motorcycle_Type_MotorcycleTypeEntityId",
                table: "Motorcycle",
                column: "MotorcycleTypeEntityId",
                principalTable: "Type",
                principalColumn: "Id");
        }
    }
}
