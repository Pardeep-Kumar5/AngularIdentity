using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Api_Jwt_1030.Models.Identity
{ 
  public class ApplicationDbcontext:IdentityDbContext<ApplicationUser>
  {
    public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext>options):base(options)
    {

    }
    public DbSet<ApplicationRole> ApplicationRoles { get; set; }
    public DbSet<Employee> Employees { get; set; }
   
  }
}
