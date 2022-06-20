using Microsoft.EntityFrameworkCore;
using PlayerInfoGQL.Models;

namespace PlayerInfoGQL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentType> CommentTypes { get; set; }
        public DbSet<AnalysisResult> AnalysisResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region team
            modelBuilder.Entity<Team>()
                .HasMany(t => t.Players)
                .WithOne(p => p.Team)
                .HasForeignKey(p => p.TeamId)
                .HasConstraintName("ForeignKey_Player_Team")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Team>()
                .Property(t => t.Name)
                .IsRequired();

            modelBuilder.Entity<Team>()
                .Property(t => t.Country)
                .IsRequired();

            modelBuilder.Entity<Team>()
                .Property(t => t.League)
                .IsRequired();
            #endregion

            #region Player
            modelBuilder.Entity<Player>()
                .HasMany(p => p.Comments)
                .WithOne(c => c.Player)
                .HasForeignKey(c => c.PlayerId)
                .HasConstraintName("ForeignKey_Comment_Player")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Player>()
                .HasOne<AnalysisResult>()
                .WithMany()
                .HasForeignKey(p => p.AnalysisResult)
                .HasPrincipalKey(a => a.Description)
                .HasConstraintName("ForeignKey_Player_AnalysisResult")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Player>()
                .Property(p => p.FirstName)
                .IsRequired();

            modelBuilder.Entity<Player>()
                .Property(p => p.LastName)
                .IsRequired();

            modelBuilder.Entity<Player>()
                .Property(p => p.FirstName)
                .IsRequired();

            modelBuilder.Entity<Player>()
                .Property(p => p.Country)
                .IsRequired();

            modelBuilder.Entity<Player>()
                .Property(p => p.Age)
                .IsRequired();

            modelBuilder.Entity<Player>()
                .Property(p => p.Position)
                .IsRequired();

            #endregion

            #region Comment
            modelBuilder.Entity<Comment>()
                .HasOne<CommentType>()
                .WithMany()
                .HasForeignKey(c => c.Type)
                .HasPrincipalKey(ct => ct.Description)
                .HasConstraintName("ForeignKey_Comment_CommentType")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>()
                .Property(c => c.Text)
                .IsRequired();
            #endregion

            #region CommentType
            modelBuilder.Entity<CommentType>()
                .Property(ct => ct.Description)
                .IsRequired();
            #endregion

            #region AnalysisResult
            modelBuilder.Entity<AnalysisResult>()
                .Property(a => a.Description)
                .IsRequired();
            #endregion
        }
    }
}