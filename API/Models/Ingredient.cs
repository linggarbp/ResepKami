using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models;
[Table("tb_ingredient")]
public class Ingredient
{
    [Key, Column("id_bahan", TypeName = "char(5)")]
    public int Id { get; set; }

    [Column("nm_bahan", TypeName = "varchar(255)")]
    public string IngredientName { get; set; }

    [Column("jumlah", TypeName = "varchar(50)")]
    public string Total { get; set; }

    [Column("id_resep", TypeName = "char(5)")]
    public int RecipeId { get; set; }

    //Cardinality
    [JsonIgnore]
    public Recipe? Recipe { get; set; }
}
