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
        public DbSet<Author> Authors { get; set; }
        public DbSet<ArticleAuthor> ArticleAuthors { get; set; }
        public DbSet<ArticleProofReader> ArticleProofReaders { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Conference> Conferences { get; set; }
        public DbSet<Relecture> Relectures { get; set; }
        public DbSet<CommitteeMember> CommitteeMembers { get; set; }
        public DbSet<ProofReader> ProofReaders { get; set; }
        public DbSet<Participant> Participants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration de la table de jonction ArticleAuthor
            modelBuilder.Entity<ArticleAuthor>()
                .HasKey(aa => new { aa.ArticleId, aa.AuthorId });

            modelBuilder.Entity<ArticleAuthor>()
                .HasOne(aa => aa.Article)
                .WithMany(a => a.Authors)
                .HasForeignKey(aa => aa.ArticleId);

            modelBuilder.Entity<ArticleAuthor>()
                .HasOne(aa => aa.Author)
                .WithMany(a => a.Articles)
                .HasForeignKey(aa => aa.AuthorId);

            // Configuration de la table de jonction ArticleProofReader
            modelBuilder.Entity<ArticleProofReader>()
                .HasKey(apr => new { apr.ArticleId, apr.ProofReaderId });

            modelBuilder.Entity<ArticleProofReader>()
                .HasOne(apr => apr.Article)
                .WithMany(a => a.ArticleProofReaders)
                .HasForeignKey(apr => apr.ArticleId);

            modelBuilder.Entity<ArticleProofReader>()
                .HasOne(apr => apr.ProofReader)
                .WithMany(pr => pr.Articles)
                .HasForeignKey(apr => apr.ProofReaderId);

            // Configuration de la relation un-à-un entre ArticleProofReader et Relecture
            modelBuilder.Entity<Relecture>()
                .HasOne(r => r.ArticleProofReader)
                .WithOne(apr => apr.Relecture)
                .HasForeignKey<ArticleProofReader>(apr => apr.RelectureId) // Utilisez la clé étrangère appropriée ici
                .OnDelete(DeleteBehavior.Cascade); // Supprimez cette ligne si la suppression en cascade n'est pas souhaitée

            // Configuration de la relation entre ProofReader et Relecture
            modelBuilder.Entity<ProofReader>()
                .HasMany(pr => pr.Relectures)
                .WithOne(r => r.ProofReader)
                .HasForeignKey(r => r.ProofReaderId);

            // Configuration des clés primaires pour toutes les entités
            modelBuilder.Entity<Conference>()
                .HasKey(c => c.Id);

            // Ajoutez les configurations pour d'autres entités si nécessaire
        }
    }
}