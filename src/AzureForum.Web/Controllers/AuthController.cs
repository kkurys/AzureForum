using System.Threading.Tasks;
using AzureForum.Account.Contracts;
using AzureForum.Account.Models;
using Microsoft.AspNetCore.Mvc;

namespace AzureForum.Web.Controllers
{
    public class AuthController: BaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<JsonResult> Register([FromBody] RegisterViewModel model)
        {
            var token = await _authService.Register(model);
            return Json(token);
        }

        [HttpPost]
        public async Task<JsonResult> Login([FromBody] SignInViewModel model)
        {
            var token = await _authService.SignIn(model);
            return Json(token);
        }
    }
}
