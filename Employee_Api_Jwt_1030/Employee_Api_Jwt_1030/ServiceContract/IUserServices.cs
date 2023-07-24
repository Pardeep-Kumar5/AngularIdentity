using Employee_Api_Jwt_1030.Models.Identity;
using Employee_Api_Jwt_1030.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Api_Jwt_1030.ServiceContract
{
 public interface IUserServices
  {
    Task<ApplicationUser> Authenticate(LoginViewModel loginViewModel);
  }
}
