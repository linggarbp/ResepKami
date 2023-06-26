using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Client.Models;
[Table("tb_comment")]
public class Comment
{
    // id
    public string Id { get; set; }

    // id resep (FK)
    public string RecipeId { get; set; }

    // id pengguna (FK)
    public string UserId { get; set; }

    // tanggal komentar
    public DateTime CommentDate { get; set; } = DateTime.Now;

    // isi komentar
    public string ContentComment { get; set; }

}
