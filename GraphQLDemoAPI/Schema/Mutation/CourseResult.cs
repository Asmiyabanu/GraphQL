using GraphQLDemoAPI.Schema.Queries;
using System;

namespace GraphQLDemoAPI.Schema.Queries

{
    public class CourseResult
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Subject subject { get; set; }

        public Guid InstructorId { get; set; }

    }
}
