using campus_circle_api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace campus_circle_api.Controllers;

[ApiController]
public class MessageController : ControllerBase
{
    private readonly SqlDbContext _context;

    public MessageController(SqlDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    [Route("job/{message_id}/apply")]
    public async Task<ActionResult> ApplyJob([FromRoute] string message_id, [FromQuery] string user_id)
    {
        var user = await _context.Users.FindAsync(user_id);

        if (user == null)
            return NotFound("User not found");

        var jobPost = await _context.Messages.FirstOrDefaultAsync(m => m.message_id == message_id);
        if (jobPost is not { message_type: MessageType.Job })
            return NotFound("Job not found");

        if (await _context.JobApplications.FirstOrDefaultAsync(j =>
                j.applicant_id == user.user_id && j.job_post_id == jobPost.message_id) != null)
            return BadRequest("Job application already applied");

        await _context.JobApplications.AddAsync(new JobApplication(user_id, message_id));
        await _context.SaveChangesAsync();

        return Ok();
    }
}