// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlayerInfoGQL.Data;

#nullable disable

namespace PlayerInfoGQL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220620031055_ChangeDeleteBehaviourToRestrict")]
    partial class ChangeDeleteBehaviourToRestrict
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.6");

            modelBuilder.Entity("PlayerInfoGQL.Models.AnalysisResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AnalysisResults");
                });

            modelBuilder.Entity("PlayerInfoGQL.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("Type");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("PlayerInfoGQL.Models.CommentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CommentTypes");
                });

            modelBuilder.Entity("PlayerInfoGQL.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("AnalysisResult")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("BehaviourScore")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("LoyaltyScore")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("PotentialScore")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeamId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AnalysisResult");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("PlayerInfoGQL.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("League")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("PlayerInfoGQL.Models.Comment", b =>
                {
                    b.HasOne("PlayerInfoGQL.Models.Player", "Player")
                        .WithMany("Comments")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("ForeignKey_Comment_Player");

                    b.HasOne("PlayerInfoGQL.Models.CommentType", null)
                        .WithMany()
                        .HasForeignKey("Type")
                        .HasPrincipalKey("Description")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("ForeignKey_Comment_CommentType");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("PlayerInfoGQL.Models.Player", b =>
                {
                    b.HasOne("PlayerInfoGQL.Models.AnalysisResult", null)
                        .WithMany()
                        .HasForeignKey("AnalysisResult")
                        .HasPrincipalKey("Description")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("ForeignKey_Player_AnalysisResult");

                    b.HasOne("PlayerInfoGQL.Models.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("ForeignKey_Player_Team");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("PlayerInfoGQL.Models.Player", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("PlayerInfoGQL.Models.Team", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
