using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solution.Database.Migrations
{
    /// <inheritdoc />
    public partial class types : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var query = @$"
                INSERT INTO 
                    [Type] 
                    ([Name])
                VALUES
                    ('Flip Phone (Clamshell)'),
                    ('Smart phone'),
                    ('Feature Phones'),
                    ('Brick Phones'),
                    ('Slider Phones'),
                    ('Touchscreen Phones (Non-smart)'),
                    ('Satellite Phones'),
                    ('Rugged Phones'),
                    ('Foldable Phones');
            ";

            migrationBuilder.Sql(query);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var query = $"truncate table [Type]";

            migrationBuilder.Sql(query);

        }
    }
}