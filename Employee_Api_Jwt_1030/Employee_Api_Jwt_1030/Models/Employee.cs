using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Api_Jwt_1030.Models
{
  public class Employee
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public int Salary { get; set; }
  }
}
