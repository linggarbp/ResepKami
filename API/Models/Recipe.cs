using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models;
[Table("tb_recipe")]
public class Recipe 
{
    // id
    [Key, Column("id_recipe", TypeName ="char(5)")]
    public string RecipeId { get; set; }

    // nama resep
    [Column("nm_resep", TypeName = "varchar(100)")]
    public string RecipeName { get; set; }

    // deskripsi
    [Column("deskripsi", TypeName = "varchar(255)")]
    public string Description { get; set; }

    //
    // langkah - langkah 
    [Column("langkah", TypeName ="varchar(255)")]
    public string Step { get; set; }

    // waktu persiapan
    [Column("wkt_persiapan", TypeName = "varchar(20)")]
    public string PrepareTime { get; set; }

    //waktu memasak
    [Column("wkt_memasak", TypeName = "varchar(20)")]
    public string CookingTime { get; set; }

    // kesulitan
    [Column("kesulitan", TypeName = "varchar(20)")]
    public string Difficulty { get; set; }

    // Cardinality
  
}
