using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models; 

[Table("tb_user")]
public class User
{
    [Key, Column("id", TypeName = "char(5)")]
    public int Id { get; set; }

    [Column("username", TypeName = "varchar(50)")]
    public string UserName { get; set; }

    [Column("email", TypeName = "varchar(50)")]
    public string Email { get; set; }

    [Column("password", TypeName = "varchar(255)")]
    public string Password { get; set; }

    // Cardinality
    [JsonIgnore]
    public ICollection<UserRole>? UserRoles{ get; set; }
    
    [JsonIgnore]
    public ICollection<Recipe>? Recipes { get; set; }
}
