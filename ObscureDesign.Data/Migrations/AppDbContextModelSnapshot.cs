using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;

namespace ObscureDesign.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ObscureDesign.Web.Models.Article", b =>
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

                    b.Property<string>("PreprocessorAQM")
                        .IsRequired();

                    b.Property<DateTime?>("Published");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<DateTime?>("Updated");

                    b.HasKey("ArticleId");
                });

            modelBuilder.Entity("ObscureDesign.Web.Models.ArticleTag", b =>
                {
                    b.Property<int>("TagId");

                    b.Property<int>("ArticleId");

                    b.HasKey("TagId", "ArticleId");
                });

            modelBuilder.Entity("ObscureDesign.Web.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ArticleId");

                    b.Property<string>("Author");

                    b.Property<int>("Awards");

                    b.Property<string>("Content");

                    b.Property<string>("PostprocessorAQM")
                        .IsRequired();

                    b.Property<string>("PreprocessorAQM")
                        .IsRequired();

                    b.HasKey("CommentId");
                });

            modelBuilder.Entity("ObscureDesign.Web.Models.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("TagId");

                    b.HasIndex("Name")
                        .IsUnique();
                });

            modelBuilder.Entity("ObscureDesign.Web.Models.User", b =>
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

            modelBuilder.Entity("ObscureDesign.Web.Models.Article", b =>
                {
                    b.HasOne("ObscureDesign.Web.Models.User")
                        .WithMany()
                        .HasForeignKey("AuthorId");
                });

            modelBuilder.Entity("ObscureDesign.Web.Models.ArticleTag", b =>
                {
                    b.HasOne("ObscureDesign.Web.Models.Article")
                        .WithMany()
                        .HasForeignKey("ArticleId");

                    b.HasOne("ObscureDesign.Web.Models.Tag")
                        .WithMany()
                        .HasForeignKey("TagId");
                });

            modelBuilder.Entity("ObscureDesign.Web.Models.Comment", b =>
                {
                    b.HasOne("ObscureDesign.Web.Models.Article")
                        .WithMany()
                        .HasForeignKey("ArticleId");
                });
        }
    }
}
