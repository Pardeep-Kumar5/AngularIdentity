using Employee_Api_Jwt_1030.Models.Identity;
using Employee_Api_Jwt_1030.ServiceContract;
using Employee_Api_Jwt_1030.ViewModel;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Api_Jwt_1030.Service
{
  public class UserService : IUserServices
  {
    private readonly ApplicationUserManager _applicationUserManager;
    private readonly ApplicationSignInManager _applicationSignInManager;
    private readonly AppSetting _appSetting;

    public UserService(ApplicationUserManager applicationUserManager, ApplicationSignInManager applicationSignInManager,
      IOptions<AppSetting> appsetting)
    {
      _applicationUserManager = applicationUserManager;
      _applicationSignInManager = applicationSignInManager;
      _appSetting = appsetting.Value;
    }

    public async Task<ApplicationUser> Authenticate(LoginViewModel loginViewModel)
    {
      var Result = await _applicationSignInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, false, false);
      if(Result.Succeeded)
      {
        var ApplicationUser = await _applicationUserManager.FindByNameAsync(loginViewModel.UserName);
        ApplicationUser.PasswordHash = "";
        //jwt token
        if (await _applicationUserManager.IsInRoleAsync(ApplicationUser, SD.Role_Admin))
          ApplicationUser.Role = SD.Role_Admin;
        if (await _applicationUserManager.IsInRoleAsync(ApplicationUser, SD.Role_Employee))
          ApplicationUser.Role = SD.Role_Employee;

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSetting.Secret);
        var tokenDescritor = new SecurityTokenDescriptor()
        {
          Subject = new ClaimsIdentity(new Claim[]
            {
                    new Claim(ClaimTypes.Name, ApplicationUser.Id),
                    new Claim(ClaimTypes.Email, ApplicationUser.Email),
                     new Claim(ClaimTypes.Role, ApplicationUser.Role)

            }),
          Expires = DateTime.UtcNow.AddDays(7),
          SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescritor);
        ApplicationUser.Token = tokenHandler.WriteToken(token);
        return ApplicationUser;
      }
      else
      {
        return null;
      }
    }
  }
}
