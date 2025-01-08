using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace campus_circle_api.Model;

[Table("chat")] // table name
public class Chat
{
    // constructor required for json parser, since it assigns them manually
    public Chat()
    {
    }

    // constructor may be used by developer, to assign all values at once
    // will be removed if it is not necessary
    public Chat(string chatId, string name, string username, ChatType chatType, string description, DateTime date)
    {
        chat_id = chatId;
        this.name = name;
        this.username = username;
        chat_type = chatType;
        this.description = description;
        this.date = date;
    }

    // ignore it from client request, we shall assign chat_id ourselves not the client (not chat creator admin)
    [JsonIgnore] [Key] public string chat_id { get; set; } = Guid.NewGuid().ToString();

    // column names goes here
    [Column("name")] public string name { get; set; }

    [Column("username")] public string username { get; set; }

    [Column("chat_type")] public ChatType chat_type { get; set; }

    [Column("description")] public string description { get; set; }

    [JsonIgnore] [Column("date")] public DateTime date { get; set; } = DateTime.Now;
}

public enum ChatType
{
    Channel,
    Group
}