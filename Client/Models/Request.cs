using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Client.Models;
public class Request
{
    public int Id { get; set; }
    public int RecipeId { get; set; }
    public string RecipeName { get; set; }
    public bool IsApproved { get; set; } = false;
}
