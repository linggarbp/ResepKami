using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models;

[Table("tb_user")]
public class User
{
    // user id
    [Key, Column("user_id", TypeName = "char(5")]
    public string UserId { get; set; }

    // user name
    [Column("user_name", TypeName = "varchar(50)")]
    public string UserName { get; set; }

    // user email
    [Column("email", TypeName = "varchar(50)")]
    public string Email { get; set; }

    // user password
    [Column("password", TypeName = "varchar(255)")]
    public string Password { get; set; }

    // Cardinality
    [JsonIgnore]
    public Comment? Comment { get; set; }

}
