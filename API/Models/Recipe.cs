using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models;
[Table("tb_recipe")]
public class Recipe 
{
    // id
    [Key, Column("id", TypeName ="char(5)")]
    public string Id { get; set; }

    // nama resep
    [Column("nm_resep", TypeName = "varchar(100)")]
    public string RecipeName { get; set; }

    // deskripsi
    [Column("deskripsi", TypeName = "varchar(255)")]
    public string Description { get; set; }

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

    //user id
    [Column("user_id", TypeName = "char(5)")]
    public string UserId { get; set; }

    // Cardinality
    [JsonIgnore]
    public User? User { get; set; }

    [JsonIgnore]
    public ICollection<Ingredient>? Ingredients { get; set; }
}
