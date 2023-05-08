using Microsoft.AspNetCore.Mvc;
using VanSync.Domain.Interfaces.Services;
using VanSync.Domain.Models;

namespace VanSync.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly ILoginServices _loginService;

        public LoginController(ILogger<LoginController> logger,
                               ILoginServices loginService)
        {
            _logger = logger;
            _loginService = loginService;
        }

        [HttpPost("v1/login/register")]
        public async Task<ActionResult<ResultModel>> Register(LoginModel loginModel)
            => await _loginService.Register(loginModel);

        [HttpPost("v1/login/login")]
        public async Task<ActionResult<ResultModel>> Login(string email, string passWord)
            => await _loginService.Login(email, passWord);

        [HttpPost("v1/login/alter-password")]
        public async Task<ActionResult<ResultModel>> AlterPassWord(AlterPassWordModel alterPassWordModel)
            => await _loginService.AlterPassWord(alterPassWordModel);
    }
}
