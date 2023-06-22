using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models;

public class Comment
{
    // id
    [Key, Column("id_komen", TypeName = "char(100)")]
    public int Id { get; set; }

    // tanggal komentar
    [Column("tgl_komentar", TypeName = "datetime")]
    public DateTime CommentDate { get; set; }

    // isi komentar
    [Column("isi_komentar", TypeName = "varchar(255)")]
    public string ContentComment { get; set; }

    // Cardinality
    [JsonIgnore]
    public User? User { get; set; }
    public Recipe? Recipe { get; set; }
}
