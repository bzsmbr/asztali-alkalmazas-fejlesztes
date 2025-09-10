using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solution.Database.Migrations
{
    /// <inheritdoc />
    public partial class MotorcycleTypeEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "MotorcycleTypeEntityId",
                table: "Motorcycle",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Motorcycle_MotorcycleTypeEntityId",
                table: "Motorcycle",
                column: "MotorcycleTypeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Type_Name",
                table: "Type",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Motorcycle_Type_MotorcycleTypeEntityId",
                table: "Motorcycle",
                column: "MotorcycleTypeEntityId",
                principalTable: "Type",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycle_Type_MotorcycleTypeEntityId",
                table: "Motorcycle");

            migrationBuilder.DropTable(
                name: "Type");

            migrationBuilder.DropIndex(
                name: "IX_Motorcycle_MotorcycleTypeEntityId",
                table: "Motorcycle");

            migrationBuilder.DropColumn(
                name: "MotorcycleTypeEntityId",
                table: "Motorcycle");
        }
    }
}
