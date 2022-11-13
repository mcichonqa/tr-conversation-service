using ConversationService.Api.Model;
using Microsoft.AspNetCore.Mvc;

namespace ConversationService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[AuthorizeRoles(UserRole.Admin, UserRole.Customer)]
    public class ConversationController : ControllerBase
    {
    }
}