using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JackTrack.Migrations
{
    public partial class MissionsConnectionMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Missions_MissionId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_MissionId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MissionId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "MissionUser",
                columns: table => new
                {
                    MissionsId = table.Column<long>(type: "bigint", nullable: false),
                    ToUsersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissionUser", x => new { x.MissionsId, x.ToUsersId });
                    table.ForeignKey(
                        name: "FK_MissionUser_Missions_MissionsId",
                        column: x => x.MissionsId,
                        principalTable: "Missions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MissionUser_Users_ToUsersId",
                        column: x => x.ToUsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MissionUser_ToUsersId",
                table: "MissionUser",
                column: "ToUsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MissionUser");

            migrationBuilder.AddColumn<long>(
                name: "MissionId",
                table: "Users",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_MissionId",
                table: "Users",
                column: "MissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Missions_MissionId",
                table: "Users",
                column: "MissionId",
                principalTable: "Missions",
                principalColumn: "Id");
        }
    }
}
