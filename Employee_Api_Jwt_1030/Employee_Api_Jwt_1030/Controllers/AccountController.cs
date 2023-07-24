using Employee_Api_Jwt_1030.ServiceContract;
using Employee_Api_Jwt_1030.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Api_Jwt_1030.Controllers
{
  [Route("api/Account")]
  [ApiController]
  public class AccountController : ControllerBase
  {
    private readonly IUserServices _userServices;
    public AccountController(IUserServices userServices)
    {
      _userServices = userServices;
    }
    [HttpPost]
    [Route("authenticate")]
    public async Task<IActionResult> Authenticate([FromBody] LoginViewModel loginViewModel)
    {
      var User = await _userServices.Authenticate(loginViewModel);
      if (User == null) return BadRequest(new { message = "Wrong User/PWD" });
      return Ok(User);
    }
  }
}
