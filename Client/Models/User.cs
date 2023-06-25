using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Client.Models; 

[Table("tb_user")]
public class User
{
    // user id
    public string Id { get; set; }

    // user name
    public string UserName { get; set; }

    // user email
    public string Email { get; set; }

    // user password
    public string Password { get; set; }

}
