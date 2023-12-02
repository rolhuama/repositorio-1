using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ColabManager360.Infrastructure.Data.Migrations.SQL
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CostCenter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostCenter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentTypes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntryTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Holidays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    days = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holidays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Industries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Industries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasterDetailTable",
                columns: table => new
                {
                    TableName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TableCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ShortDesc = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LongDesc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DecimalValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IntegerValue = table.Column<int>(type: "int", nullable: true),
                    IsSystemTable = table.Column<bool>(type: "bit", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterDetailTable", x => new { x.TableName, x.TableCode, x.ShortDesc });
                    table.UniqueConstraint("AK_MasterDetailTable_ShortDesc", x => x.ShortDesc);
                });

            migrationBuilder.CreateTable(
                name: "MenuGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Order = table.Column<int>(type: "int", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ubigeo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Department = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Province = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    District = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Region = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Zone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ubigeo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "WorkAreas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkAreas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LegalName = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    CommercialName = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    FiscalAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxIdentificationNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EconomicSector = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CostCenterId = table.Column<int>(type: "int", nullable: true),
                    IsInterCompany = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_CostCenter_CostCenterId",
                        column: x => x.CostCenterId,
                        principalTable: "CostCenter",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PersonInformation",
                columns: table => new
                {
                    Uid = table.Column<Guid>(type: "uniqueidentifier", maxLength: 380, nullable: false),
                    EntelgyCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    FirstName1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FirstName2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LastName1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LastName2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DocumentTypeId = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonalEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    WorkEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PersonalCellPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    WorkCellPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EntelgyStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EntelgyEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    EntryTypeId = table.Column<int>(type: "int", nullable: true),
                    BusinessUnitId = table.Column<int>(type: "int", nullable: true),
                    EntelgyContractProfile = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EntelgyContractCategory = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    YearsOfExperience = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReferenceAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Province = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Department = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    HasChildren = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonInformation", x => x.Uid);
                    table.ForeignKey(
                        name: "FK_PersonInformation_BusinessUnits_BusinessUnitId",
                        column: x => x.BusinessUnitId,
                        principalTable: "BusinessUnits",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PersonInformation_DocumentTypes_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "DocumentTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PersonInformation_EntryTypes_EntryTypeId",
                        column: x => x.EntryTypeId,
                        principalTable: "EntryTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Periods",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    State = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    MaximumDays = table.Column<int>(type: "int", nullable: true),
                    MaximumHours = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Periods_MasterDetailTable_State",
                        column: x => x.State,
                        principalTable: "MasterDetailTable",
                        principalColumn: "ShortDesc");
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menu_MenuGroup_GroupId",
                        column: x => x.GroupId,
                        principalTable: "MenuGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WorkAreaTeams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkAreaId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkAreaTeams", x => new { x.Id, x.WorkAreaId });
                    table.ForeignKey(
                        name: "FK_WorkAreaTeams_WorkAreas_WorkAreaId",
                        column: x => x.WorkAreaId,
                        principalTable: "WorkAreas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ActivityTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityTypes_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompanyAreas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyAreas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyAreas_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompanyServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    CostCenterId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyServices_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyServices_CostCenter_CostCenterId",
                        column: x => x.CostCenterId,
                        principalTable: "CostCenter",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyServices_ServiceTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ServiceTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContactServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceTypeId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    FirstName1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FirstName2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LastName1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LastName2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EmailContact = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CellPhoneContact = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactServices_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContactServices_ServiceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PersonCertifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Grade = table.Column<decimal>(type: "decimal(18,2)", maxLength: 255, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    StudyCenter = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonCertifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonCertifications_PersonInformation_PersonUid",
                        column: x => x.PersonUid,
                        principalTable: "PersonInformation",
                        principalColumn: "Uid");
                });

            migrationBuilder.CreateTable(
                name: "PersonDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DocumentDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sent = table.Column<bool>(type: "bit", nullable: true),
                    Received = table.Column<bool>(type: "bit", nullable: true),
                    Attendance = table.Column<bool>(type: "bit", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonDocuments_PersonInformation_PersonUid",
                        column: x => x.PersonUid,
                        principalTable: "PersonInformation",
                        principalColumn: "Uid");
                });

            migrationBuilder.CreateTable(
                name: "PersonHistory",
                columns: table => new
                {
                    Uid = table.Column<Guid>(type: "uniqueidentifier", maxLength: 380, nullable: false),
                    PersonUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActionTypeId = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonHistory", x => x.Uid);
                    table.ForeignKey(
                        name: "FK_PersonHistory_ActionTypes_ActionTypeId",
                        column: x => x.ActionTypeId,
                        principalTable: "ActionTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PersonHistory_PersonInformation_PersonUid",
                        column: x => x.PersonUid,
                        principalTable: "PersonInformation",
                        principalColumn: "Uid");
                });

            migrationBuilder.CreateTable(
                name: "PersonIndustries",
                columns: table => new
                {
                    IndustryId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 380, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonIndustries", x => new { x.IndustryId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_PersonIndustries_Industries_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "Industries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PersonIndustries_PersonInformation_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PersonInformation",
                        principalColumn: "Uid");
                });

            migrationBuilder.CreateTable(
                name: "PersonLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Idioma = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nivel = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonLanguages_PersonInformation_PersonUid",
                        column: x => x.PersonUid,
                        principalTable: "PersonInformation",
                        principalColumn: "Uid");
                });

            migrationBuilder.CreateTable(
                name: "ServiceManagers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceManagers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceManagers_PersonInformation_PersonUid",
                        column: x => x.PersonUid,
                        principalTable: "PersonInformation",
                        principalColumn: "Uid");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(380)", maxLength: 380, nullable: false),
                    PersonUid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_PersonInformation_PersonUid",
                        column: x => x.PersonUid,
                        principalTable: "PersonInformation",
                        principalColumn: "Uid");
                });

            migrationBuilder.CreateTable(
                name: "MenuRole",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuRole", x => new { x.MenuId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_MenuRole_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MenuRole_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Collaborators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Transversal = table.Column<bool>(type: "bit", nullable: true),
                    WorkAreaId = table.Column<int>(type: "int", nullable: true),
                    WorkAreaTeamId = table.Column<int>(type: "int", nullable: true),
                    WorkAreaTeamWorkAreaId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collaborators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Collaborators_PersonInformation_PersonUid",
                        column: x => x.PersonUid,
                        principalTable: "PersonInformation",
                        principalColumn: "Uid");
                    table.ForeignKey(
                        name: "FK_Collaborators_WorkAreaTeams_WorkAreaTeamId_WorkAreaTeamWorkAreaId",
                        columns: x => new { x.WorkAreaTeamId, x.WorkAreaTeamWorkAreaId },
                        principalTable: "WorkAreaTeams",
                        principalColumns: new[] { "Id", "WorkAreaId" });
                    table.ForeignKey(
                        name: "FK_Collaborators_WorkAreas_WorkAreaId",
                        column: x => x.WorkAreaId,
                        principalTable: "WorkAreas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(380)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(380)", maxLength: 380, nullable: false),
                    CollaboratorId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DurationHours = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DurationDays = table.Column<int>(type: "int", nullable: true),
                    DurationMonths = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActivityTypeId = table.Column<int>(type: "int", nullable: false),
                    CompanyServiceId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NotifiesHR = table.Column<bool>(type: "bit", nullable: false),
                    CoordinatesWithClient = table.Column<bool>(type: "bit", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TicketCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Week = table.Column<int>(type: "int", nullable: true),
                    PeriodId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_ActivityTypes_ActivityTypeId",
                        column: x => x.ActivityTypeId,
                        principalTable: "ActivityTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Activities_Collaborators_CollaboratorId",
                        column: x => x.CollaboratorId,
                        principalTable: "Collaborators",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Activities_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Activities_CompanyServices_CompanyServiceId",
                        column: x => x.CompanyServiceId,
                        principalTable: "CompanyServices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Activities_Periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Periods",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CollaboratorAdditionalInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollaboratorId = table.Column<int>(type: "int", nullable: false),
                    AttributeId = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollaboratorAdditionalInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CollaboratorAdditionalInfos_Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Attributes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CollaboratorAdditionalInfos_Collaborators_CollaboratorId",
                        column: x => x.CollaboratorId,
                        principalTable: "Collaborators",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CollaboratorCompanies",
                columns: table => new
                {
                    CollaboratorId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    ClientPosition = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollaboratorCompanies", x => new { x.CollaboratorId, x.CompanyId });
                    table.ForeignKey(
                        name: "FK_CollaboratorCompanies_Collaborators_CollaboratorId",
                        column: x => x.CollaboratorId,
                        principalTable: "Collaborators",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CollaboratorCompanies_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CollaboratorContacts",
                columns: table => new
                {
                    CollaboratorId = table.Column<int>(type: "int", nullable: false),
                    ContactServiceId = table.Column<int>(type: "int", nullable: false),
                    Realtion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollaboratorContacts", x => new { x.CollaboratorId, x.ContactServiceId });
                    table.ForeignKey(
                        name: "FK_CollaboratorContacts_Collaborators_CollaboratorId",
                        column: x => x.CollaboratorId,
                        principalTable: "Collaborators",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CollaboratorContacts_ContactServices_ContactServiceId",
                        column: x => x.ContactServiceId,
                        principalTable: "ContactServices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompanyAreaCollaborators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyAreaId = table.Column<int>(type: "int", nullable: false),
                    CollaboratorId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyAreaCollaborators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyAreaCollaborators_Collaborators_CollaboratorId",
                        column: x => x.CollaboratorId,
                        principalTable: "Collaborators",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyAreaCollaborators_CompanyAreas_CompanyAreaId",
                        column: x => x.CompanyAreaId,
                        principalTable: "CompanyAreas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Novelties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollaboratorId = table.Column<int>(type: "int", nullable: false),
                    InitialDays = table.Column<int>(type: "int", nullable: true),
                    AccumulatedDays = table.Column<int>(type: "int", nullable: true),
                    ConsumedDays = table.Column<int>(type: "int", nullable: true),
                    AvailableDays = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Novelties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Novelties_Collaborators_CollaboratorId",
                        column: x => x.CollaboratorId,
                        principalTable: "Collaborators",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    From = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    To = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CollaboratorId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_Collaborators_CollaboratorId",
                        column: x => x.CollaboratorId,
                        principalTable: "Collaborators",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServiceManagerCollaborators",
                columns: table => new
                {
                    ServiceManagerId = table.Column<int>(type: "int", nullable: false),
                    CollaboratorId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceManagerCollaborators", x => new { x.ServiceManagerId, x.CollaboratorId });
                    table.ForeignKey(
                        name: "FK_ServiceManagerCollaborators_Collaborators_CollaboratorId",
                        column: x => x.CollaboratorId,
                        principalTable: "Collaborators",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceManagerCollaborators_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceManagerCollaborators_ServiceManagers_ServiceManagerId",
                        column: x => x.ServiceManagerId,
                        principalTable: "ServiceManagers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ActivitiesDetail",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(380)", maxLength: 380, nullable: false),
                    ActivityId = table.Column<string>(type: "nvarchar(380)", nullable: false),
                    Week = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    DayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hours = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivitiesDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivitiesDetail_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NoveltyRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoveltyId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalDays = table.Column<int>(type: "int", nullable: true),
                    ApprovedByDirectSupervisor = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    ApprovedByHR = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2 default getdate()", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoveltyRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoveltyRequests_Novelties_NoveltyId",
                        column: x => x.NoveltyId,
                        principalTable: "Novelties",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "ActivityTypes",
                columns: new[] { "Id", "Code", "CompanyId", "CreatedBy", "Description", "LastModifiedBy" },
                values: new object[,]
                {
                    { 1, "AT0001", null, null, "Entrevista", null },
                    { 2, "AT0002", null, null, "Formación", null },
                    { 3, "AT0003", null, null, "Garantía", null },
                    { 4, "AT0004", null, null, "Gestión", null },
                    { 5, "AT0005", null, null, "Incidencias", null },
                    { 6, "AT0006", null, null, "Operaciones", null },
                    { 7, "AT0007", null, null, "Preventa", null },
                    { 8, "AT0008", null, null, "Proyecto", null },
                    { 9, "AT0009", null, null, "Servicio", null },
                    { 10, "AT0010", null, null, "Soporte TI", null }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "CommercialName", "CostCenterId", "Country", "CreatedBy", "EconomicSector", "FiscalAddress", "IsActive", "IsInterCompany", "LastModifiedBy", "LegalName", "TaxIdentificationNumber" },
                values: new object[] { 1, "Pandero", null, "PE", null, null, "Av. Dos de Mayo Nro. 382", true, false, null, "PANDERO S.A.", "20100115663" });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "CreatedBy", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { "AR", null, null, "Argentina" },
                    { "BR", null, null, "Brasil" },
                    { "CL", null, null, "Chile" },
                    { "CO", null, null, "Colombia" },
                    { "MX", null, null, "México" },
                    { "PE", null, null, "Perú" },
                    { "US", null, null, "USA" }
                });

            migrationBuilder.InsertData(
                table: "DocumentTypes",
                columns: new[] { "Id", "Country", "CreatedBy", "Description", "LastModifiedBy" },
                values: new object[,]
                {
                    { "0", "PE", null, "Otros", null },
                    { "1", "PE", null, "Documento Nacional de Identidad", null },
                    { "4", "PE", null, "Carné de Extranjería", null },
                    { "7", "PE", null, "Pasaporte", null },
                    { "F", "PE", null, "Carné Permiso Temporal de Permanencia (PTP)", null }
                });

            migrationBuilder.InsertData(
                table: "MasterDetailTable",
                columns: new[] { "ShortDesc", "TableCode", "TableName", "DecimalValue", "IntegerValue", "IsSystemTable", "LongDesc", "Order" },
                values: new object[,]
                {
                    { "A", "States", "Periods", null, null, null, "Habilitado", null },
                    { "B", "States", "Periods", null, null, null, "Bloqueado", null }
                });

            migrationBuilder.InsertData(
                table: "MenuGroup",
                columns: new[] { "Id", "CreatedBy", "Icon", "LastModifiedBy", "Name", "Order" },
                values: new object[,]
                {
                    { 1, null, "bi bi-grid", null, "Dashboard", 1 },
                    { 2, null, "bi bi-journal-text", null, "Actividades", 2 },
                    { 3, null, "bi bi-journal-text", null, "Novedades", 3 },
                    { 4, null, "bi bi-bar-chart", null, "Reportes", 4 },
                    { 5, null, "bi bi-people", null, "People", 5 },
                    { 6, null, "bi bi-gear", null, "Configuraciones", 6 },
                    { 7, null, "bi bi-building-fill-gear", null, "Administración", 7 },
                    { 8, null, "bi bi-person", null, "Cuenta", 8 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ADMIN", null, "Administrador", "Administrador" },
                    { "COLAB", null, "Colaborador", "Colaborador" },
                    { "RRHH", null, "RRHH", "RRHH" },
                    { "SERVMAN", null, "ServiceManager", "ServiceManager" }
                });

            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] { "Id", "CreatedBy", "Description", "IsActive", "LastModifiedBy" },
                values: new object[,]
                {
                    { 1, null, "Proyecto", true, null },
                    { 2, null, "Servicio", true, null }
                });

            migrationBuilder.InsertData(
                table: "Ubigeo",
                columns: new[] { "Id", "Country", "CreatedBy", "Department", "District", "LastModifiedBy", "Name", "PostalCode", "Province", "Region", "Zone" },
                values: new object[,]
                {
                    { 1, "PE", null, "10", "10", null, "Singa", null, "05", null, null },
                    { 2, "PE", null, "10", "11", null, "Tantamayo", null, "05", null, null },
                    { 3, "PE", null, "10", "00", null, "Leoncio Prado", null, "06", null, null },
                    { 4, "PE", null, "10", "01", null, "Rupa-Rupa", null, "06", null, null },
                    { 5, "PE", null, "10", "02", null, "Daniel Alomias Robles", null, "06", null, null },
                    { 6, "PE", null, "10", "03", null, "Hermilio Valdizan", null, "06", null, null },
                    { 7, "PE", null, "10", "04", null, "Jose Crespo y Castillo", null, "06", null, null },
                    { 8, "PE", null, "10", "05", null, "Luyando", null, "06", null, null },
                    { 9, "PE", null, "10", "06", null, "Mariano Damaso Beraun", null, "06", null, null },
                    { 10, "PE", null, "10", "00", null, "Marañon", null, "07", null, null },
                    { 11, "PE", null, "10", "01", null, "Huacrachuco", null, "07", null, null },
                    { 12, "PE", null, "10", "02", null, "Cholon", null, "07", null, null },
                    { 13, "PE", null, "10", "03", null, "San Buenaventura", null, "07", null, null },
                    { 14, "PE", null, "10", "00", null, "Pachitea", null, "08", null, null },
                    { 15, "PE", null, "10", "01", null, "Panao", null, "08", null, null },
                    { 16, "PE", null, "10", "02", null, "Chaglla", null, "08", null, null },
                    { 17, "PE", null, "10", "03", null, "Molino", null, "08", null, null },
                    { 18, "PE", null, "10", "04", null, "Umari", null, "08", null, null },
                    { 19, "PE", null, "10", "00", null, "Puerto Inca", null, "09", null, null },
                    { 20, "PE", null, "10", "01", null, "Puerto Inca", null, "09", null, null },
                    { 21, "PE", null, "10", "02", null, "Codo del Pozuzo", null, "09", null, null },
                    { 22, "PE", null, "10", "03", null, "Honoria", null, "09", null, null },
                    { 23, "PE", null, "10", "04", null, "Tournavista", null, "09", null, null },
                    { 24, "PE", null, "10", "05", null, "Yuyapichis", null, "09", null, null },
                    { 25, "PE", null, "10", "00", null, "Lauricocha", null, "10", null, null },
                    { 26, "PE", null, "10", "01", null, "Jesus", null, "10", null, null },
                    { 27, "PE", null, "10", "02", null, "Baños", null, "10", null, null },
                    { 28, "PE", null, "10", "03", null, "Jivia", null, "10", null, null },
                    { 29, "PE", null, "10", "04", null, "Queropalca", null, "10", null, null },
                    { 30, "PE", null, "10", "05", null, "Rondos", null, "10", null, null },
                    { 31, "PE", null, "10", "06", null, "San Francisco de Asis", null, "10", null, null },
                    { 32, "PE", null, "10", "07", null, "San Miguel de Cauri", null, "10", null, null },
                    { 33, "PE", null, "10", "00", null, "Yarowilca", null, "11", null, null },
                    { 34, "PE", null, "10", "01", null, "Chavinillo", null, "11", null, null },
                    { 35, "PE", null, "10", "02", null, "Cahuac", null, "11", null, null },
                    { 36, "PE", null, "10", "03", null, "Chacabamba", null, "11", null, null },
                    { 37, "PE", null, "10", "04", null, "Chupan", null, "11", null, null },
                    { 38, "PE", null, "10", "05", null, "Jacas Chico", null, "11", null, null },
                    { 39, "PE", null, "10", "06", null, "Obas", null, "11", null, null },
                    { 40, "PE", null, "10", "07", null, "Pampamarca", null, "11", null, null },
                    { 41, "PE", null, "10", "08", null, "Choras", null, "11", null, null },
                    { 42, "PE", null, "11", "00", null, "Ica", null, "00", null, null },
                    { 43, "PE", null, "11", "00", null, "Ica", null, "01", null, null },
                    { 44, "PE", null, "11", "01", null, "Ica", null, "01", null, null },
                    { 45, "PE", null, "11", "02", null, "La Tinguiña", null, "01", null, null },
                    { 46, "PE", null, "11", "03", null, "Los Aquijes", null, "01", null, null },
                    { 47, "PE", null, "11", "04", null, "Ocucaje", null, "01", null, null },
                    { 48, "PE", null, "11", "05", null, "Pachacutec", null, "01", null, null },
                    { 49, "PE", null, "11", "06", null, "Parcona", null, "01", null, null },
                    { 50, "PE", null, "11", "07", null, "Pueblo Nuevo", null, "01", null, null },
                    { 51, "PE", null, "11", "08", null, "Salas", null, "01", null, null },
                    { 52, "PE", null, "11", "09", null, "San Jose de los Molinos", null, "01", null, null },
                    { 53, "PE", null, "11", "10", null, "San Juan Bautista", null, "01", null, null },
                    { 54, "PE", null, "11", "11", null, "Santiago", null, "01", null, null },
                    { 55, "PE", null, "11", "12", null, "Subtanjalla", null, "01", null, null },
                    { 56, "PE", null, "11", "13", null, "Tate", null, "01", null, null },
                    { 57, "PE", null, "11", "14", null, "Yauca del Rosario", null, "01", null, null },
                    { 58, "PE", null, "11", "00", null, "Chincha", null, "02", null, null },
                    { 59, "PE", null, "11", "01", null, "Chincha Alta", null, "02", null, null },
                    { 60, "PE", null, "11", "02", null, "Alto Laran", null, "02", null, null },
                    { 61, "PE", null, "11", "03", null, "Chavin", null, "02", null, null },
                    { 62, "PE", null, "11", "04", null, "Chincha Baja", null, "02", null, null },
                    { 63, "PE", null, "11", "05", null, "El Carmen", null, "02", null, null },
                    { 64, "PE", null, "11", "06", null, "Grocio Prado", null, "02", null, null },
                    { 65, "PE", null, "11", "07", null, "Pueblo Nuevo", null, "02", null, null },
                    { 66, "PE", null, "11", "08", null, "San Juan de Yanac", null, "02", null, null },
                    { 67, "PE", null, "11", "09", null, "San Pedro de Huacarpana", null, "02", null, null },
                    { 68, "PE", null, "11", "10", null, "Sunampe", null, "02", null, null },
                    { 69, "PE", null, "11", "11", null, "Tambo de Mora", null, "02", null, null },
                    { 70, "PE", null, "11", "00", null, "Nazca", null, "03", null, null },
                    { 71, "PE", null, "11", "01", null, "Nazca", null, "03", null, null },
                    { 72, "PE", null, "11", "02", null, "Changuillo", null, "03", null, null },
                    { 73, "PE", null, "11", "03", null, "El Ingenio", null, "03", null, null },
                    { 74, "PE", null, "11", "04", null, "Marcona", null, "03", null, null },
                    { 75, "PE", null, "11", "05", null, "Vista Alegre", null, "03", null, null },
                    { 76, "PE", null, "11", "00", null, "Palpa", null, "04", null, null },
                    { 77, "PE", null, "11", "01", null, "Palpa", null, "04", null, null },
                    { 78, "PE", null, "11", "02", null, "Llipata", null, "04", null, null },
                    { 79, "PE", null, "11", "03", null, "Rio Grande", null, "04", null, null },
                    { 80, "PE", null, "11", "04", null, "Santa Cruz", null, "04", null, null },
                    { 81, "PE", null, "11", "05", null, "Tibillo", null, "04", null, null },
                    { 82, "PE", null, "11", "00", null, "Pisco", null, "05", null, null },
                    { 83, "PE", null, "11", "01", null, "Pisco", null, "05", null, null },
                    { 84, "PE", null, "11", "02", null, "Huancano", null, "05", null, null },
                    { 85, "PE", null, "11", "03", null, "Humay", null, "05", null, null },
                    { 86, "PE", null, "11", "04", null, "Independencia", null, "05", null, null },
                    { 87, "PE", null, "11", "05", null, "Paracas", null, "05", null, null },
                    { 88, "PE", null, "11", "06", null, "San Andres", null, "05", null, null },
                    { 89, "PE", null, "11", "07", null, "San Clemente", null, "05", null, null },
                    { 90, "PE", null, "11", "08", null, "Tupac Amaru Inca", null, "05", null, null },
                    { 91, "PE", null, "12", "00", null, "Junin", null, "00", null, null },
                    { 92, "PE", null, "12", "00", null, "Huancayo", null, "01", null, null },
                    { 93, "PE", null, "12", "01", null, "Huancayo", null, "01", null, null },
                    { 94, "PE", null, "12", "04", null, "Carhuacallanga", null, "01", null, null },
                    { 95, "PE", null, "12", "05", null, "Chacapampa", null, "01", null, null },
                    { 96, "PE", null, "12", "06", null, "Chicche", null, "01", null, null },
                    { 97, "PE", null, "12", "07", null, "Chilca", null, "01", null, null },
                    { 98, "PE", null, "12", "08", null, "Chongos Alto", null, "01", null, null },
                    { 99, "PE", null, "12", "11", null, "Chupuro", null, "01", null, null },
                    { 100, "PE", null, "12", "12", null, "Colca", null, "01", null, null },
                    { 101, "PE", null, "12", "13", null, "Cullhuas", null, "01", null, null },
                    { 102, "PE", null, "12", "14", null, "El Tambo", null, "01", null, null },
                    { 103, "PE", null, "12", "16", null, "Huacrapuquio", null, "01", null, null },
                    { 104, "PE", null, "12", "17", null, "Hualhuas", null, "01", null, null },
                    { 105, "PE", null, "12", "19", null, "Huancan", null, "01", null, null },
                    { 106, "PE", null, "12", "20", null, "Huasicancha", null, "01", null, null },
                    { 107, "PE", null, "12", "21", null, "Huayucachi", null, "01", null, null },
                    { 108, "PE", null, "12", "22", null, "Ingenio", null, "01", null, null },
                    { 109, "PE", null, "12", "24", null, "Pariahuanca", null, "01", null, null },
                    { 110, "PE", null, "12", "25", null, "Pilcomayo", null, "01", null, null },
                    { 111, "PE", null, "12", "26", null, "Pucara", null, "01", null, null },
                    { 112, "PE", null, "12", "27", null, "Quichuay", null, "01", null, null },
                    { 113, "PE", null, "12", "28", null, "Quilcas", null, "01", null, null },
                    { 114, "PE", null, "12", "29", null, "San Agustin", null, "01", null, null },
                    { 115, "PE", null, "12", "30", null, "San Jeronimo de Tunan", null, "01", null, null },
                    { 116, "PE", null, "12", "32", null, "Saño", null, "01", null, null },
                    { 117, "PE", null, "12", "33", null, "Sapallanga", null, "01", null, null },
                    { 118, "PE", null, "12", "34", null, "Sicaya", null, "01", null, null },
                    { 119, "PE", null, "12", "35", null, "Santo Domingo de Acobamba", null, "01", null, null },
                    { 120, "PE", null, "12", "36", null, "Viques", null, "01", null, null },
                    { 121, "PE", null, "12", "00", null, "Concepcion", null, "02", null, null },
                    { 122, "PE", null, "12", "01", null, "Concepcion", null, "02", null, null },
                    { 123, "PE", null, "12", "02", null, "Aco", null, "02", null, null },
                    { 124, "PE", null, "12", "03", null, "Andamarca", null, "02", null, null },
                    { 125, "PE", null, "12", "04", null, "Chambara", null, "02", null, null },
                    { 126, "PE", null, "12", "05", null, "Cochas", null, "02", null, null },
                    { 127, "PE", null, "12", "06", null, "Comas", null, "02", null, null },
                    { 128, "PE", null, "12", "07", null, "Heroinas Toledo", null, "02", null, null },
                    { 129, "PE", null, "12", "08", null, "Manzanares", null, "02", null, null },
                    { 130, "PE", null, "12", "09", null, "Mariscal Castilla", null, "02", null, null },
                    { 131, "PE", null, "12", "10", null, "Matahuasi", null, "02", null, null },
                    { 132, "PE", null, "12", "11", null, "Mito", null, "02", null, null },
                    { 133, "PE", null, "12", "12", null, "Nueve de Julio", null, "02", null, null },
                    { 134, "PE", null, "12", "13", null, "Orcotuna", null, "02", null, null },
                    { 135, "PE", null, "12", "14", null, "San Jose de Quero", null, "02", null, null },
                    { 136, "PE", null, "12", "15", null, "Santa Rosa de Ocopa", null, "02", null, null },
                    { 137, "PE", null, "12", "00", null, "Chanchamayo", null, "03", null, null },
                    { 138, "PE", null, "12", "01", null, "Chanchamayo", null, "03", null, null },
                    { 139, "PE", null, "12", "02", null, "Perene", null, "03", null, null },
                    { 140, "PE", null, "12", "03", null, "Pichanaqui", null, "03", null, null },
                    { 141, "PE", null, "12", "04", null, "San Luis de Shuaro", null, "03", null, null },
                    { 142, "PE", null, "12", "05", null, "San Ramon", null, "03", null, null },
                    { 143, "PE", null, "12", "06", null, "Vitoc", null, "03", null, null },
                    { 144, "PE", null, "12", "00", null, "Jauja", null, "04", null, null },
                    { 145, "PE", null, "12", "01", null, "Jauja", null, "04", null, null },
                    { 146, "PE", null, "12", "02", null, "Acolla", null, "04", null, null },
                    { 147, "PE", null, "12", "03", null, "Apata", null, "04", null, null },
                    { 148, "PE", null, "12", "04", null, "Ataura", null, "04", null, null },
                    { 149, "PE", null, "12", "05", null, "Canchayllo", null, "04", null, null },
                    { 150, "PE", null, "12", "06", null, "Curicaca", null, "04", null, null },
                    { 151, "PE", null, "12", "07", null, "El Mantaro", null, "04", null, null },
                    { 152, "PE", null, "12", "08", null, "Huamali", null, "04", null, null },
                    { 153, "PE", null, "12", "09", null, "Huaripampa", null, "04", null, null },
                    { 154, "PE", null, "12", "10", null, "Huertas", null, "04", null, null },
                    { 155, "PE", null, "12", "11", null, "Janjaillo", null, "04", null, null },
                    { 156, "PE", null, "12", "12", null, "Julcan", null, "04", null, null },
                    { 157, "PE", null, "12", "13", null, "Leonor Ordoñez", null, "04", null, null },
                    { 158, "PE", null, "12", "14", null, "Llocllapampa", null, "04", null, null },
                    { 159, "PE", null, "12", "15", null, "Marco", null, "04", null, null },
                    { 160, "PE", null, "12", "16", null, "Masma", null, "04", null, null },
                    { 161, "PE", null, "12", "17", null, "Masma Chicche", null, "04", null, null },
                    { 162, "PE", null, "12", "18", null, "Molinos", null, "04", null, null },
                    { 163, "PE", null, "12", "19", null, "Monobamba", null, "04", null, null },
                    { 164, "PE", null, "12", "20", null, "Muqui", null, "04", null, null },
                    { 165, "PE", null, "12", "21", null, "Muquiyauyo", null, "04", null, null },
                    { 166, "PE", null, "12", "22", null, "Paca", null, "04", null, null },
                    { 167, "PE", null, "12", "23", null, "Paccha", null, "04", null, null },
                    { 168, "PE", null, "12", "24", null, "Pancan", null, "04", null, null },
                    { 169, "PE", null, "12", "25", null, "Parco", null, "04", null, null },
                    { 170, "PE", null, "12", "26", null, "Pomacancha", null, "04", null, null },
                    { 171, "PE", null, "12", "27", null, "Ricran", null, "04", null, null },
                    { 172, "PE", null, "12", "28", null, "San Lorenzo", null, "04", null, null },
                    { 173, "PE", null, "12", "29", null, "San Pedro de Chunan", null, "04", null, null },
                    { 174, "PE", null, "12", "30", null, "Sausa", null, "04", null, null },
                    { 175, "PE", null, "12", "31", null, "Sincos", null, "04", null, null },
                    { 176, "PE", null, "12", "32", null, "Tunan Marca", null, "04", null, null },
                    { 177, "PE", null, "12", "33", null, "Yauli", null, "04", null, null },
                    { 178, "PE", null, "12", "34", null, "Yauyos", null, "04", null, null },
                    { 179, "PE", null, "12", "00", null, "Junin", null, "05", null, null },
                    { 180, "PE", null, "12", "01", null, "Junin", null, "05", null, null },
                    { 181, "PE", null, "12", "02", null, "Carhuamayo", null, "05", null, null },
                    { 182, "PE", null, "12", "03", null, "Ondores", null, "05", null, null },
                    { 183, "PE", null, "12", "04", null, "Ulcumayo", null, "05", null, null },
                    { 184, "PE", null, "12", "00", null, "Satipo", null, "06", null, null },
                    { 185, "PE", null, "12", "01", null, "Satipo", null, "06", null, null },
                    { 186, "PE", null, "12", "02", null, "Coviriali", null, "06", null, null },
                    { 187, "PE", null, "12", "03", null, "Llaylla", null, "06", null, null },
                    { 188, "PE", null, "12", "04", null, "Mazamari", null, "06", null, null },
                    { 189, "PE", null, "12", "05", null, "Pampa Hermosa", null, "06", null, null },
                    { 190, "PE", null, "12", "06", null, "Pangoa", null, "06", null, null },
                    { 191, "PE", null, "12", "07", null, "Rio Negro", null, "06", null, null },
                    { 192, "PE", null, "12", "08", null, "Rio Tambo", null, "06", null, null },
                    { 193, "PE", null, "12", "99", null, "Mazamari-Pangoa", null, "06", null, null },
                    { 194, "PE", null, "12", "00", null, "Tarma", null, "07", null, null },
                    { 195, "PE", null, "12", "01", null, "Tarma", null, "07", null, null },
                    { 196, "PE", null, "12", "02", null, "Acobamba", null, "07", null, null },
                    { 197, "PE", null, "12", "03", null, "Huaricolca", null, "07", null, null },
                    { 198, "PE", null, "12", "04", null, "Huasahuasi", null, "07", null, null },
                    { 199, "PE", null, "12", "05", null, "La Union", null, "07", null, null },
                    { 200, "PE", null, "12", "06", null, "Palca", null, "07", null, null },
                    { 201, "PE", null, "12", "07", null, "Palcamayo", null, "07", null, null },
                    { 202, "PE", null, "12", "08", null, "San Pedro de Cajas", null, "07", null, null },
                    { 203, "PE", null, "12", "09", null, "Tapo", null, "07", null, null },
                    { 204, "PE", null, "12", "00", null, "Yauli", null, "08", null, null },
                    { 205, "PE", null, "12", "01", null, "La Oroya", null, "08", null, null },
                    { 206, "PE", null, "12", "02", null, "Chacapalpa", null, "08", null, null },
                    { 207, "PE", null, "12", "03", null, "Huay-Huay", null, "08", null, null },
                    { 208, "PE", null, "12", "04", null, "Marcapomacocha", null, "08", null, null },
                    { 209, "PE", null, "12", "05", null, "Morococha", null, "08", null, null },
                    { 210, "PE", null, "12", "06", null, "Paccha", null, "08", null, null },
                    { 211, "PE", null, "12", "07", null, "Santa Barbara de Carhuacayan", null, "08", null, null },
                    { 212, "PE", null, "12", "08", null, "Santa Rosa de Sacco", null, "08", null, null },
                    { 213, "PE", null, "12", "09", null, "Suitucancha", null, "08", null, null },
                    { 214, "PE", null, "12", "10", null, "Yauli", null, "08", null, null },
                    { 215, "PE", null, "12", "00", null, "Chupaca", null, "09", null, null },
                    { 216, "PE", null, "12", "01", null, "Chupaca", null, "09", null, null },
                    { 217, "PE", null, "12", "02", null, "Ahuac", null, "09", null, null },
                    { 218, "PE", null, "12", "03", null, "Chongos Bajo", null, "09", null, null },
                    { 219, "PE", null, "12", "04", null, "Huachac", null, "09", null, null },
                    { 220, "PE", null, "12", "05", null, "Huamancaca Chico", null, "09", null, null },
                    { 221, "PE", null, "12", "06", null, "San Juan de Iscos", null, "09", null, null },
                    { 222, "PE", null, "12", "07", null, "San Juan de Jarpa", null, "09", null, null },
                    { 223, "PE", null, "12", "08", null, "3 de Diciembre", null, "09", null, null },
                    { 224, "PE", null, "12", "09", null, "Yanacancha", null, "09", null, null },
                    { 225, "PE", null, "13", "00", null, "La Libertad", null, "00", null, null },
                    { 226, "PE", null, "13", "00", null, "Trujillo", null, "01", null, null },
                    { 227, "PE", null, "13", "01", null, "Trujillo", null, "01", null, null },
                    { 228, "PE", null, "13", "02", null, "El Porvenir", null, "01", null, null },
                    { 229, "PE", null, "13", "03", null, "Florencia de Mora", null, "01", null, null },
                    { 230, "PE", null, "13", "04", null, "Huanchaco", null, "01", null, null },
                    { 231, "PE", null, "13", "05", null, "La Esperanza", null, "01", null, null },
                    { 232, "PE", null, "13", "06", null, "Laredo", null, "01", null, null },
                    { 233, "PE", null, "13", "07", null, "Moche", null, "01", null, null },
                    { 234, "PE", null, "13", "08", null, "Poroto", null, "01", null, null },
                    { 235, "PE", null, "13", "09", null, "Salaverry", null, "01", null, null },
                    { 236, "PE", null, "13", "10", null, "Simbal", null, "01", null, null },
                    { 237, "PE", null, "13", "11", null, "Victor Larco Herrera", null, "01", null, null },
                    { 238, "PE", null, "13", "00", null, "Ascope", null, "02", null, null },
                    { 239, "PE", null, "13", "01", null, "Ascope", null, "02", null, null },
                    { 240, "PE", null, "13", "02", null, "Chicama", null, "02", null, null },
                    { 241, "PE", null, "13", "03", null, "Chocope", null, "02", null, null },
                    { 242, "PE", null, "13", "04", null, "Magdalena de Cao", null, "02", null, null },
                    { 243, "PE", null, "13", "05", null, "Paijan", null, "02", null, null },
                    { 244, "PE", null, "13", "06", null, "Razuri", null, "02", null, null },
                    { 245, "PE", null, "13", "07", null, "Santiago de Cao", null, "02", null, null },
                    { 246, "PE", null, "13", "08", null, "Casa Grande", null, "02", null, null },
                    { 247, "PE", null, "13", "00", null, "Bolivar", null, "03", null, null },
                    { 248, "PE", null, "13", "01", null, "Bolivar", null, "03", null, null },
                    { 249, "PE", null, "13", "02", null, "Bambamarca", null, "03", null, null },
                    { 250, "PE", null, "13", "03", null, "Condormarca", null, "03", null, null },
                    { 251, "PE", null, "13", "04", null, "Longotea", null, "03", null, null },
                    { 252, "PE", null, "13", "05", null, "Uchumarca", null, "03", null, null },
                    { 253, "PE", null, "13", "06", null, "Ucuncha", null, "03", null, null },
                    { 254, "PE", null, "13", "00", null, "Chepen", null, "04", null, null },
                    { 255, "PE", null, "13", "01", null, "Chepen", null, "04", null, null },
                    { 256, "PE", null, "13", "02", null, "Pacanga", null, "04", null, null },
                    { 257, "PE", null, "01", "00", null, "Amazonas", null, "00", null, null },
                    { 258, "PE", null, "01", "00", null, "Chachapoyas", null, "01", null, null },
                    { 259, "PE", null, "01", "01", null, "Chachapoyas", null, "01", null, null },
                    { 260, "PE", null, "01", "02", null, "Asuncion", null, "01", null, null },
                    { 261, "PE", null, "01", "03", null, "Balsas", null, "01", null, null },
                    { 262, "PE", null, "01", "04", null, "Cheto", null, "01", null, null },
                    { 263, "PE", null, "01", "05", null, "Chiliquin", null, "01", null, null },
                    { 264, "PE", null, "01", "06", null, "Chuquibamba", null, "01", null, null },
                    { 265, "PE", null, "01", "07", null, "Granada", null, "01", null, null },
                    { 266, "PE", null, "01", "08", null, "Huancas", null, "01", null, null },
                    { 267, "PE", null, "01", "09", null, "La Jalca", null, "01", null, null },
                    { 268, "PE", null, "01", "10", null, "Leimebamba", null, "01", null, null },
                    { 269, "PE", null, "01", "11", null, "Levanto", null, "01", null, null },
                    { 270, "PE", null, "01", "12", null, "Magdalena", null, "01", null, null },
                    { 271, "PE", null, "01", "13", null, "Mariscal Castilla", null, "01", null, null },
                    { 272, "PE", null, "01", "14", null, "Molinopampa", null, "01", null, null },
                    { 273, "PE", null, "01", "15", null, "Montevideo", null, "01", null, null },
                    { 274, "PE", null, "01", "16", null, "Olleros", null, "01", null, null },
                    { 275, "PE", null, "01", "17", null, "Quinjalca", null, "01", null, null },
                    { 276, "PE", null, "01", "18", null, "San Francisco de Daguas", null, "01", null, null },
                    { 277, "PE", null, "01", "19", null, "San Isidro de Maino", null, "01", null, null },
                    { 278, "PE", null, "01", "20", null, "Soloco", null, "01", null, null },
                    { 279, "PE", null, "01", "21", null, "Sonche", null, "01", null, null },
                    { 280, "PE", null, "01", "00", null, "Bagua", null, "02", null, null },
                    { 281, "PE", null, "01", "01", null, "Bagua", null, "02", null, null },
                    { 282, "PE", null, "01", "02", null, "Aramango", null, "02", null, null },
                    { 283, "PE", null, "01", "03", null, "Copallin", null, "02", null, null },
                    { 284, "PE", null, "01", "04", null, "El Parco", null, "02", null, null },
                    { 285, "PE", null, "01", "05", null, "Imaza", null, "02", null, null },
                    { 286, "PE", null, "01", "06", null, "La Peca", null, "02", null, null },
                    { 287, "PE", null, "01", "00", null, "Bongara", null, "03", null, null },
                    { 288, "PE", null, "01", "01", null, "Jumbilla", null, "03", null, null },
                    { 289, "PE", null, "01", "02", null, "Chisquilla", null, "03", null, null },
                    { 290, "PE", null, "01", "03", null, "Churuja", null, "03", null, null },
                    { 291, "PE", null, "01", "04", null, "Corosha", null, "03", null, null },
                    { 292, "PE", null, "01", "05", null, "Cuispes", null, "03", null, null },
                    { 293, "PE", null, "01", "06", null, "Florida", null, "03", null, null },
                    { 294, "PE", null, "01", "07", null, "Jazán", null, "03", null, null },
                    { 295, "PE", null, "01", "08", null, "Recta", null, "03", null, null },
                    { 296, "PE", null, "01", "09", null, "San Carlos", null, "03", null, null },
                    { 297, "PE", null, "01", "10", null, "Shipasbamba", null, "03", null, null },
                    { 298, "PE", null, "01", "11", null, "Valera", null, "03", null, null },
                    { 299, "PE", null, "01", "12", null, "Yambrasbamba", null, "03", null, null },
                    { 300, "PE", null, "01", "00", null, "Condorcanqui", null, "04", null, null },
                    { 301, "PE", null, "01", "01", null, "Nieva", null, "04", null, null },
                    { 302, "PE", null, "01", "02", null, "El Cenepa", null, "04", null, null },
                    { 303, "PE", null, "01", "03", null, "Rio Santiago", null, "04", null, null },
                    { 304, "PE", null, "01", "00", null, "Luya", null, "05", null, null },
                    { 305, "PE", null, "01", "01", null, "Lamud", null, "05", null, null },
                    { 306, "PE", null, "01", "02", null, "Camporredondo", null, "05", null, null },
                    { 307, "PE", null, "01", "03", null, "Cocabamba", null, "05", null, null },
                    { 308, "PE", null, "01", "04", null, "Colcamar", null, "05", null, null },
                    { 309, "PE", null, "01", "05", null, "Conila", null, "05", null, null },
                    { 310, "PE", null, "01", "06", null, "Inguilpata", null, "05", null, null },
                    { 311, "PE", null, "01", "07", null, "Longuita", null, "05", null, null },
                    { 312, "PE", null, "01", "08", null, "Lonya Chico", null, "05", null, null },
                    { 313, "PE", null, "01", "09", null, "Luya", null, "05", null, null },
                    { 314, "PE", null, "01", "10", null, "Luya Viejo", null, "05", null, null },
                    { 315, "PE", null, "01", "11", null, "Maria", null, "05", null, null },
                    { 316, "PE", null, "01", "12", null, "Ocalli", null, "05", null, null },
                    { 317, "PE", null, "01", "13", null, "Ocumal", null, "05", null, null },
                    { 318, "PE", null, "01", "14", null, "Pisuquia", null, "05", null, null },
                    { 319, "PE", null, "01", "15", null, "Providencia", null, "05", null, null },
                    { 320, "PE", null, "01", "16", null, "San Cristobal", null, "05", null, null },
                    { 321, "PE", null, "01", "17", null, "San Francisco del Yeso", null, "05", null, null },
                    { 322, "PE", null, "01", "18", null, "San Jeronimo", null, "05", null, null },
                    { 323, "PE", null, "01", "19", null, "San Juan de Lopecancha", null, "05", null, null },
                    { 324, "PE", null, "01", "20", null, "Santa Catalina", null, "05", null, null },
                    { 325, "PE", null, "01", "21", null, "Santo Tomas", null, "05", null, null },
                    { 326, "PE", null, "01", "22", null, "Tingo", null, "05", null, null },
                    { 327, "PE", null, "01", "23", null, "Trita", null, "05", null, null },
                    { 328, "PE", null, "01", "00", null, "Rodriguez de Mendoza", null, "06", null, null },
                    { 329, "PE", null, "01", "01", null, "San Nicolas", null, "06", null, null },
                    { 330, "PE", null, "01", "02", null, "Chirimoto", null, "06", null, null },
                    { 331, "PE", null, "01", "03", null, "Cochamal", null, "06", null, null },
                    { 332, "PE", null, "01", "04", null, "Huambo", null, "06", null, null },
                    { 333, "PE", null, "01", "05", null, "Limabamba", null, "06", null, null },
                    { 334, "PE", null, "01", "06", null, "Longar", null, "06", null, null },
                    { 335, "PE", null, "01", "07", null, "Mariscal Benavides", null, "06", null, null },
                    { 336, "PE", null, "01", "08", null, "Milpuc", null, "06", null, null },
                    { 337, "PE", null, "01", "09", null, "Omia", null, "06", null, null },
                    { 338, "PE", null, "01", "10", null, "Santa Rosa", null, "06", null, null },
                    { 339, "PE", null, "01", "11", null, "Totora", null, "06", null, null },
                    { 340, "PE", null, "01", "12", null, "Vista Alegre", null, "06", null, null },
                    { 341, "PE", null, "01", "00", null, "Utcubamba", null, "07", null, null },
                    { 342, "PE", null, "01", "01", null, "Bagua Grande", null, "07", null, null },
                    { 343, "PE", null, "01", "02", null, "Cajaruro", null, "07", null, null },
                    { 344, "PE", null, "01", "03", null, "Cumba", null, "07", null, null },
                    { 345, "PE", null, "01", "04", null, "El Milagro", null, "07", null, null },
                    { 346, "PE", null, "01", "05", null, "Jamalca", null, "07", null, null },
                    { 347, "PE", null, "01", "06", null, "Lonya Grande", null, "07", null, null },
                    { 348, "PE", null, "01", "07", null, "Yamon", null, "07", null, null },
                    { 349, "PE", null, "02", "00", null, "Ancash", null, "00", null, null },
                    { 350, "PE", null, "02", "00", null, "Huaraz", null, "01", null, null },
                    { 351, "PE", null, "02", "01", null, "Huaraz", null, "01", null, null },
                    { 352, "PE", null, "02", "02", null, "Cochabamba", null, "01", null, null },
                    { 353, "PE", null, "02", "03", null, "Colcabamba", null, "01", null, null },
                    { 354, "PE", null, "02", "04", null, "Huanchay", null, "01", null, null },
                    { 355, "PE", null, "02", "05", null, "Independencia", null, "01", null, null },
                    { 356, "PE", null, "02", "06", null, "Jangas", null, "01", null, null },
                    { 357, "PE", null, "02", "07", null, "La Libertad", null, "01", null, null },
                    { 358, "PE", null, "02", "08", null, "Olleros", null, "01", null, null },
                    { 359, "PE", null, "02", "09", null, "Pampas", null, "01", null, null },
                    { 360, "PE", null, "02", "10", null, "Pariacoto", null, "01", null, null },
                    { 361, "PE", null, "02", "11", null, "Pira", null, "01", null, null },
                    { 362, "PE", null, "02", "12", null, "Tarica", null, "01", null, null },
                    { 363, "PE", null, "02", "00", null, "Aija", null, "02", null, null },
                    { 364, "PE", null, "02", "01", null, "Aija", null, "02", null, null },
                    { 365, "PE", null, "02", "02", null, "Coris", null, "02", null, null },
                    { 366, "PE", null, "02", "03", null, "Huacllan", null, "02", null, null },
                    { 367, "PE", null, "02", "04", null, "La Merced", null, "02", null, null },
                    { 368, "PE", null, "02", "05", null, "Succha", null, "02", null, null },
                    { 369, "PE", null, "02", "00", null, "Antonio Raymondi", null, "03", null, null },
                    { 370, "PE", null, "02", "01", null, "Llamellin", null, "03", null, null },
                    { 371, "PE", null, "02", "02", null, "Aczo", null, "03", null, null },
                    { 372, "PE", null, "02", "03", null, "Chaccho", null, "03", null, null },
                    { 373, "PE", null, "02", "04", null, "Chingas", null, "03", null, null },
                    { 374, "PE", null, "02", "05", null, "Mirgas", null, "03", null, null },
                    { 375, "PE", null, "02", "06", null, "San Juan de Rontoy", null, "03", null, null },
                    { 376, "PE", null, "02", "00", null, "Asuncion", null, "04", null, null },
                    { 377, "PE", null, "02", "01", null, "Chacas", null, "04", null, null },
                    { 378, "PE", null, "02", "02", null, "Acochaca", null, "04", null, null },
                    { 379, "PE", null, "02", "00", null, "Bolognesi", null, "05", null, null },
                    { 380, "PE", null, "02", "01", null, "Chiquian", null, "05", null, null },
                    { 381, "PE", null, "02", "02", null, "Abelardo Pardo Lezameta", null, "05", null, null },
                    { 382, "PE", null, "02", "03", null, "Antonio Raymondi", null, "05", null, null },
                    { 383, "PE", null, "02", "04", null, "Aquia", null, "05", null, null },
                    { 384, "PE", null, "02", "05", null, "Cajacay", null, "05", null, null },
                    { 385, "PE", null, "02", "06", null, "Canis", null, "05", null, null },
                    { 386, "PE", null, "02", "07", null, "Colquioc", null, "05", null, null },
                    { 387, "PE", null, "02", "08", null, "Huallanca", null, "05", null, null },
                    { 388, "PE", null, "02", "09", null, "Huasta", null, "05", null, null },
                    { 389, "PE", null, "02", "10", null, "Huayllacayan", null, "05", null, null },
                    { 390, "PE", null, "02", "11", null, "La Primavera", null, "05", null, null },
                    { 391, "PE", null, "02", "12", null, "Mangas", null, "05", null, null },
                    { 392, "PE", null, "02", "13", null, "Pacllon", null, "05", null, null },
                    { 393, "PE", null, "02", "14", null, "San Miguel de Corpanqui", null, "05", null, null },
                    { 394, "PE", null, "02", "15", null, "Ticllos", null, "05", null, null },
                    { 395, "PE", null, "02", "00", null, "Carhuaz", null, "06", null, null },
                    { 396, "PE", null, "02", "01", null, "Carhuaz", null, "06", null, null },
                    { 397, "PE", null, "02", "02", null, "Acopampa", null, "06", null, null },
                    { 398, "PE", null, "02", "03", null, "Amashca", null, "06", null, null },
                    { 399, "PE", null, "02", "04", null, "Anta", null, "06", null, null },
                    { 400, "PE", null, "02", "05", null, "Ataquero", null, "06", null, null },
                    { 401, "PE", null, "02", "06", null, "Marcara", null, "06", null, null },
                    { 402, "PE", null, "02", "07", null, "Pariahuanca", null, "06", null, null },
                    { 403, "PE", null, "02", "08", null, "San Miguel de Aco", null, "06", null, null },
                    { 404, "PE", null, "02", "09", null, "Shilla", null, "06", null, null },
                    { 405, "PE", null, "02", "10", null, "Tinco", null, "06", null, null },
                    { 406, "PE", null, "02", "11", null, "Yungar", null, "06", null, null },
                    { 407, "PE", null, "02", "00", null, "Carlos Fermin Fitzcarrald", null, "07", null, null },
                    { 408, "PE", null, "02", "01", null, "San Luis", null, "07", null, null },
                    { 409, "PE", null, "02", "02", null, "San Nicolas", null, "07", null, null },
                    { 410, "PE", null, "02", "03", null, "Yauya", null, "07", null, null },
                    { 411, "PE", null, "02", "00", null, "Casma", null, "08", null, null },
                    { 412, "PE", null, "02", "01", null, "Casma", null, "08", null, null },
                    { 413, "PE", null, "02", "02", null, "Buena Vista Alta", null, "08", null, null },
                    { 414, "PE", null, "02", "03", null, "Comandante Noel", null, "08", null, null },
                    { 415, "PE", null, "02", "04", null, "Yautan", null, "08", null, null },
                    { 416, "PE", null, "02", "00", null, "Corongo", null, "09", null, null },
                    { 417, "PE", null, "02", "01", null, "Corongo", null, "09", null, null },
                    { 418, "PE", null, "02", "02", null, "Aco", null, "09", null, null },
                    { 419, "PE", null, "02", "03", null, "Bambas", null, "09", null, null },
                    { 420, "PE", null, "02", "04", null, "Cusca", null, "09", null, null },
                    { 421, "PE", null, "02", "05", null, "La Pampa", null, "09", null, null },
                    { 422, "PE", null, "02", "06", null, "Yanac", null, "09", null, null },
                    { 423, "PE", null, "02", "07", null, "Yupan", null, "09", null, null },
                    { 424, "PE", null, "02", "00", null, "Huari", null, "10", null, null },
                    { 425, "PE", null, "02", "01", null, "Huari", null, "10", null, null },
                    { 426, "PE", null, "02", "02", null, "Anra", null, "10", null, null },
                    { 427, "PE", null, "02", "03", null, "Cajay", null, "10", null, null },
                    { 428, "PE", null, "02", "04", null, "Chavin de Huantar", null, "10", null, null },
                    { 429, "PE", null, "02", "05", null, "Huacachi", null, "10", null, null },
                    { 430, "PE", null, "02", "06", null, "Huacchis", null, "10", null, null },
                    { 431, "PE", null, "02", "07", null, "Huachis", null, "10", null, null },
                    { 432, "PE", null, "02", "08", null, "Huantar", null, "10", null, null },
                    { 433, "PE", null, "02", "09", null, "Masin", null, "10", null, null },
                    { 434, "PE", null, "02", "10", null, "Paucas", null, "10", null, null },
                    { 435, "PE", null, "02", "11", null, "Ponto", null, "10", null, null },
                    { 436, "PE", null, "02", "12", null, "Rahuapampa", null, "10", null, null },
                    { 437, "PE", null, "02", "13", null, "Rapayan", null, "10", null, null },
                    { 438, "PE", null, "02", "14", null, "San Marcos", null, "10", null, null },
                    { 439, "PE", null, "02", "15", null, "San Pedro de Chana", null, "10", null, null },
                    { 440, "PE", null, "02", "16", null, "Uco", null, "10", null, null },
                    { 441, "PE", null, "02", "00", null, "Huarmey", null, "11", null, null },
                    { 442, "PE", null, "02", "01", null, "Huarmey", null, "11", null, null },
                    { 443, "PE", null, "02", "02", null, "Cochapeti", null, "11", null, null },
                    { 444, "PE", null, "02", "03", null, "Culebras", null, "11", null, null },
                    { 445, "PE", null, "02", "04", null, "Huayan", null, "11", null, null },
                    { 446, "PE", null, "02", "05", null, "Malvas", null, "11", null, null },
                    { 447, "PE", null, "02", "00", null, "Huaylas", null, "12", null, null },
                    { 448, "PE", null, "02", "01", null, "Caraz", null, "12", null, null },
                    { 449, "PE", null, "02", "02", null, "Huallanca", null, "12", null, null },
                    { 450, "PE", null, "02", "03", null, "Huata", null, "12", null, null },
                    { 451, "PE", null, "02", "04", null, "Huaylas", null, "12", null, null },
                    { 452, "PE", null, "02", "05", null, "Mato", null, "12", null, null },
                    { 453, "PE", null, "02", "06", null, "Pamparomas", null, "12", null, null },
                    { 454, "PE", null, "02", "07", null, "Pueblo Libre", null, "12", null, null },
                    { 455, "PE", null, "02", "08", null, "Santa Cruz", null, "12", null, null },
                    { 456, "PE", null, "02", "09", null, "Santo Toribio", null, "12", null, null },
                    { 457, "PE", null, "02", "10", null, "Yuracmarca", null, "12", null, null },
                    { 458, "PE", null, "02", "00", null, "Mariscal Luzuriaga", null, "13", null, null },
                    { 459, "PE", null, "02", "01", null, "Piscobamba", null, "13", null, null },
                    { 460, "PE", null, "02", "02", null, "Casca", null, "13", null, null },
                    { 461, "PE", null, "02", "03", null, "Eleazar Guzman Barron", null, "13", null, null },
                    { 462, "PE", null, "02", "04", null, "Fidel Olivas Escudero", null, "13", null, null },
                    { 463, "PE", null, "02", "05", null, "Llama", null, "13", null, null },
                    { 464, "PE", null, "02", "06", null, "Llumpa", null, "13", null, null },
                    { 465, "PE", null, "02", "07", null, "Lucma", null, "13", null, null },
                    { 466, "PE", null, "02", "08", null, "Musga", null, "13", null, null },
                    { 467, "PE", null, "02", "00", null, "Ocros", null, "14", null, null },
                    { 468, "PE", null, "02", "01", null, "Ocros", null, "14", null, null },
                    { 469, "PE", null, "02", "02", null, "Acas", null, "14", null, null },
                    { 470, "PE", null, "02", "03", null, "Cajamarquilla", null, "14", null, null },
                    { 471, "PE", null, "02", "04", null, "Carhuapampa", null, "14", null, null },
                    { 472, "PE", null, "02", "05", null, "Cochas", null, "14", null, null },
                    { 473, "PE", null, "02", "06", null, "Congas", null, "14", null, null },
                    { 474, "PE", null, "02", "07", null, "Llipa", null, "14", null, null },
                    { 475, "PE", null, "02", "08", null, "San Cristobal de Rajan", null, "14", null, null },
                    { 476, "PE", null, "02", "09", null, "San Pedro", null, "14", null, null },
                    { 477, "PE", null, "02", "10", null, "Santiago de Chilcas", null, "14", null, null },
                    { 478, "PE", null, "02", "00", null, "Pallasca", null, "15", null, null },
                    { 479, "PE", null, "02", "01", null, "Cabana", null, "15", null, null },
                    { 480, "PE", null, "02", "02", null, "Bolognesi", null, "15", null, null },
                    { 481, "PE", null, "02", "03", null, "Conchucos", null, "15", null, null },
                    { 482, "PE", null, "02", "04", null, "Huacaschuque", null, "15", null, null },
                    { 483, "PE", null, "02", "05", null, "Huandoval", null, "15", null, null },
                    { 484, "PE", null, "02", "06", null, "Lacabamba", null, "15", null, null },
                    { 485, "PE", null, "02", "07", null, "Llapo", null, "15", null, null },
                    { 486, "PE", null, "02", "08", null, "Pallasca", null, "15", null, null },
                    { 487, "PE", null, "02", "09", null, "Pampas", null, "15", null, null },
                    { 488, "PE", null, "02", "10", null, "Santa Rosa", null, "15", null, null },
                    { 489, "PE", null, "02", "11", null, "Tauca", null, "15", null, null },
                    { 490, "PE", null, "02", "00", null, "Pomabamba", null, "16", null, null },
                    { 491, "PE", null, "02", "01", null, "Pomabamba", null, "16", null, null },
                    { 492, "PE", null, "02", "02", null, "Huayllan", null, "16", null, null },
                    { 493, "PE", null, "02", "03", null, "Parobamba", null, "16", null, null },
                    { 494, "PE", null, "02", "04", null, "Quinuabamba", null, "16", null, null },
                    { 495, "PE", null, "02", "00", null, "Recuay", null, "17", null, null },
                    { 496, "PE", null, "02", "01", null, "Recuay", null, "17", null, null },
                    { 497, "PE", null, "02", "02", null, "Catac", null, "17", null, null },
                    { 498, "PE", null, "02", "03", null, "Cotaparaco", null, "17", null, null },
                    { 499, "PE", null, "02", "04", null, "Huayllapampa", null, "17", null, null },
                    { 500, "PE", null, "02", "05", null, "Llacllin", null, "17", null, null },
                    { 501, "PE", null, "02", "06", null, "Marca", null, "17", null, null },
                    { 502, "PE", null, "02", "07", null, "Pampas Chico", null, "17", null, null },
                    { 503, "PE", null, "02", "08", null, "Pararin", null, "17", null, null },
                    { 504, "PE", null, "02", "09", null, "Tapacocha", null, "17", null, null },
                    { 505, "PE", null, "02", "10", null, "Ticapampa", null, "17", null, null },
                    { 506, "PE", null, "02", "00", null, "Santa", null, "18", null, null },
                    { 507, "PE", null, "02", "01", null, "Chimbote", null, "18", null, null },
                    { 508, "PE", null, "02", "02", null, "Caceres del Peru", null, "18", null, null },
                    { 509, "PE", null, "02", "03", null, "Coishco", null, "18", null, null },
                    { 510, "PE", null, "02", "04", null, "Macate", null, "18", null, null },
                    { 511, "PE", null, "02", "05", null, "Moro", null, "18", null, null },
                    { 512, "PE", null, "02", "06", null, "Nepeña", null, "18", null, null },
                    { 513, "PE", null, "02", "07", null, "Samanco", null, "18", null, null },
                    { 514, "PE", null, "02", "08", null, "Santa", null, "18", null, null },
                    { 515, "PE", null, "02", "09", null, "Nuevo Chimbote", null, "18", null, null },
                    { 516, "PE", null, "02", "00", null, "Sihuas", null, "19", null, null },
                    { 517, "PE", null, "02", "01", null, "Sihuas", null, "19", null, null },
                    { 518, "PE", null, "02", "02", null, "Acobamba", null, "19", null, null },
                    { 519, "PE", null, "02", "03", null, "Alfonso Ugarte", null, "19", null, null },
                    { 520, "PE", null, "02", "04", null, "Cashapampa", null, "19", null, null },
                    { 521, "PE", null, "02", "05", null, "Chingalpo", null, "19", null, null },
                    { 522, "PE", null, "02", "06", null, "Huayllabamba", null, "19", null, null },
                    { 523, "PE", null, "02", "07", null, "Quiches", null, "19", null, null },
                    { 524, "PE", null, "02", "08", null, "Ragash", null, "19", null, null },
                    { 525, "PE", null, "02", "09", null, "San Juan", null, "19", null, null },
                    { 526, "PE", null, "02", "10", null, "Sicsibamba", null, "19", null, null },
                    { 527, "PE", null, "02", "00", null, "Yungay", null, "20", null, null },
                    { 528, "PE", null, "02", "01", null, "Yungay", null, "20", null, null },
                    { 529, "PE", null, "02", "02", null, "Cascapara", null, "20", null, null },
                    { 530, "PE", null, "02", "03", null, "Mancos", null, "20", null, null },
                    { 531, "PE", null, "02", "04", null, "Matacoto", null, "20", null, null },
                    { 532, "PE", null, "02", "05", null, "Quillo", null, "20", null, null },
                    { 533, "PE", null, "02", "06", null, "Ranrahirca", null, "20", null, null },
                    { 534, "PE", null, "02", "07", null, "Shupluy", null, "20", null, null },
                    { 535, "PE", null, "02", "08", null, "Yanama", null, "20", null, null },
                    { 536, "PE", null, "03", "00", null, "Apurimac", null, "00", null, null },
                    { 537, "PE", null, "03", "00", null, "Abancay", null, "01", null, null },
                    { 538, "PE", null, "03", "01", null, "Abancay", null, "01", null, null },
                    { 539, "PE", null, "03", "02", null, "Chacoche", null, "01", null, null },
                    { 540, "PE", null, "03", "03", null, "Circa", null, "01", null, null },
                    { 541, "PE", null, "03", "04", null, "Curahuasi", null, "01", null, null },
                    { 542, "PE", null, "03", "05", null, "Huanipaca", null, "01", null, null },
                    { 543, "PE", null, "03", "06", null, "Lambrama", null, "01", null, null },
                    { 544, "PE", null, "03", "07", null, "Pichirhua", null, "01", null, null },
                    { 545, "PE", null, "03", "08", null, "San Pedro de Cachora", null, "01", null, null },
                    { 546, "PE", null, "03", "09", null, "Tamburco", null, "01", null, null },
                    { 547, "PE", null, "03", "00", null, "Andahuaylas", null, "02", null, null },
                    { 548, "PE", null, "03", "01", null, "Andahuaylas", null, "02", null, null },
                    { 549, "PE", null, "03", "02", null, "Andarapa", null, "02", null, null },
                    { 550, "PE", null, "03", "03", null, "Chiara", null, "02", null, null },
                    { 551, "PE", null, "03", "04", null, "Huancarama", null, "02", null, null },
                    { 552, "PE", null, "03", "05", null, "Huancaray", null, "02", null, null },
                    { 553, "PE", null, "03", "06", null, "Huayana", null, "02", null, null },
                    { 554, "PE", null, "03", "07", null, "Kishuara", null, "02", null, null },
                    { 555, "PE", null, "03", "08", null, "Pacobamba", null, "02", null, null },
                    { 556, "PE", null, "03", "09", null, "Pacucha", null, "02", null, null },
                    { 557, "PE", null, "03", "10", null, "Pampachiri", null, "02", null, null },
                    { 558, "PE", null, "03", "11", null, "Pomacocha", null, "02", null, null },
                    { 559, "PE", null, "03", "12", null, "San Antonio de Cachi", null, "02", null, null },
                    { 560, "PE", null, "03", "13", null, "San Jeronimo", null, "02", null, null },
                    { 561, "PE", null, "03", "14", null, "San Miguel de Chaccrampa", null, "02", null, null },
                    { 562, "PE", null, "03", "15", null, "Santa Maria de Chicmo", null, "02", null, null },
                    { 563, "PE", null, "03", "16", null, "Talavera", null, "02", null, null },
                    { 564, "PE", null, "03", "17", null, "Tumay Huaraca", null, "02", null, null },
                    { 565, "PE", null, "03", "18", null, "Turpo", null, "02", null, null },
                    { 566, "PE", null, "03", "19", null, "Kaquiabamba", null, "02", null, null },
                    { 567, "PE", null, "03", "00", null, "Antabamba", null, "03", null, null },
                    { 568, "PE", null, "03", "01", null, "Antabamba", null, "03", null, null },
                    { 569, "PE", null, "03", "02", null, "El Oro", null, "03", null, null },
                    { 570, "PE", null, "03", "03", null, "Huaquirca", null, "03", null, null },
                    { 571, "PE", null, "03", "04", null, "Juan Espinoza Medrano", null, "03", null, null },
                    { 572, "PE", null, "03", "05", null, "Oropesa", null, "03", null, null },
                    { 573, "PE", null, "03", "06", null, "Pachaconas", null, "03", null, null },
                    { 574, "PE", null, "03", "07", null, "Sabaino", null, "03", null, null },
                    { 575, "PE", null, "03", "00", null, "Aymaraes", null, "04", null, null },
                    { 576, "PE", null, "03", "01", null, "Chalhuanca", null, "04", null, null },
                    { 577, "PE", null, "03", "02", null, "Capaya", null, "04", null, null },
                    { 578, "PE", null, "03", "03", null, "Caraybamba", null, "04", null, null },
                    { 579, "PE", null, "03", "04", null, "Chapimarca", null, "04", null, null },
                    { 580, "PE", null, "03", "05", null, "Colcabamba", null, "04", null, null },
                    { 581, "PE", null, "03", "06", null, "Cotaruse", null, "04", null, null },
                    { 582, "PE", null, "03", "07", null, "Huayllo", null, "04", null, null },
                    { 583, "PE", null, "03", "08", null, "Justo Apu Sahuaraura", null, "04", null, null },
                    { 584, "PE", null, "03", "09", null, "Lucre", null, "04", null, null },
                    { 585, "PE", null, "03", "10", null, "Pocohuanca", null, "04", null, null },
                    { 586, "PE", null, "03", "11", null, "San Juan de Chacña", null, "04", null, null },
                    { 587, "PE", null, "03", "12", null, "Sañayca", null, "04", null, null },
                    { 588, "PE", null, "03", "13", null, "Soraya", null, "04", null, null },
                    { 589, "PE", null, "03", "14", null, "Tapairihua", null, "04", null, null },
                    { 590, "PE", null, "03", "15", null, "Tintay", null, "04", null, null },
                    { 591, "PE", null, "03", "16", null, "Toraya", null, "04", null, null },
                    { 592, "PE", null, "03", "17", null, "Yanaca", null, "04", null, null },
                    { 593, "PE", null, "03", "00", null, "Cotabambas", null, "05", null, null },
                    { 594, "PE", null, "03", "01", null, "Tambobamba", null, "05", null, null },
                    { 595, "PE", null, "03", "02", null, "Cotabambas", null, "05", null, null },
                    { 596, "PE", null, "03", "03", null, "Coyllurqui", null, "05", null, null },
                    { 597, "PE", null, "03", "04", null, "Haquira", null, "05", null, null },
                    { 598, "PE", null, "03", "05", null, "Mara", null, "05", null, null },
                    { 599, "PE", null, "03", "06", null, "Challhuahuacho", null, "05", null, null },
                    { 600, "PE", null, "03", "00", null, "Chincheros", null, "06", null, null },
                    { 601, "PE", null, "03", "01", null, "Chincheros", null, "06", null, null },
                    { 602, "PE", null, "03", "02", null, "Anco-Huallo", null, "06", null, null },
                    { 603, "PE", null, "03", "03", null, "Cocharcas", null, "06", null, null },
                    { 604, "PE", null, "03", "04", null, "Huaccana", null, "06", null, null },
                    { 605, "PE", null, "03", "05", null, "Ocobamba", null, "06", null, null },
                    { 606, "PE", null, "03", "06", null, "Ongoy", null, "06", null, null },
                    { 607, "PE", null, "03", "07", null, "Uranmarca", null, "06", null, null },
                    { 608, "PE", null, "03", "08", null, "Ranracancha", null, "06", null, null },
                    { 609, "PE", null, "03", "00", null, "Grau", null, "07", null, null },
                    { 610, "PE", null, "03", "01", null, "Chuquibambilla", null, "07", null, null },
                    { 611, "PE", null, "03", "02", null, "Curpahuasi", null, "07", null, null },
                    { 612, "PE", null, "03", "03", null, "Gamarra", null, "07", null, null },
                    { 613, "PE", null, "03", "04", null, "Huayllati", null, "07", null, null },
                    { 614, "PE", null, "03", "05", null, "Mamara", null, "07", null, null },
                    { 615, "PE", null, "03", "06", null, "Micaela Bastidas", null, "07", null, null },
                    { 616, "PE", null, "03", "07", null, "Pataypampa", null, "07", null, null },
                    { 617, "PE", null, "03", "08", null, "Progreso", null, "07", null, null },
                    { 618, "PE", null, "03", "09", null, "San Antonio", null, "07", null, null },
                    { 619, "PE", null, "03", "10", null, "Santa Rosa", null, "07", null, null },
                    { 620, "PE", null, "03", "11", null, "Turpay", null, "07", null, null },
                    { 621, "PE", null, "03", "12", null, "Vilcabamba", null, "07", null, null },
                    { 622, "PE", null, "03", "13", null, "Virundo", null, "07", null, null },
                    { 623, "PE", null, "03", "14", null, "Curasco", null, "07", null, null },
                    { 624, "PE", null, "04", "00", null, "Arequipa", null, "00", null, null },
                    { 625, "PE", null, "04", "00", null, "Arequipa", null, "01", null, null },
                    { 626, "PE", null, "04", "01", null, "Arequipa", null, "01", null, null },
                    { 627, "PE", null, "04", "02", null, "Alto Selva Alegre", null, "01", null, null },
                    { 628, "PE", null, "04", "03", null, "Cayma", null, "01", null, null },
                    { 629, "PE", null, "04", "04", null, "Cerro Colorado", null, "01", null, null },
                    { 630, "PE", null, "04", "05", null, "Characato", null, "01", null, null },
                    { 631, "PE", null, "04", "06", null, "Chiguata", null, "01", null, null },
                    { 632, "PE", null, "04", "07", null, "Jacobo Hunter", null, "01", null, null },
                    { 633, "PE", null, "04", "08", null, "La Joya", null, "01", null, null },
                    { 634, "PE", null, "04", "09", null, "Mariano Melgar", null, "01", null, null },
                    { 635, "PE", null, "04", "10", null, "Miraflores", null, "01", null, null },
                    { 636, "PE", null, "04", "11", null, "Mollebaya", null, "01", null, null },
                    { 637, "PE", null, "04", "12", null, "Paucarpata", null, "01", null, null },
                    { 638, "PE", null, "04", "13", null, "Pocsi", null, "01", null, null },
                    { 639, "PE", null, "04", "14", null, "Polobaya", null, "01", null, null },
                    { 640, "PE", null, "04", "15", null, "Quequeña", null, "01", null, null },
                    { 641, "PE", null, "04", "16", null, "Sabandia", null, "01", null, null },
                    { 642, "PE", null, "04", "17", null, "Sachaca", null, "01", null, null },
                    { 643, "PE", null, "04", "18", null, "San Juan de Siguas", null, "01", null, null },
                    { 644, "PE", null, "04", "19", null, "San Juan de Tarucani", null, "01", null, null },
                    { 645, "PE", null, "04", "20", null, "Santa Isabel de Siguas", null, "01", null, null },
                    { 646, "PE", null, "04", "21", null, "Santa Rita de Siguas", null, "01", null, null },
                    { 647, "PE", null, "04", "22", null, "Socabaya", null, "01", null, null },
                    { 648, "PE", null, "04", "23", null, "Tiabaya", null, "01", null, null },
                    { 649, "PE", null, "04", "24", null, "Uchumayo", null, "01", null, null },
                    { 650, "PE", null, "04", "25", null, "Vitor", null, "01", null, null },
                    { 651, "PE", null, "04", "26", null, "Yanahuara", null, "01", null, null },
                    { 652, "PE", null, "04", "27", null, "Yarabamba", null, "01", null, null },
                    { 653, "PE", null, "04", "28", null, "Yura", null, "01", null, null },
                    { 654, "PE", null, "04", "29", null, "Jose Luis Bustamante y Rivero", null, "01", null, null },
                    { 655, "PE", null, "04", "00", null, "Camana", null, "02", null, null },
                    { 656, "PE", null, "04", "01", null, "Camana", null, "02", null, null },
                    { 657, "PE", null, "04", "02", null, "Jose Maria Quimper", null, "02", null, null },
                    { 658, "PE", null, "04", "03", null, "Mariano Nicolas Valcarcel", null, "02", null, null },
                    { 659, "PE", null, "04", "04", null, "Mariscal Caceres", null, "02", null, null },
                    { 660, "PE", null, "04", "05", null, "Nicolas de Pierola", null, "02", null, null },
                    { 661, "PE", null, "04", "06", null, "Ocoña", null, "02", null, null },
                    { 662, "PE", null, "04", "07", null, "Quilca", null, "02", null, null },
                    { 663, "PE", null, "04", "08", null, "Samuel Pastor", null, "02", null, null },
                    { 664, "PE", null, "04", "00", null, "Caraveli", null, "03", null, null },
                    { 665, "PE", null, "04", "01", null, "Caraveli", null, "03", null, null },
                    { 666, "PE", null, "04", "02", null, "Acari", null, "03", null, null },
                    { 667, "PE", null, "04", "03", null, "Atico", null, "03", null, null },
                    { 668, "PE", null, "04", "04", null, "Atiquipa", null, "03", null, null },
                    { 669, "PE", null, "04", "05", null, "Bella Union", null, "03", null, null },
                    { 670, "PE", null, "04", "06", null, "Cahuacho", null, "03", null, null },
                    { 671, "PE", null, "04", "07", null, "Chala", null, "03", null, null },
                    { 672, "PE", null, "04", "08", null, "Chaparra", null, "03", null, null },
                    { 673, "PE", null, "04", "09", null, "Huanuhuanu", null, "03", null, null },
                    { 674, "PE", null, "04", "10", null, "Jaqui", null, "03", null, null },
                    { 675, "PE", null, "04", "11", null, "Lomas", null, "03", null, null },
                    { 676, "PE", null, "04", "12", null, "Quicacha", null, "03", null, null },
                    { 677, "PE", null, "04", "13", null, "Yauca", null, "03", null, null },
                    { 678, "PE", null, "04", "00", null, "Castilla", null, "04", null, null },
                    { 679, "PE", null, "04", "01", null, "Aplao", null, "04", null, null },
                    { 680, "PE", null, "04", "02", null, "Andagua", null, "04", null, null },
                    { 681, "PE", null, "04", "03", null, "Ayo", null, "04", null, null },
                    { 682, "PE", null, "04", "04", null, "Chachas", null, "04", null, null },
                    { 683, "PE", null, "04", "05", null, "Chilcaymarca", null, "04", null, null },
                    { 684, "PE", null, "04", "06", null, "Choco", null, "04", null, null },
                    { 685, "PE", null, "04", "07", null, "Huancarqui", null, "04", null, null },
                    { 686, "PE", null, "04", "08", null, "Machaguay", null, "04", null, null },
                    { 687, "PE", null, "04", "09", null, "Orcopampa", null, "04", null, null },
                    { 688, "PE", null, "04", "10", null, "Pampacolca", null, "04", null, null },
                    { 689, "PE", null, "04", "11", null, "Tipan", null, "04", null, null },
                    { 690, "PE", null, "04", "12", null, "Uñon", null, "04", null, null },
                    { 691, "PE", null, "04", "13", null, "Uraca", null, "04", null, null },
                    { 692, "PE", null, "04", "14", null, "Viraco", null, "04", null, null },
                    { 693, "PE", null, "04", "00", null, "Caylloma", null, "05", null, null },
                    { 694, "PE", null, "04", "01", null, "Chivay", null, "05", null, null },
                    { 695, "PE", null, "04", "02", null, "Achoma", null, "05", null, null },
                    { 696, "PE", null, "04", "03", null, "Cabanaconde", null, "05", null, null },
                    { 697, "PE", null, "04", "04", null, "Callalli", null, "05", null, null },
                    { 698, "PE", null, "04", "05", null, "Caylloma", null, "05", null, null },
                    { 699, "PE", null, "04", "06", null, "Coporaque", null, "05", null, null },
                    { 700, "PE", null, "04", "07", null, "Huambo", null, "05", null, null },
                    { 701, "PE", null, "04", "08", null, "Huanca", null, "05", null, null },
                    { 702, "PE", null, "04", "09", null, "Ichupampa", null, "05", null, null },
                    { 703, "PE", null, "04", "10", null, "Lari", null, "05", null, null },
                    { 704, "PE", null, "04", "11", null, "Lluta", null, "05", null, null },
                    { 705, "PE", null, "04", "12", null, "Maca", null, "05", null, null },
                    { 706, "PE", null, "04", "13", null, "Madrigal", null, "05", null, null },
                    { 707, "PE", null, "04", "14", null, "San Antonio de Chuca", null, "05", null, null },
                    { 708, "PE", null, "04", "15", null, "Sibayo", null, "05", null, null },
                    { 709, "PE", null, "04", "16", null, "Tapay", null, "05", null, null },
                    { 710, "PE", null, "04", "17", null, "Tisco", null, "05", null, null },
                    { 711, "PE", null, "04", "18", null, "Tuti", null, "05", null, null },
                    { 712, "PE", null, "04", "19", null, "Yanque", null, "05", null, null },
                    { 713, "PE", null, "04", "20", null, "Majes", null, "05", null, null },
                    { 714, "PE", null, "04", "00", null, "Condesuyos", null, "06", null, null },
                    { 715, "PE", null, "04", "01", null, "Chuquibamba", null, "06", null, null },
                    { 716, "PE", null, "04", "02", null, "Andaray", null, "06", null, null },
                    { 717, "PE", null, "04", "03", null, "Cayarani", null, "06", null, null },
                    { 718, "PE", null, "04", "04", null, "Chichas", null, "06", null, null },
                    { 719, "PE", null, "04", "05", null, "Iray", null, "06", null, null },
                    { 720, "PE", null, "04", "06", null, "Rio Grande", null, "06", null, null },
                    { 721, "PE", null, "04", "07", null, "Salamanca", null, "06", null, null },
                    { 722, "PE", null, "04", "08", null, "Yanaquihua", null, "06", null, null },
                    { 723, "PE", null, "04", "00", null, "Islay", null, "07", null, null },
                    { 724, "PE", null, "04", "01", null, "Mollendo", null, "07", null, null },
                    { 725, "PE", null, "04", "02", null, "Cocachacra", null, "07", null, null },
                    { 726, "PE", null, "04", "03", null, "Dean Valdivia", null, "07", null, null },
                    { 727, "PE", null, "04", "04", null, "Islay", null, "07", null, null },
                    { 728, "PE", null, "04", "05", null, "Mejia", null, "07", null, null },
                    { 729, "PE", null, "04", "06", null, "Punta de Bombon", null, "07", null, null },
                    { 730, "PE", null, "04", "00", null, "La Union", null, "08", null, null },
                    { 731, "PE", null, "04", "01", null, "Cotahuasi", null, "08", null, null },
                    { 732, "PE", null, "04", "02", null, "Alca", null, "08", null, null },
                    { 733, "PE", null, "04", "03", null, "Charcana", null, "08", null, null },
                    { 734, "PE", null, "04", "04", null, "Huaynacotas", null, "08", null, null },
                    { 735, "PE", null, "04", "05", null, "Pampamarca", null, "08", null, null },
                    { 736, "PE", null, "04", "06", null, "Puyca", null, "08", null, null },
                    { 737, "PE", null, "04", "07", null, "Quechualla", null, "08", null, null },
                    { 738, "PE", null, "04", "08", null, "Sayla", null, "08", null, null },
                    { 739, "PE", null, "04", "09", null, "Tauria", null, "08", null, null },
                    { 740, "PE", null, "04", "10", null, "Tomepampa", null, "08", null, null },
                    { 741, "PE", null, "04", "11", null, "Toro", null, "08", null, null },
                    { 742, "PE", null, "05", "00", null, "Ayacucho", null, "00", null, null },
                    { 743, "PE", null, "05", "00", null, "Huamanga", null, "01", null, null },
                    { 744, "PE", null, "05", "01", null, "Ayacucho", null, "01", null, null },
                    { 745, "PE", null, "05", "02", null, "Acocro", null, "01", null, null },
                    { 746, "PE", null, "05", "03", null, "Acos Vinchos", null, "01", null, null },
                    { 747, "PE", null, "05", "04", null, "Carmen Alto", null, "01", null, null },
                    { 748, "PE", null, "05", "05", null, "Chiara", null, "01", null, null },
                    { 749, "PE", null, "05", "06", null, "Ocros", null, "01", null, null },
                    { 750, "PE", null, "05", "07", null, "Pacaycasa", null, "01", null, null },
                    { 751, "PE", null, "05", "08", null, "Quinua", null, "01", null, null },
                    { 752, "PE", null, "05", "09", null, "San Jose de Ticllas", null, "01", null, null },
                    { 753, "PE", null, "05", "10", null, "San Juan Bautista", null, "01", null, null },
                    { 754, "PE", null, "05", "11", null, "Santiago de Pischa", null, "01", null, null },
                    { 755, "PE", null, "05", "12", null, "Socos", null, "01", null, null },
                    { 756, "PE", null, "05", "13", null, "Tambillo", null, "01", null, null },
                    { 757, "PE", null, "05", "14", null, "Vinchos", null, "01", null, null },
                    { 758, "PE", null, "05", "15", null, "Jesús Nazareno", null, "01", null, null },
                    { 759, "PE", null, "05", "16", null, "Andrés Avelino Cáceres Dorregay", null, "01", null, null },
                    { 760, "PE", null, "05", "00", null, "Cangallo", null, "02", null, null },
                    { 761, "PE", null, "05", "01", null, "Cangallo", null, "02", null, null },
                    { 762, "PE", null, "05", "02", null, "Chuschi", null, "02", null, null },
                    { 763, "PE", null, "05", "03", null, "Los Morochucos", null, "02", null, null },
                    { 764, "PE", null, "05", "04", null, "Maria Parado de Bellido", null, "02", null, null },
                    { 765, "PE", null, "05", "05", null, "Paras", null, "02", null, null },
                    { 766, "PE", null, "05", "06", null, "Totos", null, "02", null, null },
                    { 767, "PE", null, "05", "00", null, "Huanca Sancos", null, "03", null, null },
                    { 768, "PE", null, "05", "01", null, "Sancos", null, "03", null, null },
                    { 769, "PE", null, "05", "02", null, "Carapo", null, "03", null, null },
                    { 770, "PE", null, "05", "03", null, "Sacsamarca", null, "03", null, null },
                    { 771, "PE", null, "05", "04", null, "Santiago de Lucanamarca", null, "03", null, null },
                    { 772, "PE", null, "05", "00", null, "Huanta", null, "04", null, null },
                    { 773, "PE", null, "05", "01", null, "Huanta", null, "04", null, null },
                    { 774, "PE", null, "05", "02", null, "Ayahuanco", null, "04", null, null },
                    { 775, "PE", null, "05", "03", null, "Huamanguilla", null, "04", null, null },
                    { 776, "PE", null, "05", "04", null, "Iguain", null, "04", null, null },
                    { 777, "PE", null, "05", "05", null, "Luricocha", null, "04", null, null },
                    { 778, "PE", null, "05", "06", null, "Santillana", null, "04", null, null },
                    { 779, "PE", null, "05", "07", null, "Sivia", null, "04", null, null },
                    { 780, "PE", null, "05", "08", null, "Llochegua", null, "04", null, null },
                    { 781, "PE", null, "05", "09", null, "Canayre", null, "04", null, null },
                    { 782, "PE", null, "05", "10", null, "Uchuraccay", null, "04", null, null },
                    { 783, "PE", null, "05", "11", null, "Pucacolpa", null, "04", null, null },
                    { 784, "PE", null, "05", "00", null, "La Mar", null, "05", null, null },
                    { 785, "PE", null, "05", "01", null, "San Miguel", null, "05", null, null },
                    { 786, "PE", null, "05", "02", null, "Anco", null, "05", null, null },
                    { 787, "PE", null, "05", "03", null, "Ayna", null, "05", null, null },
                    { 788, "PE", null, "05", "04", null, "Chilcas", null, "05", null, null },
                    { 789, "PE", null, "05", "05", null, "Chungui", null, "05", null, null },
                    { 790, "PE", null, "05", "06", null, "Luis Carranza", null, "05", null, null },
                    { 791, "PE", null, "05", "07", null, "Santa Rosa", null, "05", null, null },
                    { 792, "PE", null, "05", "08", null, "Tambo", null, "05", null, null },
                    { 793, "PE", null, "05", "09", null, "Samugari", null, "05", null, null },
                    { 794, "PE", null, "05", "10", null, "Anchihuay", null, "05", null, null },
                    { 795, "PE", null, "05", "00", null, "Lucanas", null, "06", null, null },
                    { 796, "PE", null, "05", "01", null, "Puquio", null, "06", null, null },
                    { 797, "PE", null, "05", "02", null, "Aucara", null, "06", null, null },
                    { 798, "PE", null, "05", "03", null, "Cabana", null, "06", null, null },
                    { 799, "PE", null, "05", "04", null, "Carmen Salcedo", null, "06", null, null },
                    { 800, "PE", null, "05", "05", null, "Chaviña", null, "06", null, null },
                    { 801, "PE", null, "05", "06", null, "Chipao", null, "06", null, null },
                    { 802, "PE", null, "05", "07", null, "Huac-Huas", null, "06", null, null },
                    { 803, "PE", null, "05", "08", null, "Laramate", null, "06", null, null },
                    { 804, "PE", null, "05", "09", null, "Leoncio Prado", null, "06", null, null },
                    { 805, "PE", null, "05", "10", null, "Llauta", null, "06", null, null },
                    { 806, "PE", null, "05", "11", null, "Lucanas", null, "06", null, null },
                    { 807, "PE", null, "05", "12", null, "Ocaña", null, "06", null, null },
                    { 808, "PE", null, "05", "13", null, "Otoca", null, "06", null, null },
                    { 809, "PE", null, "05", "14", null, "Saisa", null, "06", null, null },
                    { 810, "PE", null, "05", "15", null, "San Cristobal", null, "06", null, null },
                    { 811, "PE", null, "05", "16", null, "San Juan", null, "06", null, null },
                    { 812, "PE", null, "05", "17", null, "San Pedro", null, "06", null, null },
                    { 813, "PE", null, "05", "18", null, "San Pedro de Palco", null, "06", null, null },
                    { 814, "PE", null, "05", "19", null, "Sancos", null, "06", null, null },
                    { 815, "PE", null, "05", "20", null, "Santa Ana de Huaycahuacho", null, "06", null, null },
                    { 816, "PE", null, "05", "21", null, "Santa Lucia", null, "06", null, null },
                    { 817, "PE", null, "05", "00", null, "Parinacochas", null, "07", null, null },
                    { 818, "PE", null, "05", "01", null, "Coracora", null, "07", null, null },
                    { 819, "PE", null, "05", "02", null, "Chumpi", null, "07", null, null },
                    { 820, "PE", null, "05", "03", null, "Coronel Castañeda", null, "07", null, null },
                    { 821, "PE", null, "05", "04", null, "Pacapausa", null, "07", null, null },
                    { 822, "PE", null, "05", "05", null, "Pullo", null, "07", null, null },
                    { 823, "PE", null, "05", "06", null, "Puyusca", null, "07", null, null },
                    { 824, "PE", null, "05", "07", null, "San Francisco de Ravacayco", null, "07", null, null },
                    { 825, "PE", null, "05", "08", null, "Upahuacho", null, "07", null, null },
                    { 826, "PE", null, "05", "00", null, "Paucar del Sara Sara", null, "08", null, null },
                    { 827, "PE", null, "05", "01", null, "Pausa", null, "08", null, null },
                    { 828, "PE", null, "05", "02", null, "Colta", null, "08", null, null },
                    { 829, "PE", null, "05", "03", null, "Corculla", null, "08", null, null },
                    { 830, "PE", null, "05", "04", null, "Lampa", null, "08", null, null },
                    { 831, "PE", null, "05", "05", null, "Marcabamba", null, "08", null, null },
                    { 832, "PE", null, "05", "06", null, "Oyolo", null, "08", null, null },
                    { 833, "PE", null, "05", "07", null, "Pararca", null, "08", null, null },
                    { 834, "PE", null, "05", "08", null, "San Javier de Alpabamba", null, "08", null, null },
                    { 835, "PE", null, "05", "09", null, "San Jose de Ushua", null, "08", null, null },
                    { 836, "PE", null, "05", "10", null, "Sara Sara", null, "08", null, null },
                    { 837, "PE", null, "05", "00", null, "Sucre", null, "09", null, null },
                    { 838, "PE", null, "05", "01", null, "Querobamba", null, "09", null, null },
                    { 839, "PE", null, "05", "02", null, "Belen", null, "09", null, null },
                    { 840, "PE", null, "05", "03", null, "Chalcos", null, "09", null, null },
                    { 841, "PE", null, "05", "04", null, "Chilcayoc", null, "09", null, null },
                    { 842, "PE", null, "05", "05", null, "Huacaña", null, "09", null, null },
                    { 843, "PE", null, "05", "06", null, "Morcolla", null, "09", null, null },
                    { 844, "PE", null, "05", "07", null, "Paico", null, "09", null, null },
                    { 845, "PE", null, "05", "08", null, "San Pedro de Larcay", null, "09", null, null },
                    { 846, "PE", null, "05", "09", null, "San Salvador de Quije", null, "09", null, null },
                    { 847, "PE", null, "05", "10", null, "Santiago de Paucaray", null, "09", null, null },
                    { 848, "PE", null, "05", "11", null, "Soras", null, "09", null, null },
                    { 849, "PE", null, "05", "00", null, "Victor Fajardo", null, "10", null, null },
                    { 850, "PE", null, "05", "01", null, "Huancapi", null, "10", null, null },
                    { 851, "PE", null, "05", "02", null, "Alcamenca", null, "10", null, null },
                    { 852, "PE", null, "05", "03", null, "Apongo", null, "10", null, null },
                    { 853, "PE", null, "05", "04", null, "Asquipata", null, "10", null, null },
                    { 854, "PE", null, "05", "05", null, "Canaria", null, "10", null, null },
                    { 855, "PE", null, "05", "06", null, "Cayara", null, "10", null, null },
                    { 856, "PE", null, "05", "07", null, "Colca", null, "10", null, null },
                    { 857, "PE", null, "05", "08", null, "Huamanquiquia", null, "10", null, null },
                    { 858, "PE", null, "05", "09", null, "Huancaraylla", null, "10", null, null },
                    { 859, "PE", null, "05", "10", null, "Huaya", null, "10", null, null },
                    { 860, "PE", null, "05", "11", null, "Sarhua", null, "10", null, null },
                    { 861, "PE", null, "05", "12", null, "Vilcanchos", null, "10", null, null },
                    { 862, "PE", null, "05", "00", null, "Vilcas Huaman", null, "11", null, null },
                    { 863, "PE", null, "05", "01", null, "Vilcas Huaman", null, "11", null, null },
                    { 864, "PE", null, "05", "02", null, "Accomarca", null, "11", null, null },
                    { 865, "PE", null, "05", "03", null, "Carhuanca", null, "11", null, null },
                    { 866, "PE", null, "05", "04", null, "Concepcion", null, "11", null, null },
                    { 867, "PE", null, "05", "05", null, "Huambalpa", null, "11", null, null },
                    { 868, "PE", null, "05", "06", null, "Independencia", null, "11", null, null },
                    { 869, "PE", null, "05", "07", null, "Saurama", null, "11", null, null },
                    { 870, "PE", null, "05", "08", null, "Vischongo", null, "11", null, null },
                    { 871, "PE", null, "06", "00", null, "Cajamarca", null, "00", null, null },
                    { 872, "PE", null, "06", "00", null, "Cajamarca", null, "01", null, null },
                    { 873, "PE", null, "06", "01", null, "Cajamarca", null, "01", null, null },
                    { 874, "PE", null, "06", "02", null, "Asuncion", null, "01", null, null },
                    { 875, "PE", null, "06", "03", null, "Chetilla", null, "01", null, null },
                    { 876, "PE", null, "06", "04", null, "Cospan", null, "01", null, null },
                    { 877, "PE", null, "06", "05", null, "Encañada", null, "01", null, null },
                    { 878, "PE", null, "06", "06", null, "Jesus", null, "01", null, null },
                    { 879, "PE", null, "06", "07", null, "Llacanora", null, "01", null, null },
                    { 880, "PE", null, "06", "08", null, "Los Baños del Inca", null, "01", null, null },
                    { 881, "PE", null, "06", "09", null, "Magdalena", null, "01", null, null },
                    { 882, "PE", null, "06", "10", null, "Matara", null, "01", null, null },
                    { 883, "PE", null, "06", "11", null, "Namora", null, "01", null, null },
                    { 884, "PE", null, "06", "12", null, "San Juan", null, "01", null, null },
                    { 885, "PE", null, "06", "00", null, "Cajabamba", null, "02", null, null },
                    { 886, "PE", null, "06", "01", null, "Cajabamba", null, "02", null, null },
                    { 887, "PE", null, "06", "02", null, "Cachachi", null, "02", null, null },
                    { 888, "PE", null, "06", "03", null, "Condebamba", null, "02", null, null },
                    { 889, "PE", null, "06", "04", null, "Sitacocha", null, "02", null, null },
                    { 890, "PE", null, "06", "00", null, "Celendin", null, "03", null, null },
                    { 891, "PE", null, "06", "01", null, "Celendin", null, "03", null, null },
                    { 892, "PE", null, "06", "02", null, "Chumuch", null, "03", null, null },
                    { 893, "PE", null, "06", "03", null, "Cortegana", null, "03", null, null },
                    { 894, "PE", null, "06", "04", null, "Huasmin", null, "03", null, null },
                    { 895, "PE", null, "06", "05", null, "Jorge Chavez", null, "03", null, null },
                    { 896, "PE", null, "06", "06", null, "Jose Galvez", null, "03", null, null },
                    { 897, "PE", null, "06", "07", null, "Miguel Iglesias", null, "03", null, null },
                    { 898, "PE", null, "06", "08", null, "Oxamarca", null, "03", null, null },
                    { 899, "PE", null, "06", "09", null, "Sorochuco", null, "03", null, null },
                    { 900, "PE", null, "06", "10", null, "Sucre", null, "03", null, null },
                    { 901, "PE", null, "06", "11", null, "Utco", null, "03", null, null },
                    { 902, "PE", null, "06", "12", null, "La Libertad de Pallan", null, "03", null, null },
                    { 903, "PE", null, "06", "00", null, "Chota", null, "04", null, null },
                    { 904, "PE", null, "06", "01", null, "Chota", null, "04", null, null },
                    { 905, "PE", null, "06", "02", null, "Anguia", null, "04", null, null },
                    { 906, "PE", null, "06", "03", null, "Chadin", null, "04", null, null },
                    { 907, "PE", null, "06", "04", null, "Chiguirip", null, "04", null, null },
                    { 908, "PE", null, "06", "05", null, "Chimban", null, "04", null, null },
                    { 909, "PE", null, "06", "06", null, "Choropampa", null, "04", null, null },
                    { 910, "PE", null, "06", "07", null, "Cochabamba", null, "04", null, null },
                    { 911, "PE", null, "06", "08", null, "Conchan", null, "04", null, null },
                    { 912, "PE", null, "06", "09", null, "Huambos", null, "04", null, null },
                    { 913, "PE", null, "06", "10", null, "Lajas", null, "04", null, null },
                    { 914, "PE", null, "06", "11", null, "Llama", null, "04", null, null },
                    { 915, "PE", null, "06", "12", null, "Miracosta", null, "04", null, null },
                    { 916, "PE", null, "06", "13", null, "Paccha", null, "04", null, null },
                    { 917, "PE", null, "06", "14", null, "Pion", null, "04", null, null },
                    { 918, "PE", null, "06", "15", null, "Querocoto", null, "04", null, null },
                    { 919, "PE", null, "06", "16", null, "San Juan de Licupis", null, "04", null, null },
                    { 920, "PE", null, "06", "17", null, "Tacabamba", null, "04", null, null },
                    { 921, "PE", null, "06", "18", null, "Tocmoche", null, "04", null, null },
                    { 922, "PE", null, "06", "19", null, "Chalamarca", null, "04", null, null },
                    { 923, "PE", null, "06", "00", null, "Contumaza", null, "05", null, null },
                    { 924, "PE", null, "06", "01", null, "Contumaza", null, "05", null, null },
                    { 925, "PE", null, "06", "02", null, "Chilete", null, "05", null, null },
                    { 926, "PE", null, "06", "03", null, "Cupisnique", null, "05", null, null },
                    { 927, "PE", null, "06", "04", null, "Guzmango", null, "05", null, null },
                    { 928, "PE", null, "06", "05", null, "San Benito", null, "05", null, null },
                    { 929, "PE", null, "06", "06", null, "Santa Cruz de Toled", null, "05", null, null },
                    { 930, "PE", null, "06", "07", null, "Tantarica", null, "05", null, null },
                    { 931, "PE", null, "06", "08", null, "Yonan", null, "05", null, null },
                    { 932, "PE", null, "06", "00", null, "Cutervo", null, "06", null, null },
                    { 933, "PE", null, "06", "01", null, "Cutervo", null, "06", null, null },
                    { 934, "PE", null, "06", "02", null, "Callayuc", null, "06", null, null },
                    { 935, "PE", null, "06", "03", null, "Choros", null, "06", null, null },
                    { 936, "PE", null, "06", "04", null, "Cujillo", null, "06", null, null },
                    { 937, "PE", null, "06", "05", null, "La Ramada", null, "06", null, null },
                    { 938, "PE", null, "06", "06", null, "Pimpingos", null, "06", null, null },
                    { 939, "PE", null, "06", "07", null, "Querocotillo", null, "06", null, null },
                    { 940, "PE", null, "06", "08", null, "San Andres de Cutervo", null, "06", null, null },
                    { 941, "PE", null, "06", "09", null, "San Juan de Cutervo", null, "06", null, null },
                    { 942, "PE", null, "06", "10", null, "San Luis de Lucma", null, "06", null, null },
                    { 943, "PE", null, "06", "11", null, "Santa Cruz", null, "06", null, null },
                    { 944, "PE", null, "06", "12", null, "Santo Domingo de la Capilla", null, "06", null, null },
                    { 945, "PE", null, "06", "13", null, "Santo Tomas", null, "06", null, null },
                    { 946, "PE", null, "06", "14", null, "Socota", null, "06", null, null },
                    { 947, "PE", null, "06", "15", null, "Toribio Casanova", null, "06", null, null },
                    { 948, "PE", null, "06", "00", null, "Hualgayoc", null, "07", null, null },
                    { 949, "PE", null, "06", "01", null, "Bambamarca", null, "07", null, null },
                    { 950, "PE", null, "06", "02", null, "Chugur", null, "07", null, null },
                    { 951, "PE", null, "06", "03", null, "Hualgayoc", null, "07", null, null },
                    { 952, "PE", null, "06", "00", null, "Jaen", null, "08", null, null },
                    { 953, "PE", null, "06", "01", null, "Jaen", null, "08", null, null },
                    { 954, "PE", null, "06", "02", null, "Bellavista", null, "08", null, null },
                    { 955, "PE", null, "06", "03", null, "Chontali", null, "08", null, null },
                    { 956, "PE", null, "06", "04", null, "Colasay", null, "08", null, null },
                    { 957, "PE", null, "06", "05", null, "Huabal", null, "08", null, null },
                    { 958, "PE", null, "06", "06", null, "Las Pirias", null, "08", null, null },
                    { 959, "PE", null, "06", "07", null, "Pomahuaca", null, "08", null, null },
                    { 960, "PE", null, "06", "08", null, "Pucara", null, "08", null, null },
                    { 961, "PE", null, "06", "09", null, "Sallique", null, "08", null, null },
                    { 962, "PE", null, "06", "10", null, "San Felipe", null, "08", null, null },
                    { 963, "PE", null, "06", "11", null, "San Jose del Alto", null, "08", null, null },
                    { 964, "PE", null, "06", "12", null, "Santa Rosa", null, "08", null, null },
                    { 965, "PE", null, "06", "00", null, "San Ignacio", null, "09", null, null },
                    { 966, "PE", null, "06", "01", null, "San Ignacio", null, "09", null, null },
                    { 967, "PE", null, "06", "02", null, "Chirinos", null, "09", null, null },
                    { 968, "PE", null, "06", "03", null, "Huarango", null, "09", null, null },
                    { 969, "PE", null, "06", "04", null, "La Coipa", null, "09", null, null },
                    { 970, "PE", null, "06", "05", null, "Namballe", null, "09", null, null },
                    { 971, "PE", null, "06", "06", null, "San Jose de Lourdes", null, "09", null, null },
                    { 972, "PE", null, "06", "07", null, "Tabaconas", null, "09", null, null },
                    { 973, "PE", null, "06", "00", null, "San Marcos", null, "10", null, null },
                    { 974, "PE", null, "06", "01", null, "Pedro Galvez", null, "10", null, null },
                    { 975, "PE", null, "06", "02", null, "Chancay", null, "10", null, null },
                    { 976, "PE", null, "06", "03", null, "Eduardo Villanueva", null, "10", null, null },
                    { 977, "PE", null, "06", "04", null, "Gregorio Pita", null, "10", null, null },
                    { 978, "PE", null, "06", "05", null, "Ichocan", null, "10", null, null },
                    { 979, "PE", null, "06", "06", null, "Jose Manuel Quiroz", null, "10", null, null },
                    { 980, "PE", null, "06", "07", null, "Jose Sabogal", null, "10", null, null },
                    { 981, "PE", null, "06", "00", null, "San Miguel", null, "11", null, null },
                    { 982, "PE", null, "06", "01", null, "San Miguel", null, "11", null, null },
                    { 983, "PE", null, "06", "02", null, "Bolivar", null, "11", null, null },
                    { 984, "PE", null, "06", "03", null, "Calquis", null, "11", null, null },
                    { 985, "PE", null, "06", "04", null, "Catilluc", null, "11", null, null },
                    { 986, "PE", null, "06", "05", null, "El Prado", null, "11", null, null },
                    { 987, "PE", null, "06", "06", null, "La Florida", null, "11", null, null },
                    { 988, "PE", null, "06", "07", null, "Llapa", null, "11", null, null },
                    { 989, "PE", null, "06", "08", null, "Nanchoc", null, "11", null, null },
                    { 990, "PE", null, "06", "09", null, "Niepos", null, "11", null, null },
                    { 991, "PE", null, "06", "10", null, "San Gregorio", null, "11", null, null },
                    { 992, "PE", null, "06", "11", null, "San Silvestre de Cochan", null, "11", null, null },
                    { 993, "PE", null, "06", "12", null, "Tongod", null, "11", null, null },
                    { 994, "PE", null, "06", "13", null, "Union Agua Blanca", null, "11", null, null },
                    { 995, "PE", null, "06", "00", null, "San Pablo", null, "12", null, null },
                    { 996, "PE", null, "06", "01", null, "San Pablo", null, "12", null, null },
                    { 997, "PE", null, "06", "02", null, "San Bernardino", null, "12", null, null },
                    { 998, "PE", null, "06", "03", null, "San Luis", null, "12", null, null },
                    { 999, "PE", null, "06", "04", null, "Tumbaden", null, "12", null, null },
                    { 1000, "PE", null, "06", "00", null, "Santa Cruz", null, "13", null, null },
                    { 1001, "PE", null, "06", "01", null, "Santa Cruz", null, "13", null, null },
                    { 1002, "PE", null, "06", "02", null, "Andabamba", null, "13", null, null },
                    { 1003, "PE", null, "06", "03", null, "Catache", null, "13", null, null },
                    { 1004, "PE", null, "06", "04", null, "Chancaybaños", null, "13", null, null },
                    { 1005, "PE", null, "06", "05", null, "La Esperanza", null, "13", null, null },
                    { 1006, "PE", null, "06", "06", null, "Ninabamba", null, "13", null, null },
                    { 1007, "PE", null, "06", "07", null, "Pulan", null, "13", null, null },
                    { 1008, "PE", null, "06", "08", null, "Saucepampa", null, "13", null, null },
                    { 1009, "PE", null, "06", "09", null, "Sexi", null, "13", null, null },
                    { 1010, "PE", null, "06", "10", null, "Uticyacu", null, "13", null, null },
                    { 1011, "PE", null, "06", "11", null, "Yauyucan", null, "13", null, null },
                    { 1012, "PE", null, "07", "00", null, "Callao", null, "00", null, null },
                    { 1013, "PE", null, "07", "00", null, "Prov. Const. del Callao", null, "01", null, null },
                    { 1014, "PE", null, "07", "01", null, "Callao", null, "01", null, null },
                    { 1015, "PE", null, "07", "02", null, "Bellavista", null, "01", null, null },
                    { 1016, "PE", null, "07", "03", null, "Carmen de la Legua Reynoso", null, "01", null, null },
                    { 1017, "PE", null, "07", "04", null, "La Perla", null, "01", null, null },
                    { 1018, "PE", null, "07", "05", null, "La Punta", null, "01", null, null },
                    { 1019, "PE", null, "07", "06", null, "Ventanilla", null, "01", null, null },
                    { 1020, "PE", null, "07", "07", null, "Mi Perú", null, "01", null, null },
                    { 1021, "PE", null, "08", "00", null, "Cusco", null, "00", null, null },
                    { 1022, "PE", null, "08", "00", null, "Cusco", null, "01", null, null },
                    { 1023, "PE", null, "08", "01", null, "Cusco", null, "01", null, null },
                    { 1024, "PE", null, "08", "02", null, "Ccorca", null, "01", null, null },
                    { 1025, "PE", null, "08", "03", null, "Poroy", null, "01", null, null },
                    { 1026, "PE", null, "08", "04", null, "San Jeronimo", null, "01", null, null },
                    { 1027, "PE", null, "08", "05", null, "San Sebastian", null, "01", null, null },
                    { 1028, "PE", null, "08", "06", null, "Santiago", null, "01", null, null },
                    { 1029, "PE", null, "08", "07", null, "Saylla", null, "01", null, null },
                    { 1030, "PE", null, "08", "08", null, "Wanchaq", null, "01", null, null },
                    { 1031, "PE", null, "08", "00", null, "Acomayo", null, "02", null, null },
                    { 1032, "PE", null, "08", "01", null, "Acomayo", null, "02", null, null },
                    { 1033, "PE", null, "08", "02", null, "Acopia", null, "02", null, null },
                    { 1034, "PE", null, "08", "03", null, "Acos", null, "02", null, null },
                    { 1035, "PE", null, "08", "04", null, "Mosoc Llacta", null, "02", null, null },
                    { 1036, "PE", null, "08", "05", null, "Pomacanchi", null, "02", null, null },
                    { 1037, "PE", null, "08", "06", null, "Rondocan", null, "02", null, null },
                    { 1038, "PE", null, "08", "07", null, "Sangarara", null, "02", null, null },
                    { 1039, "PE", null, "08", "00", null, "Anta", null, "03", null, null },
                    { 1040, "PE", null, "08", "01", null, "Anta", null, "03", null, null },
                    { 1041, "PE", null, "08", "02", null, "Ancahuasi", null, "03", null, null },
                    { 1042, "PE", null, "08", "03", null, "Cachimayo", null, "03", null, null },
                    { 1043, "PE", null, "08", "04", null, "Chinchaypujio", null, "03", null, null },
                    { 1044, "PE", null, "08", "05", null, "Huarocondo", null, "03", null, null },
                    { 1045, "PE", null, "08", "06", null, "Limatambo", null, "03", null, null },
                    { 1046, "PE", null, "08", "07", null, "Mollepata", null, "03", null, null },
                    { 1047, "PE", null, "08", "08", null, "Pucyura", null, "03", null, null },
                    { 1048, "PE", null, "08", "09", null, "Zurite", null, "03", null, null },
                    { 1049, "PE", null, "08", "00", null, "Calca", null, "04", null, null },
                    { 1050, "PE", null, "08", "01", null, "Calca", null, "04", null, null },
                    { 1051, "PE", null, "08", "02", null, "Coya", null, "04", null, null },
                    { 1052, "PE", null, "08", "03", null, "Lamay", null, "04", null, null },
                    { 1053, "PE", null, "08", "04", null, "Lares", null, "04", null, null },
                    { 1054, "PE", null, "08", "05", null, "Pisac", null, "04", null, null },
                    { 1055, "PE", null, "08", "06", null, "San Salvador", null, "04", null, null },
                    { 1056, "PE", null, "08", "07", null, "Taray", null, "04", null, null },
                    { 1057, "PE", null, "08", "08", null, "Yanatile", null, "04", null, null },
                    { 1058, "PE", null, "08", "00", null, "Canas", null, "05", null, null },
                    { 1059, "PE", null, "08", "01", null, "Yanaoca", null, "05", null, null },
                    { 1060, "PE", null, "08", "02", null, "Checca", null, "05", null, null },
                    { 1061, "PE", null, "08", "03", null, "Kunturkanki", null, "05", null, null },
                    { 1062, "PE", null, "08", "04", null, "Langui", null, "05", null, null },
                    { 1063, "PE", null, "08", "05", null, "Layo", null, "05", null, null },
                    { 1064, "PE", null, "08", "06", null, "Pampamarca", null, "05", null, null },
                    { 1065, "PE", null, "08", "07", null, "Quehue", null, "05", null, null },
                    { 1066, "PE", null, "08", "08", null, "Tupac Amaru", null, "05", null, null },
                    { 1067, "PE", null, "08", "00", null, "Canchis", null, "06", null, null },
                    { 1068, "PE", null, "08", "01", null, "Sicuani", null, "06", null, null },
                    { 1069, "PE", null, "08", "02", null, "Checacupe", null, "06", null, null },
                    { 1070, "PE", null, "08", "03", null, "Combapata", null, "06", null, null },
                    { 1071, "PE", null, "08", "04", null, "Marangani", null, "06", null, null },
                    { 1072, "PE", null, "08", "05", null, "Pitumarca", null, "06", null, null },
                    { 1073, "PE", null, "08", "06", null, "San Pablo", null, "06", null, null },
                    { 1074, "PE", null, "08", "07", null, "San Pedro", null, "06", null, null },
                    { 1075, "PE", null, "08", "08", null, "Tinta", null, "06", null, null },
                    { 1076, "PE", null, "08", "00", null, "Chumbivilcas", null, "07", null, null },
                    { 1077, "PE", null, "08", "01", null, "Santo Tomas", null, "07", null, null },
                    { 1078, "PE", null, "08", "02", null, "Capacmarca", null, "07", null, null },
                    { 1079, "PE", null, "08", "03", null, "Chamaca", null, "07", null, null },
                    { 1080, "PE", null, "08", "04", null, "Colquemarca", null, "07", null, null },
                    { 1081, "PE", null, "08", "05", null, "Livitaca", null, "07", null, null },
                    { 1082, "PE", null, "08", "06", null, "Llusco", null, "07", null, null },
                    { 1083, "PE", null, "08", "07", null, "Quiñota", null, "07", null, null },
                    { 1084, "PE", null, "08", "08", null, "Velille", null, "07", null, null },
                    { 1085, "PE", null, "08", "00", null, "Espinar", null, "08", null, null },
                    { 1086, "PE", null, "08", "01", null, "Espinar", null, "08", null, null },
                    { 1087, "PE", null, "08", "02", null, "Condoroma", null, "08", null, null },
                    { 1088, "PE", null, "08", "03", null, "Coporaque", null, "08", null, null },
                    { 1089, "PE", null, "08", "04", null, "Ocoruro", null, "08", null, null },
                    { 1090, "PE", null, "08", "05", null, "Pallpata", null, "08", null, null },
                    { 1091, "PE", null, "08", "06", null, "Pichigua", null, "08", null, null },
                    { 1092, "PE", null, "08", "07", null, "Suyckutambo", null, "08", null, null },
                    { 1093, "PE", null, "08", "08", null, "Alto Pichigua", null, "08", null, null },
                    { 1094, "PE", null, "08", "00", null, "La Convencion", null, "09", null, null },
                    { 1095, "PE", null, "08", "01", null, "Santa Ana", null, "09", null, null },
                    { 1096, "PE", null, "08", "02", null, "Echarate", null, "09", null, null },
                    { 1097, "PE", null, "08", "03", null, "Huayopata", null, "09", null, null },
                    { 1098, "PE", null, "08", "04", null, "Maranura", null, "09", null, null },
                    { 1099, "PE", null, "08", "05", null, "Ocobamba", null, "09", null, null },
                    { 1100, "PE", null, "08", "06", null, "Quellouno", null, "09", null, null },
                    { 1101, "PE", null, "08", "07", null, "Kimbiri", null, "09", null, null },
                    { 1102, "PE", null, "08", "08", null, "Santa Teresa", null, "09", null, null },
                    { 1103, "PE", null, "08", "09", null, "Vilcabamba", null, "09", null, null },
                    { 1104, "PE", null, "08", "10", null, "Pichari", null, "09", null, null },
                    { 1105, "PE", null, "08", "11", null, "Inkawasi", null, "09", null, null },
                    { 1106, "PE", null, "08", "12", null, "Villa Virgen", null, "09", null, null },
                    { 1107, "PE", null, "08", "00", null, "Paruro", null, "10", null, null },
                    { 1108, "PE", null, "08", "01", null, "Paruro", null, "10", null, null },
                    { 1109, "PE", null, "08", "02", null, "Accha", null, "10", null, null },
                    { 1110, "PE", null, "08", "03", null, "Ccapi", null, "10", null, null },
                    { 1111, "PE", null, "08", "04", null, "Colcha", null, "10", null, null },
                    { 1112, "PE", null, "08", "05", null, "Huanoquite", null, "10", null, null },
                    { 1113, "PE", null, "08", "06", null, "Omacha", null, "10", null, null },
                    { 1114, "PE", null, "08", "07", null, "Paccaritambo", null, "10", null, null },
                    { 1115, "PE", null, "08", "08", null, "Pillpinto", null, "10", null, null },
                    { 1116, "PE", null, "08", "09", null, "Yaurisque", null, "10", null, null },
                    { 1117, "PE", null, "08", "00", null, "Paucartambo", null, "11", null, null },
                    { 1118, "PE", null, "08", "01", null, "Paucartambo", null, "11", null, null },
                    { 1119, "PE", null, "08", "02", null, "Caicay", null, "11", null, null },
                    { 1120, "PE", null, "08", "03", null, "Challabamba", null, "11", null, null },
                    { 1121, "PE", null, "08", "04", null, "Colquepata", null, "11", null, null },
                    { 1122, "PE", null, "08", "05", null, "Huancarani", null, "11", null, null },
                    { 1123, "PE", null, "08", "06", null, "Kosñipata", null, "11", null, null },
                    { 1124, "PE", null, "08", "00", null, "Quispicanchi", null, "12", null, null },
                    { 1125, "PE", null, "08", "01", null, "Urcos", null, "12", null, null },
                    { 1126, "PE", null, "08", "02", null, "Andahuaylillas", null, "12", null, null },
                    { 1127, "PE", null, "08", "03", null, "Camanti", null, "12", null, null },
                    { 1128, "PE", null, "08", "04", null, "Ccarhuayo", null, "12", null, null },
                    { 1129, "PE", null, "08", "05", null, "Ccatca", null, "12", null, null },
                    { 1130, "PE", null, "08", "06", null, "Cusipata", null, "12", null, null },
                    { 1131, "PE", null, "08", "07", null, "Huaro", null, "12", null, null },
                    { 1132, "PE", null, "08", "08", null, "Lucre", null, "12", null, null },
                    { 1133, "PE", null, "08", "09", null, "Marcapata", null, "12", null, null },
                    { 1134, "PE", null, "08", "10", null, "Ocongate", null, "12", null, null },
                    { 1135, "PE", null, "08", "11", null, "Oropesa", null, "12", null, null },
                    { 1136, "PE", null, "08", "12", null, "Quiquijana", null, "12", null, null },
                    { 1137, "PE", null, "08", "00", null, "Urubamba", null, "13", null, null },
                    { 1138, "PE", null, "08", "01", null, "Urubamba", null, "13", null, null },
                    { 1139, "PE", null, "08", "02", null, "Chinchero", null, "13", null, null },
                    { 1140, "PE", null, "08", "03", null, "Huayllabamba", null, "13", null, null },
                    { 1141, "PE", null, "08", "04", null, "Machupicchu", null, "13", null, null },
                    { 1142, "PE", null, "08", "05", null, "Maras", null, "13", null, null },
                    { 1143, "PE", null, "08", "06", null, "Ollantaytambo", null, "13", null, null },
                    { 1144, "PE", null, "08", "07", null, "Yucay", null, "13", null, null },
                    { 1145, "PE", null, "09", "00", null, "Huancavelica", null, "00", null, null },
                    { 1146, "PE", null, "09", "00", null, "Huancavelica", null, "01", null, null },
                    { 1147, "PE", null, "09", "01", null, "Huancavelica", null, "01", null, null },
                    { 1148, "PE", null, "09", "02", null, "Acobambilla", null, "01", null, null },
                    { 1149, "PE", null, "09", "03", null, "Acoria", null, "01", null, null },
                    { 1150, "PE", null, "09", "04", null, "Conayca", null, "01", null, null },
                    { 1151, "PE", null, "09", "05", null, "Cuenca", null, "01", null, null },
                    { 1152, "PE", null, "09", "06", null, "Huachocolpa", null, "01", null, null },
                    { 1153, "PE", null, "09", "07", null, "Huayllahuara", null, "01", null, null },
                    { 1154, "PE", null, "09", "08", null, "Izcuchaca", null, "01", null, null },
                    { 1155, "PE", null, "09", "09", null, "Laria", null, "01", null, null },
                    { 1156, "PE", null, "09", "10", null, "Manta", null, "01", null, null },
                    { 1157, "PE", null, "09", "11", null, "Mariscal Caceres", null, "01", null, null },
                    { 1158, "PE", null, "09", "12", null, "Moya", null, "01", null, null },
                    { 1159, "PE", null, "09", "13", null, "Nuevo Occoro", null, "01", null, null },
                    { 1160, "PE", null, "09", "14", null, "Palca", null, "01", null, null },
                    { 1161, "PE", null, "09", "15", null, "Pilchaca", null, "01", null, null },
                    { 1162, "PE", null, "09", "16", null, "Vilca", null, "01", null, null },
                    { 1163, "PE", null, "09", "17", null, "Yauli", null, "01", null, null },
                    { 1164, "PE", null, "09", "18", null, "Ascensión", null, "01", null, null },
                    { 1165, "PE", null, "09", "19", null, "Huando", null, "01", null, null },
                    { 1166, "PE", null, "09", "00", null, "Acobamba", null, "02", null, null },
                    { 1167, "PE", null, "09", "01", null, "Acobamba", null, "02", null, null },
                    { 1168, "PE", null, "09", "02", null, "Andabamba", null, "02", null, null },
                    { 1169, "PE", null, "09", "03", null, "Anta", null, "02", null, null },
                    { 1170, "PE", null, "09", "04", null, "Caja", null, "02", null, null },
                    { 1171, "PE", null, "09", "05", null, "Marcas", null, "02", null, null },
                    { 1172, "PE", null, "09", "06", null, "Paucara", null, "02", null, null },
                    { 1173, "PE", null, "09", "07", null, "Pomacocha", null, "02", null, null },
                    { 1174, "PE", null, "09", "08", null, "Rosario", null, "02", null, null },
                    { 1175, "PE", null, "09", "00", null, "Angaraes", null, "03", null, null },
                    { 1176, "PE", null, "09", "01", null, "Lircay", null, "03", null, null },
                    { 1177, "PE", null, "09", "02", null, "Anchonga", null, "03", null, null },
                    { 1178, "PE", null, "09", "03", null, "Callanmarca", null, "03", null, null },
                    { 1179, "PE", null, "09", "04", null, "Ccochaccasa", null, "03", null, null },
                    { 1180, "PE", null, "09", "05", null, "Chincho", null, "03", null, null },
                    { 1181, "PE", null, "09", "06", null, "Congalla", null, "03", null, null },
                    { 1182, "PE", null, "09", "07", null, "Huanca-Huanca", null, "03", null, null },
                    { 1183, "PE", null, "09", "08", null, "Huayllay Grande", null, "03", null, null },
                    { 1184, "PE", null, "09", "09", null, "Julcamarca", null, "03", null, null },
                    { 1185, "PE", null, "09", "10", null, "San Antonio de Antaparco", null, "03", null, null },
                    { 1186, "PE", null, "09", "11", null, "Santo Tomas de Pata", null, "03", null, null },
                    { 1187, "PE", null, "09", "12", null, "Secclla", null, "03", null, null },
                    { 1188, "PE", null, "09", "00", null, "Castrovirreyna", null, "04", null, null },
                    { 1189, "PE", null, "09", "01", null, "Castrovirreyna", null, "04", null, null },
                    { 1190, "PE", null, "09", "02", null, "Arma", null, "04", null, null },
                    { 1191, "PE", null, "09", "03", null, "Aurahua", null, "04", null, null },
                    { 1192, "PE", null, "09", "04", null, "Capillas", null, "04", null, null },
                    { 1193, "PE", null, "09", "05", null, "Chupamarca", null, "04", null, null },
                    { 1194, "PE", null, "09", "06", null, "Cocas", null, "04", null, null },
                    { 1195, "PE", null, "09", "07", null, "Huachos", null, "04", null, null },
                    { 1196, "PE", null, "09", "08", null, "Huamatambo", null, "04", null, null },
                    { 1197, "PE", null, "09", "09", null, "Mollepampa", null, "04", null, null },
                    { 1198, "PE", null, "09", "10", null, "San Juan", null, "04", null, null },
                    { 1199, "PE", null, "09", "11", null, "Santa Ana", null, "04", null, null },
                    { 1200, "PE", null, "09", "12", null, "Tantara", null, "04", null, null },
                    { 1201, "PE", null, "09", "13", null, "Ticrapo", null, "04", null, null },
                    { 1202, "PE", null, "09", "00", null, "Churcampa", null, "05", null, null },
                    { 1203, "PE", null, "09", "01", null, "Churcampa", null, "05", null, null },
                    { 1204, "PE", null, "09", "02", null, "Anco", null, "05", null, null },
                    { 1205, "PE", null, "09", "03", null, "Chinchihuasi", null, "05", null, null },
                    { 1206, "PE", null, "09", "04", null, "El Carmen", null, "05", null, null },
                    { 1207, "PE", null, "09", "05", null, "La Merced", null, "05", null, null },
                    { 1208, "PE", null, "09", "06", null, "Locroja", null, "05", null, null },
                    { 1209, "PE", null, "09", "07", null, "Paucarbamba", null, "05", null, null },
                    { 1210, "PE", null, "09", "08", null, "San Miguel de Mayocc", null, "05", null, null },
                    { 1211, "PE", null, "09", "09", null, "San Pedro de Coris", null, "05", null, null },
                    { 1212, "PE", null, "09", "10", null, "Pachamarca", null, "05", null, null },
                    { 1213, "PE", null, "09", "11", null, "Cosme", null, "05", null, null },
                    { 1214, "PE", null, "09", "00", null, "Huaytara", null, "06", null, null },
                    { 1215, "PE", null, "09", "01", null, "Huaytara", null, "06", null, null },
                    { 1216, "PE", null, "09", "02", null, "Ayavi", null, "06", null, null },
                    { 1217, "PE", null, "09", "03", null, "Cordova", null, "06", null, null },
                    { 1218, "PE", null, "09", "04", null, "Huayacundo Arma", null, "06", null, null },
                    { 1219, "PE", null, "09", "05", null, "Laramarca", null, "06", null, null },
                    { 1220, "PE", null, "09", "06", null, "Ocoyo", null, "06", null, null },
                    { 1221, "PE", null, "09", "07", null, "Pilpichaca", null, "06", null, null },
                    { 1222, "PE", null, "09", "08", null, "Querco", null, "06", null, null },
                    { 1223, "PE", null, "09", "09", null, "Quito-Arma", null, "06", null, null },
                    { 1224, "PE", null, "09", "10", null, "San Antonio de Cusicancha", null, "06", null, null },
                    { 1225, "PE", null, "09", "11", null, "San Francisco de Sangayaico", null, "06", null, null },
                    { 1226, "PE", null, "09", "12", null, "San Isidro", null, "06", null, null },
                    { 1227, "PE", null, "09", "13", null, "Santiago de Chocorvos", null, "06", null, null },
                    { 1228, "PE", null, "09", "14", null, "Santiago de Quirahuara", null, "06", null, null },
                    { 1229, "PE", null, "09", "15", null, "Santo Domingo de Capillas", null, "06", null, null },
                    { 1230, "PE", null, "09", "16", null, "Tambo", null, "06", null, null },
                    { 1231, "PE", null, "09", "00", null, "Tayacaja", null, "07", null, null },
                    { 1232, "PE", null, "09", "01", null, "Pampas", null, "07", null, null },
                    { 1233, "PE", null, "09", "02", null, "Acostambo", null, "07", null, null },
                    { 1234, "PE", null, "09", "03", null, "Acraquia", null, "07", null, null },
                    { 1235, "PE", null, "09", "04", null, "Ahuaycha", null, "07", null, null },
                    { 1236, "PE", null, "09", "05", null, "Colcabamba", null, "07", null, null },
                    { 1237, "PE", null, "09", "06", null, "Daniel Hernandez", null, "07", null, null },
                    { 1238, "PE", null, "09", "07", null, "Huachocolpa", null, "07", null, null },
                    { 1239, "PE", null, "09", "09", null, "Huaribamba", null, "07", null, null },
                    { 1240, "PE", null, "09", "10", null, "Ñahuimpuquio", null, "07", null, null },
                    { 1241, "PE", null, "09", "11", null, "Pazos", null, "07", null, null },
                    { 1242, "PE", null, "09", "13", null, "Quishuar", null, "07", null, null },
                    { 1243, "PE", null, "09", "14", null, "Salcabamba", null, "07", null, null },
                    { 1244, "PE", null, "09", "15", null, "Salcahuasi", null, "07", null, null },
                    { 1245, "PE", null, "09", "16", null, "San Marcos de Rocchac", null, "07", null, null },
                    { 1246, "PE", null, "09", "17", null, "Surcubamba", null, "07", null, null },
                    { 1247, "PE", null, "09", "18", null, "Tintay Puncu", null, "07", null, null },
                    { 1248, "PE", null, "10", "00", null, "Huanuco", null, "00", null, null },
                    { 1249, "PE", null, "10", "00", null, "Huanuco", null, "01", null, null },
                    { 1250, "PE", null, "10", "01", null, "Huanuco", null, "01", null, null },
                    { 1251, "PE", null, "10", "02", null, "Amarilis", null, "01", null, null },
                    { 1252, "PE", null, "10", "03", null, "Chinchao", null, "01", null, null },
                    { 1253, "PE", null, "10", "04", null, "Churubamba", null, "01", null, null },
                    { 1254, "PE", null, "10", "05", null, "Margos", null, "01", null, null },
                    { 1255, "PE", null, "10", "06", null, "Quisqui", null, "01", null, null },
                    { 1256, "PE", null, "10", "07", null, "San Francisco de Cayran", null, "01", null, null },
                    { 1257, "PE", null, "10", "08", null, "San Pedro de Chaulan", null, "01", null, null },
                    { 1258, "PE", null, "10", "09", null, "Santa Maria del Valle", null, "01", null, null },
                    { 1259, "PE", null, "10", "10", null, "Yarumayo", null, "01", null, null },
                    { 1260, "PE", null, "10", "11", null, "Pillco Marca", null, "01", null, null },
                    { 1261, "PE", null, "10", "12", null, "Yacus", null, "01", null, null },
                    { 1262, "PE", null, "10", "00", null, "Ambo", null, "02", null, null },
                    { 1263, "PE", null, "10", "01", null, "Ambo", null, "02", null, null },
                    { 1264, "PE", null, "10", "02", null, "Cayna", null, "02", null, null },
                    { 1265, "PE", null, "10", "03", null, "Colpas", null, "02", null, null },
                    { 1266, "PE", null, "10", "04", null, "Conchamarca", null, "02", null, null },
                    { 1267, "PE", null, "10", "05", null, "Huacar", null, "02", null, null },
                    { 1268, "PE", null, "10", "06", null, "San Francisco", null, "02", null, null },
                    { 1269, "PE", null, "10", "07", null, "San Rafael", null, "02", null, null },
                    { 1270, "PE", null, "10", "08", null, "Tomay Kichwa", null, "02", null, null },
                    { 1271, "PE", null, "10", "00", null, "Dos de Mayo", null, "03", null, null },
                    { 1272, "PE", null, "10", "01", null, "La Union", null, "03", null, null },
                    { 1273, "PE", null, "10", "07", null, "Chuquis", null, "03", null, null },
                    { 1274, "PE", null, "10", "11", null, "Marias", null, "03", null, null },
                    { 1275, "PE", null, "10", "13", null, "Pachas", null, "03", null, null },
                    { 1276, "PE", null, "10", "16", null, "Quivilla", null, "03", null, null },
                    { 1277, "PE", null, "10", "17", null, "Ripan", null, "03", null, null },
                    { 1278, "PE", null, "10", "21", null, "Shunqui", null, "03", null, null },
                    { 1279, "PE", null, "10", "22", null, "Sillapata", null, "03", null, null },
                    { 1280, "PE", null, "10", "23", null, "Yanas", null, "03", null, null },
                    { 1281, "PE", null, "10", "00", null, "Huacaybamba", null, "04", null, null },
                    { 1282, "PE", null, "10", "01", null, "Huacaybamba", null, "04", null, null },
                    { 1283, "PE", null, "10", "02", null, "Canchabamba", null, "04", null, null },
                    { 1284, "PE", null, "10", "03", null, "Cochabamba", null, "04", null, null },
                    { 1285, "PE", null, "10", "04", null, "Pinra", null, "04", null, null },
                    { 1286, "PE", null, "10", "00", null, "Huamalies", null, "05", null, null },
                    { 1287, "PE", null, "10", "01", null, "Llata", null, "05", null, null },
                    { 1288, "PE", null, "10", "02", null, "Arancay", null, "05", null, null },
                    { 1289, "PE", null, "10", "03", null, "Chavin de Pariarca", null, "05", null, null },
                    { 1290, "PE", null, "10", "04", null, "Jacas Grande", null, "05", null, null },
                    { 1291, "PE", null, "10", "05", null, "Jircan", null, "05", null, null },
                    { 1292, "PE", null, "10", "06", null, "Miraflores", null, "05", null, null },
                    { 1293, "PE", null, "10", "07", null, "Monzon", null, "05", null, null },
                    { 1294, "PE", null, "10", "08", null, "Punchao", null, "05", null, null },
                    { 1295, "PE", null, "10", "09", null, "Puños", null, "05", null, null },
                    { 1296, "PE", null, "13", "03", null, "Pueblo Nuevo", null, "04", null, null },
                    { 1297, "PE", null, "13", "00", null, "Julcan", null, "05", null, null },
                    { 1298, "PE", null, "13", "01", null, "Julcan", null, "05", null, null },
                    { 1299, "PE", null, "13", "02", null, "Calamarca", null, "05", null, null },
                    { 1300, "PE", null, "13", "03", null, "Carabamba", null, "05", null, null },
                    { 1301, "PE", null, "13", "04", null, "Huaso", null, "05", null, null },
                    { 1302, "PE", null, "13", "00", null, "Otuzco", null, "06", null, null },
                    { 1303, "PE", null, "13", "01", null, "Otuzco", null, "06", null, null },
                    { 1304, "PE", null, "13", "02", null, "Agallpampa", null, "06", null, null },
                    { 1305, "PE", null, "13", "04", null, "Charat", null, "06", null, null },
                    { 1306, "PE", null, "13", "05", null, "Huaranchal", null, "06", null, null },
                    { 1307, "PE", null, "13", "06", null, "La Cuesta", null, "06", null, null },
                    { 1308, "PE", null, "13", "08", null, "Mache", null, "06", null, null },
                    { 1309, "PE", null, "13", "10", null, "Paranday", null, "06", null, null },
                    { 1310, "PE", null, "13", "11", null, "Salpo", null, "06", null, null },
                    { 1311, "PE", null, "13", "13", null, "Sinsicap", null, "06", null, null },
                    { 1312, "PE", null, "13", "14", null, "Usquil", null, "06", null, null },
                    { 1313, "PE", null, "13", "00", null, "Pacasmayo", null, "07", null, null },
                    { 1314, "PE", null, "13", "01", null, "San Pedro de Lloc", null, "07", null, null },
                    { 1315, "PE", null, "13", "02", null, "Guadalupe", null, "07", null, null },
                    { 1316, "PE", null, "13", "03", null, "Jequetepeque", null, "07", null, null },
                    { 1317, "PE", null, "13", "04", null, "Pacasmayo", null, "07", null, null },
                    { 1318, "PE", null, "13", "05", null, "San Jose", null, "07", null, null },
                    { 1319, "PE", null, "13", "00", null, "Pataz", null, "08", null, null },
                    { 1320, "PE", null, "13", "01", null, "Tayabamba", null, "08", null, null },
                    { 1321, "PE", null, "13", "02", null, "Buldibuyo", null, "08", null, null },
                    { 1322, "PE", null, "13", "03", null, "Chillia", null, "08", null, null },
                    { 1323, "PE", null, "13", "04", null, "Huancaspata", null, "08", null, null },
                    { 1324, "PE", null, "13", "05", null, "Huaylillas", null, "08", null, null },
                    { 1325, "PE", null, "13", "06", null, "Huayo", null, "08", null, null },
                    { 1326, "PE", null, "13", "07", null, "Ongon", null, "08", null, null },
                    { 1327, "PE", null, "13", "08", null, "Parcoy", null, "08", null, null },
                    { 1328, "PE", null, "13", "09", null, "Pataz", null, "08", null, null },
                    { 1329, "PE", null, "13", "10", null, "Pias", null, "08", null, null },
                    { 1330, "PE", null, "13", "11", null, "Santiago de Challas", null, "08", null, null },
                    { 1331, "PE", null, "13", "12", null, "Taurija", null, "08", null, null },
                    { 1332, "PE", null, "13", "13", null, "Urpay", null, "08", null, null },
                    { 1333, "PE", null, "13", "00", null, "Sanchez Carrion", null, "09", null, null },
                    { 1334, "PE", null, "13", "01", null, "Huamachuco", null, "09", null, null },
                    { 1335, "PE", null, "13", "02", null, "Chugay", null, "09", null, null },
                    { 1336, "PE", null, "13", "03", null, "Cochorco", null, "09", null, null },
                    { 1337, "PE", null, "13", "04", null, "Curgos", null, "09", null, null },
                    { 1338, "PE", null, "13", "05", null, "Marcabal", null, "09", null, null },
                    { 1339, "PE", null, "13", "06", null, "Sanagoran", null, "09", null, null },
                    { 1340, "PE", null, "13", "07", null, "Sarin", null, "09", null, null },
                    { 1341, "PE", null, "13", "08", null, "Sartimbamba", null, "09", null, null },
                    { 1342, "PE", null, "13", "00", null, "Santiago de Chuco", null, "10", null, null },
                    { 1343, "PE", null, "13", "01", null, "Santiago de Chuco", null, "10", null, null },
                    { 1344, "PE", null, "13", "02", null, "Angasmarca", null, "10", null, null },
                    { 1345, "PE", null, "13", "03", null, "Cachicadan", null, "10", null, null },
                    { 1346, "PE", null, "13", "04", null, "Mollebamba", null, "10", null, null },
                    { 1347, "PE", null, "13", "05", null, "Mollepata", null, "10", null, null },
                    { 1348, "PE", null, "13", "06", null, "Quiruvilca", null, "10", null, null },
                    { 1349, "PE", null, "13", "07", null, "Santa Cruz de Chuca", null, "10", null, null },
                    { 1350, "PE", null, "13", "08", null, "Sitabamba", null, "10", null, null },
                    { 1351, "PE", null, "13", "00", null, "Gran Chimu", null, "11", null, null },
                    { 1352, "PE", null, "13", "01", null, "Cascas", null, "11", null, null },
                    { 1353, "PE", null, "13", "02", null, "Lucma", null, "11", null, null },
                    { 1354, "PE", null, "13", "03", null, "Marmot", null, "11", null, null },
                    { 1355, "PE", null, "13", "04", null, "Sayapullo", null, "11", null, null },
                    { 1356, "PE", null, "13", "00", null, "Viru", null, "12", null, null },
                    { 1357, "PE", null, "13", "01", null, "Viru", null, "12", null, null },
                    { 1358, "PE", null, "13", "02", null, "Chao", null, "12", null, null },
                    { 1359, "PE", null, "13", "03", null, "Guadalupito", null, "12", null, null },
                    { 1360, "PE", null, "14", "00", null, "Lambayeque", null, "00", null, null },
                    { 1361, "PE", null, "14", "00", null, "Chiclayo", null, "01", null, null },
                    { 1362, "PE", null, "14", "01", null, "Chiclayo", null, "01", null, null },
                    { 1363, "PE", null, "14", "02", null, "Chongoyape", null, "01", null, null },
                    { 1364, "PE", null, "14", "03", null, "Eten", null, "01", null, null },
                    { 1365, "PE", null, "14", "04", null, "Eten Puerto", null, "01", null, null },
                    { 1366, "PE", null, "14", "05", null, "Jose Leonardo Ortiz", null, "01", null, null },
                    { 1367, "PE", null, "14", "06", null, "La Victoria", null, "01", null, null },
                    { 1368, "PE", null, "14", "07", null, "Lagunas", null, "01", null, null },
                    { 1369, "PE", null, "14", "08", null, "Monsefu", null, "01", null, null },
                    { 1370, "PE", null, "14", "09", null, "Nueva Arica", null, "01", null, null },
                    { 1371, "PE", null, "14", "10", null, "Oyotun", null, "01", null, null },
                    { 1372, "PE", null, "14", "11", null, "Picsi", null, "01", null, null },
                    { 1373, "PE", null, "14", "12", null, "Pimentel", null, "01", null, null },
                    { 1374, "PE", null, "14", "13", null, "Reque", null, "01", null, null },
                    { 1375, "PE", null, "14", "14", null, "Santa Rosa", null, "01", null, null },
                    { 1376, "PE", null, "14", "15", null, "Saña", null, "01", null, null },
                    { 1377, "PE", null, "14", "16", null, "Cayaltí", null, "01", null, null },
                    { 1378, "PE", null, "14", "17", null, "Patapo", null, "01", null, null },
                    { 1379, "PE", null, "14", "18", null, "Pomalca", null, "01", null, null },
                    { 1380, "PE", null, "14", "19", null, "Pucalá", null, "01", null, null },
                    { 1381, "PE", null, "14", "20", null, "Tumán", null, "01", null, null },
                    { 1382, "PE", null, "14", "00", null, "Ferreñafe", null, "02", null, null },
                    { 1383, "PE", null, "14", "01", null, "Ferreñafe", null, "02", null, null },
                    { 1384, "PE", null, "14", "02", null, "Cañaris", null, "02", null, null },
                    { 1385, "PE", null, "14", "03", null, "Incahuasi", null, "02", null, null },
                    { 1386, "PE", null, "14", "04", null, "Manuel Antonio Mesones Muro", null, "02", null, null },
                    { 1387, "PE", null, "14", "05", null, "Pitipo", null, "02", null, null },
                    { 1388, "PE", null, "14", "06", null, "Pueblo Nuevo", null, "02", null, null },
                    { 1389, "PE", null, "14", "00", null, "Lambayeque", null, "03", null, null },
                    { 1390, "PE", null, "14", "01", null, "Lambayeque", null, "03", null, null },
                    { 1391, "PE", null, "14", "02", null, "Chochope", null, "03", null, null },
                    { 1392, "PE", null, "14", "03", null, "Illimo", null, "03", null, null },
                    { 1393, "PE", null, "14", "04", null, "Jayanca", null, "03", null, null },
                    { 1394, "PE", null, "14", "05", null, "Mochumi", null, "03", null, null },
                    { 1395, "PE", null, "14", "06", null, "Morrope", null, "03", null, null },
                    { 1396, "PE", null, "14", "07", null, "Motupe", null, "03", null, null },
                    { 1397, "PE", null, "14", "08", null, "Olmos", null, "03", null, null },
                    { 1398, "PE", null, "14", "09", null, "Pacora", null, "03", null, null },
                    { 1399, "PE", null, "14", "10", null, "Salas", null, "03", null, null },
                    { 1400, "PE", null, "14", "11", null, "San Jose", null, "03", null, null },
                    { 1401, "PE", null, "14", "12", null, "Tucume", null, "03", null, null },
                    { 1402, "PE", null, "15", "00", null, "Lima", null, "00", null, null },
                    { 1403, "PE", null, "15", "00", null, "Lima", null, "01", null, null },
                    { 1404, "PE", null, "15", "01", null, "Lima", null, "01", null, null },
                    { 1405, "PE", null, "15", "02", null, "Ancon", null, "01", null, null },
                    { 1406, "PE", null, "15", "03", null, "Ate", null, "01", null, null },
                    { 1407, "PE", null, "15", "04", null, "Barranco", null, "01", null, null },
                    { 1408, "PE", null, "15", "05", null, "Breña", null, "01", null, null },
                    { 1409, "PE", null, "15", "06", null, "Carabayllo", null, "01", null, null },
                    { 1410, "PE", null, "15", "07", null, "Chaclacayo", null, "01", null, null },
                    { 1411, "PE", null, "15", "08", null, "Chorrillos", null, "01", null, null },
                    { 1412, "PE", null, "15", "09", null, "Cieneguilla", null, "01", null, null },
                    { 1413, "PE", null, "15", "10", null, "Comas", null, "01", null, null },
                    { 1414, "PE", null, "15", "11", null, "El Agustino", null, "01", null, null },
                    { 1415, "PE", null, "15", "12", null, "Independencia", null, "01", null, null },
                    { 1416, "PE", null, "15", "13", null, "Jesus Maria", null, "01", null, null },
                    { 1417, "PE", null, "15", "14", null, "La Molina", null, "01", null, null },
                    { 1418, "PE", null, "15", "15", null, "La Victoria", null, "01", null, null },
                    { 1419, "PE", null, "15", "16", null, "Lince", null, "01", null, null },
                    { 1420, "PE", null, "15", "17", null, "Los Olivos", null, "01", null, null },
                    { 1421, "PE", null, "15", "18", null, "Lurigancho", null, "01", null, null },
                    { 1422, "PE", null, "15", "19", null, "Lurin", null, "01", null, null },
                    { 1423, "PE", null, "15", "20", null, "Magdalena del Mar", null, "01", null, null },
                    { 1424, "PE", null, "15", "21", null, "Pueblo Libre (Magdalena Vieja)", null, "01", null, null },
                    { 1425, "PE", null, "15", "22", null, "Miraflores", null, "01", null, null },
                    { 1426, "PE", null, "15", "23", null, "Pachacamac", null, "01", null, null },
                    { 1427, "PE", null, "15", "24", null, "Pucusana", null, "01", null, null },
                    { 1428, "PE", null, "15", "25", null, "Puente Piedra", null, "01", null, null },
                    { 1429, "PE", null, "15", "26", null, "Punta Hermosa", null, "01", null, null },
                    { 1430, "PE", null, "15", "27", null, "Punta Negra", null, "01", null, null },
                    { 1431, "PE", null, "15", "28", null, "Rimac", null, "01", null, null },
                    { 1432, "PE", null, "15", "29", null, "San Bartolo", null, "01", null, null },
                    { 1433, "PE", null, "15", "30", null, "San Borja", null, "01", null, null },
                    { 1434, "PE", null, "15", "31", null, "San Isidro", null, "01", null, null },
                    { 1435, "PE", null, "15", "32", null, "San Juan de Lurigancho", null, "01", null, null },
                    { 1436, "PE", null, "15", "33", null, "San Juan de Miraflores", null, "01", null, null },
                    { 1437, "PE", null, "15", "34", null, "San Luis", null, "01", null, null },
                    { 1438, "PE", null, "15", "35", null, "San Martin de Porres", null, "01", null, null },
                    { 1439, "PE", null, "15", "36", null, "San Miguel", null, "01", null, null },
                    { 1440, "PE", null, "15", "37", null, "Santa Anita", null, "01", null, null },
                    { 1441, "PE", null, "15", "38", null, "Santa Maria del Mar", null, "01", null, null },
                    { 1442, "PE", null, "15", "39", null, "Santa Rosa", null, "01", null, null },
                    { 1443, "PE", null, "15", "40", null, "Santiago de Surco", null, "01", null, null },
                    { 1444, "PE", null, "15", "41", null, "Surquillo", null, "01", null, null },
                    { 1445, "PE", null, "15", "42", null, "Villa El Salvador", null, "01", null, null },
                    { 1446, "PE", null, "15", "43", null, "Villa Maria del Triunfo", null, "01", null, null },
                    { 1447, "PE", null, "15", "00", null, "Barranca", null, "02", null, null },
                    { 1448, "PE", null, "15", "01", null, "Barranca", null, "02", null, null },
                    { 1449, "PE", null, "15", "02", null, "Paramonga", null, "02", null, null },
                    { 1450, "PE", null, "15", "03", null, "Pativilca", null, "02", null, null },
                    { 1451, "PE", null, "15", "04", null, "Supe", null, "02", null, null },
                    { 1452, "PE", null, "15", "05", null, "Supe Puerto", null, "02", null, null },
                    { 1453, "PE", null, "15", "00", null, "Cajatambo", null, "03", null, null },
                    { 1454, "PE", null, "15", "01", null, "Cajatambo", null, "03", null, null },
                    { 1455, "PE", null, "15", "02", null, "Copa", null, "03", null, null },
                    { 1456, "PE", null, "15", "03", null, "Gorgor", null, "03", null, null },
                    { 1457, "PE", null, "15", "04", null, "Huancapon", null, "03", null, null },
                    { 1458, "PE", null, "15", "05", null, "Manas", null, "03", null, null },
                    { 1459, "PE", null, "15", "00", null, "Canta", null, "04", null, null },
                    { 1460, "PE", null, "15", "01", null, "Canta", null, "04", null, null },
                    { 1461, "PE", null, "15", "02", null, "Arahuay", null, "04", null, null },
                    { 1462, "PE", null, "15", "03", null, "Huamantanga", null, "04", null, null },
                    { 1463, "PE", null, "15", "04", null, "Huaros", null, "04", null, null },
                    { 1464, "PE", null, "15", "05", null, "Lachaqui", null, "04", null, null },
                    { 1465, "PE", null, "15", "06", null, "San Buenaventura", null, "04", null, null },
                    { 1466, "PE", null, "15", "07", null, "Santa Rosa de Quives", null, "04", null, null },
                    { 1467, "PE", null, "15", "00", null, "Cañete", null, "05", null, null },
                    { 1468, "PE", null, "15", "01", null, "San Vicente de Cañete", null, "05", null, null },
                    { 1469, "PE", null, "15", "02", null, "Asia", null, "05", null, null },
                    { 1470, "PE", null, "15", "03", null, "Calango", null, "05", null, null },
                    { 1471, "PE", null, "15", "04", null, "Cerro Azul", null, "05", null, null },
                    { 1472, "PE", null, "15", "05", null, "Chilca", null, "05", null, null },
                    { 1473, "PE", null, "15", "06", null, "Coayllo", null, "05", null, null },
                    { 1474, "PE", null, "15", "07", null, "Imperial", null, "05", null, null },
                    { 1475, "PE", null, "15", "08", null, "Lunahuana", null, "05", null, null },
                    { 1476, "PE", null, "15", "09", null, "Mala", null, "05", null, null },
                    { 1477, "PE", null, "15", "10", null, "Nuevo Imperial", null, "05", null, null },
                    { 1478, "PE", null, "15", "11", null, "Pacaran", null, "05", null, null },
                    { 1479, "PE", null, "15", "12", null, "Quilmana", null, "05", null, null },
                    { 1480, "PE", null, "15", "13", null, "San Antonio", null, "05", null, null },
                    { 1481, "PE", null, "15", "14", null, "San Luis", null, "05", null, null },
                    { 1482, "PE", null, "15", "15", null, "Santa Cruz de Flores", null, "05", null, null },
                    { 1483, "PE", null, "15", "16", null, "Zuñiga", null, "05", null, null },
                    { 1484, "PE", null, "15", "00", null, "Huaral", null, "06", null, null },
                    { 1485, "PE", null, "15", "01", null, "Huaral", null, "06", null, null },
                    { 1486, "PE", null, "15", "02", null, "Atavillos Alto", null, "06", null, null },
                    { 1487, "PE", null, "15", "03", null, "Atavillos Bajo", null, "06", null, null },
                    { 1488, "PE", null, "15", "04", null, "Aucallama", null, "06", null, null },
                    { 1489, "PE", null, "15", "05", null, "Chancay", null, "06", null, null },
                    { 1490, "PE", null, "15", "06", null, "Ihuari", null, "06", null, null },
                    { 1491, "PE", null, "15", "07", null, "Lampian", null, "06", null, null },
                    { 1492, "PE", null, "15", "08", null, "Pacaraos", null, "06", null, null },
                    { 1493, "PE", null, "15", "09", null, "San Miguel de Acos", null, "06", null, null },
                    { 1494, "PE", null, "15", "10", null, "Santa Cruz de Andamarca", null, "06", null, null },
                    { 1495, "PE", null, "15", "11", null, "Sumbilca", null, "06", null, null },
                    { 1496, "PE", null, "15", "12", null, "Veintisiete de Noviembre", null, "06", null, null },
                    { 1497, "PE", null, "15", "00", null, "Huarochiri", null, "07", null, null },
                    { 1498, "PE", null, "15", "01", null, "Matucana", null, "07", null, null },
                    { 1499, "PE", null, "15", "02", null, "Antioquia", null, "07", null, null },
                    { 1500, "PE", null, "15", "03", null, "Callahuanca", null, "07", null, null },
                    { 1501, "PE", null, "15", "04", null, "Carampoma", null, "07", null, null },
                    { 1502, "PE", null, "15", "05", null, "Chicla", null, "07", null, null },
                    { 1503, "PE", null, "15", "06", null, "Cuenca", null, "07", null, null },
                    { 1504, "PE", null, "15", "07", null, "Huachupampa", null, "07", null, null },
                    { 1505, "PE", null, "15", "08", null, "Huanza", null, "07", null, null },
                    { 1506, "PE", null, "15", "09", null, "Huarochiri", null, "07", null, null },
                    { 1507, "PE", null, "15", "10", null, "Lahuaytambo", null, "07", null, null },
                    { 1508, "PE", null, "15", "11", null, "Langa", null, "07", null, null },
                    { 1509, "PE", null, "15", "12", null, "Laraos", null, "07", null, null },
                    { 1510, "PE", null, "15", "13", null, "Mariatana", null, "07", null, null },
                    { 1511, "PE", null, "15", "14", null, "Ricardo Palma", null, "07", null, null },
                    { 1512, "PE", null, "15", "15", null, "San Andres de Tupicocha", null, "07", null, null },
                    { 1513, "PE", null, "15", "16", null, "San Antonio", null, "07", null, null },
                    { 1514, "PE", null, "15", "17", null, "San Bartolome", null, "07", null, null },
                    { 1515, "PE", null, "15", "18", null, "San Damian", null, "07", null, null },
                    { 1516, "PE", null, "15", "19", null, "San Juan de Iris", null, "07", null, null },
                    { 1517, "PE", null, "15", "20", null, "San Juan de Tantaranche", null, "07", null, null },
                    { 1518, "PE", null, "15", "21", null, "San Lorenzo de Quinti", null, "07", null, null },
                    { 1519, "PE", null, "15", "22", null, "San Mateo", null, "07", null, null },
                    { 1520, "PE", null, "15", "23", null, "San Mateo de Otao", null, "07", null, null },
                    { 1521, "PE", null, "15", "24", null, "San Pedro de Casta", null, "07", null, null },
                    { 1522, "PE", null, "15", "25", null, "San Pedro de Huancayre", null, "07", null, null },
                    { 1523, "PE", null, "15", "26", null, "Sangallaya", null, "07", null, null },
                    { 1524, "PE", null, "15", "27", null, "Santa Cruz de Cocachacra", null, "07", null, null },
                    { 1525, "PE", null, "15", "28", null, "Santa Eulalia", null, "07", null, null },
                    { 1526, "PE", null, "15", "29", null, "Santiago de Anchucaya", null, "07", null, null },
                    { 1527, "PE", null, "15", "30", null, "Santiago de Tuna", null, "07", null, null },
                    { 1528, "PE", null, "15", "31", null, "Santo Domingo de los Olleros", null, "07", null, null },
                    { 1529, "PE", null, "15", "32", null, "Surco", null, "07", null, null },
                    { 1530, "PE", null, "15", "00", null, "Huaura", null, "08", null, null },
                    { 1531, "PE", null, "15", "01", null, "Huacho", null, "08", null, null },
                    { 1532, "PE", null, "15", "02", null, "Ambar", null, "08", null, null },
                    { 1533, "PE", null, "15", "03", null, "Caleta de Carquin", null, "08", null, null },
                    { 1534, "PE", null, "15", "04", null, "Checras", null, "08", null, null },
                    { 1535, "PE", null, "15", "05", null, "Hualmay", null, "08", null, null },
                    { 1536, "PE", null, "15", "06", null, "Huaura", null, "08", null, null },
                    { 1537, "PE", null, "15", "07", null, "Leoncio Prado", null, "08", null, null },
                    { 1538, "PE", null, "15", "08", null, "Paccho", null, "08", null, null },
                    { 1539, "PE", null, "15", "09", null, "Santa Leonor", null, "08", null, null },
                    { 1540, "PE", null, "15", "10", null, "Santa Maria", null, "08", null, null },
                    { 1541, "PE", null, "15", "11", null, "Sayan", null, "08", null, null },
                    { 1542, "PE", null, "15", "12", null, "Vegueta", null, "08", null, null },
                    { 1543, "PE", null, "15", "00", null, "Oyon", null, "09", null, null },
                    { 1544, "PE", null, "15", "01", null, "Oyon", null, "09", null, null },
                    { 1545, "PE", null, "15", "02", null, "Andajes", null, "09", null, null },
                    { 1546, "PE", null, "15", "03", null, "Caujul", null, "09", null, null },
                    { 1547, "PE", null, "15", "04", null, "Cochamarca", null, "09", null, null },
                    { 1548, "PE", null, "15", "05", null, "Navan", null, "09", null, null },
                    { 1549, "PE", null, "15", "06", null, "Pachangara", null, "09", null, null },
                    { 1550, "PE", null, "25", "00", null, "Padre Abad", null, "03", null, null },
                    { 1551, "PE", null, "25", "01", null, "Padre Abad", null, "03", null, null },
                    { 1552, "PE", null, "25", "02", null, "Irazola", null, "03", null, null },
                    { 1553, "PE", null, "25", "03", null, "Curimana", null, "03", null, null },
                    { 1554, "PE", null, "25", "00", null, "Purus", null, "04", null, null },
                    { 1555, "PE", null, "25", "01", null, "Purus", null, "04", null, null },
                    { 1556, "PE", null, "99", "00", null, "Extranjero", null, "00", null, null },
                    { 1557, "PE", null, "99", "00", null, "Extranjero", null, "99", null, null },
                    { 1558, "PE", null, "99", "99", null, "Extranjero", null, "99", null, null },
                    { 1559, "PE", null, "15", "00", null, "Yauyos", null, "10", null, null },
                    { 1560, "PE", null, "15", "01", null, "Yauyos", null, "10", null, null },
                    { 1561, "PE", null, "15", "02", null, "Alis", null, "10", null, null },
                    { 1562, "PE", null, "15", "03", null, "Ayauca", null, "10", null, null },
                    { 1563, "PE", null, "15", "04", null, "Ayaviri", null, "10", null, null },
                    { 1564, "PE", null, "15", "05", null, "Azangaro", null, "10", null, null },
                    { 1565, "PE", null, "15", "06", null, "Cacra", null, "10", null, null },
                    { 1566, "PE", null, "15", "07", null, "Carania", null, "10", null, null },
                    { 1567, "PE", null, "15", "08", null, "Catahuasi", null, "10", null, null },
                    { 1568, "PE", null, "15", "09", null, "Chocos", null, "10", null, null },
                    { 1569, "PE", null, "15", "10", null, "Cochas", null, "10", null, null },
                    { 1570, "PE", null, "15", "11", null, "Colonia", null, "10", null, null },
                    { 1571, "PE", null, "15", "12", null, "Hongos", null, "10", null, null },
                    { 1572, "PE", null, "15", "13", null, "Huampara", null, "10", null, null },
                    { 1573, "PE", null, "15", "14", null, "Huancaya", null, "10", null, null },
                    { 1574, "PE", null, "15", "15", null, "Huangascar", null, "10", null, null },
                    { 1575, "PE", null, "15", "16", null, "Huantan", null, "10", null, null },
                    { 1576, "PE", null, "15", "17", null, "Huañec", null, "10", null, null },
                    { 1577, "PE", null, "15", "18", null, "Laraos", null, "10", null, null },
                    { 1578, "PE", null, "15", "19", null, "Lincha", null, "10", null, null },
                    { 1579, "PE", null, "15", "20", null, "Madean", null, "10", null, null },
                    { 1580, "PE", null, "15", "21", null, "Miraflores", null, "10", null, null },
                    { 1581, "PE", null, "15", "22", null, "Omas", null, "10", null, null },
                    { 1582, "PE", null, "15", "23", null, "Putinza", null, "10", null, null },
                    { 1583, "PE", null, "15", "24", null, "Quinches", null, "10", null, null },
                    { 1584, "PE", null, "15", "25", null, "Quinocay", null, "10", null, null },
                    { 1585, "PE", null, "15", "26", null, "San Joaquin", null, "10", null, null },
                    { 1586, "PE", null, "15", "27", null, "San Pedro de Pilas", null, "10", null, null },
                    { 1587, "PE", null, "15", "28", null, "Tanta", null, "10", null, null },
                    { 1588, "PE", null, "15", "29", null, "Tauripampa", null, "10", null, null },
                    { 1589, "PE", null, "15", "30", null, "Tomas", null, "10", null, null },
                    { 1590, "PE", null, "15", "31", null, "Tupe", null, "10", null, null },
                    { 1591, "PE", null, "15", "32", null, "Viñac", null, "10", null, null },
                    { 1592, "PE", null, "15", "33", null, "Vitis", null, "10", null, null },
                    { 1593, "PE", null, "16", "00", null, "Loreto", null, "00", null, null },
                    { 1594, "PE", null, "16", "00", null, "Maynas", null, "01", null, null },
                    { 1595, "PE", null, "16", "01", null, "Iquitos", null, "01", null, null },
                    { 1596, "PE", null, "16", "02", null, "Alto Nanay", null, "01", null, null },
                    { 1597, "PE", null, "16", "03", null, "Fernando Lores", null, "01", null, null },
                    { 1598, "PE", null, "16", "04", null, "Indiana", null, "01", null, null },
                    { 1599, "PE", null, "16", "05", null, "Las Amazonas", null, "01", null, null },
                    { 1600, "PE", null, "16", "06", null, "Mazan", null, "01", null, null },
                    { 1601, "PE", null, "16", "07", null, "Napo", null, "01", null, null },
                    { 1602, "PE", null, "16", "08", null, "Punchana", null, "01", null, null },
                    { 1603, "PE", null, "16", "09", null, "Putumayo", null, "01", null, null },
                    { 1604, "PE", null, "16", "10", null, "Torres Causana", null, "01", null, null },
                    { 1605, "PE", null, "16", "12", null, "Belén", null, "01", null, null },
                    { 1606, "PE", null, "16", "13", null, "San Juan Bautista", null, "01", null, null },
                    { 1607, "PE", null, "16", "14", null, "Teniente Manuel Clavero", null, "01", null, null },
                    { 1608, "PE", null, "16", "00", null, "Alto Amazonas", null, "02", null, null },
                    { 1609, "PE", null, "16", "01", null, "Yurimaguas", null, "02", null, null },
                    { 1610, "PE", null, "16", "02", null, "Balsapuerto", null, "02", null, null },
                    { 1611, "PE", null, "16", "05", null, "Jeberos", null, "02", null, null },
                    { 1612, "PE", null, "16", "06", null, "Lagunas", null, "02", null, null },
                    { 1613, "PE", null, "16", "10", null, "Santa Cruz", null, "02", null, null },
                    { 1614, "PE", null, "16", "11", null, "Teniente Cesar Lopez Rojas", null, "02", null, null },
                    { 1615, "PE", null, "16", "00", null, "Loreto", null, "03", null, null },
                    { 1616, "PE", null, "16", "01", null, "Nauta", null, "03", null, null },
                    { 1617, "PE", null, "16", "02", null, "Parinari", null, "03", null, null },
                    { 1618, "PE", null, "16", "03", null, "Tigre", null, "03", null, null },
                    { 1619, "PE", null, "16", "04", null, "Trompeteros", null, "03", null, null },
                    { 1620, "PE", null, "16", "05", null, "Urarinas", null, "03", null, null },
                    { 1621, "PE", null, "16", "00", null, "Mariscal Ramon Castilla", null, "04", null, null },
                    { 1622, "PE", null, "16", "01", null, "Ramon Castilla", null, "04", null, null },
                    { 1623, "PE", null, "16", "02", null, "Pebas", null, "04", null, null },
                    { 1624, "PE", null, "16", "03", null, "Yavari", null, "04", null, null },
                    { 1625, "PE", null, "16", "04", null, "San Pablo", null, "04", null, null },
                    { 1626, "PE", null, "16", "00", null, "Requena", null, "05", null, null },
                    { 1627, "PE", null, "16", "01", null, "Requena", null, "05", null, null },
                    { 1628, "PE", null, "16", "02", null, "Alto Tapiche", null, "05", null, null },
                    { 1629, "PE", null, "16", "03", null, "Capelo", null, "05", null, null },
                    { 1630, "PE", null, "16", "04", null, "Emilio San Martin", null, "05", null, null },
                    { 1631, "PE", null, "16", "05", null, "Maquia", null, "05", null, null },
                    { 1632, "PE", null, "16", "06", null, "Puinahua", null, "05", null, null },
                    { 1633, "PE", null, "16", "07", null, "Saquena", null, "05", null, null },
                    { 1634, "PE", null, "16", "08", null, "Soplin", null, "05", null, null },
                    { 1635, "PE", null, "16", "09", null, "Tapiche", null, "05", null, null },
                    { 1636, "PE", null, "16", "10", null, "Jenaro Herrera", null, "05", null, null },
                    { 1637, "PE", null, "16", "11", null, "Yaquerana", null, "05", null, null },
                    { 1638, "PE", null, "16", "00", null, "Ucayali", null, "06", null, null },
                    { 1639, "PE", null, "16", "01", null, "Contamana", null, "06", null, null },
                    { 1640, "PE", null, "16", "02", null, "Inahuaya", null, "06", null, null },
                    { 1641, "PE", null, "16", "03", null, "Padre Marquez", null, "06", null, null },
                    { 1642, "PE", null, "16", "04", null, "Pampa Hermosa", null, "06", null, null },
                    { 1643, "PE", null, "16", "05", null, "Sarayacu", null, "06", null, null },
                    { 1644, "PE", null, "16", "06", null, "Vargas Guerra", null, "06", null, null },
                    { 1645, "PE", null, "16", "00", null, "Datem del Marañón", null, "07", null, null },
                    { 1646, "PE", null, "16", "01", null, "Barranca", null, "07", null, null },
                    { 1647, "PE", null, "16", "02", null, "Cahuapanas", null, "07", null, null },
                    { 1648, "PE", null, "16", "03", null, "Manseriche", null, "07", null, null },
                    { 1649, "PE", null, "16", "04", null, "Morona", null, "07", null, null },
                    { 1650, "PE", null, "16", "05", null, "Pastaza", null, "07", null, null },
                    { 1651, "PE", null, "16", "06", null, "Andoas", null, "07", null, null },
                    { 1652, "PE", null, "16", "00", null, "Putumayo", null, "08", null, null },
                    { 1653, "PE", null, "16", "01", null, "Putumayo", null, "08", null, null },
                    { 1654, "PE", null, "16", "02", null, "Rosa Panduro", null, "08", null, null },
                    { 1655, "PE", null, "16", "03", null, "Teniente Manuel Clavero", null, "08", null, null },
                    { 1656, "PE", null, "16", "04", null, "Yaguas", null, "08", null, null },
                    { 1657, "PE", null, "17", "00", null, "Madre de Dios", null, "00", null, null },
                    { 1658, "PE", null, "17", "00", null, "Tambopata", null, "01", null, null },
                    { 1659, "PE", null, "17", "01", null, "Tambopata", null, "01", null, null },
                    { 1660, "PE", null, "17", "02", null, "Inambari", null, "01", null, null },
                    { 1661, "PE", null, "17", "03", null, "Las Piedras", null, "01", null, null },
                    { 1662, "PE", null, "17", "04", null, "Laberinto", null, "01", null, null },
                    { 1663, "PE", null, "17", "00", null, "Manu", null, "02", null, null },
                    { 1664, "PE", null, "17", "01", null, "Manu", null, "02", null, null },
                    { 1665, "PE", null, "17", "02", null, "Fitzcarrald", null, "02", null, null },
                    { 1666, "PE", null, "17", "03", null, "Madre de Dios", null, "02", null, null },
                    { 1667, "PE", null, "17", "04", null, "Huepetuhe", null, "02", null, null },
                    { 1668, "PE", null, "17", "00", null, "Tahuamanu", null, "03", null, null },
                    { 1669, "PE", null, "17", "01", null, "Iñapari", null, "03", null, null },
                    { 1670, "PE", null, "17", "02", null, "Iberia", null, "03", null, null },
                    { 1671, "PE", null, "17", "03", null, "Tahuamanu", null, "03", null, null },
                    { 1672, "PE", null, "18", "00", null, "Moquegua", null, "00", null, null },
                    { 1673, "PE", null, "18", "00", null, "Mariscal Nieto", null, "01", null, null },
                    { 1674, "PE", null, "18", "01", null, "Moquegua", null, "01", null, null },
                    { 1675, "PE", null, "18", "02", null, "Carumas", null, "01", null, null },
                    { 1676, "PE", null, "18", "03", null, "Cuchumbaya", null, "01", null, null },
                    { 1677, "PE", null, "18", "04", null, "Samegua", null, "01", null, null },
                    { 1678, "PE", null, "18", "05", null, "San Cristobal", null, "01", null, null },
                    { 1679, "PE", null, "18", "06", null, "Torata", null, "01", null, null },
                    { 1680, "PE", null, "18", "00", null, "General Sanchez Cerro", null, "02", null, null },
                    { 1681, "PE", null, "18", "01", null, "Omate", null, "02", null, null },
                    { 1682, "PE", null, "18", "02", null, "Chojata", null, "02", null, null },
                    { 1683, "PE", null, "18", "03", null, "Coalaque", null, "02", null, null },
                    { 1684, "PE", null, "18", "04", null, "Ichuña", null, "02", null, null },
                    { 1685, "PE", null, "18", "05", null, "La Capilla", null, "02", null, null },
                    { 1686, "PE", null, "18", "06", null, "Lloque", null, "02", null, null },
                    { 1687, "PE", null, "18", "07", null, "Matalaque", null, "02", null, null },
                    { 1688, "PE", null, "18", "08", null, "Puquina", null, "02", null, null },
                    { 1689, "PE", null, "18", "09", null, "Quinistaquillas", null, "02", null, null },
                    { 1690, "PE", null, "18", "10", null, "Ubinas", null, "02", null, null },
                    { 1691, "PE", null, "18", "11", null, "Yunga", null, "02", null, null },
                    { 1692, "PE", null, "18", "00", null, "Ilo", null, "03", null, null },
                    { 1693, "PE", null, "18", "01", null, "Ilo", null, "03", null, null },
                    { 1694, "PE", null, "18", "02", null, "El Algarrobal", null, "03", null, null },
                    { 1695, "PE", null, "18", "03", null, "Pacocha", null, "03", null, null },
                    { 1696, "PE", null, "19", "00", null, "Pasco", null, "00", null, null },
                    { 1697, "PE", null, "19", "00", null, "Pasco", null, "01", null, null },
                    { 1698, "PE", null, "19", "01", null, "Chaupimarca", null, "01", null, null },
                    { 1699, "PE", null, "19", "02", null, "Huachon", null, "01", null, null },
                    { 1700, "PE", null, "19", "03", null, "Huariaca", null, "01", null, null },
                    { 1701, "PE", null, "19", "04", null, "Huayllay", null, "01", null, null },
                    { 1702, "PE", null, "19", "05", null, "Ninacaca", null, "01", null, null },
                    { 1703, "PE", null, "19", "06", null, "Pallanchacra", null, "01", null, null },
                    { 1704, "PE", null, "19", "07", null, "Paucartambo", null, "01", null, null },
                    { 1705, "PE", null, "19", "08", null, "San Fco. de Asís de Yarusyacán", null, "01", null, null },
                    { 1706, "PE", null, "19", "09", null, "Simon Bolivar", null, "01", null, null },
                    { 1707, "PE", null, "19", "10", null, "Ticlacayan", null, "01", null, null },
                    { 1708, "PE", null, "19", "11", null, "Tinyahuarco", null, "01", null, null },
                    { 1709, "PE", null, "19", "12", null, "Vicco", null, "01", null, null },
                    { 1710, "PE", null, "19", "13", null, "Yanacancha", null, "01", null, null },
                    { 1711, "PE", null, "19", "00", null, "Daniel Alcides Carrion", null, "02", null, null },
                    { 1712, "PE", null, "19", "01", null, "Yanahuanca", null, "02", null, null },
                    { 1713, "PE", null, "19", "02", null, "Chacayan", null, "02", null, null },
                    { 1714, "PE", null, "19", "03", null, "Goyllarisquizga", null, "02", null, null },
                    { 1715, "PE", null, "19", "04", null, "Paucar", null, "02", null, null },
                    { 1716, "PE", null, "19", "05", null, "San Pedro de Pillao", null, "02", null, null },
                    { 1717, "PE", null, "19", "06", null, "Santa Ana de Tusi", null, "02", null, null },
                    { 1718, "PE", null, "19", "07", null, "Tapuc", null, "02", null, null },
                    { 1719, "PE", null, "19", "08", null, "Vilcabamba", null, "02", null, null },
                    { 1720, "PE", null, "19", "00", null, "Oxapampa", null, "03", null, null },
                    { 1721, "PE", null, "19", "01", null, "Oxapampa", null, "03", null, null },
                    { 1722, "PE", null, "19", "02", null, "Chontabamba", null, "03", null, null },
                    { 1723, "PE", null, "19", "03", null, "Huancabamba", null, "03", null, null },
                    { 1724, "PE", null, "19", "04", null, "Palcazu", null, "03", null, null },
                    { 1725, "PE", null, "19", "05", null, "Pozuzo", null, "03", null, null },
                    { 1726, "PE", null, "19", "06", null, "Puerto Bermudez", null, "03", null, null },
                    { 1727, "PE", null, "19", "07", null, "Villa Rica", null, "03", null, null },
                    { 1728, "PE", null, "19", "08", null, "Constitucion", null, "03", null, null },
                    { 1729, "PE", null, "20", "00", null, "Piura", null, "00", null, null },
                    { 1730, "PE", null, "20", "00", null, "Piura", null, "01", null, null },
                    { 1731, "PE", null, "20", "01", null, "Piura", null, "01", null, null },
                    { 1732, "PE", null, "20", "04", null, "Castilla", null, "01", null, null },
                    { 1733, "PE", null, "20", "05", null, "Catacaos", null, "01", null, null },
                    { 1734, "PE", null, "20", "07", null, "Cura Mori", null, "01", null, null },
                    { 1735, "PE", null, "20", "08", null, "El Tallan", null, "01", null, null },
                    { 1736, "PE", null, "20", "09", null, "La Arena", null, "01", null, null },
                    { 1737, "PE", null, "20", "10", null, "La Union", null, "01", null, null },
                    { 1738, "PE", null, "20", "11", null, "Las Lomas", null, "01", null, null },
                    { 1739, "PE", null, "20", "14", null, "Tambo Grande", null, "01", null, null },
                    { 1740, "PE", null, "20", "15", null, "Veintiséis de Octubre", null, "01", null, null },
                    { 1741, "PE", null, "20", "00", null, "Ayabaca", null, "02", null, null },
                    { 1742, "PE", null, "20", "01", null, "Ayabaca", null, "02", null, null },
                    { 1743, "PE", null, "20", "02", null, "Frias", null, "02", null, null },
                    { 1744, "PE", null, "20", "03", null, "Jilili", null, "02", null, null },
                    { 1745, "PE", null, "20", "04", null, "Lagunas", null, "02", null, null },
                    { 1746, "PE", null, "20", "05", null, "Montero", null, "02", null, null },
                    { 1747, "PE", null, "20", "06", null, "Pacaipampa", null, "02", null, null },
                    { 1748, "PE", null, "20", "07", null, "Paimas", null, "02", null, null },
                    { 1749, "PE", null, "20", "08", null, "Sapillica", null, "02", null, null },
                    { 1750, "PE", null, "20", "09", null, "Sicchez", null, "02", null, null },
                    { 1751, "PE", null, "20", "10", null, "Suyo", null, "02", null, null },
                    { 1752, "PE", null, "20", "00", null, "Huancabamba", null, "03", null, null },
                    { 1753, "PE", null, "20", "01", null, "Huancabamba", null, "03", null, null },
                    { 1754, "PE", null, "20", "02", null, "Canchaque", null, "03", null, null },
                    { 1755, "PE", null, "20", "03", null, "El Carmen de la Frontera", null, "03", null, null },
                    { 1756, "PE", null, "20", "04", null, "Huarmaca", null, "03", null, null },
                    { 1757, "PE", null, "20", "05", null, "Lalaquiz", null, "03", null, null },
                    { 1758, "PE", null, "20", "06", null, "San Miguel de El Faique", null, "03", null, null },
                    { 1759, "PE", null, "20", "07", null, "Sondor", null, "03", null, null },
                    { 1760, "PE", null, "20", "08", null, "Sondorillo", null, "03", null, null },
                    { 1761, "PE", null, "20", "00", null, "Morropon", null, "04", null, null },
                    { 1762, "PE", null, "20", "01", null, "Chulucanas", null, "04", null, null },
                    { 1763, "PE", null, "20", "02", null, "Buenos Aires", null, "04", null, null },
                    { 1764, "PE", null, "20", "03", null, "Chalaco", null, "04", null, null },
                    { 1765, "PE", null, "20", "04", null, "La Matanza", null, "04", null, null },
                    { 1766, "PE", null, "20", "05", null, "Morropon", null, "04", null, null },
                    { 1767, "PE", null, "20", "06", null, "Salitral", null, "04", null, null },
                    { 1768, "PE", null, "20", "07", null, "San Juan de Bigote", null, "04", null, null },
                    { 1769, "PE", null, "20", "08", null, "Santa Catalina de Mossa", null, "04", null, null },
                    { 1770, "PE", null, "20", "09", null, "Santo Domingo", null, "04", null, null },
                    { 1771, "PE", null, "20", "10", null, "Yamango", null, "04", null, null },
                    { 1772, "PE", null, "20", "00", null, "Paita", null, "05", null, null },
                    { 1773, "PE", null, "20", "01", null, "Paita", null, "05", null, null },
                    { 1774, "PE", null, "20", "02", null, "Amotape", null, "05", null, null },
                    { 1775, "PE", null, "20", "03", null, "Arenal", null, "05", null, null },
                    { 1776, "PE", null, "20", "04", null, "Colan", null, "05", null, null },
                    { 1777, "PE", null, "20", "05", null, "La Huaca", null, "05", null, null },
                    { 1778, "PE", null, "20", "06", null, "Tamarindo", null, "05", null, null },
                    { 1779, "PE", null, "20", "07", null, "Vichayal", null, "05", null, null },
                    { 1780, "PE", null, "20", "00", null, "Sullana", null, "06", null, null },
                    { 1781, "PE", null, "20", "01", null, "Sullana", null, "06", null, null },
                    { 1782, "PE", null, "20", "02", null, "Bellavista", null, "06", null, null },
                    { 1783, "PE", null, "20", "03", null, "Ignacio Escudero", null, "06", null, null },
                    { 1784, "PE", null, "20", "04", null, "Lancones", null, "06", null, null },
                    { 1785, "PE", null, "20", "05", null, "Marcavelica", null, "06", null, null },
                    { 1786, "PE", null, "20", "06", null, "Miguel Checa", null, "06", null, null },
                    { 1787, "PE", null, "20", "07", null, "Querecotillo", null, "06", null, null },
                    { 1788, "PE", null, "20", "08", null, "Salitral", null, "06", null, null },
                    { 1789, "PE", null, "20", "00", null, "Talara", null, "07", null, null },
                    { 1790, "PE", null, "20", "01", null, "Pariñas", null, "07", null, null },
                    { 1791, "PE", null, "20", "02", null, "El Alto", null, "07", null, null },
                    { 1792, "PE", null, "20", "03", null, "La Brea", null, "07", null, null },
                    { 1793, "PE", null, "20", "04", null, "Lobitos", null, "07", null, null },
                    { 1794, "PE", null, "20", "05", null, "Los Organos", null, "07", null, null },
                    { 1795, "PE", null, "20", "06", null, "Mancora", null, "07", null, null },
                    { 1796, "PE", null, "20", "00", null, "Sechura", null, "08", null, null },
                    { 1797, "PE", null, "20", "01", null, "Sechura", null, "08", null, null },
                    { 1798, "PE", null, "20", "02", null, "Bellavista de la Union", null, "08", null, null },
                    { 1799, "PE", null, "20", "03", null, "Bernal", null, "08", null, null },
                    { 1800, "PE", null, "20", "04", null, "Cristo Nos Valga", null, "08", null, null },
                    { 1801, "PE", null, "20", "05", null, "Vice", null, "08", null, null },
                    { 1802, "PE", null, "20", "06", null, "Rinconada Llicuar", null, "08", null, null },
                    { 1803, "PE", null, "21", "00", null, "Puno", null, "00", null, null },
                    { 1804, "PE", null, "21", "00", null, "Puno", null, "01", null, null },
                    { 1805, "PE", null, "21", "01", null, "Puno", null, "01", null, null },
                    { 1806, "PE", null, "21", "02", null, "Acora", null, "01", null, null },
                    { 1807, "PE", null, "21", "03", null, "Amantani", null, "01", null, null },
                    { 1808, "PE", null, "21", "04", null, "Atuncolla", null, "01", null, null },
                    { 1809, "PE", null, "21", "05", null, "Capachica", null, "01", null, null },
                    { 1810, "PE", null, "21", "06", null, "Chucuito", null, "01", null, null },
                    { 1811, "PE", null, "21", "07", null, "Coata", null, "01", null, null },
                    { 1812, "PE", null, "21", "08", null, "Huata", null, "01", null, null },
                    { 1813, "PE", null, "21", "09", null, "Mañazo", null, "01", null, null },
                    { 1814, "PE", null, "21", "10", null, "Paucarcolla", null, "01", null, null },
                    { 1815, "PE", null, "21", "11", null, "Pichacani", null, "01", null, null },
                    { 1816, "PE", null, "21", "12", null, "Plateria", null, "01", null, null },
                    { 1817, "PE", null, "21", "13", null, "San Antonio", null, "01", null, null },
                    { 1818, "PE", null, "21", "14", null, "Tiquillaca", null, "01", null, null },
                    { 1819, "PE", null, "21", "15", null, "Vilque", null, "01", null, null },
                    { 1820, "PE", null, "21", "00", null, "Azangaro", null, "02", null, null },
                    { 1821, "PE", null, "21", "01", null, "Azangaro", null, "02", null, null },
                    { 1822, "PE", null, "21", "02", null, "Achaya", null, "02", null, null },
                    { 1823, "PE", null, "21", "03", null, "Arapa", null, "02", null, null },
                    { 1824, "PE", null, "21", "04", null, "Asillo", null, "02", null, null },
                    { 1825, "PE", null, "21", "05", null, "Caminaca", null, "02", null, null },
                    { 1826, "PE", null, "21", "06", null, "Chupa", null, "02", null, null },
                    { 1827, "PE", null, "21", "07", null, "Jose Domingo Choquehuanca", null, "02", null, null },
                    { 1828, "PE", null, "21", "08", null, "Muñani", null, "02", null, null },
                    { 1829, "PE", null, "21", "09", null, "Potoni", null, "02", null, null },
                    { 1830, "PE", null, "21", "10", null, "Saman", null, "02", null, null },
                    { 1831, "PE", null, "21", "11", null, "San Anton", null, "02", null, null },
                    { 1832, "PE", null, "21", "12", null, "San Jose", null, "02", null, null },
                    { 1833, "PE", null, "21", "13", null, "San Juan de Salinas", null, "02", null, null },
                    { 1834, "PE", null, "21", "14", null, "Santiago de Pupuja", null, "02", null, null },
                    { 1835, "PE", null, "21", "15", null, "Tirapata", null, "02", null, null },
                    { 1836, "PE", null, "21", "00", null, "Carabaya", null, "03", null, null },
                    { 1837, "PE", null, "21", "01", null, "Macusani", null, "03", null, null },
                    { 1838, "PE", null, "21", "02", null, "Ajoyani", null, "03", null, null },
                    { 1839, "PE", null, "21", "03", null, "Ayapata", null, "03", null, null },
                    { 1840, "PE", null, "21", "04", null, "Coasa", null, "03", null, null },
                    { 1841, "PE", null, "21", "05", null, "Corani", null, "03", null, null },
                    { 1842, "PE", null, "21", "06", null, "Crucero", null, "03", null, null },
                    { 1843, "PE", null, "21", "07", null, "Ituata", null, "03", null, null },
                    { 1844, "PE", null, "21", "08", null, "Ollachea", null, "03", null, null },
                    { 1845, "PE", null, "21", "09", null, "San Gaban", null, "03", null, null },
                    { 1846, "PE", null, "21", "10", null, "Usicayos", null, "03", null, null },
                    { 1847, "PE", null, "21", "00", null, "Chucuito", null, "04", null, null },
                    { 1848, "PE", null, "21", "01", null, "Juli", null, "04", null, null },
                    { 1849, "PE", null, "21", "02", null, "Desaguadero", null, "04", null, null },
                    { 1850, "PE", null, "21", "03", null, "Huacullani", null, "04", null, null },
                    { 1851, "PE", null, "21", "04", null, "Kelluyo", null, "04", null, null },
                    { 1852, "PE", null, "21", "05", null, "Pisacoma", null, "04", null, null },
                    { 1853, "PE", null, "21", "06", null, "Pomata", null, "04", null, null },
                    { 1854, "PE", null, "21", "07", null, "Zepita", null, "04", null, null },
                    { 1855, "PE", null, "21", "00", null, "El Collao", null, "05", null, null },
                    { 1856, "PE", null, "21", "01", null, "Ilave", null, "05", null, null },
                    { 1857, "PE", null, "21", "02", null, "Capaso", null, "05", null, null },
                    { 1858, "PE", null, "21", "03", null, "Pilcuyo", null, "05", null, null },
                    { 1859, "PE", null, "21", "04", null, "Santa Rosa", null, "05", null, null },
                    { 1860, "PE", null, "21", "05", null, "Conduriri", null, "05", null, null },
                    { 1861, "PE", null, "21", "00", null, "Huancane", null, "06", null, null },
                    { 1862, "PE", null, "21", "01", null, "Huancane", null, "06", null, null },
                    { 1863, "PE", null, "21", "02", null, "Cojata", null, "06", null, null },
                    { 1864, "PE", null, "21", "03", null, "Huatasani", null, "06", null, null },
                    { 1865, "PE", null, "21", "04", null, "Inchupalla", null, "06", null, null },
                    { 1866, "PE", null, "21", "05", null, "Pusi", null, "06", null, null },
                    { 1867, "PE", null, "21", "06", null, "Rosaspata", null, "06", null, null },
                    { 1868, "PE", null, "21", "07", null, "Taraco", null, "06", null, null },
                    { 1869, "PE", null, "21", "08", null, "Vilque Chico", null, "06", null, null },
                    { 1870, "PE", null, "21", "00", null, "Lampa", null, "07", null, null },
                    { 1871, "PE", null, "21", "01", null, "Lampa", null, "07", null, null },
                    { 1872, "PE", null, "21", "02", null, "Cabanilla", null, "07", null, null },
                    { 1873, "PE", null, "21", "03", null, "Calapuja", null, "07", null, null },
                    { 1874, "PE", null, "21", "04", null, "Nicasio", null, "07", null, null },
                    { 1875, "PE", null, "21", "05", null, "Ocuviri", null, "07", null, null },
                    { 1876, "PE", null, "21", "06", null, "Palca", null, "07", null, null },
                    { 1877, "PE", null, "21", "07", null, "Paratia", null, "07", null, null },
                    { 1878, "PE", null, "21", "08", null, "Pucara", null, "07", null, null },
                    { 1879, "PE", null, "21", "09", null, "Santa Lucia", null, "07", null, null },
                    { 1880, "PE", null, "21", "10", null, "Vilavila", null, "07", null, null },
                    { 1881, "PE", null, "21", "00", null, "Melgar", null, "08", null, null },
                    { 1882, "PE", null, "21", "01", null, "Ayaviri", null, "08", null, null },
                    { 1883, "PE", null, "21", "02", null, "Antauta", null, "08", null, null },
                    { 1884, "PE", null, "21", "03", null, "Cupi", null, "08", null, null },
                    { 1885, "PE", null, "21", "04", null, "Llalli", null, "08", null, null },
                    { 1886, "PE", null, "21", "05", null, "Macari", null, "08", null, null },
                    { 1887, "PE", null, "21", "06", null, "Nuñoa", null, "08", null, null },
                    { 1888, "PE", null, "21", "07", null, "Orurillo", null, "08", null, null },
                    { 1889, "PE", null, "21", "08", null, "Santa Rosa", null, "08", null, null },
                    { 1890, "PE", null, "21", "09", null, "Umachiri", null, "08", null, null },
                    { 1891, "PE", null, "21", "00", null, "Moho", null, "09", null, null },
                    { 1892, "PE", null, "21", "01", null, "Moho", null, "09", null, null },
                    { 1893, "PE", null, "21", "02", null, "Conima", null, "09", null, null },
                    { 1894, "PE", null, "21", "03", null, "Huayrapata", null, "09", null, null },
                    { 1895, "PE", null, "21", "04", null, "Tilali", null, "09", null, null },
                    { 1896, "PE", null, "21", "00", null, "San Antonio de Putina", null, "10", null, null },
                    { 1897, "PE", null, "21", "01", null, "Putina", null, "10", null, null },
                    { 1898, "PE", null, "21", "02", null, "Ananea", null, "10", null, null },
                    { 1899, "PE", null, "21", "03", null, "Pedro Vilca Apaza", null, "10", null, null },
                    { 1900, "PE", null, "21", "04", null, "Quilcapuncu", null, "10", null, null },
                    { 1901, "PE", null, "21", "05", null, "Sina", null, "10", null, null },
                    { 1902, "PE", null, "21", "00", null, "San Roman", null, "11", null, null },
                    { 1903, "PE", null, "21", "01", null, "Juliaca", null, "11", null, null },
                    { 1904, "PE", null, "21", "02", null, "Cabana", null, "11", null, null },
                    { 1905, "PE", null, "21", "03", null, "Cabanillas", null, "11", null, null },
                    { 1906, "PE", null, "21", "04", null, "Caracoto", null, "11", null, null },
                    { 1907, "PE", null, "21", "00", null, "Sandia", null, "12", null, null },
                    { 1908, "PE", null, "21", "01", null, "Sandia", null, "12", null, null },
                    { 1909, "PE", null, "21", "02", null, "Cuyocuyo", null, "12", null, null },
                    { 1910, "PE", null, "21", "03", null, "Limbani", null, "12", null, null },
                    { 1911, "PE", null, "21", "04", null, "Patambuco", null, "12", null, null },
                    { 1912, "PE", null, "21", "05", null, "Phara", null, "12", null, null },
                    { 1913, "PE", null, "21", "06", null, "Quiaca", null, "12", null, null },
                    { 1914, "PE", null, "21", "07", null, "San Juan del Oro", null, "12", null, null },
                    { 1915, "PE", null, "21", "08", null, "Yanahuaya", null, "12", null, null },
                    { 1916, "PE", null, "21", "09", null, "Alto Inambari", null, "12", null, null },
                    { 1917, "PE", null, "21", "10", null, "San Pedro de Putina Punco", null, "12", null, null },
                    { 1918, "PE", null, "21", "00", null, "Yunguyo", null, "13", null, null },
                    { 1919, "PE", null, "21", "01", null, "Yunguyo", null, "13", null, null },
                    { 1920, "PE", null, "21", "02", null, "Anapia", null, "13", null, null },
                    { 1921, "PE", null, "21", "03", null, "Copani", null, "13", null, null },
                    { 1922, "PE", null, "21", "04", null, "Cuturapi", null, "13", null, null },
                    { 1923, "PE", null, "21", "05", null, "Ollaraya", null, "13", null, null },
                    { 1924, "PE", null, "21", "06", null, "Tinicachi", null, "13", null, null },
                    { 1925, "PE", null, "21", "07", null, "Unicachi", null, "13", null, null },
                    { 1926, "PE", null, "22", "00", null, "San Martin", null, "00", null, null },
                    { 1927, "PE", null, "22", "00", null, "Moyobamba", null, "01", null, null },
                    { 1928, "PE", null, "22", "01", null, "Moyobamba", null, "01", null, null },
                    { 1929, "PE", null, "22", "02", null, "Calzada", null, "01", null, null },
                    { 1930, "PE", null, "22", "03", null, "Habana", null, "01", null, null },
                    { 1931, "PE", null, "22", "04", null, "Jepelacio", null, "01", null, null },
                    { 1932, "PE", null, "22", "05", null, "Soritor", null, "01", null, null },
                    { 1933, "PE", null, "22", "06", null, "Yantalo", null, "01", null, null },
                    { 1934, "PE", null, "22", "00", null, "Bellavista", null, "02", null, null },
                    { 1935, "PE", null, "22", "01", null, "Bellavista", null, "02", null, null },
                    { 1936, "PE", null, "22", "02", null, "Alto Biavo", null, "02", null, null },
                    { 1937, "PE", null, "22", "03", null, "Bajo Biavo", null, "02", null, null },
                    { 1938, "PE", null, "22", "04", null, "Huallaga", null, "02", null, null },
                    { 1939, "PE", null, "22", "05", null, "San Pablo", null, "02", null, null },
                    { 1940, "PE", null, "22", "06", null, "San Rafael", null, "02", null, null },
                    { 1941, "PE", null, "22", "00", null, "El Dorado", null, "03", null, null },
                    { 1942, "PE", null, "22", "01", null, "San Jose de Sisa", null, "03", null, null },
                    { 1943, "PE", null, "22", "02", null, "Agua Blanca", null, "03", null, null },
                    { 1944, "PE", null, "22", "03", null, "San Martin", null, "03", null, null },
                    { 1945, "PE", null, "22", "04", null, "Santa Rosa", null, "03", null, null },
                    { 1946, "PE", null, "22", "05", null, "Shatoja", null, "03", null, null },
                    { 1947, "PE", null, "22", "00", null, "Huallaga", null, "04", null, null },
                    { 1948, "PE", null, "22", "01", null, "Saposoa", null, "04", null, null },
                    { 1949, "PE", null, "22", "02", null, "Alto Saposoa", null, "04", null, null },
                    { 1950, "PE", null, "22", "03", null, "El Eslabon", null, "04", null, null },
                    { 1951, "PE", null, "22", "04", null, "Piscoyacu", null, "04", null, null },
                    { 1952, "PE", null, "22", "05", null, "Sacanche", null, "04", null, null },
                    { 1953, "PE", null, "22", "06", null, "Tingo de Saposoa", null, "04", null, null },
                    { 1954, "PE", null, "22", "00", null, "Lamas", null, "05", null, null },
                    { 1955, "PE", null, "22", "01", null, "Lamas", null, "05", null, null },
                    { 1956, "PE", null, "22", "02", null, "Alonso de Alvarado", null, "05", null, null },
                    { 1957, "PE", null, "22", "03", null, "Barranquita", null, "05", null, null },
                    { 1958, "PE", null, "22", "04", null, "Caynarachi", null, "05", null, null },
                    { 1959, "PE", null, "22", "05", null, "Cuñumbuqui", null, "05", null, null },
                    { 1960, "PE", null, "22", "06", null, "Pinto Recodo", null, "05", null, null },
                    { 1961, "PE", null, "22", "07", null, "Rumisapa", null, "05", null, null },
                    { 1962, "PE", null, "22", "08", null, "San Roque de Cumbaza", null, "05", null, null },
                    { 1963, "PE", null, "22", "09", null, "Shanao", null, "05", null, null },
                    { 1964, "PE", null, "22", "10", null, "Tabalosos", null, "05", null, null },
                    { 1965, "PE", null, "22", "11", null, "Zapatero", null, "05", null, null },
                    { 1966, "PE", null, "22", "00", null, "Mariscal Caceres", null, "06", null, null },
                    { 1967, "PE", null, "22", "01", null, "Juanjui", null, "06", null, null },
                    { 1968, "PE", null, "22", "02", null, "Campanilla", null, "06", null, null },
                    { 1969, "PE", null, "22", "03", null, "Huicungo", null, "06", null, null },
                    { 1970, "PE", null, "22", "04", null, "Pachiza", null, "06", null, null },
                    { 1971, "PE", null, "22", "05", null, "Pajarillo", null, "06", null, null },
                    { 1972, "PE", null, "22", "00", null, "Picota", null, "07", null, null },
                    { 1973, "PE", null, "22", "01", null, "Picota", null, "07", null, null },
                    { 1974, "PE", null, "22", "02", null, "Buenos Aires", null, "07", null, null },
                    { 1975, "PE", null, "22", "03", null, "Caspisapa", null, "07", null, null },
                    { 1976, "PE", null, "22", "04", null, "Pilluana", null, "07", null, null },
                    { 1977, "PE", null, "22", "05", null, "Pucacaca", null, "07", null, null },
                    { 1978, "PE", null, "22", "06", null, "San Cristobal", null, "07", null, null },
                    { 1979, "PE", null, "22", "07", null, "San Hilarion", null, "07", null, null },
                    { 1980, "PE", null, "22", "08", null, "Shamboyacu", null, "07", null, null },
                    { 1981, "PE", null, "22", "09", null, "Tingo de Ponasa", null, "07", null, null },
                    { 1982, "PE", null, "22", "10", null, "Tres Unidos", null, "07", null, null },
                    { 1983, "PE", null, "22", "00", null, "Rioja", null, "08", null, null },
                    { 1984, "PE", null, "22", "01", null, "Rioja", null, "08", null, null },
                    { 1985, "PE", null, "22", "02", null, "Awajun", null, "08", null, null },
                    { 1986, "PE", null, "22", "03", null, "Elias Soplin Vargas", null, "08", null, null },
                    { 1987, "PE", null, "22", "04", null, "Nueva Cajamarca", null, "08", null, null },
                    { 1988, "PE", null, "22", "05", null, "Pardo Miguel", null, "08", null, null },
                    { 1989, "PE", null, "22", "06", null, "Posic", null, "08", null, null },
                    { 1990, "PE", null, "22", "07", null, "San Fernando", null, "08", null, null },
                    { 1991, "PE", null, "22", "08", null, "Yorongos", null, "08", null, null },
                    { 1992, "PE", null, "22", "09", null, "Yuracyacu", null, "08", null, null },
                    { 1993, "PE", null, "22", "00", null, "San Martin", null, "09", null, null },
                    { 1994, "PE", null, "22", "01", null, "Tarapoto", null, "09", null, null },
                    { 1995, "PE", null, "22", "02", null, "Alberto Leveau", null, "09", null, null },
                    { 1996, "PE", null, "22", "03", null, "Cacatachi", null, "09", null, null },
                    { 1997, "PE", null, "22", "04", null, "Chazuta", null, "09", null, null },
                    { 1998, "PE", null, "22", "05", null, "Chipurana", null, "09", null, null },
                    { 1999, "PE", null, "22", "06", null, "El Porvenir", null, "09", null, null },
                    { 2000, "PE", null, "22", "07", null, "Huimbayoc", null, "09", null, null },
                    { 2001, "PE", null, "22", "08", null, "Juan Guerra", null, "09", null, null },
                    { 2002, "PE", null, "22", "09", null, "La Banda de Shilcayo", null, "09", null, null },
                    { 2003, "PE", null, "22", "10", null, "Morales", null, "09", null, null },
                    { 2004, "PE", null, "22", "11", null, "Papaplaya", null, "09", null, null },
                    { 2005, "PE", null, "22", "12", null, "San Antonio", null, "09", null, null },
                    { 2006, "PE", null, "22", "13", null, "Sauce", null, "09", null, null },
                    { 2007, "PE", null, "22", "14", null, "Shapaja", null, "09", null, null },
                    { 2008, "PE", null, "22", "00", null, "Tocache", null, "10", null, null },
                    { 2009, "PE", null, "22", "01", null, "Tocache", null, "10", null, null },
                    { 2010, "PE", null, "22", "02", null, "Nuevo Progreso", null, "10", null, null },
                    { 2011, "PE", null, "22", "03", null, "Polvora", null, "10", null, null },
                    { 2012, "PE", null, "22", "04", null, "Shunte", null, "10", null, null },
                    { 2013, "PE", null, "22", "05", null, "Uchiza", null, "10", null, null },
                    { 2014, "PE", null, "23", "00", null, "Tacna", null, "00", null, null },
                    { 2015, "PE", null, "23", "00", null, "Tacna", null, "01", null, null },
                    { 2016, "PE", null, "23", "01", null, "Tacna", null, "01", null, null },
                    { 2017, "PE", null, "23", "02", null, "Alto de la Alianza", null, "01", null, null },
                    { 2018, "PE", null, "23", "03", null, "Calana", null, "01", null, null },
                    { 2019, "PE", null, "23", "04", null, "Ciudad Nueva", null, "01", null, null },
                    { 2020, "PE", null, "23", "05", null, "Inclan", null, "01", null, null },
                    { 2021, "PE", null, "23", "06", null, "Pachia", null, "01", null, null },
                    { 2022, "PE", null, "23", "07", null, "Palca", null, "01", null, null },
                    { 2023, "PE", null, "23", "08", null, "Pocollay", null, "01", null, null },
                    { 2024, "PE", null, "23", "09", null, "Sama", null, "01", null, null },
                    { 2025, "PE", null, "23", "10", null, "Coronel Gregorio Albarracín L", null, "01", null, null },
                    { 2026, "PE", null, "23", "00", null, "Candarave", null, "02", null, null },
                    { 2027, "PE", null, "23", "01", null, "Candarave", null, "02", null, null },
                    { 2028, "PE", null, "23", "02", null, "Cairani", null, "02", null, null },
                    { 2029, "PE", null, "23", "03", null, "Camilaca", null, "02", null, null },
                    { 2030, "PE", null, "23", "04", null, "Curibaya", null, "02", null, null },
                    { 2031, "PE", null, "23", "05", null, "Huanuara", null, "02", null, null },
                    { 2032, "PE", null, "23", "06", null, "Quilahuani", null, "02", null, null },
                    { 2033, "PE", null, "23", "00", null, "Jorge Basadre", null, "03", null, null },
                    { 2034, "PE", null, "23", "01", null, "Locumba", null, "03", null, null },
                    { 2035, "PE", null, "23", "02", null, "Ilabaya", null, "03", null, null },
                    { 2036, "PE", null, "23", "03", null, "Ite", null, "03", null, null },
                    { 2037, "PE", null, "23", "00", null, "Tarata", null, "04", null, null },
                    { 2038, "PE", null, "23", "01", null, "Tarata", null, "04", null, null },
                    { 2039, "PE", null, "23", "02", null, "Chucatamani", null, "04", null, null },
                    { 2040, "PE", null, "23", "03", null, "Estique", null, "04", null, null },
                    { 2041, "PE", null, "23", "04", null, "Estique-Pampa", null, "04", null, null },
                    { 2042, "PE", null, "23", "05", null, "Sitajara", null, "04", null, null },
                    { 2043, "PE", null, "23", "06", null, "Susapaya", null, "04", null, null },
                    { 2044, "PE", null, "23", "07", null, "Tarucachi", null, "04", null, null },
                    { 2045, "PE", null, "23", "08", null, "Ticaco", null, "04", null, null },
                    { 2046, "PE", null, "24", "00", null, "Tumbes", null, "00", null, null },
                    { 2047, "PE", null, "24", "00", null, "Tumbes", null, "01", null, null },
                    { 2048, "PE", null, "24", "01", null, "Tumbes", null, "01", null, null },
                    { 2049, "PE", null, "24", "02", null, "Corrales", null, "01", null, null },
                    { 2050, "PE", null, "24", "03", null, "La Cruz", null, "01", null, null },
                    { 2051, "PE", null, "24", "04", null, "Pampas de Hospital", null, "01", null, null },
                    { 2052, "PE", null, "24", "05", null, "San Jacinto", null, "01", null, null },
                    { 2053, "PE", null, "24", "06", null, "San Juan de la Virgen", null, "01", null, null },
                    { 2054, "PE", null, "24", "00", null, "Contralmirante Villar", null, "02", null, null },
                    { 2055, "PE", null, "24", "01", null, "Zorritos", null, "02", null, null },
                    { 2056, "PE", null, "24", "02", null, "Casitas", null, "02", null, null },
                    { 2057, "PE", null, "24", "03", null, "Canoas de Punta Sal", null, "02", null, null },
                    { 2058, "PE", null, "24", "00", null, "Zarumilla", null, "03", null, null },
                    { 2059, "PE", null, "24", "01", null, "Zarumilla", null, "03", null, null },
                    { 2060, "PE", null, "24", "02", null, "Aguas Verdes", null, "03", null, null },
                    { 2061, "PE", null, "24", "03", null, "Matapalo", null, "03", null, null },
                    { 2062, "PE", null, "24", "04", null, "Papayal", null, "03", null, null },
                    { 2063, "PE", null, "25", "00", null, "Ucayali", null, "00", null, null },
                    { 2064, "PE", null, "25", "00", null, "Coronel Portillo", null, "01", null, null },
                    { 2065, "PE", null, "25", "01", null, "Callaria (Pucallpa)", null, "01", null, null },
                    { 2066, "PE", null, "25", "02", null, "Campoverde", null, "01", null, null },
                    { 2067, "PE", null, "25", "03", null, "Iparia", null, "01", null, null },
                    { 2068, "PE", null, "25", "04", null, "Masisea", null, "01", null, null },
                    { 2069, "PE", null, "25", "05", null, "Yarinacocha", null, "01", null, null },
                    { 2070, "PE", null, "25", "06", null, "Nueva Requena", null, "01", null, null },
                    { 2071, "PE", null, "25", "07", null, "Manantay", null, "01", null, null },
                    { 2072, "PE", null, "25", "00", null, "Atalaya", null, "02", null, null },
                    { 2073, "PE", null, "25", "01", null, "Raymondi", null, "02", null, null },
                    { 2074, "PE", null, "25", "02", null, "Sepahua", null, "02", null, null },
                    { 2075, "PE", null, "25", "03", null, "Tahuania", null, "02", null, null },
                    { 2076, "PE", null, "25", "04", null, "Yurua", null, "02", null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PersonUid", "PhoneNumber", "PhoneNumberConfirmed", "Picture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "100", 0, "f31ab303-64cc-4207-bd8d-307ac914ebdb", "admin@admin", false, false, null, "ADMIN@ADMIN", "ADMIN@ADMIN", "AQAAAAIAAYagAAAAEB790SarCkJKVajShbc32OW4P1XGF2AOce+tAeJA2yhjHwvAei8LRVdkiJEjqiOGeQ==", null, null, false, null, "2cfd4901-97f7-49c4-a090-56e140b8b6b5", false, "admin@admin" });

            migrationBuilder.InsertData(
                table: "WorkAreas",
                columns: new[] { "Id", "Code", "CreatedBy", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, null, null, null, "Digital" },
                    { 2, null, null, null, "Consulting" },
                    { 3, null, null, null, "Outsourcing" },
                    { 4, null, null, null, "Security" },
                    { 5, null, null, null, "Comercial" },
                    { 6, null, null, null, "Finanzas" },
                    { 7, null, null, null, "Gerencia" },
                    { 8, null, null, null, "People" },
                    { 9, null, null, null, "Training" }
                });

            migrationBuilder.InsertData(
                table: "Menu",
                columns: new[] { "Id", "CreatedBy", "GroupId", "Icon", "LastModifiedBy", "Name", "Order", "Url" },
                values: new object[,]
                {
                    { 1, null, 1, "bi bi-circle", null, "Dashboard", 0, "/dashboard" },
                    { 2, null, 2, "bi bi-circle", null, "Registro Diario", 0, "/activities/daily" },
                    { 3, null, 3, "bi bi-circle", null, "Solicitar Vacaciones", 0, "/novelty/vacation-request" },
                    { 4, null, 4, "bi bi-circle", null, "Inputación de Horas", 0, "/reports/collaborator/daily-hours-input" },
                    { 5, null, 5, "bi bi-circle", null, "Feriados", 0, "/people/holidays-config" },
                    { 6, null, 5, "bi bi-circle", null, "Periodos", 0, "/people/periods-config" },
                    { 7, null, 5, "bi bi-circle", null, "Tipos Actividad Diaria", 0, "/people/activity-type-config" },
                    { 8, null, 6, "bi bi-circle", null, "Gestión Colaboradores", 0, "/config/collaborator-managment" },
                    { 9, null, 6, "bi bi-circle", null, "Gestión Clientes", 0, "/config/company-config" },
                    { 10, null, 7, "bi bi-circle", null, "Usuarios", 0, "/admin/users" },
                    { 11, null, 7, "bi bi-circle", null, "Roles", 0, "/admin/roles" },
                    { 12, null, 7, "bi bi-circle", null, "Clientes", 0, "/admin/companies" },
                    { 13, null, 7, "bi bi-circle", null, "CECO", 0, "/admin/ceco" },
                    { 14, null, 7, "bi bi-circle", null, "Áreas de Trabajo", 0, "/admin/work-areas" }
                });

            migrationBuilder.InsertData(
                table: "Periods",
                columns: new[] { "Id", "CreatedBy", "Description", "EndDate", "LastModifiedBy", "MaximumDays", "MaximumHours", "Month", "StartDate", "State", "Year" },
                values: new object[,]
                {
                    { "202310", null, "Periodo 10", null, null, 22, 176, 10, null, "A", 2023 },
                    { "202311", null, "Periodo 11", null, null, 22, 176, 11, null, "A", 2023 },
                    { "202312", null, "Periodo 12", null, null, 22, 176, 12, null, "A", 2023 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ADMIN", "100" });

            migrationBuilder.InsertData(
                table: "MenuRole",
                columns: new[] { "MenuId", "RoleId" },
                values: new object[,]
                {
                    { 1, "COLAB" },
                    { 2, "COLAB" },
                    { 3, "COLAB" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ActivityTypeId",
                table: "Activities",
                column: "ActivityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_CollaboratorId",
                table: "Activities",
                column: "CollaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_CompanyId",
                table: "Activities",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_CompanyServiceId",
                table: "Activities",
                column: "CompanyServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_PeriodId",
                table: "Activities",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivitiesDetail_ActivityId",
                table: "ActivitiesDetail",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityTypes_CompanyId",
                table: "ActivityTypes",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CollaboratorAdditionalInfos_AttributeId",
                table: "CollaboratorAdditionalInfos",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_CollaboratorAdditionalInfos_CollaboratorId",
                table: "CollaboratorAdditionalInfos",
                column: "CollaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_CollaboratorCompanies_CompanyId",
                table: "CollaboratorCompanies",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CollaboratorContacts_ContactServiceId",
                table: "CollaboratorContacts",
                column: "ContactServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Collaborators_PersonUid",
                table: "Collaborators",
                column: "PersonUid");

            migrationBuilder.CreateIndex(
                name: "IX_Collaborators_WorkAreaId",
                table: "Collaborators",
                column: "WorkAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Collaborators_WorkAreaTeamId_WorkAreaTeamWorkAreaId",
                table: "Collaborators",
                columns: new[] { "WorkAreaTeamId", "WorkAreaTeamWorkAreaId" });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CostCenterId",
                table: "Companies",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAreaCollaborators_CollaboratorId",
                table: "CompanyAreaCollaborators",
                column: "CollaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAreaCollaborators_CompanyAreaId",
                table: "CompanyAreaCollaborators",
                column: "CompanyAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAreas_CompanyId",
                table: "CompanyAreas",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyServices_CompanyId",
                table: "CompanyServices",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyServices_CostCenterId",
                table: "CompanyServices",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyServices_TypeId",
                table: "CompanyServices",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactServices_CompanyId",
                table: "ContactServices",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactServices_ServiceTypeId",
                table: "ContactServices",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CostCenter_Code",
                table: "CostCenter",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_MasterDetailTable_TableName_TableCode",
                table: "MasterDetailTable",
                columns: new[] { "TableName", "TableCode" });

            migrationBuilder.CreateIndex(
                name: "IX_Menu_GroupId",
                table: "Menu",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuRole_RoleId",
                table: "MenuRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Novelties_CollaboratorId",
                table: "Novelties",
                column: "CollaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_NoveltyRequests_NoveltyId",
                table: "NoveltyRequests",
                column: "NoveltyId");

            migrationBuilder.CreateIndex(
                name: "IX_Periods_State",
                table: "Periods",
                column: "State");

            migrationBuilder.CreateIndex(
                name: "IX_PersonCertifications_PersonUid",
                table: "PersonCertifications",
                column: "PersonUid");

            migrationBuilder.CreateIndex(
                name: "IX_PersonDocuments_PersonUid",
                table: "PersonDocuments",
                column: "PersonUid");

            migrationBuilder.CreateIndex(
                name: "IX_PersonHistory_ActionTypeId",
                table: "PersonHistory",
                column: "ActionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonHistory_PersonUid",
                table: "PersonHistory",
                column: "PersonUid");

            migrationBuilder.CreateIndex(
                name: "IX_PersonIndustries_PersonId",
                table: "PersonIndustries",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInformation_BusinessUnitId",
                table: "PersonInformation",
                column: "BusinessUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInformation_DocumentTypeId",
                table: "PersonInformation",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInformation_EntryTypeId",
                table: "PersonInformation",
                column: "EntryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonLanguages_PersonUid",
                table: "PersonLanguages",
                column: "PersonUid");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_CollaboratorId",
                table: "Schedules",
                column: "CollaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceManagerCollaborators_CollaboratorId",
                table: "ServiceManagerCollaborators",
                column: "CollaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceManagerCollaborators_CompanyId",
                table: "ServiceManagerCollaborators",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceManagers_PersonUid",
                table: "ServiceManagers",
                column: "PersonUid");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonUid",
                table: "Users",
                column: "PersonUid");

            migrationBuilder.CreateIndex(
                name: "IX_WorkAreaTeams_WorkAreaId",
                table: "WorkAreaTeams",
                column: "WorkAreaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivitiesDetail");

            migrationBuilder.DropTable(
                name: "CollaboratorAdditionalInfos");

            migrationBuilder.DropTable(
                name: "CollaboratorCompanies");

            migrationBuilder.DropTable(
                name: "CollaboratorContacts");

            migrationBuilder.DropTable(
                name: "CompanyAreaCollaborators");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Holidays");

            migrationBuilder.DropTable(
                name: "MenuRole");

            migrationBuilder.DropTable(
                name: "NoveltyRequests");

            migrationBuilder.DropTable(
                name: "PersonCertifications");

            migrationBuilder.DropTable(
                name: "PersonDocuments");

            migrationBuilder.DropTable(
                name: "PersonHistory");

            migrationBuilder.DropTable(
                name: "PersonIndustries");

            migrationBuilder.DropTable(
                name: "PersonLanguages");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "ServiceManagerCollaborators");

            migrationBuilder.DropTable(
                name: "Ubigeo");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Attributes");

            migrationBuilder.DropTable(
                name: "ContactServices");

            migrationBuilder.DropTable(
                name: "CompanyAreas");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Novelties");

            migrationBuilder.DropTable(
                name: "ActionTypes");

            migrationBuilder.DropTable(
                name: "Industries");

            migrationBuilder.DropTable(
                name: "ServiceManagers");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ActivityTypes");

            migrationBuilder.DropTable(
                name: "CompanyServices");

            migrationBuilder.DropTable(
                name: "Periods");

            migrationBuilder.DropTable(
                name: "MenuGroup");

            migrationBuilder.DropTable(
                name: "Collaborators");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "ServiceTypes");

            migrationBuilder.DropTable(
                name: "MasterDetailTable");

            migrationBuilder.DropTable(
                name: "PersonInformation");

            migrationBuilder.DropTable(
                name: "WorkAreaTeams");

            migrationBuilder.DropTable(
                name: "CostCenter");

            migrationBuilder.DropTable(
                name: "BusinessUnits");

            migrationBuilder.DropTable(
                name: "DocumentTypes");

            migrationBuilder.DropTable(
                name: "EntryTypes");

            migrationBuilder.DropTable(
                name: "WorkAreas");
        }
    }
}
