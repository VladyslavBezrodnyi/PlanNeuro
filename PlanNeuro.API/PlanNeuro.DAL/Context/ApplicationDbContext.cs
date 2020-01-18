using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PlanNeuro.DAL.Entities;

namespace PlanNeuro.DAL.Context
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public virtual DbSet<Board> Boards { get; set; }
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<PlanCard> PlanCards { get; set; }
        public virtual DbSet<HabitCard> HabitCards { get; set; }
        public virtual DbSet<CardsList> CardsLists { get; set; }
        public virtual DbSet<UserBoard> UserBoards { get; set; }
        public virtual DbSet<ConversationReply> ConversationReplies { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(ApplicationDbContextFactory.stringConnection);

            //optionsBuilder
            //    .UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Board>()
                .HasKey(k => k.Id);
            builder.Entity<Card>()
                .HasKey(k => k.Id);
            builder.Entity<CardsList>()
                .HasKey(k => k.Id);
            builder.Entity<UserBoard>()
                .HasKey(k => new { k.UserId, k.BoardId});
            builder.Entity<ConversationReply>()
               .HasKey(k => k.Id);

            builder.Entity<UserBoard>()
                .HasOne(obj => obj.User)
                .WithMany(obj => obj.UserBoards)
                .HasForeignKey(k => k.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UserBoard>()
                .HasOne(obj => obj.Board)
                .WithMany(obj => obj.UserBoards)
                .HasForeignKey(k => k.BoardId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CardsList>()
                .HasOne(obj => obj.Board)
                .WithMany(obj => obj.CardsLists)
                .HasForeignKey(k => k.BoardId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Card>()
                .HasOne(obj => obj.CardsList)
                .WithMany(obj => obj.Cards)
                .HasForeignKey(k => k.CardsListId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PlanCard>()
                .HasOne(obj => obj.DoneUser)
                .WithMany(obj => obj.DoneCards)
                .HasForeignKey(k => k.DoneUserId);

            builder.Entity<ConversationReply>()
                .HasOne(obj => obj.Participant)
                .WithMany(obj => obj.ConversationReplies)
                .HasForeignKey(k => new { k.UserId, k.BoardId })
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Board>()
                .HasOne(obj => obj.User)
                .WithOne(obj => obj.PersonalBoard)
                .HasForeignKey<Board>(k => k.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(builder);
        }
    }

    // <summary>
    /// For Migrations
    /// </summary>
    /*
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {

        public static readonly string stringConnection = "";

        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder
                .UseSqlServer(stringConnection, b => b.MigrationsAssembly("PlanNeuro.DAL"));
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
    */
    
}
