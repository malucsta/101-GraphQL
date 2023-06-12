namespace GraphQL.Demo.API.DTOs;

public class InstructorDTO
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public decimal Salary { get; set; }

    public IEnumerable<CourseDTO> Courses { get; set; }
}
