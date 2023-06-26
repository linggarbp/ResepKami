using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

public class Request
{
    [Key, Column("id")]
    public int Id { get; set; }

    [Column("recipe_name")]
    public string RecipeName { get; set; }

    [Column("is_approved")]
    public bool IsApproved { get; set; }
    
    [Column("recipe_id")]
    public int RecipeId { get; set; }

    //Cardinality
    public Recipe? Recipe { get; set; }
}
