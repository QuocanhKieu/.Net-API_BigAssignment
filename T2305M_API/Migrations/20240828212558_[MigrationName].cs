using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace T2305M_API.Migrations
{
    /// <inheritdoc />
    public partial class MigrationName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Creator",
                columns: table => new
                {
                    CreatorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creator", x => x.CreatorId);
                });

            migrationBuilder.CreateTable(
                name: "Artifact",
                columns: table => new
                {
                    ArtifactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThumbnailImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DiscoveredDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Continent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artifact", x => x.ArtifactId);
                    table.ForeignKey(
                        name: "FK_Artifact_Creator_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Creator",
                        principalColumn: "CreatorId");
                });

            migrationBuilder.CreateTable(
                name: "Culture",
                columns: table => new
                {
                    CultureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThumbnailImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Continent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Culture", x => x.CultureId);
                    table.ForeignKey(
                        name: "FK_Culture_Creator_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Creator",
                        principalColumn: "CreatorId");
                });

            migrationBuilder.CreateTable(
                name: "Exhibition",
                columns: table => new
                {
                    ExhibitionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThumbnailImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Organizer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Continent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exhibition", x => x.ExhibitionId);
                    table.ForeignKey(
                        name: "FK_Exhibition_Creator_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Creator",
                        principalColumn: "CreatorId");
                });

            migrationBuilder.CreateTable(
                name: "NationalEvent",
                columns: table => new
                {
                    NationalEventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThumbnailImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Continent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NationalEvent", x => x.NationalEventID);
                    table.ForeignKey(
                        name: "FK_NationalEvent_Creator_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Creator",
                        principalColumn: "CreatorId");
                });

            migrationBuilder.CreateTable(
                name: "ArtifactArticle",
                columns: table => new
                {
                    ArtifactArticleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThumbnailImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArtifactId = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtifactArticle", x => x.ArtifactArticleId);
                    table.ForeignKey(
                        name: "FK_ArtifactArticle_Artifact_ArtifactId",
                        column: x => x.ArtifactId,
                        principalTable: "Artifact",
                        principalColumn: "ArtifactId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtifactArticle_Creator_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Creator",
                        principalColumn: "CreatorId");
                });

            migrationBuilder.CreateTable(
                name: "ArtifactImage",
                columns: table => new
                {
                    ArtifactImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ArtifactId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtifactImage", x => x.ArtifactImageId);
                    table.ForeignKey(
                        name: "FK_ArtifactImage_Artifact_ArtifactId",
                        column: x => x.ArtifactId,
                        principalTable: "Artifact",
                        principalColumn: "ArtifactId");
                });

            migrationBuilder.CreateTable(
                name: "CultureArticle",
                columns: table => new
                {
                    CultureArticleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThumbnailImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CultureId = table.Column<int>(type: "int", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CultureArticle", x => x.CultureArticleId);
                    table.ForeignKey(
                        name: "FK_CultureArticle_Creator_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Creator",
                        principalColumn: "CreatorId");
                    table.ForeignKey(
                        name: "FK_CultureArticle_Culture_CultureId",
                        column: x => x.CultureId,
                        principalTable: "Culture",
                        principalColumn: "CultureId");
                });

            migrationBuilder.CreateTable(
                name: "CultureImage",
                columns: table => new
                {
                    CultureImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CultureId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CultureImage", x => x.CultureImageId);
                    table.ForeignKey(
                        name: "FK_CultureImage_Culture_CultureId",
                        column: x => x.CultureId,
                        principalTable: "Culture",
                        principalColumn: "CultureId");
                });

            migrationBuilder.CreateTable(
                name: "ExhibitionArticle",
                columns: table => new
                {
                    ExhibitionArticleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThumbnailImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ExhibitionId = table.Column<int>(type: "int", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExhibitionArticle", x => x.ExhibitionArticleId);
                    table.ForeignKey(
                        name: "FK_ExhibitionArticle_Creator_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Creator",
                        principalColumn: "CreatorId");
                    table.ForeignKey(
                        name: "FK_ExhibitionArticle_Exhibition_ExhibitionId",
                        column: x => x.ExhibitionId,
                        principalTable: "Exhibition",
                        principalColumn: "ExhibitionId");
                });

            migrationBuilder.CreateTable(
                name: "ExhibitionImage",
                columns: table => new
                {
                    ExhibitionImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExhibitionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExhibitionImage", x => x.ExhibitionImageId);
                    table.ForeignKey(
                        name: "FK_ExhibitionImage_Exhibition_ExhibitionId",
                        column: x => x.ExhibitionId,
                        principalTable: "Exhibition",
                        principalColumn: "ExhibitionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NationalEventArticle",
                columns: table => new
                {
                    NationalEventArticleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThumbnailImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    NationalEventID = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NationalEventArticle", x => x.NationalEventArticleId);
                    table.ForeignKey(
                        name: "FK_NationalEventArticle_Creator_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Creator",
                        principalColumn: "CreatorId");
                    table.ForeignKey(
                        name: "FK_NationalEventArticle_NationalEvent_NationalEventID",
                        column: x => x.NationalEventID,
                        principalTable: "NationalEvent",
                        principalColumn: "NationalEventID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NationalEventImage",
                columns: table => new
                {
                    NationalEventImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalEventID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NationalEventImage", x => x.NationalEventImageId);
                    table.ForeignKey(
                        name: "FK_NationalEventImage_NationalEvent_NationalEventID",
                        column: x => x.NationalEventID,
                        principalTable: "NationalEvent",
                        principalColumn: "NationalEventID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtifactArticleImage",
                columns: table => new
                {
                    ArtifactArticleImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArtifactArticleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtifactArticleImage", x => x.ArtifactArticleImageId);
                    table.ForeignKey(
                        name: "FK_ArtifactArticleImage_ArtifactArticle_ArtifactArticleId",
                        column: x => x.ArtifactArticleId,
                        principalTable: "ArtifactArticle",
                        principalColumn: "ArtifactArticleId");
                });

            migrationBuilder.CreateTable(
                name: "CultureArticleImage",
                columns: table => new
                {
                    CultureArticleImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CultureArticleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CultureArticleImage", x => x.CultureArticleImageId);
                    table.ForeignKey(
                        name: "FK_CultureArticleImage_CultureArticle_CultureArticleId",
                        column: x => x.CultureArticleId,
                        principalTable: "CultureArticle",
                        principalColumn: "CultureArticleId");
                });

            migrationBuilder.CreateTable(
                name: "ExhibitionArticleImage",
                columns: table => new
                {
                    ExhibitionArticleImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExhibitionArticleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExhibitionArticleImage", x => x.ExhibitionArticleImageId);
                    table.ForeignKey(
                        name: "FK_ExhibitionArticleImage_ExhibitionArticle_ExhibitionArticleId",
                        column: x => x.ExhibitionArticleId,
                        principalTable: "ExhibitionArticle",
                        principalColumn: "ExhibitionArticleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NationalEventArticleImage",
                columns: table => new
                {
                    NationalEventArticleImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalEventArticleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NationalEventArticleImage", x => x.NationalEventArticleImageId);
                    table.ForeignKey(
                        name: "FK_NationalEventArticleImage_NationalEventArticle_NationalEventArticleId",
                        column: x => x.NationalEventArticleId,
                        principalTable: "NationalEventArticle",
                        principalColumn: "NationalEventArticleId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artifact_CreatorId",
                table: "Artifact",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtifactArticle_ArtifactId",
                table: "ArtifactArticle",
                column: "ArtifactId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtifactArticle_CreatorId",
                table: "ArtifactArticle",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtifactArticleImage_ArtifactArticleId",
                table: "ArtifactArticleImage",
                column: "ArtifactArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtifactImage_ArtifactId",
                table: "ArtifactImage",
                column: "ArtifactId");

            migrationBuilder.CreateIndex(
                name: "IX_Culture_CreatorId",
                table: "Culture",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_CultureArticle_CreatorId",
                table: "CultureArticle",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_CultureArticle_CultureId",
                table: "CultureArticle",
                column: "CultureId");

            migrationBuilder.CreateIndex(
                name: "IX_CultureArticleImage_CultureArticleId",
                table: "CultureArticleImage",
                column: "CultureArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_CultureImage_CultureId",
                table: "CultureImage",
                column: "CultureId");

            migrationBuilder.CreateIndex(
                name: "IX_Exhibition_CreatorId",
                table: "Exhibition",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ExhibitionArticle_CreatorId",
                table: "ExhibitionArticle",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ExhibitionArticle_ExhibitionId",
                table: "ExhibitionArticle",
                column: "ExhibitionId");

            migrationBuilder.CreateIndex(
                name: "IX_ExhibitionArticleImage_ExhibitionArticleId",
                table: "ExhibitionArticleImage",
                column: "ExhibitionArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ExhibitionImage_ExhibitionId",
                table: "ExhibitionImage",
                column: "ExhibitionId");

            migrationBuilder.CreateIndex(
                name: "IX_NationalEvent_CreatorId",
                table: "NationalEvent",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_NationalEventArticle_CreatorId",
                table: "NationalEventArticle",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_NationalEventArticle_NationalEventID",
                table: "NationalEventArticle",
                column: "NationalEventID");

            migrationBuilder.CreateIndex(
                name: "IX_NationalEventArticleImage_NationalEventArticleId",
                table: "NationalEventArticleImage",
                column: "NationalEventArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_NationalEventImage_NationalEventID",
                table: "NationalEventImage",
                column: "NationalEventID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtifactArticleImage");

            migrationBuilder.DropTable(
                name: "ArtifactImage");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "CultureArticleImage");

            migrationBuilder.DropTable(
                name: "CultureImage");

            migrationBuilder.DropTable(
                name: "ExhibitionArticleImage");

            migrationBuilder.DropTable(
                name: "ExhibitionImage");

            migrationBuilder.DropTable(
                name: "NationalEventArticleImage");

            migrationBuilder.DropTable(
                name: "NationalEventImage");

            migrationBuilder.DropTable(
                name: "ArtifactArticle");

            migrationBuilder.DropTable(
                name: "CultureArticle");

            migrationBuilder.DropTable(
                name: "ExhibitionArticle");

            migrationBuilder.DropTable(
                name: "NationalEventArticle");

            migrationBuilder.DropTable(
                name: "Artifact");

            migrationBuilder.DropTable(
                name: "Culture");

            migrationBuilder.DropTable(
                name: "Exhibition");

            migrationBuilder.DropTable(
                name: "NationalEvent");

            migrationBuilder.DropTable(
                name: "Creator");
        }
    }
}
