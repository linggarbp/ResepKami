using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace API.Models;

public class Ingredient
{
    // id
    [Key, Column("id_bahan", TypeName = "varchar(100)")]
    public string Id { get; set; }

    // nama bahan
    [Column("nm_bahan", TypeName = "varchar(100)")]
    public string IngredientName { get; set; }

    // jumlah bahan
    [Column("jumlah", TypeName = "varchar(255)")]
    public string Total { get; set; }

    // satuan
    [Column("satuan", TypeName = "varchar(255)")]
    public string Unit { get; set; }
}
