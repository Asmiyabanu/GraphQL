using GraphQLDemoAPI.Schema.Queries;
using HotChocolate;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDemoAPI.Schema.Subscription
{
    public class Subscription
    {
        [Subscribe]

        public CourseType CourseCreated([EventMessage] CourseType course) => course;

        [Subscribe]

        public ValueTask <ISourceStream<CourseResult>> CourseUpdated(Guid courdeId, [Service]ITopicEventReceiver topicEventReceiver)
        {

           string topicName =($"{courseId}_{nameof(Subscription.CourseUpdated)}");

            return topicEventReceiver.SubscribeAsync<string, CourseResult>(topicName);
    }
}
