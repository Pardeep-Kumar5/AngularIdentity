using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Api_Jwt_1030.Models.Identity
{
  public class ApplicationUser:IdentityUser
  {
    [NotMapped]
    public string Token { get; set; }
    [NotMapped]
    public string Role { get; set; }
  }
}
