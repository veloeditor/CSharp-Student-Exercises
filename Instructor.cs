using System;
using System.Collections.Generic;

namespace StudentExercises
{
    public class Instructor : People {
        // You must define a type for representing an instructor in code.

        // First name
        // Last name
        // Slack handle
        // The instructor's cohort
        // The instructor's specialty (e.g. jokes, snack cakes, dancing, etc.)
        // A method to assign an exercise to a student

        // public string FirstName {get; set;}
        // public string LastName {get; set;}
        // public string SlackHandle {get; set;}
        // public Cohort Cohort {get; set;}
        public string Specialty {get; set;}

        public Instructor(string firstName, string lastName, string slackHandle, Cohort cohort, string InstructorSpecialty) {
            FirstName = firstName;
            LastName = lastName;
            SlackHandle = slackHandle;
            Cohort = cohort;
            Specialty = InstructorSpecialty;
        }

        //assignment method for instructors to assign excerises to students
        public void SetAssignment(Exercise exercise, Student student)
        {
            student.Exercises.Add(exercise);
        }
    }
}