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
    [Route("sendMessage")]
    public async Task<ActionResult> SendMessage([FromBody] Message message)
    {
        await _context.Messages.AddAsync(message);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpPost]
    [Route("chat/add")]
    public async Task<ActionResult> AddChat([FromBody] Chat chat)
    {
        await _context.Chats.AddAsync(chat);
        await _context.SaveChangesAsync();
        return Ok();
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