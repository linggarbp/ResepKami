using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Client.Models;
[Table("tb_ingredient")]
public class Ingredient
{
    // id (FK Recipe)
    public string Id { get; set; }

    // nama bahan
    public string IngredientName { get; set; }

    // jumlah bahan
    public string Total { get; set; }

    // satuan
    public string Unit { get; set; }

    // recipe id
    public string RecipeId { get; set; }

}
