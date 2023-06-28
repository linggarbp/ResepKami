using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models;

[Table("tb_approval")]
public class Approval
{
    [Key, Column("id")]
    public int Id { get; set; }

    [Column("recipe_id", TypeName = "char(5)")]
    public int RecipeId { get; set; }

    [Column("recipe_name")]
    public string RecipeName { get; set; }

    [Column("is_approved")]
    public bool IsApproved { get; set; } = false;


    //Cardinality
    [JsonIgnore]
    public Recipe? Recipe { get; set; }
}
