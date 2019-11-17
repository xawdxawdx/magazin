using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DanilaWebApp.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Country = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    AdditionalLocation = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    SelfExport = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommunicationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CommunicationName = table.Column<string>(nullable: true),
                    CommunicationSubType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunicationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhoneCharacteristics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    type = table.Column<string>(nullable: true),
                    opSystem = table.Column<string>(nullable: true),
                    ScreenType = table.Column<string>(nullable: true),
                    PhoneWidth = table.Column<int>(nullable: false),
                    PhoneHeight = table.Column<int>(nullable: false),
                    PhoneDepth = table.Column<int>(nullable: false),
                    CpuModel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneCharacteristics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    RegistrationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SupportedCommunicationTypes",
                columns: table => new
                {
                    PhoneCharacteristicId = table.Column<int>(nullable: false),
                    CommunicationTypeId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportedCommunicationTypes", x => new { x.CommunicationTypeId, x.PhoneCharacteristicId });
                    table.ForeignKey(
                        name: "FK_SupportedCommunicationTypes_CommunicationTypes_CommunicationTypeId",
                        column: x => x.CommunicationTypeId,
                        principalTable: "CommunicationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupportedCommunicationTypes_PhoneCharacteristics_PhoneCharacteristicId",
                        column: x => x.PhoneCharacteristicId,
                        principalTable: "PhoneCharacteristics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AddressId = table.Column<int>(nullable: false),
                    ProfileId = table.Column<int>(nullable: false),
                    ContactPhone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Company = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    CharacteristicId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phones_PhoneCharacteristics_CharacteristicId",
                        column: x => x.CharacteristicId,
                        principalTable: "PhoneCharacteristics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Phones_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CommunicationTypes",
                columns: new[] { "Id", "CommunicationName", "CommunicationSubType" },
                values: new object[] { 1, "4G", "IMT Advanced" });

            migrationBuilder.InsertData(
                table: "CommunicationTypes",
                columns: new[] { "Id", "CommunicationName", "CommunicationSubType" },
                values: new object[] { 2, "4G", "LTE Advanced Pro" });

            migrationBuilder.InsertData(
                table: "CommunicationTypes",
                columns: new[] { "Id", "CommunicationName", "CommunicationSubType" },
                values: new object[] { 3, "3G", "LTE" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AddressId",
                table: "Orders",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProfileId",
                table: "Orders",
                column: "ProfileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Phones_CharacteristicId",
                table: "Phones",
                column: "CharacteristicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Phones_OrderId",
                table: "Phones",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SupportedCommunicationTypes_PhoneCharacteristicId",
                table: "SupportedCommunicationTypes",
                column: "PhoneCharacteristicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "SupportedCommunicationTypes");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "CommunicationTypes");

            migrationBuilder.DropTable(
                name: "PhoneCharacteristics");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
