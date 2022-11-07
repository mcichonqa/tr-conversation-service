using ActivityService.Attributes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ActivityService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AuthorizeRoles(UserRole.Admin, UserRole.Supervisor, UserRole.Customer)]
    public class ActivityController : ControllerBase
    {
        public ActivityController()
        {
        }

        [HttpGet("activities")]
        public async Task<IActionResult> GetActivities()
        {
            return Ok(new[] { "chat", "video", "email" });
        }
    }
}