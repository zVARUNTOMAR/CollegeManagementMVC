using System;

namespace Entities
{
   public class Student
    {
        public string studentId { get; set; }

        public string studentName { get; set; }

        public College college { get; set; }

        public int percentage { get; set; }

        public Student() { 
        
        }
    }
}
