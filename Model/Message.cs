using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace campus_circle_api.Model;

[Table("message")]
public class Message
{
    public Message()
    {
    }

    [JsonIgnore]
    [Key] // primary key
    public string message_id { get; set; } = Guid.NewGuid().ToString();

    [ForeignKey("Chat")]
    [Column("chat_id")]
    public string chat_id { get; set; }

    [JsonIgnore] public virtual Chat? Chat { get; set; }

    // [JsonIgnore]
    [ForeignKey("User")]
    [Column("sender_id")]
    public string sender_id { get; set; } // set from session

    [JsonIgnore] public virtual User? User { get; set; }

    [Column("text")] public string text { get; set; }

    [Column("message_type")] public MessageType message_type { get; set; }

    [JsonIgnore] [Column("date")] public DateTime date { get; set; } = DateTime.Now;
}

public enum MessageType
{
    Default,
    Event,
    Job,
}