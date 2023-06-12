using GraphQL.Demo.API.Schema.Mutations;
using HotChocolate.Subscriptions;
using HotChocolate.Execution;

namespace GraphQL.Demo.API.Schema.Subscriptions
{
    public class Subscription
    {
        [Subscribe]
        [Topic(Consts.Topics.CourseCreated)]
        public CourseResult CourseCreated([EventMessage] CourseResult course) => course;

        [SubscribeAndResolve]
        public ValueTask<ISourceStream<CourseResult>> CourseUpdated(string id, [Service] ITopicEventReceiver receiver)
        {
            return receiver.SubscribeAsync<CourseResult>(Consts.Topics.CourseUpdatedById(id));
        }
    }
}
