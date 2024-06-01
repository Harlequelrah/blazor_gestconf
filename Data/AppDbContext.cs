using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace blazor_gestconf.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Auteur> Auteurs { get; set; }
        public DbSet<ArticleAuteur> ArticleAuteurs { get; set; }

        public DbSet<ParticipantConference> ParticipantConferences { get; set; }
        public DbSet<ArticleRelecteur> ArticleRelecteurs { get; set; }
        public DbSet<Administrateur> Administrateurs { get; set; }
        public DbSet<Conference> Conferences { get; set;}
        // public DbSet<User> Users { get; set; }
        public DbSet<Relecture> Relectures { get; set; }
        public DbSet<MembreComite> MembreComites { get; set; }
        public DbSet<Relecteur> Relecteurs{ get; set; }
        public DbSet<Participant> Participants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration de la table de jonction ArticleAuteur
            modelBuilder.Entity<ArticleAuteur>()
                .HasKey(aa => new { aa.ArticleId, aa.AuteurId });

            modelBuilder.Entity<ParticipantConference>()
                .HasKey(aa => new { aa.ParticipantId, aa.ConferenceId });

            modelBuilder.Entity<ArticleAuteur>()
                .HasOne(aa => aa.Article)
                .WithMany(a => a.Auteur)
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

            // Configuration de la table de jonction ArticleRelecteur
            modelBuilder.Entity<ArticleRelecteur>()
                .HasKey(apr => new { apr.ArticleId, apr.RelecteurId });

            modelBuilder.Entity<ArticleRelecteur>()
                .HasOne(apr => apr.Article)
                .WithMany(a => a.ArticleRelecteurs)
                .HasForeignKey(apr => apr.ArticleId);



            modelBuilder.Entity<ArticleRelecteur>()
                .HasOne(apr => apr.Relecteur)
                .WithMany(pr => pr.Articles)
                .HasForeignKey(apr => apr.RelecteurId);

            // Configuration de la relation un-à-un entre ArticleRelecteur et Relecture
            modelBuilder.Entity<Relecture>()
                .HasOne(r => r.ArticleRelecteur)
                .WithOne(apr => apr.Relecture)
                .HasForeignKey<ArticleRelecteur>(apr => apr.RelectureId) ;// Utilisez la clé étrangère appropriée ici
                // .OnDelete(DeleteBehavior.Cascade); Supprimez cette ligne si la suppression en cascade n'est pas souhaitée

            // Configuration de la relation entre Relecteur et Relecture
            modelBuilder.Entity<Relecteur>()
                .HasMany(pr => pr.Relectures)
                .WithOne(r => r.Relecteur)
                .HasForeignKey(r => r.RelecteurId);


            // modelBuilder.Entity<User>(entity =>
            // {
            //     entity.Property(e => e.Name).HasColumnType("varchar(100)");
            //     entity.Property(e => e.Email).HasColumnType("varchar(255)");
            //     entity.Property(e => e.Password).HasColumnType("varchar(255)");
            // });


            modelBuilder.Entity<Conference>(entity =>
            {
                entity.Property(e => e.Nom).HasColumnType("varchar(155)");
                entity.Property(e => e.Sigle).HasColumnType("varchar(155)");
                entity.Property(e => e.Theme).HasColumnType("varchar(155)");
            });

            modelBuilder.Entity<Auteur>(entity =>
            {
                entity.Property(e => e.Entreprise).HasColumnType("varchar(100)");
                entity.Property(e => e.Universite).HasColumnType("varchar(100)");
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
                entity.Property(e => e.FichierPdf).HasColumnType("varchar(255)");
                entity.Property(e => e.Statut).HasColumnType("varchar(100)");
            });

            // Configuration des clés primaires pour toutes les entités


            // Ajoutez les configurations pour d'autres entités si nécessaire
        }
    }
}
