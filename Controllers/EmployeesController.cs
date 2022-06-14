using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using API_Eg.Models;

namespace API_Eg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly Eurofins_dbContext _context;

        public EmployeesController(Eurofins_dbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            return Ok(_context.Employees.ToList());
        }

        [HttpPost]
        public async Task<ActionResult> AddEmployees(Employee e)
        {
            _context.Employees.Add(e);
            _context.SaveChanges();
            return Ok(e);
        }

        [HttpPut]
        public async Task<ActionResult> EditEmployees(int id,Employee e)
        {
            /*Employee E = _context.Employees.Find(id);*/
            _context.Employees.Update(e);
            _context.SaveChanges();
            return Ok();
        }
        [Route("GetPrdById")]
        [HttpGet]
        public async Task<ActionResult> GetEmployeeById(int id)
        {
            Employee E = _context.Employees.Find(id);
            return Ok(E);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            Employee E = _context.Employees.Find(id);
            _context.Employees.Remove(E);
            _context.SaveChanges();
            return Ok();
        }


    }
}
