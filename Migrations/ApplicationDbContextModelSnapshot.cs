﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using blazor_gestconf.Data;

#nullable disable

namespace blazor_gestconf.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("longtext");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("longtext");

                    b.HasKey("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("blazor_gestconf.Models.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ConferenceId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<byte[]>("FichierPdf")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<string>("Statut")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ConferenceId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("blazor_gestconf.Models.ArticleAuteur", b =>
                {
                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<int>("AuteurId")
                        .HasColumnType("int");

                    b.HasKey("ArticleId", "AuteurId");

                    b.HasIndex("AuteurId");

                    b.ToTable("ArticleAuteurs");
                });

            modelBuilder.Entity("blazor_gestconf.Models.Conference", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateConferenceDebut")
                        .HasColumnType("Date");

                    b.Property<DateTime>("DateConferenceFin")
                        .HasColumnType("Date");

                    b.Property<DateTime>("DateInscriptionDebut")
                        .HasColumnType("Date");

                    b.Property<DateTime>("DateInscriptionFin")
                        .HasColumnType("Date");

                    b.Property<DateTime>("DateRemiseResultats")
                        .HasColumnType("Date");

                    b.Property<DateTime>("DateSoumissionDebut")
                        .HasColumnType("Date");

                    b.Property<DateTime>("DateSoumissionFin")
                        .HasColumnType("Date");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("varchar(155)");

                    b.Property<string>("Sigle")
                        .IsRequired()
                        .HasColumnType("varchar(155)");

                    b.Property<string>("Theme")
                        .IsRequired()
                        .HasColumnType("varchar(155)");

                    b.HasKey("Id");

                    b.ToTable("Conferences");
                });

            modelBuilder.Entity("blazor_gestconf.Models.Entreprise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adresse")
                        .HasColumnType("varchar(155)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("varchar(155)");

                    b.HasKey("Id");

                    b.ToTable("Entreprises");
                });

            modelBuilder.Entity("blazor_gestconf.Models.ParticipantAvis", b =>
                {
                    b.Property<int>("ParticipantId")
                        .HasColumnType("int");

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<string>("Avis")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ParticipantId", "ArticleId");

                    b.HasIndex("ArticleId");

                    b.ToTable("ParticipantAvis");
                });

            modelBuilder.Entity("blazor_gestconf.Models.ParticipantConference", b =>
                {
                    b.Property<int>("ParticipantId")
                        .HasColumnType("int");

                    b.Property<int>("ConferenceId")
                        .HasColumnType("int");

                    b.HasKey("ParticipantId", "ConferenceId");

                    b.HasIndex("ConferenceId");

                    b.ToTable("ParticipantConferences");
                });

            modelBuilder.Entity("blazor_gestconf.Models.Relecture", b =>
                {
                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<int>("RelecteurId")
                        .HasColumnType("int");

                    b.Property<int>("AuteurId")
                        .HasColumnType("int");

                    b.Property<string>("Avis")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Justification")
                        .HasColumnType("varchar(100)");

                    b.Property<int>("NoteFond")
                        .HasColumnType("int");

                    b.Property<int>("NoteForme")
                        .HasColumnType("int");

                    b.Property<int>("NotePertinenceScientifique")
                        .HasColumnType("int");

                    b.HasKey("ArticleId", "RelecteurId");

                    b.HasIndex("AuteurId");

                    b.HasIndex("RelecteurId");

                    b.ToTable("Relectures");
                });

            modelBuilder.Entity("blazor_gestconf.Models.Universite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adresse")
                        .HasColumnType("varchar(155)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("varchar(155)");

                    b.HasKey("Id");

                    b.ToTable("Universites");
                });

            modelBuilder.Entity("blazor_gestconf.Models.Utilisateur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("varchar(21)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("Utilisateur");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("blazor_gestconf.Models.Administrateur", b =>
                {
                    b.HasBaseType("blazor_gestconf.Models.Utilisateur");

                    b.HasDiscriminator().HasValue("Administrateur");
                });

            modelBuilder.Entity("blazor_gestconf.Models.Auteur", b =>
                {
                    b.HasBaseType("blazor_gestconf.Models.Utilisateur");

                    b.Property<int?>("EntrepriseId")
                        .HasColumnType("int");

                    b.Property<int?>("UniversiteId")
                        .HasColumnType("int");

                    b.HasIndex("EntrepriseId");

                    b.HasIndex("UniversiteId");

                    b.HasDiscriminator().HasValue("Auteur");
                });

            modelBuilder.Entity("blazor_gestconf.Models.MembreComite", b =>
                {
                    b.HasBaseType("blazor_gestconf.Models.Utilisateur");

                    b.HasDiscriminator().HasValue("MembreComite");
                });

            modelBuilder.Entity("blazor_gestconf.Models.Participant", b =>
                {
                    b.HasBaseType("blazor_gestconf.Models.Utilisateur");

                    b.HasDiscriminator().HasValue("Participant");
                });

            modelBuilder.Entity("blazor_gestconf.Models.Relecteur", b =>
                {
                    b.HasBaseType("blazor_gestconf.Models.Utilisateur");

                    b.HasDiscriminator().HasValue("Relecteur");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("blazor_gestconf.Models.Utilisateur", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("blazor_gestconf.Models.Utilisateur", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("blazor_gestconf.Models.Utilisateur", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("blazor_gestconf.Models.Utilisateur", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("blazor_gestconf.Models.Article", b =>
                {
                    b.HasOne("blazor_gestconf.Models.Conference", "Conference")
                        .WithMany("Articles")
                        .HasForeignKey("ConferenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conference");
                });

            modelBuilder.Entity("blazor_gestconf.Models.ArticleAuteur", b =>
                {
                    b.HasOne("blazor_gestconf.Models.Article", "Article")
                        .WithMany("Auteurs")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("blazor_gestconf.Models.Auteur", "Auteur")
                        .WithMany("Articles")
                        .HasForeignKey("AuteurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("Auteur");
                });

            modelBuilder.Entity("blazor_gestconf.Models.ParticipantAvis", b =>
                {
                    b.HasOne("blazor_gestconf.Models.Article", "Article")
                        .WithMany("ParticipantAvis")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("blazor_gestconf.Models.Participant", "Participant")
                        .WithMany("ParticipantAvis")
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("Participant");
                });

            modelBuilder.Entity("blazor_gestconf.Models.ParticipantConference", b =>
                {
                    b.HasOne("blazor_gestconf.Models.Conference", "Conference")
                        .WithMany("ParticipantConferences")
                        .HasForeignKey("ConferenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("blazor_gestconf.Models.Participant", "Participant")
                        .WithMany("ParticipantConferences")
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conference");

                    b.Navigation("Participant");
                });

            modelBuilder.Entity("blazor_gestconf.Models.Relecture", b =>
                {
                    b.HasOne("blazor_gestconf.Models.Article", "Article")
                        .WithMany("Relectures")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("blazor_gestconf.Models.Auteur", "Auteur")
                        .WithMany("Relectures")
                        .HasForeignKey("AuteurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("blazor_gestconf.Models.Relecteur", "Relecteur")
                        .WithMany("Relectures")
                        .HasForeignKey("RelecteurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("Auteur");

                    b.Navigation("Relecteur");
                });

            modelBuilder.Entity("blazor_gestconf.Models.Auteur", b =>
                {
                    b.HasOne("blazor_gestconf.Models.Entreprise", "Entreprise")
                        .WithMany()
                        .HasForeignKey("EntrepriseId");

                    b.HasOne("blazor_gestconf.Models.Universite", "Universite")
                        .WithMany()
                        .HasForeignKey("UniversiteId");

                    b.Navigation("Entreprise");

                    b.Navigation("Universite");
                });

            modelBuilder.Entity("blazor_gestconf.Models.Article", b =>
                {
                    b.Navigation("Auteurs");

                    b.Navigation("ParticipantAvis");

                    b.Navigation("Relectures");
                });

            modelBuilder.Entity("blazor_gestconf.Models.Conference", b =>
                {
                    b.Navigation("Articles");

                    b.Navigation("ParticipantConferences");
                });

            modelBuilder.Entity("blazor_gestconf.Models.Auteur", b =>
                {
                    b.Navigation("Articles");

                    b.Navigation("Relectures");
                });

            modelBuilder.Entity("blazor_gestconf.Models.Participant", b =>
                {
                    b.Navigation("ParticipantAvis");

                    b.Navigation("ParticipantConferences");
                });

            modelBuilder.Entity("blazor_gestconf.Models.Relecteur", b =>
                {
                    b.Navigation("Relectures");
                });
#pragma warning restore 612, 618
        }
    }
}
