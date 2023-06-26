using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models;
[Table("tb_recipe")]
public class Recipe 
{
    [Key, Column("id", TypeName = "char(5)")]
    public int Id { get; set; }
    [Column("user_id", TypeName = "char(5)")]
    public int UserId { get; set; }

    [Column("username", TypeName = "varchar(50)")]
    public string UserName { get; set; }

    [Column("nm_resep", TypeName = "varchar(100)")]
    public string RecipeName { get; set; }

    [Column("deskripsi", TypeName = "varchar(255)")]
    public string Description { get; set; }

    [Column("nm_bahan", TypeName = "varchar(255)")]
    public string IngredientName { get; set; }

    [Column("jumlah", TypeName = "varchar(50)")]
    public string Total { get; set; }

    [Column("langkah", TypeName ="varchar(255)")]
    public string Step { get; set; }

    [Column("wkt_memasak", TypeName = "varchar(20)")]
    public string CookingTime { get; set; }

    [Column("kesulitan", TypeName = "varchar(20)")]
    public string Difficulty { get; set; }

    // Cardinality
    [JsonIgnore]
    public User? User { get; set; }

    [JsonIgnore]
    public Request? Request { get; set; }
}
