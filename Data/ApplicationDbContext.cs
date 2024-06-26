﻿using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace blazor_gestconf.Data
{
    public class ApplicationDbContext : IdentityDbContext<Utilisateur, IdentityRole<int>, int>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleAuteur> ArticleAuteurs { get; set; }
        public DbSet<ParticipantConference> ParticipantConferences { get; set; }
        public DbSet<ParticipantAvis> ParticipantAvis { get; set; }



        // public DbSet<ArticleRelecteur> ArticleRelecteurs { get; set; }

        public DbSet<Conference> Conferences { get; set; }
        public DbSet<Administrateur> Administrateurs { get; set; }
        public DbSet<Universite> Universites { get; set; }
        public DbSet<Entreprise> Entreprises { get; set; }
        public DbSet<MembreComite> MembreComites { get; set; }
        public DbSet<Relecteur> Relecteurs { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Auteur> Auteurs { get; set; }
        public DbSet<Relecture> Relectures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuration de la relation entre Auteur et Entreprise
            modelBuilder.Entity<Auteur>()
                .HasOne(a => a.Entreprise)
                .WithMany()
                .HasForeignKey(a => a.EntrepriseId);

            modelBuilder.Entity<Entreprise>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Nom).HasColumnType("varchar(155)");
                entity.Property(a => a.Adresse).HasColumnType("varchar(155)");
            });


            modelBuilder.Entity<Universite>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Nom).HasColumnType("varchar(155)");
                entity.Property(a => a.Adresse).HasColumnType("varchar(155)");
            });


            // Configuration de la relation entre Auteur et Universite
            modelBuilder.Entity<Auteur>()
                .HasOne(a => a.Universite)
                .WithMany()
                .HasForeignKey(a => a.UniversiteId);  // Important d'appeler la base!

            modelBuilder.Entity<IdentityUserLogin<int>>()
                .HasKey(login => login.UserId);

            modelBuilder.Entity<IdentityUserRole<int>>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<IdentityUserToken<int>>(b =>
            {
                b.HasKey(ut => new { ut.UserId, ut.LoginProvider, ut.Name });
            });


            modelBuilder.Entity<ArticleAuteur>()
                .HasKey(aa => new { aa.ArticleId, aa.AuteurId });


            modelBuilder.Entity<ArticleAuteur>()
                .HasOne(aa => aa.Article)
                .WithMany(a => a.Auteurs)
                .HasForeignKey(aa => aa.ArticleId);


            modelBuilder.Entity<ParticipantConference>()
            .HasKey(pc => new { pc.ParticipantId, pc.ConferenceId });

            modelBuilder.Entity<ParticipantConference>()
                .HasOne(pc => pc.Participant)
                .WithMany(p => p.ParticipantConferences)
                .HasForeignKey(pc => pc.ParticipantId);

            modelBuilder.Entity<ParticipantConference>()
                .HasOne(pc => pc.Conference)
                .WithMany(c => c.ParticipantConferences)
                .HasForeignKey(pc => pc.ConferenceId);

            modelBuilder.Entity<ParticipantConference>()
                .HasKey(aa => new { aa.ParticipantId, aa.ConferenceId });

            modelBuilder.Entity<Relecture>()
                .HasKey(apr => new { apr.ArticleId, apr.RelecteurId });

            modelBuilder.Entity<Relecture>()
            .HasOne(r => r.Article)
            .WithMany(a => a.Relectures)
            .HasForeignKey(r => r.ArticleId)
            .OnDelete(DeleteBehavior.Cascade); // ou DeleteBehavior.Restrict selon votre logique métier

        modelBuilder.Entity<Relecture>()
            .HasOne(r => r.Relecteur)
            .WithMany(a => a.Relectures)
            .HasForeignKey(r => r.RelecteurId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ArticleAuteur>()
                .HasKey(aa => new { aa.ArticleId, aa.AuteurId });



            modelBuilder.Entity<ArticleAuteur>()
                .HasOne(aa => aa.Article)
                .WithMany(a => a.Auteurs)
                .HasForeignKey(aa => aa.ArticleId);



            modelBuilder.Entity<ArticleAuteur>()
                .HasOne(aa => aa.Auteur)
                .WithMany(a => a.Articles)
                .HasForeignKey(aa => aa.AuteurId);

            modelBuilder.Entity<ParticipantAvis>()
                .HasKey(pa => new { pa.ParticipantId, pa.ArticleId });

            modelBuilder.Entity<ParticipantAvis>()
                .HasOne(pa => pa.Participant)
                .WithMany(p => p.ParticipantAvis)
                .HasForeignKey(pa => pa.ParticipantId);

            modelBuilder.Entity<ParticipantAvis>()
                .HasOne(pa=>pa.Article)
                .WithMany(a => a.ParticipantAvis)
                .HasForeignKey(pa=>pa.ArticleId);


            // modelBuilder.Entity<ArticleRelecteur>()
            //     .HasKey(apr => new { apr.ArticleId, apr.RelecteurId });


            // modelBuilder.Entity<ArticleRelecteur>()
            //     .HasOne(apr => apr.Article)
            //     .WithMany(a => a.Relecteurs)
            //     .HasForeignKey(apr => apr.ArticleId);


            // modelBuilder.Entity<ArticleRelecteur>()
            //     .HasOne(apr => apr.Relecteur)
            //     .WithMany(pr => pr.Articles)
            //     .HasForeignKey(apr => apr.RelecteurId);

            // modelBuilder.Entity<Relecture>()
            //     .HasOne(r => r.ArticleRelecteur)
            //     .WithOne(apr => apr.Relecture)
            //     .HasForeignKey<ArticleRelecteur>(apr => apr.RelectureId);

            // modelBuilder.Entity<Relecteur>()
            //     .HasMany(pr => pr.Relectures)
            //     .WithOne(r => r.Relecteur)
            //     .HasForeignKey(r => r.RelecteurId);

            modelBuilder.Entity<Conference>(entity =>
            {
                entity.Property(e => e.Nom).HasColumnType("varchar(155)");
                entity.Property(e => e.Sigle).HasColumnType("varchar(155)");
                entity.Property(e => e.Theme).HasColumnType("varchar(155)");
                entity.Property(e => e.DateSoumissionDebut).HasColumnType("Date");
                entity.Property(e => e.DateSoumissionFin).HasColumnType("Date");
                entity.Property(e => e.DateRemiseResultats).HasColumnType("Date");
                entity.Property(e => e.DateInscriptionDebut).HasColumnType("Date");
                entity.Property(e => e.DateInscriptionFin).HasColumnType("Date");
                entity.Property(e => e.DateConferenceDebut).HasColumnType("Date");
                entity.Property(e => e.DateConferenceFin).HasColumnType("Date");
            });


            modelBuilder.Entity<Relecture>(entity =>
            {
                entity.Property(e => e.Justification).HasColumnType("varchar(100)");
                entity.Property(e => e.Avis).HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<Article>(entity =>
            {
                entity.Property(e => e.Titre).HasColumnType("varchar(100)");
                entity.Property(e => e.Description).HasColumnType("varchar(150)");
                entity.Property(e => e.Statut).HasColumnType("varchar(100)");
                entity.HasOne(a => a.Conference)
                      .WithMany(c => c.Articles)
                      .HasForeignKey(a => a.ConferenceId);
            });
        }
    }
}
