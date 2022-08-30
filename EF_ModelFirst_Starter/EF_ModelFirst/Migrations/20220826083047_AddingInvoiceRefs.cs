using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_ModelFirst.Migrations
{
    public partial class AddingInvoiceRefs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InvoiceRef",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceRef",
                table: "Orders");
        }
    }
}
