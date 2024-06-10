using Microsoft.EntityFrameworkCore;
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
        public DbSet<ArticleRelecteur> ArticleRelecteurs { get; set; }
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

            modelBuilder.Entity<ParticipantConference>()
                .HasKey(aa => new { aa.ParticipantId, aa.ConferenceId });

            modelBuilder.Entity<ArticleAuteur>()
                .HasOne(aa => aa.Article)
                .WithMany(a => a.Auteurs)
                .HasForeignKey(aa => aa.ArticleId);

            modelBuilder.Entity<ParticipantConference>()
                .HasOne(aa => aa.Participant)
                .WithMany(a => a.Conferences)
                .HasForeignKey(aa => aa.ParticipantId);

            modelBuilder.Entity<ParticipantConference>()
                .HasOne(aa => aa.Conference)
                .WithMany(a => a.Participants)
                .HasForeignKey(aa => aa.ConferenceId);

            modelBuilder.Entity<ArticleAuteur>()
                .HasOne(aa => aa.Auteur)
                .WithMany(a => a.Articles)
                .HasForeignKey(aa => aa.AuteurId);

            modelBuilder.Entity<ArticleRelecteur>()
                .HasKey(apr => new { apr.ArticleId, apr.RelecteurId });

            modelBuilder.Entity<ArticleRelecteur>()
                .HasOne(apr => apr.Article)
                .WithMany(a => a.Relecteurs)
                .HasForeignKey(apr => apr.ArticleId);

            modelBuilder.Entity<ArticleRelecteur>()
                .HasOne(apr => apr.Relecteur)
                .WithMany(pr => pr.Articles)
                .HasForeignKey(apr => apr.RelecteurId);

            modelBuilder.Entity<Relecture>()
                .HasOne(r => r.ArticleRelecteur)
                .WithOne(apr => apr.Relecture)
                .HasForeignKey<ArticleRelecteur>(apr => apr.RelectureId);

            modelBuilder.Entity<Relecteur>()
                .HasMany(pr => pr.Relectures)
                .WithOne(r => r.Relecteur)
                .HasForeignKey(r => r.RelecteurId);

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
                entity.Property(e => e.Comments).HasColumnType("varchar(100)");
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
