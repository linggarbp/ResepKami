using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Client.Models;

[Table("tb_m_user_roles")]
public class UserRole
{
    public int Id { get; set; }
    public string? UserId { get; set; }    
    public int? RoleId { get; set; }

}
