using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Client.Models;
[Table("tb_recipe")]
public class Recipe 
{
    // id
    public string Id { get; set; }

    // nama resep
    public string RecipeName { get; set; }

    // deskripsi
    public string Description { get; set; }

    // langkah - langkah 
    public string Step { get; set; }

    // waktu persiapan
    public string PrepareTime { get; set; }

    //waktu memasak
    public string CookingTime { get; set; }

    // kesulitan
    public string Difficulty { get; set; }

    //user id
    public string UserId { get; set; }

}
