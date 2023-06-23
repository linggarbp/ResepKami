﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models; 

[Table("tb_user")]
public class User
{
    // user id
    [Key, Column("id", TypeName = "char(5)")]
    public string Id { get; set; }

    // user name
    [Column("username", TypeName = "varchar(50)")]
    public string UserName { get; set; }

    // user email
    [Column("email", TypeName = "varchar(50)")]
    public string Email { get; set; }

    // user password
    [Column("password", TypeName = "varchar(255)")]
    public string Password { get; set; }

    // user id
    [Column("role_id", TypeName = "char(5)")]
    public string RoleId { get; set; }

    // Cardinality
    [JsonIgnore]
    public UserRole? UserRole{ get; set; }
    
    [JsonIgnore]
    public ICollection<Recipe>? Recipes { get; set; }

    [JsonIgnore]
    public ICollection<Comment>? Comments { get; set; }

}
