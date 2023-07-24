using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Api_Jwt_1030.Models.Identity
{
  public class ApplicationUserStore:UserStore<ApplicationUser>
  {
    public ApplicationUserStore(ApplicationDbcontext context):base(context)
    {

    }
  }
}
