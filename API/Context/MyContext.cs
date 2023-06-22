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

}//
