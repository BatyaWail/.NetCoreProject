using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeSrever.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaleOrFmale = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeRoles",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    IsManagementRole = table.Column<bool>(type: "bit", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRoles", x => new { x.EmployeeId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_EmployeeRoles_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name", "Password" },
                values: new object[,]
                {
                    { 1, "company1", "123456" },
                    { 2, "company2", "123456" },
                    { 3, "company3", "123456" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { 1, "Developer" },
                    { 2, "Designer" },
                    { 3, "Manager" },
                    { 4, "Accountant" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CompanyId", "DateOfBirth", "FirstName", "Identity", "LastName", "MaleOrFmale", "StartDate", "Status" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(1967, 4, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4430), "Solomon", "000000001", "Stein", true, new DateTime(2023, 10, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4381), true },
                    { 2, 1, new DateTime(1999, 4, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4441), "Jacob", "000000002", "Stern", true, new DateTime(2023, 9, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4439), true },
                    { 3, 1, new DateTime(1987, 4, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4446), "Elijah", "000000003", "Levi", true, new DateTime(2023, 6, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4444), true },
                    { 4, 3, new DateTime(1970, 4, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4451), "Jacob", "000000004", "Shapiro", true, new DateTime(2023, 9, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4449), true },
                    { 5, 3, new DateTime(2006, 4, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4455), "Aaron", "000000005", "Goldberg", true, new DateTime(2023, 11, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4453), true },
                    { 6, 1, new DateTime(1988, 4, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4460), "Samuel", "000000006", "Stein", true, new DateTime(2023, 9, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4458), true },
                    { 7, 3, new DateTime(1976, 4, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4465), "Isaac", "000000007", "Friedman", true, new DateTime(2023, 11, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4463), true },
                    { 8, 2, new DateTime(1986, 4, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4469), "Aaron", "000000008", "Adler", true, new DateTime(2023, 9, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4467), true },
                    { 9, 3, new DateTime(1997, 4, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4474), "Jacob", "000000009", "Klein", true, new DateTime(2024, 3, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4472), true },
                    { 10, 3, new DateTime(1992, 4, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4481), "David", "000000010", "Zimmerman", true, new DateTime(2024, 1, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4479), true },
                    { 11, 1, new DateTime(1993, 4, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4486), "Samuel", "000000011", "Segal", true, new DateTime(2023, 12, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4484), true },
                    { 12, 1, new DateTime(2000, 4, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4491), "Daniel", "000000012", "Segal", true, new DateTime(2024, 2, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4489), true },
                    { 13, 1, new DateTime(1971, 4, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4496), "Abraham", "000000013", "Stern", true, new DateTime(2023, 11, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4494), true },
                    { 14, 2, new DateTime(1988, 4, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4501), "Samuel", "000000014", "Adler", true, new DateTime(2023, 9, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4499), true },
                    { 15, 1, new DateTime(2003, 4, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4506), "Isaac", "000000015", "Zimmerman", true, new DateTime(2023, 11, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4504), true },
                    { 16, 3, new DateTime(1968, 4, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4513), "Miriam", "000000016", "Weiss", false, new DateTime(2023, 5, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4511), true },
                    { 17, 2, new DateTime(2005, 4, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4519), "Rebecca", "000000017", "Schwartz", false, new DateTime(2023, 9, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4518), true },
                    { 18, 3, new DateTime(1973, 4, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4525), "Leah", "000000018", "Blum", false, new DateTime(2023, 10, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4523), true },
                    { 19, 1, new DateTime(2003, 4, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4530), "Ruth", "000000019", "Weiss", false, new DateTime(2023, 8, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4528), true },
                    { 20, 2, new DateTime(1979, 4, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4534), "Sarah", "000000020", "Segal", false, new DateTime(2024, 2, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4533), true },
                    { 21, 1, new DateTime(1971, 4, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4539), "Ruth", "000000021", "Levi", false, new DateTime(2023, 8, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4537), true },
                    { 22, 1, new DateTime(1989, 4, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4544), "Rebecca", "000000022", "Goldberg", false, new DateTime(2023, 7, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4542), true },
                    { 23, 2, new DateTime(1985, 4, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4549), "Shoshana", "000000023", "Stern", false, new DateTime(2023, 6, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4547), true },
                    { 24, 2, new DateTime(1972, 4, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4554), "Esther", "000000024", "Stern", false, new DateTime(2023, 10, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4552), true },
                    { 25, 1, new DateTime(1971, 4, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4558), "Sarah", "000000025", "Stein", false, new DateTime(2024, 1, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4556), true },
                    { 26, 2, new DateTime(1966, 4, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4563), "Esther", "000000026", "Rosenb0erg", false, new DateTime(2023, 8, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4561), true },
                    { 27, 3, new DateTime(1983, 4, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4567), "Shoshana", "000000027", "Gordon", false, new DateTime(2023, 8, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4565), true },
                    { 28, 2, new DateTime(1968, 4, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4572), "Leah", "000000028", "Gordon", false, new DateTime(2023, 9, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4570), true },
                    { 29, 1, new DateTime(1985, 4, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4576), "Esther", "000000029", "Katz", false, new DateTime(2024, 2, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4575), true },
                    { 30, 1, new DateTime(1968, 4, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4581), "Rebecca", "000000030", "Katz", false, new DateTime(2024, 3, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4579), true }
                });

            migrationBuilder.InsertData(
                table: "EmployeeRoles",
                columns: new[] { "EmployeeId", "RoleId", "EntryDate", "IsManagementRole" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 10, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4381), true },
                    { 1, 2, new DateTime(2023, 10, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4381), false },
                    { 2, 1, new DateTime(2023, 9, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4439), true },
                    { 2, 3, new DateTime(2023, 9, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4439), false },
                    { 2, 4, new DateTime(2023, 9, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4439), true },
                    { 3, 2, new DateTime(2023, 6, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4444), true },
                    { 3, 4, new DateTime(2023, 6, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4444), false },
                    { 4, 2, new DateTime(2023, 9, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4449), true },
                    { 4, 3, new DateTime(2023, 9, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4449), false },
                    { 5, 1, new DateTime(2023, 11, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4453), false },
                    { 5, 2, new DateTime(2023, 11, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4453), true },
                    { 5, 3, new DateTime(2023, 11, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4453), true },
                    { 6, 2, new DateTime(2023, 9, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4458), true },
                    { 6, 3, new DateTime(2023, 9, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4458), true },
                    { 7, 1, new DateTime(2023, 11, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4463), false },
                    { 7, 2, new DateTime(2023, 11, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4463), false },
                    { 8, 1, new DateTime(2023, 9, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4467), false },
                    { 8, 2, new DateTime(2023, 9, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4467), true },
                    { 9, 3, new DateTime(2024, 3, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4472), true },
                    { 9, 4, new DateTime(2024, 3, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4472), false },
                    { 10, 1, new DateTime(2024, 1, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4479), false },
                    { 10, 2, new DateTime(2024, 1, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4479), false },
                    { 10, 3, new DateTime(2024, 1, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4479), false },
                    { 11, 1, new DateTime(2023, 12, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4484), false },
                    { 11, 2, new DateTime(2023, 12, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4484), false },
                    { 11, 4, new DateTime(2023, 12, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4484), true },
                    { 12, 1, new DateTime(2024, 2, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4489), true },
                    { 12, 2, new DateTime(2024, 2, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4489), false },
                    { 12, 3, new DateTime(2024, 2, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4489), false },
                    { 13, 2, new DateTime(2023, 11, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4494), false },
                    { 13, 3, new DateTime(2023, 11, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4494), false },
                    { 13, 4, new DateTime(2023, 11, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4494), true },
                    { 14, 2, new DateTime(2023, 9, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4499), false },
                    { 14, 4, new DateTime(2023, 9, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4499), false },
                    { 15, 3, new DateTime(2023, 11, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4504), true },
                    { 15, 4, new DateTime(2023, 11, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4504), true },
                    { 16, 3, new DateTime(2023, 5, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4511), true },
                    { 16, 4, new DateTime(2023, 5, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4511), false },
                    { 17, 1, new DateTime(2023, 9, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4518), false },
                    { 17, 3, new DateTime(2023, 9, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4518), false },
                    { 17, 4, new DateTime(2023, 9, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4518), false },
                    { 18, 1, new DateTime(2023, 10, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4523), true }
                });

            migrationBuilder.InsertData(
                table: "EmployeeRoles",
                columns: new[] { "EmployeeId", "RoleId", "EntryDate", "IsManagementRole" },
                values: new object[,]
                {
                    { 18, 4, new DateTime(2023, 10, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4523), false },
                    { 19, 1, new DateTime(2023, 8, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4528), false },
                    { 19, 2, new DateTime(2023, 8, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4528), false },
                    { 20, 2, new DateTime(2024, 2, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4533), true },
                    { 20, 3, new DateTime(2024, 2, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4533), false },
                    { 21, 2, new DateTime(2023, 8, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4537), true },
                    { 21, 3, new DateTime(2023, 8, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4537), true },
                    { 21, 4, new DateTime(2023, 8, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4537), true },
                    { 22, 1, new DateTime(2023, 7, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4542), false },
                    { 22, 2, new DateTime(2023, 7, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4542), false },
                    { 22, 3, new DateTime(2023, 7, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4542), false },
                    { 23, 1, new DateTime(2023, 6, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4547), true },
                    { 23, 2, new DateTime(2023, 6, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4547), false },
                    { 24, 2, new DateTime(2023, 10, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4552), false },
                    { 24, 3, new DateTime(2023, 10, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4552), false },
                    { 24, 4, new DateTime(2023, 10, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4552), true },
                    { 25, 2, new DateTime(2024, 1, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4556), true },
                    { 25, 4, new DateTime(2024, 1, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4556), true },
                    { 26, 1, new DateTime(2023, 8, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4561), false },
                    { 26, 3, new DateTime(2023, 8, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4561), true },
                    { 26, 4, new DateTime(2023, 8, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4561), true },
                    { 27, 1, new DateTime(2023, 8, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4565), false },
                    { 27, 3, new DateTime(2023, 8, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4565), true },
                    { 27, 4, new DateTime(2023, 8, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4565), true },
                    { 28, 1, new DateTime(2023, 9, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4570), false },
                    { 28, 2, new DateTime(2023, 9, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4570), false },
                    { 28, 3, new DateTime(2023, 9, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4570), false },
                    { 29, 2, new DateTime(2024, 2, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4575), true },
                    { 29, 3, new DateTime(2024, 2, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4575), false },
                    { 30, 2, new DateTime(2024, 3, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4579), true },
                    { 30, 3, new DateTime(2024, 3, 11, 3, 26, 48, 120, DateTimeKind.Local).AddTicks(4579), true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRoles_RoleId",
                table: "EmployeeRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyId",
                table: "Employees",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeRoles");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
