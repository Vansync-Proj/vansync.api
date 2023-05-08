using Microsoft.AspNetCore.Mvc;
using VanSync.Domain.Interfaces.Services;

namespace VanSync.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }
    }
}
