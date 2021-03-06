using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using ObscureDesign.Data;

namespace ObscureDesign.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20160313081908_Removed preprocessors")]
    partial class Removedpreprocessors
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ObscureDesign.Data.Article", b =>
                {
                    b.Property<int>("ArticleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Abstract")
                        .IsRequired();

                    b.Property<int>("AuthorId");

                    b.Property<string>("Conclusion")
                        .IsRequired();

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<DateTime?>("Created");

                    b.Property<string>("PostprocessorAQM")
                        .IsRequired();

                    b.Property<DateTime?>("Published");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<DateTime?>("Updated");

                    b.HasKey("ArticleId");

                    b.HasIndex("Slug")
                        .IsUnique();
                });

            modelBuilder.Entity("ObscureDesign.Data.ArticleTag", b =>
                {
                    b.Property<int>("TagId");

                    b.Property<int>("ArticleId");

                    b.HasKey("TagId", "ArticleId");
                });

            modelBuilder.Entity("ObscureDesign.Data.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ArticleId");

                    b.Property<string>("Author");

                    b.Property<int>("Awards");

                    b.Property<string>("Content");

                    b.Property<string>("PostprocessorAQM")
                        .IsRequired();

                    b.HasKey("CommentId");
                });

            modelBuilder.Entity("ObscureDesign.Data.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("TagId");

                    b.HasIndex("Name")
                        .IsUnique();
                });

            modelBuilder.Entity("ObscureDesign.Data.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CertificateThumbrint")
                        .IsRequired();

                    b.Property<string>("DisplayName")
                        .IsRequired();

                    b.Property<string>("Email");

                    b.Property<int>("Permissions");

                    b.HasKey("UserId");
                });

            modelBuilder.Entity("ObscureDesign.Data.Article", b =>
                {
                    b.HasOne("ObscureDesign.Data.User")
                        .WithMany()
                        .HasForeignKey("AuthorId");
                });

            modelBuilder.Entity("ObscureDesign.Data.ArticleTag", b =>
                {
                    b.HasOne("ObscureDesign.Data.Article")
                        .WithMany()
                        .HasForeignKey("ArticleId");

                    b.HasOne("ObscureDesign.Data.Tag")
                        .WithMany()
                        .HasForeignKey("TagId");
                });

            modelBuilder.Entity("ObscureDesign.Data.Comment", b =>
                {
                    b.HasOne("ObscureDesign.Data.Article")
                        .WithMany()
                        .HasForeignKey("ArticleId");
                });
        }
    }
}
