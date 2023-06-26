using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Client.Models;
public class UserRole
{
    public int Id { get; set; }
    public int? UserId { get; set; }
    public int? RoleId { get; set; }
}
