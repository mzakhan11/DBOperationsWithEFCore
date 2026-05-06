using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBOperationsWithEFCoreApp.Migrations
{
    /// <inheritdoc />
    public partial class TablesChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Currencies");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CurrencyTypeId",
                table: "BookPrices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BookPrices_BookId",
                table: "BookPrices",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookPrices_CurrencyTypeId",
                table: "BookPrices",
                column: "CurrencyTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookPrices_Books_BookId",
                table: "BookPrices",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookPrices_Currencies_CurrencyTypeId",
                table: "BookPrices",
                column: "CurrencyTypeId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookPrices_Books_BookId",
                table: "BookPrices");

            migrationBuilder.DropForeignKey(
                name: "FK_BookPrices_Currencies_CurrencyTypeId",
                table: "BookPrices");

            migrationBuilder.DropIndex(
                name: "IX_BookPrices_BookId",
                table: "BookPrices");

            migrationBuilder.DropIndex(
                name: "IX_BookPrices_CurrencyTypeId",
                table: "BookPrices");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "CurrencyTypeId",
                table: "BookPrices");

            migrationBuilder.AddColumn<int>(
                name: "Currency",
                table: "Currencies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
