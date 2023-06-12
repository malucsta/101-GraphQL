﻿namespace GraphQL.Demo.API.Schema.Queries;

public enum Subject
{
    Math,
    Science,
    History
}

public class CourseType
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Subject Subject { get; set; }

    [GraphQLNonNullType]
    public InstructorType Instructor { get; set; }
    public IEnumerable<StudentType> Students { get; set; }
}