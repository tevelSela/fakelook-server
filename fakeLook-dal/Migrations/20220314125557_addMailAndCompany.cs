using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fakeLook_dal.Migrations
{
    public partial class addMailAndCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mail",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "X_Position", "Y_Position", "Z_Position" },
                values: new object[] { new DateTime(2022, 3, 14, 14, 55, 56, 469, DateTimeKind.Local).AddTicks(5047), 32.644233729467423, 5.3162335949423047, 10.624636540069353 });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "X_Position", "Y_Position", "Z_Position" },
                values: new object[] { new DateTime(2022, 3, 14, 14, 55, 56, 469, DateTimeKind.Local).AddTicks(5136), 0.17957033848775006, 32.569116210555229, 44.730326814653573 });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "X_Position", "Y_Position", "Z_Position" },
                values: new object[] { new DateTime(2022, 3, 14, 14, 55, 56, 469, DateTimeKind.Local).AddTicks(5139), 36.058034325228483, 12.058343408261507, 44.622640184887587 });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "X_Position", "Y_Position", "Z_Position" },
                values: new object[] { new DateTime(2022, 3, 14, 14, 55, 56, 469, DateTimeKind.Local).AddTicks(5141), 20.173237136928691, 49.041362859501433, 39.811207577351126 });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date", "X_Position", "Y_Position", "Z_Position" },
                values: new object[] { new DateTime(2022, 3, 14, 14, 55, 56, 469, DateTimeKind.Local).AddTicks(5143), 7.0983211789580452, 2.8800038456326615, 11.12346965834079 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CommentId", "UserId" },
                values: new object[] { 14, 5 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CommentId", "UserId" },
                values: new object[] { 7, 2 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CommentId", "UserId" },
                values: new object[] { 19, 5 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CommentId", "UserId" },
                values: new object[] { 13, 5 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CommentId", "UserId" },
                values: new object[] { 11, 2 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CommentId", "UserId" },
                values: new object[] { 16, 1 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CommentId", "UserId" },
                values: new object[] { 10, 5 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CommentId", "UserId" },
                values: new object[] { 19, 2 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CommentId", "UserId" },
                values: new object[] { 16, 1 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 10,
                column: "UserId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "1996759217");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "1996759217");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "1996759217");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "1996759217");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "1996759217");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Mail",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "X_Position", "Y_Position", "Z_Position" },
                values: new object[] { new DateTime(2022, 3, 14, 14, 1, 16, 11, DateTimeKind.Local).AddTicks(3459), 18.003910756098968, 4.4228738989582075, 30.949306599937611 });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "X_Position", "Y_Position", "Z_Position" },
                values: new object[] { new DateTime(2022, 3, 14, 14, 1, 16, 11, DateTimeKind.Local).AddTicks(3505), 22.289437839255328, 10.87598733172298, 16.321879034270932 });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "X_Position", "Y_Position", "Z_Position" },
                values: new object[] { new DateTime(2022, 3, 14, 14, 1, 16, 11, DateTimeKind.Local).AddTicks(3509), 36.357759924752287, 44.916284561186529, 12.685625565722081 });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "X_Position", "Y_Position", "Z_Position" },
                values: new object[] { new DateTime(2022, 3, 14, 14, 1, 16, 11, DateTimeKind.Local).AddTicks(3512), 12.768781569990068, 47.959235266465718, 3.7551404868709612 });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date", "X_Position", "Y_Position", "Z_Position" },
                values: new object[] { new DateTime(2022, 3, 14, 14, 1, 16, 11, DateTimeKind.Local).AddTicks(3514), 46.909277001190972, 46.261151397124209, 34.230334101136492 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CommentId", "UserId" },
                values: new object[] { 2, 4 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CommentId", "UserId" },
                values: new object[] { 18, 1 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CommentId", "UserId" },
                values: new object[] { 10, 3 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CommentId", "UserId" },
                values: new object[] { 20, 4 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CommentId", "UserId" },
                values: new object[] { 5, 5 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CommentId", "UserId" },
                values: new object[] { 24, 4 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CommentId", "UserId" },
                values: new object[] { 8, 3 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CommentId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CommentId", "UserId" },
                values: new object[] { 4, 5 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 10,
                column: "UserId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "1730088443");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "1730088443");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "1730088443");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "1730088443");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "1730088443");
        }
    }
}
