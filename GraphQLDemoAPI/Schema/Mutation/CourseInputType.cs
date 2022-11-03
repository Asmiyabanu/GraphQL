using GraphQLDemoAPI.Schema.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDemoAPI.Schema.Mutation
{
    public class CourseInputType
    {
        public string Name { get; set; }
        public Subject subject { get; set; }
        public Guid InstructorId { get; set; }
    }
}
