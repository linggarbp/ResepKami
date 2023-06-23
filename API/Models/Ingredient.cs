using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models;
[Table("tb_ingredient")]
public class Ingredient
{
    // id (FK Recipe)
    [Key, Column("id_bahan", TypeName = "char(5)")]
    public string Id { get; set; }

    // nama bahan
    [Column("nm_bahan", TypeName = "varchar(255)")]
    public string IngredientName { get; set; }

    // jumlah bahan
    [Column("jumlah", TypeName = "varchar(50)")]
    public string Total { get; set; }

    // satuan
    [Column("satuan", TypeName = "varchar(50)")]
    public string Unit { get; set; }

    // recipe id
    [Column("id_resep", TypeName = "char(5)")]
    public string RecipeId { get; set; }

    //Cardinality
    [JsonIgnore]
    public Recipe? Recipe { get; set; }
}
