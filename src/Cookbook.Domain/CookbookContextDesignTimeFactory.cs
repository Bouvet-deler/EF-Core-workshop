using Cookbook.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Cookbook.Domain;

/// <summary>
/// Used for the design-time DbContext creation.
/// </summary>
/// <remarks>
/// This allows us to have the migrations in a different project than the startup-project, whilst maintaining ease of
/// use with ef tools. We don't have to specify the startup-project anymore.
/// In this case the startup-project is Cookbook.Api, and we want the migrations in Cookbok.Domain.
/// By having this DesignTimeDbContextFactory, we can use the ef tools from the folder that contains Cookbook.Domain.csproj
/// and it will know how to create the DbContext.
/// <br/>
/// <br/>
/// Alternatively, it is possible run use the host-project by installing
/// Microsoft.EntityFrameworkCore.Design-package in the Cookbook.Api-project and run something like:
/// `run dotnet ef migrations add NameHere --project .\src\Cookbook.Domain --startup-project .\src\Cookbook.Api`.
/// </remarks>
/// <seealso href="https://learn.microsoft.com/en-us/ef/core/cli/dbcontext-creation"/>
public class CookbookContextDesignTimeFactory : IDesignTimeDbContextFactory<CookbookContext>
{
    
    public CookbookContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CookbookContext>();
        
       var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        string connectionString = config.GetConnectionString("CookbookDatabase") ??
                                  throw new Exception("Database connection string required.");
        
            optionsBuilder
                .UseSqlServer(connectionString)
                .UseSeeding((context, _) =>
                {
                    bool entitiesAdded = false;
                    var pancakes = context.Set<Recipe>().FirstOrDefault(recipe => recipe.Name == "Pancakes");
                    if (pancakes == null)
                    {
                        context.Add(new Recipe
                        {
                            Id = 0,
                            Name = "Pancakes",
                            Ingredients = [
                                new Ingredient
                                {
                                    Name = "Flour",
                                    Amount = 200,
                                    UnitId = 1,
                                },
                                new Ingredient
                                {
                                    Name = "Milk",
                                    Amount = 300,
                                    UnitId = 2,
                                },
                                new Ingredient
                                {
                                    Name = "Egg",
                                    Amount = 2,
                                    UnitId = 3,
                                },
                            ],
                            Steps = [
                                new Step
                                {
                                    Description = "Mix flour, milk, and eggs.",
                                    Order = 1
                                },
                                new Step
                                {
                                    Description = "Cook the batter in a pan.",
                                    Order = 2
                                },
                            ]
                        });
                        entitiesAdded = true;
                    }
                    var spaghetti = context.Set<Recipe>().FirstOrDefault(recipe => recipe.Name == "Spaghetti Bolognese");
                    if (spaghetti == null)
                    {
                        context.Add(new Recipe
                        {
                            Id = 0,
                            Name = "Spaghetti Bolognese",
                            Ingredients =
                            [
                                new Ingredient
                                {
                                    Name = "Spaghetti",
                                    Amount = 250,
                                    UnitId = 1,
                                },
                                new Ingredient
                                {
                                    Name = "Minced Meat",
                                    Amount = 500,
                                    UnitId = 1,
                                },
                                new Ingredient
                                {
                                    Name = "Tomato Sauce",
                                    Amount = 400,
                                    UnitId = 2,
                                },
                            ],
                            Steps =
                            [
                                new Step
                                {
                                    Description = "Boil spaghetti",
                                    Order = 1
                                },
                                new Step
                                {
                                    Description = "Cook minced meat and add tomato sauce.",
                                    Order = 2
                                },
                            ]
                        });
                        entitiesAdded = true;
                    }
                    if(entitiesAdded)
                        context.SaveChanges();
                })
                .UseAsyncSeeding(async (context, _, cancellationToken) =>
                {
                    bool entitiesAdded = false;
                    var pancakes = await context.Set<Recipe>().FirstOrDefaultAsync(recipe => recipe.Name == "Pancakes", cancellationToken);
                    if (pancakes == null)
                    {
                        context.Add(new Recipe
                        {
                            Id = 0,
                            Name = "Pancakes",
                            Ingredients = [
                                new Ingredient
                                {
                                    Name = "Flour",
                                    Amount = 200,
                                    UnitId = 1,
                                },
                                new Ingredient
                                {
                                    Name = "Milk",
                                    Amount = 300,
                                    UnitId = 2,
                                },
                                new Ingredient
                                {
                                    Name = "Egg",
                                    Amount = 2,
                                    UnitId = 3,
                                },
                            ],
                            Steps = [
                                new Step
                                {
                                    Description = "Mix flour, milk, and eggs.",
                                    Order = 1
                                },
                                new Step
                                {
                                    Description = "Cook the batter in a pan.",
                                    Order = 2
                                },
                            ]
                        });
                        entitiesAdded = true;
                    }
                    var spaghetti = await context.Set<Recipe>().FirstOrDefaultAsync(recipe => recipe.Name == "Spaghetti Bolognese", cancellationToken);
                    if (spaghetti == null)
                    {
                        context.Add(new Recipe
                        {
                            Id = 0,
                            Name = "Spaghetti Bolognese",
                            Ingredients =
                            [
                                new Ingredient
                                {
                                    Name = "Spaghetti",
                                    Amount = 250,
                                    UnitId = 1,
                                },
                                new Ingredient
                                {
                                    Name = "Minced Meat",
                                    Amount = 500,
                                    UnitId = 1,
                                },
                                new Ingredient
                                {
                                    Name = "Tomato Sauce",
                                    Amount = 400,
                                    UnitId = 2,
                                },
                            ],
                            Steps =
                            [
                                new Step
                                {
                                    Description = "Boil spaghetti",
                                    Order = 1
                                },
                                new Step
                                {
                                    Description = "Cook minced meat and add tomato sauce.",
                                    Order = 2
                                },
                            ]
                        });
                        entitiesAdded = true;
                    }
                    if(entitiesAdded)
                        await context.SaveChangesAsync(cancellationToken);
                });
        
        return new CookbookContext(optionsBuilder.Options);
    }
}