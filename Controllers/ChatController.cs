using campus_circle_api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace campus_circle_api.Controllers;

[ApiController]
[Route("chat")]
public class ChatController : ControllerBase
{
    private readonly SqlDbContext _context;

    // store database context for later use in other methods
    public ChatController(SqlDbContext context)
    {
        _context = context;
    }

    [HttpPost(Name = "add")]
    public async Task<IActionResult> AddChat(Chat chat)
    {
        _context.Chats.Add(chat);
        await _context.SaveChangesAsync();
        return Ok(chat);
    }

    [HttpGet(Name = "get")]
    public async Task<List<Chat>> GetChats()
    {
        return await _context.Chats.ToListAsync();
    }
}