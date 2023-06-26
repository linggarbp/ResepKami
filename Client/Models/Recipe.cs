using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Client.Models;
public class Recipe 
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string RecipeName { get; set; }
    public string Description { get; set; }
    public string IngredientName { get; set; }
    public string Total { get; set; }
    public string Step { get; set; }
    public string CookingTime { get; set; }
    public string Difficulty { get; set; }
}
