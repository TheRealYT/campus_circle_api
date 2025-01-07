using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace campus_circle_api.Model;

[Table("user")]
public class User
{
    public User()
    {
    }

    [JsonIgnore] [Key] public string user_id { get; set; }

    [Column("f_name")] public string f_name { get; set; }

    [Column("l_name")] public string l_name { get; set; }

    [Column("email")] public string email { get; set; }

    [Column("password")] public string password { get; set; }

    [Column("img")] public string img { get; set; } = "";

    [Column("year")] public string year { get; set; }

    [Column("aau_id")] public string? aau_id { get; set; }

    [Column("department")] public string department { get; set; }

    [Column("bio")] public string bio { get; set; } = "";
}