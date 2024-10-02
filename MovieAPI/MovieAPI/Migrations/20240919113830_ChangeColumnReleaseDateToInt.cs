using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnReleaseDateToInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE \"Movies\" ALTER COLUMN \"ReleaseDate\" TYPE integer USING EXTRACT(YEAR FROM \"ReleaseDate\")::integer;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE \"Movies\" ALTER COLUMN \"ReleaseDate\" TYPE date;");
        }
    }
}
