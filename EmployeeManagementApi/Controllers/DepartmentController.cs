using EmployeeManagementApi.Data;
using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DepartmentController(ApplicationDbContext context) : ControllerBase
{
    private readonly ApplicationDbContext _context = context;

    // GET: api/department
    [HttpGet]
    public async Task<IActionResult> GetDepartments()
    {
        var departments = await _context.Departments.ToListAsync();
        return Ok(departments);
    }

    // GET: api/department/5
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetDepartment(int id)
    {
        var department = await _context.Departments.FirstOrDefaultAsync(d => d.Id == id);
        if(department is null) return NotFound();
        return Ok(department);
    }
    
    // POST: api/department
    [HttpPost]
    public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentRequest request)
    {
        var department = new Department
        {
            Name = request.Name
        };
        
        _context.Departments.Add(department);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetDepartment), new { id = department.Id }, department);
    }

    // PUT: api/department/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateDepartment(int id, [FromBody] UpdateDepartmentRequest request)
    {
        var department = await _context.Departments.FirstOrDefaultAsync(d=>d.Id == id);
        if (department is null) return NotFound();

        department.Name = request.Name;
        await _context.SaveChangesAsync();
        
        return NoContent();
    }
    
    // DELETE: api/department/5 (Soft Delete)
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteDepartment(int id)
    {
        var department = await _context.Departments.FirstOrDefaultAsync(d=>d.Id == id);
        if (department is null) return NotFound();
        
        department.IsDeleted = true;
        await _context.SaveChangesAsync();
        
        return NoContent();
    }
}