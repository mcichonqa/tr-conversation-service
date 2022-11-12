using ConversationService.Api.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ConversationService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[AuthorizeRoles(UserRole.Admin, UserRole.Customer)]
    public class ConversationController : ControllerBase
    {
        public ConversationController()
        {
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetConversationAsync(int id)
        {
            return Ok(id);
        }

        [HttpPost("createConversation")]
        public async Task<IActionResult> CreateConversationAsync([FromBody] ConversationDto conversation)
        {
            return Created($"~/api/conversation/{conversation.Id}", conversation);
        }
    }
}