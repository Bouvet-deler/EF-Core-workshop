namespace Cookbook.Domain.Models;

public class Recipe
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual List<Step> Steps { get; set; }
    public virtual List<Ingredient> Ingredients { get; set; }
}