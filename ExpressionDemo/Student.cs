using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionDemo
{
    public class Student
    {
        public int Id;
    }

    public class People
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
    }

    public class PeopleDto
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
    }
}
