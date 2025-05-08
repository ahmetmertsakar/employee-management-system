namespace EmployeeManagementAPI.Models;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsDeleted { get; set; }
    public ICollection<Employee> Employees { get; set; }
}