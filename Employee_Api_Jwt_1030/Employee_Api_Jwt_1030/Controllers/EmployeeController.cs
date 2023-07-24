using Employee_Api_Jwt_1030.Models;
using Employee_Api_Jwt_1030.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Api_Jwt_1030.Controllers
{
  [Route("api/Employee")]
  [ApiController]
  [Authorize]
  public class EmployeeController : ControllerBase
  {
    private readonly ApplicationDbcontext _context;

    public EmployeeController(ApplicationDbcontext context)
    {
      _context = context;
    }
    [HttpGet]
    public IActionResult GetEmployee()
    {
      return Ok(_context.Employees.ToList());
    }
    [HttpPost]
   
    public IActionResult SaveEmployee([FromBody] Employee employee)
    {
      if (employee == null) return NotFound();
      if (!ModelState.IsValid) return BadRequest();
      _context.Employees.Add(employee);
      _context.SaveChanges();
      return Ok();
    }
    [HttpPut]
    public IActionResult UpdateEmployee([FromBody] Employee employee)
    {
      if (employee == null) return NotFound();
      if (!ModelState.IsValid) return BadRequest();
      _context.Employees.Update(employee);
      _context.SaveChanges();
      return Ok();
    }
    [HttpDelete("{id:int}")]
    public IActionResult DeleteEmployee(int id)
    {
      var Employeefromdb = _context.Employees.Find(id);
      if (Employeefromdb == null) return NotFound();
      if (!ModelState.IsValid) return BadRequest();
      _context.Employees.Remove(Employeefromdb);
      _context.SaveChanges();
      return Ok();
    }

  }
}
