using Microsoft.AspNetCore.Mvc;
using VanSync.Domain.Interfaces.Services;
using VanSync.Domain.Models;

namespace VanSync.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IAdminServices _adminService;

        public AdminController(ILogger<AdminController> logger,
                               IAdminServices adminService)
        {
            _logger = logger;
            _adminService = adminService;
        }

        #region [USER]
        [HttpGet("v1/admin/get-all-user")]
        public async Task<ActionResult<UserModel>> GetAllUser()
            => await _adminService.GetAllUser();

        [HttpGet("v1/admin/get-user")]
        public async Task<ActionResult<UserModel>> GetUser(Guid id)
            => await _adminService.GetUser(id);

        [HttpPost("v1/admin/register-user")]
        public async Task<ActionResult<ResultModel>> RegisterUser(UserModel userModel)
            => await _adminService.RegisterUser(userModel);

        [HttpPut("v1/admin/edit-user")]
        public async Task<ActionResult<ResultModel>> EditUser(UserModel userModel)
        => await _adminService.EditUser(userModel);

        [HttpDelete("v1/admin/delete-user")]
        public async Task<ActionResult<ResultModel>> DeleteUser(Guid id)
        => await _adminService.DeleteUser(id);
        #endregion [USER]

        #region [ATTENDANCE LIST]
        #endregion [ATTENDANCE LIST]
    }
}
