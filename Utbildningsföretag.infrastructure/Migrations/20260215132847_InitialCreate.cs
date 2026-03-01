using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Utbildningsföretag.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_courses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "participants",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    full_name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_participants", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "teachers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    full_name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_teachers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "course_sessions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    course_id = table.Column<Guid>(type: "uuid", nullable: false),
                    kurs_id = table.Column<Guid>(type: "uuid", nullable: false),
                    teacher_id = table.Column<Guid>(type: "uuid", nullable: false),
                    lärare_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_course_sessions", x => x.id);
                    table.ForeignKey(
                        name: "fk_course_sessions_courses_kurs_id",
                        column: x => x.kurs_id,
                        principalTable: "courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_course_sessions_teachers_lärare_id",
                        column: x => x.lärare_id,
                        principalTable: "teachers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "registrations",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    participant_id = table.Column<Guid>(type: "uuid", nullable: false),
                    course_session_id = table.Column<Guid>(type: "uuid", nullable: false),
                    registered_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_registrations", x => x.id);
                    table.ForeignKey(
                        name: "fk_registrations_course_sessions_course_session_id",
                        column: x => x.course_session_id,
                        principalTable: "course_sessions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_registrations_participants_participant_id",
                        column: x => x.participant_id,
                        principalTable: "participants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_course_sessions_kurs_id",
                table: "course_sessions",
                column: "kurs_id");

            migrationBuilder.CreateIndex(
                name: "ix_course_sessions_lärare_id",
                table: "course_sessions",
                column: "lärare_id");

            migrationBuilder.CreateIndex(
                name: "ix_registrations_course_session_id",
                table: "registrations",
                column: "course_session_id");

            migrationBuilder.CreateIndex(
                name: "ix_registrations_participant_id",
                table: "registrations",
                column: "participant_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "registrations");

            migrationBuilder.DropTable(
                name: "course_sessions");

            migrationBuilder.DropTable(
                name: "participants");

            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.DropTable(
                name: "teachers");
        }
    }
}
