using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDemoAPI.Schema.Queries
{
    public class InstructorType
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double salary { get; set; }
        public object GPA { get; internal set; }
    }
}
