using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API.Models;

[Table("tb_m_user_roles")]
public class UserRole
{
    [Key, Column("id")]
    public int Id { get; set; }
    [Column("user_id", TypeName = "char(5)")]
    public string? UserId { get; set; }
    
    [Column("role_id")]
    public int? RoleId { get; set; }

    //Cardinality
    [JsonIgnore]
    public User? User { get; set; }

    [JsonIgnore]
    public Role? Role { get; set; }
}
