﻿using GraphQL.Demo.API.Models;

namespace GraphQL.Demo.API.DTOs;

public class CourseDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Subject Subject { get; set; }
    public Guid InstructorId { get; set; }
    public InstructorDTO Instructor { get; set; }
    public IEnumerable<StudentDTO> Students { get; set; }
}
