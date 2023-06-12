namespace GraphQL.Demo.API.Schema.Subscriptions;

public static class Consts
{
    public static class Topics
    {
        public const string CourseCreated = "CourseCreated";
        public const string CourseUpdated = "CourseUpdated";
        
        public static string CourseUpdatedById(string id) => $"{id}_{CourseUpdated}";
    }
}
