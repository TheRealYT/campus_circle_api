using campus_circle_api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace campus_circle_api.Controllers;

[ApiController]
public class SearchController : ControllerBase
{
    private readonly SqlDbContext _context;

    public SearchController(SqlDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    [Route("search")]
    public async Task<ActionResult<IEnumerable<SearchResult>>> Search(string q)
    {
        // match query with chat name and username
        var chats = await _context.Chats
            .Where(chat => chat.username.ToLower().Contains(q.ToLower()) || chat.name.ToLower().Contains(q.ToLower()))
            .ToListAsync();

        // convert found chats to search result object
        return chats.ConvertAll(chat => new SearchResult("", chat.name, chat.username, ""));
    }
}