using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace campus_circle_api.Model;

[Table("event")]
public class Event
{
    public Event()
    {
    }

    public Event(string participantId, string eventPostId)
    {
        participant_Id = participantId;
        event_post_id = eventPostId;
    }

    [Key] public string application_id { get; set; } = Guid.NewGuid().ToString();

    [ForeignKey("User")]
    [Column("participant_Id")]
    public string participant_Id { get; set; }

    [JsonIgnore] public virtual User? User { get; set; }

    [ForeignKey("EventPost")]
    [Column("event_post_id")]
    public string event_post_id { get; set; }

    [JsonIgnore] public virtual Message? EventPost { get; set; }

    [JsonIgnore] [Column("date")] public DateTime date { get; set; } = DateTime.Now;
}