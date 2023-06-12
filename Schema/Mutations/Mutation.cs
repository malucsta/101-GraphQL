using GraphQL.Demo.API.Schema.Queries;

namespace GraphQL.Demo.API.Schema.Mutations;

public class Mutation
{
    private readonly List<CourseResult> _courses = new List<CourseResult>();
    public CourseResult CreateCourse(CourseInput input)
    {
        var course = new CourseResult
        {
            Id = Guid.NewGuid(),
            Name = input.Name,
            Subject = input.Subject,
            InstructorId = input.InstructorId,
        };

        _courses.Add(course);

        return course;
    }

    public CourseResult UpdateCourse(Guid id, CourseInput input)
    {
        var course = _courses.FirstOrDefault(c => c.Id == id);

        if (course is null)
            throw new GraphQLException(new Error("Course not found", "COURSE_NOT_FOUND"));

        _courses.Remove(course);
        course.Name = input.Name;
        course.Subject = input.Subject; 
        course.InstructorId = input.InstructorId;
        _courses.Add(course);

        return course;
    }

    public bool DeleteCourse(Guid id)
    {
        return _courses.RemoveAll(c => c.Id == id) > 0;
    }
}
