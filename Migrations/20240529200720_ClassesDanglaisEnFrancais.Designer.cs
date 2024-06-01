﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using blazor_gestconf.Data;

#nullable disable

namespace blazor_gestconf.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240529200720_ClassesDanglaisEnFrancais")]
    partial class ClassesDanglaisEnFrancais
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("blazor_gestconf.Models.Administrateur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("MotDePasse")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Administrateurs");
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

                    b.Property<string>("FichierPdf")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Statut")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("blazor_gestconf.Models.ArticleAuthor", b =>
                {
                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.HasKey("ArticleId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.ToTable("ArticleAuthors");
                });

            modelBuilder.Entity("blazor_gestconf.Models.ArticleProofReader", b =>
                {
                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<int>("ProofReaderId")
                        .HasColumnType("int");

                    b.Property<int?>("RelectureId")
                        .HasColumnType("int");

                    b.HasKey("ArticleId", "ProofReaderId");

                    b.HasIndex("ProofReaderId");

                    b.HasIndex("RelectureId")
                        .IsUnique();

                    b.ToTable("ArticleProofReaders");
                });

            modelBuilder.Entity("blazor_gestconf.Models.Auteur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Entreprise")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("MotDePasse")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Universite")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Auteurs");
                });

            modelBuilder.Entity("blazor_gestconf.Models.Conference", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateConferenceDebut")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateConferenceFin")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateInscriptionDebut")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateInscriptionFin")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateRemiseResultats")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateSoumissionDebut")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateSoumissionFin")
                        .HasColumnType("datetime(6)");

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

            modelBuilder.Entity("blazor_gestconf.Models.MembreComite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("MotDePasse")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.ToTable("MembreComites");
                });

            modelBuilder.Entity("blazor_gestconf.Models.Participant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("MotDePasse")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Participants");
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

            modelBuilder.Entity("blazor_gestconf.Models.Relecteur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("MotDePasse")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Relecteurs");
                });

            modelBuilder.Entity("blazor_gestconf.Models.Relecture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArticleProofReaderId")
                        .HasColumnType("int");

                    b.Property<string>("Comments")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Justification")
                        .HasColumnType("varchar(100)");

                    b.Property<int>("NoteFond")
                        .HasColumnType("int");

                    b.Property<int>("NoteForme")
                        .HasColumnType("int");

                    b.Property<int>("NotePertinenceScientifique")
                        .HasColumnType("int");

                    b.Property<int>("ProofReaderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProofReaderId");

                    b.ToTable("Relectures");
                });

            modelBuilder.Entity("blazor_gestconf.Models.ArticleAuthor", b =>
                {
                    b.HasOne("blazor_gestconf.Models.Article", "Article")
                        .WithMany("Author")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("blazor_gestconf.Models.Auteur", "Author")
                        .WithMany("Articles")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("blazor_gestconf.Models.ArticleProofReader", b =>
                {
                    b.HasOne("blazor_gestconf.Models.Article", "Article")
                        .WithMany("ArticleProofReaders")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("blazor_gestconf.Models.Relecteur", "ProofReader")
                        .WithMany("Articles")
                        .HasForeignKey("ProofReaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("blazor_gestconf.Models.Relecture", "Relecture")
                        .WithOne("ArticleProofReader")
                        .HasForeignKey("blazor_gestconf.Models.ArticleProofReader", "RelectureId");

                    b.Navigation("Article");

                    b.Navigation("ProofReader");

                    b.Navigation("Relecture");
                });

            modelBuilder.Entity("blazor_gestconf.Models.ParticipantConference", b =>
                {
                    b.HasOne("blazor_gestconf.Models.Conference", "Conference")
                        .WithMany("Participants")
                        .HasForeignKey("ConferenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("blazor_gestconf.Models.Participant", "Participant")
                        .WithMany("Conferences")
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conference");

                    b.Navigation("Participant");
                });

            modelBuilder.Entity("blazor_gestconf.Models.Relecture", b =>
                {
                    b.HasOne("blazor_gestconf.Models.Relecteur", "ProofReader")
                        .WithMany("Relectures")
                        .HasForeignKey("ProofReaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProofReader");
                });

            modelBuilder.Entity("blazor_gestconf.Models.Article", b =>
                {
                    b.Navigation("ArticleProofReaders");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("blazor_gestconf.Models.Auteur", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("blazor_gestconf.Models.Conference", b =>
                {
                    b.Navigation("Participants");
                });

            modelBuilder.Entity("blazor_gestconf.Models.Participant", b =>
                {
                    b.Navigation("Conferences");
                });

            modelBuilder.Entity("blazor_gestconf.Models.Relecteur", b =>
                {
                    b.Navigation("Articles");

                    b.Navigation("Relectures");
                });

            modelBuilder.Entity("blazor_gestconf.Models.Relecture", b =>
                {
                    b.Navigation("ArticleProofReader")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}