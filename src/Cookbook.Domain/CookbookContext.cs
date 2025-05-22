using Cookbook.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Cookbook.Domain;

public class CookbookContext(DbContextOptions<CookbookContext> builderOptions) : DbContext(builderOptions)
{
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Step> Steps { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Recipe>()
            .Property(b => b.Name)
            .HasMaxLength(50)
            .IsRequired();
        
        modelBuilder.Entity<Ingredient>()
            .Property(b => b.Amount)
            .HasPrecision(7, 2);
        
        modelBuilder.Entity<Ingredient>()
            .Property(b => b.Name)
            .HasMaxLength(50)
            .IsRequired();

        modelBuilder.Entity<Unit>()
            .ToTable("Units");
        
        modelBuilder.Entity<Unit>()
            .Property(b => b.Id)
            .ValueGeneratedNever();
        
        modelBuilder.Entity<Unit>()
            .Property(b => b.Name)
            .HasMaxLength(100)
            .IsRequired();
    }
}