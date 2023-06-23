using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Context;

public class MyContext : DbContext
{
    public MyContext(DbContextOptions<MyContext> options) : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Comment> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //One User has many Recipe
        modelBuilder.Entity<User>()
                    .HasMany(r => r.Recipes)
                    .WithOne(u => u.User)
                    .HasForeignKey (r => r.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

        //One Recipe has many Ingredients
        modelBuilder.Entity<Recipe>()
                    .HasMany(i => i.Ingredients)
                    .WithOne(r => r.Recipe)
                    .HasForeignKey(r => r.RecipeId)
                    .OnDelete(DeleteBehavior.Restrict);

        //One User has many Comments
        modelBuilder.Entity<User>()
                    .HasMany(c => c.Comments)
                    .WithOne(u => u.User)
                    .HasForeignKey(c => c.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

        //One User has one role
        modelBuilder.Entity<User>()
                    .HasOne(r => r.UserRole)
                    .WithOne(u => u.User)
                    .HasForeignKey<UserRole>(u => u.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
    }

}
