using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            // Once you have defined all of your custom types, go to your Main() method in Program.cs and implement the following logic.

            // Create 4, or more, exercises.
            // Create 3, or more, cohorts.
            // Create 4, or more, students and assign them to one of the cohorts.
            // Create 3, or more, instructors and assign them to one of the cohorts.
            // Have each instructor assign 2 exercises to each of the students.

            //create the exercises
            Exercise nutshell = new Exercise("Nutshell React", "JavaScript");
            Exercise celebrityTribute = new Exercise("Celebrity Tribute", "HTML");
            Exercise chickenMonkey = new Exercise("Chicken Monkey", "JavaScript");
            Exercise welcomeToNashville = new Exercise("Welcome to Nashville", "JavaScript");
            Exercise CityPlanning = new Exercise("City Planning", "C#");

            //cohorts

            Cohort cohort34 = new Cohort("Full-Time Cohort 34");
            Cohort cohort33 = new Cohort("Full-Time Cohort 33");
            Cohort evening15 = new Cohort("Evening Cohort 15");

            //students

            Student brian = new Student("Brian", "Wilson", "Brian Wilson", cohort34);
            Student curtis = new Student("Curtis", "Crutchfield", "Curtis Crutchfield", cohort34);
            Student shelley = new Student("Shelley", "Thomas", "Shelley Thomas", evening15);
            Student allie = new Student("Allie", "Patton", "Allie Patton", cohort34);
            Student john = new Student("John", "Adams", "John Adams", cohort33);

            //assign students to cohorts

            cohort34.Students.Add(brian);
            cohort34.Students.Add(curtis);
            evening15.Students.Add(shelley);
            cohort34.Students.Add(allie);
            cohort33.Students.Add(john);

            //instructors

            Instructor steve = new Instructor("Steve", "Brownlee", "Steve Brownlee", cohort33, "ninja skills");
            Instructor andy = new Instructor("Andy", "Collins", "Andy Collins", cohort34, "invented csharp");
            Instructor brenda = new Instructor("Brenda", "Long", "Brenda Long", evening15, "CSS Wizard");

            //assign instructors to cohorts
            cohort34.Instructors.Add(andy);
            cohort33.Instructors.Add(steve);
            evening15.Instructors.Add(brenda);

            //assign exercises - cohort 34

            andy.SetAssignment(chickenMonkey, brian);
            andy.SetAssignment(nutshell, brian);
            andy.SetAssignment(chickenMonkey, allie);
            andy.SetAssignment(nutshell, allie);
            andy.SetAssignment(chickenMonkey, curtis);
            andy.SetAssignment(nutshell, curtis);
            brenda.SetAssignment(CityPlanning, john);
            steve.SetAssignment(nutshell, john);
            andy.SetAssignment(welcomeToNashville, john);

            //assign exercises - cohort 33

            //assign exercises - evening 15

            // Create a list of all the students
            List<Student> allTheStudents = new List<Student>()
            {
                brian, allie, curtis, shelley, john
            };

            foreach(Student student in allTheStudents) {
                // Console.WriteLine($"The students sorted normally: {student.FirstName} {student.LastName}");
            }

            // Create a list of all the exercises
            List<Exercise> allTheExercises = new List<Exercise>()
            {
                chickenMonkey, nutshell, welcomeToNashville, celebrityTribute
            };

            // Create a lit of all cohorts
            List<Cohort> allTheCohorts = new List<Cohort>()
            {
                cohort33, cohort34, evening15
            };

            //Create a list of all the instructors
            List<Instructor> allTheInstructors  = new List<Instructor> {
                steve, andy, brenda
            };

            // Generate a report that displays which students are working on which exercises.

            //List exercises for the JavaScript language by using the Where() LINQ method.
            List<Exercise> javaScript = allTheExercises.Where(exercise => exercise.Language == "JavaScript").ToList();

            //Print out the all the exercises by that language

            foreach(Exercise exercise in javaScript) {
                // Console.WriteLine($"{exercise.Name}: {exercise.Language}");
            }

            // List students in a particular cohort by using the Where() LINQ method.

            List<Student> Cohort34Students = allTheStudents.Where(student => student.Cohort.Name == "Full-Time Cohort 34").ToList();

            //Loop through students to get all students from that cohort
            foreach(Student student in Cohort34Students) {
                // Console.WriteLine($"Student: {student.FirstName} {student.LastName}, Cohort: {student.Cohort.Name}");
            }

            //List instructors in a particular cohort by using the Where() LINQ method.

            List<Instructor> Cohort34Instructor = allTheInstructors.Where(instructor => instructor.Cohort.Name == "Full-Time Cohort 34").ToList();

            foreach(Instructor instructor in Cohort34Instructor) {
                // Console.WriteLine($"Instructor: {instructor.FirstName} {instructor.LastName}, Cohort: {instructor.Cohort.Name}");
            }

            //sort students by last name
            List<Student> StudentsLastNameOrder = allTheStudents.OrderBy(p => p.LastName).ThenBy(p => p.FirstName).ToList();
            foreach(Student student in StudentsLastNameOrder) {
                // Console.WriteLine($"{student.FirstName} {student.LastName}");
            }

            // Display any students that aren't working on any exercises (Make sure one of your student instances don't have any exercises. Create a new student if you need to.)
            List<Student> StudentsWithNoExercises = allTheStudents.Where(student => student.Exercises.Count() == 0).ToList();
            foreach(Student student in StudentsWithNoExercises) {
                // Console.WriteLine("Students who have not been assigned exercises:");
                // Console.WriteLine($"{student.FirstName} {student.LastName}");
            }

            //Which student is working on the most exercises? Make sure one of your students has more exercises than the others.

            List<Student> StudentsWithMostExercises = allTheStudents.OrderByDescending(student => student.Exercises.Count()).ToList();
            Student mostExercises = StudentsWithMostExercises[0];
            Console.WriteLine($"Student with the most exercises assigned is {mostExercises.FirstName} {mostExercises.LastName}");

            //How many students in each cohort?

             var studentsPerCohort = allTheStudents.GroupBy(student => student.Cohort,
                student => student, (key, g) => new
                {
                    Cohort = key,
                    NumOfStudents = g.Count()
                }
            );
            foreach (var count in studentsPerCohort) {
                Console.WriteLine($"{count.Cohort.Name}: {count.NumOfStudents}");
            }

          


            //loop through the exercises to get exercise names
            foreach(Exercise exercise in allTheExercises) {
                // Console.WriteLine();
                // Console.WriteLine($"{exercise.Name}: ");
                // Console.WriteLine();

                //loop through students to see if their object contains exercise
                foreach(Student student in allTheStudents) {
                    if (student.Exercises.Contains(exercise)) {
                        // Console.WriteLine($"{student.FirstName} {student.LastName}");
                    }
                }
                // Console.WriteLine();
                // Console.WriteLine("--------------");
            }





        }
    }
}
