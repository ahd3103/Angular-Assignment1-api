using EmployeeManagement.Data;
using EmployeeManagement.Model;
using EmployeeManagement.RespoanceClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EFDbContext _eFDbContext;

        public EmployeeController(EFDbContext eFDbContext)
        {
            _eFDbContext = eFDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
           var employees = await _eFDbContext.Employees.Include(x=>x.Skills).ToListAsync();

            List<EmployeeResp> lstEmployeeResponseDTO = employees.Select(a => new EmployeeResp
            {
                Id = a.Id,
                Name = a.Name,
                ContactNumber = a.ContactNumber,
                Email = a.Email,
                Gender = a.Gender,
                Skills = a.Skills
            }).ToList();

            return Ok(lstEmployeeResponseDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        { 
            await _eFDbContext.Employees.AddAsync(employee);
            foreach (var skill in employee.Skills)
            {
                await _eFDbContext.Skills.AddAsync(skill);
            }
            await _eFDbContext.SaveChangesAsync();

            return Ok(employee);
        }

        [HttpGet("{empId}")]
        public async Task<IActionResult> GetEmployeeById(int empId)
        {
            //var employee = await _eFDbContext.Employees.FirstOrDefaultAsync(a => a.Id == empId);
            var employee = await _eFDbContext.Employees.Include(x => x.Skills).FirstOrDefaultAsync(x => x.Id == empId);
            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        [HttpPut("{empId}")]
        public async Task<IActionResult> UpdateEmployee(int empId, [FromBody] Employee employee)
        {
            var emp = await _eFDbContext.Employees.Include(x => x.Skills).FirstOrDefaultAsync(a => a.Id == empId);
            if (emp == null)
                return NotFound();

            emp.Name = employee.Name;
            emp.Gender = employee.Gender;
            emp.Email = employee.Email;
            emp.ContactNumber = employee.ContactNumber;

            // Remove existing skills
            _eFDbContext.Skills.RemoveRange(emp.Skills);

            // Add/update skills from the request
            foreach (var e in employee.Skills)
            {
                Skill skill = new Skill
                {
                    EmployeeId = emp.Id,
                    SkillName = e.SkillName,
                    SkillExperience = e.SkillExperience
                };
                emp.Skills.Add(skill);
            }

            await _eFDbContext.SaveChangesAsync();

            return Ok(emp);
        }

        [HttpDelete("{empId}")]
        public async Task<IActionResult> DeleteEmployee(int empId)
        {
            var emp = await _eFDbContext.Employees.Include(x => x.Skills).FirstOrDefaultAsync(a => a.Id == empId);
            if (emp == null)
                return NotFound();

            _eFDbContext.Employees.Remove(emp);
            await _eFDbContext.SaveChangesAsync();

            return Ok();
        }
    }
}






    



