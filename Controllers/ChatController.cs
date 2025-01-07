using campus_circle_api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace campus_circle_api.Controllers;

[ApiController]
public class ChatController : ControllerBase
{
    private readonly SqlDbContext _context;

    // store database context for later use in other methods
    public ChatController(SqlDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    [Route("chat/{chat_id}/messages")]
    public async Task<ActionResult<IEnumerable<Message>>> GetGroupMessages(string chat_id)
    {
        var chat = await _context.Chats.FirstOrDefaultAsync(c => c.chat_id == chat_id || c.username == chat_id);
        if (chat == null)
            return NotFound("Chat not found");

        return Ok(await _context.Messages.Where(m => m.chat_id == chat!.chat_id).ToArrayAsync());
    }
}