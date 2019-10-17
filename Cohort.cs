using System;
using System.Collections.Generic;

// ## Cohort

// You must define a type for representing a cohort in code.

// 1. The cohort's name (Evening Cohort 6, Day Cohort 25, etc.)
// 1. The collection of students in the cohort.
// 1. The collection of instructors in the cohort.

namespace StudentExercises
{
    public class Cohort
    {
        public string Name {get; set;}
        public List<Student>Students {get; set;}
        public List<Instructor>Instructors {get; set;}

        public Cohort (string name)
        {
            Name = name;
            Students = new List<Student>();
            Instructors = new List<Instructor>();

        }
    }
}