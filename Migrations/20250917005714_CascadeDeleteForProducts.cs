using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAnThietKeWeb1.Migrations
{
    /// <inheritdoc />
    public partial class CascadeDeleteForProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__CartItems__Produ__4E88ABD4",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK__Favorites__Produ__52593CB8",
                table: "Favorites");

            migrationBuilder.DropForeignKey(
                name: "FK__InvoiceDe__Produ__59FA5E80",
                table: "InvoiceDetails");

            migrationBuilder.AddForeignKey(
                name: "FK__CartItems__Produ__4E88ABD4",
                table: "CartItems",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Favorites__Produ__52593CB8",
                table: "Favorites",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__InvoiceDe__Produ__59FA5E80",
                table: "InvoiceDetails",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__CartItems__Produ__4E88ABD4",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK__Favorites__Produ__52593CB8",
                table: "Favorites");

            migrationBuilder.DropForeignKey(
                name: "FK__InvoiceDe__Produ__59FA5E80",
                table: "InvoiceDetails");

            migrationBuilder.AddForeignKey(
                name: "FK__CartItems__Produ__4E88ABD4",
                table: "CartItems",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK__Favorites__Produ__52593CB8",
                table: "Favorites",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK__InvoiceDe__Produ__59FA5E80",
                table: "InvoiceDetails",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID");
        }
    }
}
