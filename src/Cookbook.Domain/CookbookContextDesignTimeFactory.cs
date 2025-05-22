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
        
            optionsBuilder.UseSqlServer(connectionString);
      
        
        return new CookbookContext(optionsBuilder.Options);
    }
}