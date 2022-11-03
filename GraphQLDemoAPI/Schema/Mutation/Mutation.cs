using GraphQLDemoAPI.Schema.Mutation;
using GraphQLDemoAPI.Schema.Queries;
using HotChocolate;
using HotChocolate.Subscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDemoAPI.Schema.Mutations
{
    public class Mutation
    {
        private readonly List<CourseResult> _courses;
      

        public Mutation()
        {
            _courses = new List<CourseResult>();
        }

        public async Task <CourseResult> CreateCourse(CourseInputType courseInput, [Service] ITopicEventSender topicEventSender)
        {
            CourseResult courseType = new CourseResult()
            {
                Id = Guid.NewGuid(),
                Name = courseInput.Name,
                subject = courseInput.subject,
                InstructorId = courseInput.InstructorId
                 
            };
            _courses.Add(courseType);
           await topicEventSender.SendAsync(nameof(Subscription.CourseCreated),courseType);
           
            return courseType;
        }
        
        public aync Task<CourseResult> UpdateCourse(Guid id,CourseInputType courseInput, [Service] ITopicEventSender topicEventSender)
        {
            CourseResult course = _courses.FirstOrDefault(c => c.Id == id);

            if(course == null)
            {
                throw new GraphQLException(new Error("course not found.","COURSE_NOT_FOUND"));
            }

            course.Name = courseInput.Name;
            course.Subject = courseInput.Subject;
            course.InstructorId = courseInput.InstructorId;

            string UpdateCourseTopic = $"{course.Id}_{nameof(Subscription.CourseUpdated)}";
            await topicEventSender.SendAsync(UpdateCourseTopic, course);

            return course;
        }
        public bool DeleteCourse(Guid id)
        {
            return _courses.RemoveAll(c => c.Id == id) >= 1;
        }
    }
}
