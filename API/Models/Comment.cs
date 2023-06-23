using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models;
[Table("tb_comment")]
public class Comment
{
    // id
    [Key, Column("id", TypeName = "char(100)")]
    public string Id { get; set; }

    // id resep (FK)
    [Column("id_recipe", TypeName = "char(5)")]
    public string RecipeId { get; set; }

    // id pengguna (FK)
    [Column("user_id", TypeName = "char(5)")]
    public string UserId { get; set; }

    // tanggal komentar
    [Column("tgl_komentar", TypeName = "datetime")]
    public DateTime CommentDate { get; set; }

    // isi komentar
    [Column("isi_komentar", TypeName = "varchar(255)")]
    public string ContentComment { get; set; }

    // Cardinality //
    [JsonIgnore]
    public User? User { get; set; }

    [JsonIgnore]
    public Recipe? Recipe { get; set; }
}
