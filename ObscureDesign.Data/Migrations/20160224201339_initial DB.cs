using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace ObscureDesign.Data.Migrations
{
    public partial class initialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    TagId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.TagId);
                });
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DisplayName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Permissions = table.Column<int>(nullable: false),
                    CertificateThumbrint = table.Column<string>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });
            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    ArticleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    Abstract = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    Conclusion = table.Column<string>(nullable: false),
                    PreprocessorAQM = table.Column<string>(nullable: false),
                    PostprocessorAQM = table.Column<string>(nullable: false),
                    Created = table.Column<DateTime>(nullable: true),
                    Published = table.Column<DateTime>(nullable: true),
                    Updated = table.Column<DateTime>(nullable: true),
                    AuthorId = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.ArticleId);
                    table.ForeignKey(
                        name: "FK_Article_User_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "ArticleTag",
                columns: table => new
                {
                    TagId = table.Column<int>(nullable: false),
                    ArticleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleTag", x => new { x.TagId, x.ArticleId });
                    table.ForeignKey(
                        name: "FK_ArticleTag_Article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Article",
                        principalColumn: "ArticleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleTag_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    CommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArticleId = table.Column<int>(nullable: false),
                    Author = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Awards = table.Column<int>(nullable: false),
                    PreprocessorAQM = table.Column<string>(nullable: false),
                    PostprocessorAQM = table.Column<string>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comment_Article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Article",
                        principalColumn: "ArticleId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateIndex(
                name: "IX_Tag_Name",
                table: "Tag",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("ArticleTag");
            migrationBuilder.DropTable("Comment");
            migrationBuilder.DropTable("Tag");
            migrationBuilder.DropTable("Article");
            migrationBuilder.DropTable("User");
        }
    }
}
