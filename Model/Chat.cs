namespace campus_circle_api.Model;

public class Chat
{
    public Chat(string chatId, string name, string username, string chatType, string description, DateTime date)
    {
        chat_id = chatId;
        this.name = name;
        this.username = username;
        chat_type = chatType;
        this.description = description;
        this.date = date;
    }

    public string chat_id { get; set; }

    public string name { get; set; }

    public string username { get; set; }

    public string chat_type { get; set; }

    public string description { get; set; }

    public DateTime date { get; set; }
}