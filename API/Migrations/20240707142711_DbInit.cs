using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class DbInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "discount_code",
                columns: table => new
                {
                    discount_code = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    discount_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    discount_type = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    discount_value = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    discount_start_date = table.Column<DateTime>(type: "date", nullable: false),
                    discount_end_date = table.Column<DateTime>(type: "date", nullable: false),
                    discount_description = table.Column<string>(type: "text", nullable: true),
                    discount_status = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__discount__75C1F0071845DA2F", x => x.discount_code);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    product_code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    product_category = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    product_brand = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    product_price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    product_quantity = table.Column<int>(type: "int", nullable: false),
                    product_description = table.Column<string>(type: "text", nullable: true),
                    product_image = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    product_status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__product__47027DF58543E257", x => x.product_id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__roles__760965CC8F4EF5B5", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "order_item",
                columns: table => new
                {
                    order_item_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<int>(type: "int", nullable: true),
                    product_id = table.Column<int>(type: "int", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    price = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__order_it__3764B6BCD7A53B3B", x => x.order_item_id);
                    table.ForeignKey(
                        name: "FK_order_item_product_product_id",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "product_id");
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    users_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    users_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    users_email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    users_phone = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    users_address = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false),
                    passwords = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__users__EAA7D14B28B88DFA", x => x.users_id);
                    table.ForeignKey(
                        name: "FK_users_roles",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "role_id");
                });

            migrationBuilder.CreateTable(
                name: "notice",
                columns: table => new
                {
                    notice_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    notice_title = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    notice_content = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    notice_status = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__notice__3E82A5DBE9B64072", x => x.notice_id);
                    table.ForeignKey(
                        name: "FK_notice_users",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "users_id");
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_date = table.Column<DateTime>(type: "date", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    PaymentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    order_total_amount = table.Column<double>(type: "float", nullable: true),
                    order_status = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__orders__465962292AC60F6D", x => x.order_id);
                    table.ForeignKey(
                        name: "FK_orders_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "users_id");
                });

            migrationBuilder.CreateTable(
                name: "payment",
                columns: table => new
                {
                    payment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    order_payment_method = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    order_status = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    order_details = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__payment__ED1FC9EA4B2B8A33", x => x.payment_id);
                    table.ForeignKey(
                        name: "FK_payment_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_notice_user_id",
                table: "notice",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_item_product_id",
                table: "order_item",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_user_id",
                table: "orders",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_payment_order_id",
                table: "payment",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_role_id",
                table: "users",
                column: "role_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "discount_code");

            migrationBuilder.DropTable(
                name: "notice");

            migrationBuilder.DropTable(
                name: "order_item");

            migrationBuilder.DropTable(
                name: "payment");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
