using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace ObscureDesign.Data.Migrations
{
    public partial class Removedpreprocessors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Article_User_AuthorId", table: "Article");
            migrationBuilder.DropForeignKey(name: "FK_ArticleTag_Article_ArticleId", table: "ArticleTag");
            migrationBuilder.DropForeignKey(name: "FK_ArticleTag_Tag_TagId", table: "ArticleTag");
            migrationBuilder.DropForeignKey(name: "FK_Comment_Article_ArticleId", table: "Comment");
            migrationBuilder.DropColumn(name: "PreprocessorAQM", table: "Comment");
            migrationBuilder.DropColumn(name: "PreprocessorAQM", table: "Article");
            migrationBuilder.CreateIndex(
                name: "IX_Article_Slug",
                table: "Article",
                column: "Slug",
                unique: true);
            migrationBuilder.AddForeignKey(
                name: "FK_Article_User_AuthorId",
                table: "Article",
                column: "AuthorId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_ArticleTag_Article_ArticleId",
                table: "ArticleTag",
                column: "ArticleId",
                principalTable: "Article",
                principalColumn: "ArticleId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_ArticleTag_Tag_TagId",
                table: "ArticleTag",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Article_ArticleId",
                table: "Comment",
                column: "ArticleId",
                principalTable: "Article",
                principalColumn: "ArticleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Article_User_AuthorId", table: "Article");
            migrationBuilder.DropForeignKey(name: "FK_ArticleTag_Article_ArticleId", table: "ArticleTag");
            migrationBuilder.DropForeignKey(name: "FK_ArticleTag_Tag_TagId", table: "ArticleTag");
            migrationBuilder.DropForeignKey(name: "FK_Comment_Article_ArticleId", table: "Comment");
            migrationBuilder.DropIndex(name: "IX_Article_Slug", table: "Article");
            migrationBuilder.AddColumn<string>(
                name: "PreprocessorAQM",
                table: "Comment",
                nullable: false,
                defaultValue: "");
            migrationBuilder.AddColumn<string>(
                name: "PreprocessorAQM",
                table: "Article",
                nullable: false,
                defaultValue: "");
            migrationBuilder.AddForeignKey(
                name: "FK_Article_User_AuthorId",
                table: "Article",
                column: "AuthorId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_ArticleTag_Article_ArticleId",
                table: "ArticleTag",
                column: "ArticleId",
                principalTable: "Article",
                principalColumn: "ArticleId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_ArticleTag_Tag_TagId",
                table: "ArticleTag",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Article_ArticleId",
                table: "Comment",
                column: "ArticleId",
                principalTable: "Article",
                principalColumn: "ArticleId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
