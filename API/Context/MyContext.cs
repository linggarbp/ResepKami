using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Context;

public class MyContext : DbContext
{
    public MyContext(DbContextOptions<MyContext> options) : base(options) { }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // One Comment has one User (one to one)
        modelBuilder.Entity<Comment>()
            .HasOne(u => u.User)
            .WithOne(e => e.Comment)
            .IsRequired(false)
            .HasForeignKey<User>(i => i.UserId)
            .OnDelete(DeleteBehavior.SetNull);
        // One Ingredient has many Comment (one to many)
        modelBuilder.Entity<Comment>()
            .HasOne( r => r.Recipe)
            .WithOne( a => a.Comment)
            .IsRequired(false)
            .HasForeignKey<Recipe>(d => d.RecipeId)
            .OnDelete(DeleteBehavior.SetNull);
    }

}
