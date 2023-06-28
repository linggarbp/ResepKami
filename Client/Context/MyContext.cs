using API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Context;

public class MyContext : IdentityDbContext
{
    public MyContext(DbContextOptions<MyContext> options) : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Approval> Requests { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //One User has many Recipe
        modelBuilder.Entity<User>()
                    .HasMany(r => r.Recipes)
                    .WithOne(u => u.User)
                    .IsRequired(false)
                    .HasForeignKey (r => r.Id)
                    .OnDelete(DeleteBehavior.Restrict);

        //One Request has one Recipe
        modelBuilder.Entity<Recipe>()
                    .HasOne(r => r.Request)
                    .WithOne(r => r.Recipe)
                    .IsRequired(false)
                    .HasForeignKey<Approval>(r => r.RecipeId)
                    .OnDelete(DeleteBehavior.Restrict);

        //One User has many UserRole
        modelBuilder.Entity<User>()
                    .HasMany(r => r.UserRoles)
                    .WithOne(u => u.User)
                    .IsRequired(false)
                    .HasForeignKey(u => u.UserId)
                    .OnDelete(DeleteBehavior.SetNull);

        //One Role has many UserRoles
        modelBuilder.Entity<Role>()
                    .HasMany(ur => ur.UserRoles)
                    .WithOne(r => r.Role)
                    .IsRequired(false)
                    .HasForeignKey(r => r.RoleId)
                    .OnDelete(DeleteBehavior.SetNull);
    }

}
