using Chat.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Chat.Data.Entities.Seeds;


namespace Chat.Data.Entities;

public class ChatDbContext : DbContext
{
    public ChatDbContext(DbContextOptions options) : base(options)
    {
    }


    
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupUser> GroupUsers { get; set; }
        public DbSet<DirectMessage> DirectMessages { get; set; }
        public DbSet<GroupMessage> GroupMessages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
            modelBuilder.Entity<GroupUser>()
                .HasKey(gu => new { gu.UserId, gu.GroupId });

        modelBuilder.Entity<GroupUser>()
            .HasOne(gu => gu.User)
            .WithMany(u => u.GroupUsers)
            .HasForeignKey(gu => gu.UserId);

        modelBuilder.Entity<GroupUser>()
            .HasOne(gu => gu.Group)
            .WithMany(g => g.GroupUsers)
            .HasForeignKey(gu => gu.GroupId);

        modelBuilder.Entity<DirectMessage>()
            .HasOne(dm => dm.Sender)
            .WithMany(u => u.SentDirectMessages)
            .HasForeignKey(dm => dm.SenderId);

        modelBuilder.Entity<DirectMessage>()
            .HasOne(dm => dm.Receiver)
            .WithMany(u => u.ReceivedDirectMessages)
            .HasForeignKey(dm => dm.ReceiverId);

        modelBuilder.Entity<GroupMessage>()
            .HasOne(gm => gm.Sender)
            .WithMany(u => u.SentGroupMessages)
            .HasForeignKey(gm => gm.SenderId);

        modelBuilder.Entity<GroupMessage>()
            .HasOne(gm => gm.Group)
            .WithMany(g => g.GroupMessages)
            .HasForeignKey(gm => gm.GroupId);
           
        DatabaseSeeder.Seed(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }
    
}
public class ChatDbContextFactory : IDesignTimeDbContextFactory<ChatDbContext>
{
    public ChatDbContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddXmlFile("App.config")
            .Build();

        config.Providers
            .First()
            .TryGet("connectionStrings:add:Chat:connectionString", out var connectionString);

        var options = new DbContextOptionsBuilder<ChatDbContext>()
            .UseNpgsql(connectionString)
            .Options;

        return new ChatDbContext(options);
    }
}

