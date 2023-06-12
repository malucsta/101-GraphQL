using GraphQL.Demo.API.Schema.Subscriptions;
using HotChocolate.Subscriptions;

namespace GraphQL.Demo.API.Schema.Mutations;

public class Mutation
{
    private readonly List<CourseResult> _courses;

    public Mutation()
    {
        _courses = new List<CourseResult>();
    }
    
    public async Task<CourseResult> CreateCourse(CourseInput input, [Service] ITopicEventSender topicEventSender)
    {
        var course = new CourseResult
        {
            Id = Guid.NewGuid(),
            Name = input.Name,
            Subject = input.Subject,
            InstructorId = input.InstructorId,
        };

        _courses.Add(course);
        await topicEventSender.SendAsync(Consts.Topics.CourseCreated, course);

        return course;
    }

    public async Task<CourseResult> UpdateCourse(Guid id, CourseInput input, [Service] ITopicEventSender topicEventSender)
    {
        var course = _courses.FirstOrDefault(c => c.Id == id);

        if (course is null)
            throw new GraphQLException(new Error("Course not found", "COURSE_NOT_FOUND"));

        _courses.Remove(course);
        course.Name = input.Name;
        course.Subject = input.Subject; 
        course.InstructorId = input.InstructorId;
        _courses.Add(course);

        await topicEventSender.SendAsync(Consts.Topics.CourseUpdatedById(course.Id.ToString()), course);

        return course;
    }

    public bool DeleteCourse(Guid id)
    {
        return _courses.RemoveAll(c => c.Id == id) > 0;
    }
}
