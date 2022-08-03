using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RxLightningAPI.Models.DTOs;
using RxLightningAPI.Services.Interfaces;

namespace RxLightningAPI.Controllers
{
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(UserLogin userLogin)
        {
            var result = _authenticationService.Login(userLogin);

            return Ok(new { bearer = result });
        }
    }
}
