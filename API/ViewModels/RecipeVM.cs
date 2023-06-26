using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
namespace API.ViewModels;

public class RecipeVM
{
    public int Id { get; set; }
    public string RecipeName { get; set; }
    public string Description { get; set; }
    public string IngredientName { get; set; }
    public string Total { get; set; }
    public string Step { get; set; }
    public string CookingTime { get; set; }
    public string Difficulty { get; set; }
}
