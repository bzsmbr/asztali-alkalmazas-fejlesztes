using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solution.Database.Migrations
{
    /// <inheritdoc />
    public partial class MotorcycleTypeEntity_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var query = @$"
                insert into
                    [Type]
                    ([Name])
                values
                    ('Chopper'),
                    ('Crusier'),
                    ('Classic'),
                    ('Veteran'),
                    ('Cross'),
                    ('Pitpike'),
                    ('Enduro'),
                    ('Kidkmotor'),
                    ('Sport'),
                    ('Quad'),
                    ('ATV'),
                    ('RUV'),
                    ('SSV'),
                    ('UTV'),
                    ('Scooter'),
                    ('Moped'),
                    ('Supermoto'),
                    ('Trial'),
                    ('Trike'),
                    ('Tour'),
                    ('Naked')
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
