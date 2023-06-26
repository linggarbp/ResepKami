using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models;
[Table("tb_comment")]
public class Comment
{
    [Key, Column("id", TypeName = "char(100)")]
    public int Id { get; set; }

    [Column("id_recipe", TypeName = "char(5)")]
    public int RecipeId { get; set; }

    [Column("user_id", TypeName = "char(5)")]
    public int UserId { get; set; }

    [Column("tgl_komentar", TypeName = "datetime")]
    public DateTime CommentDate { get; set; }

    [Column("isi_komentar", TypeName = "varchar(255)")]
    public string ContentComment { get; set; }

    // Cardinality //
    [JsonIgnore]
    public User? User { get; set; }

    [JsonIgnore]
    public Recipe? Recipe { get; set; }
}
