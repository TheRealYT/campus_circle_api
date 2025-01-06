namespace campus_circle_api.Model;

public class SearchResult
{
    public SearchResult(string img, string title, string description, string link)
    {
        this.img = img;
        this.title = title;
        this.description = description;
        this.link = link;
    }

    public string img { get; set; }

    public string title { get; set; }

    public string description { get; set; }
    
    public string link { get; set; }
}