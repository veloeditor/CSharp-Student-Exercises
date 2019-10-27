----Create the tables that will hold the data


--CREATE TABLE Cohorts (
--	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
--	Name VARCHAR(55) NOT NULL
--);

--CREATE TABLE Students (
--	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
--	FirstName VARCHAR(55) NOT NULL,
--	LastName VARCHAR(55) NOT NULL,
--	SlackHandle VARCHAR(55) NOT NULL,
--	CohortId INTEGER NOT NULL,
--	CONSTRAINT FK_Student_Cohort FOREIGN KEY(CohortId) REFERENCES Cohorts(Id)
--);

--CREATE TABLE Exercises (
--	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
--	Name VARCHAR(55) NOT NULL,
--	CodeLanguage VARCHAR(55) NOT NULL
--);

--CREATE TABLE Instructors (
--	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
--	FirstName VARCHAR(55) NOT NULL,
--	LastName VARCHAR(55) NOT NULL,
--	SlackHandle VARCHAR(55) NOT NULL,
--	Speciality VARCHAR(55) NOT NULL,
--	CohortId INTEGER NOT NULL,
--	CONSTRAINT FK_Instructor_Cohort FOREIGN KEY(CohortId) REFERENCES Cohorts(Id)
--);

--CREATE TABLE StudentExercises (
--	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
--	StudentId INTEGER NOT NULL,
--	ExerciseId INTEGER NOT NULL,
--	InstructorId INTEGER NOT NULL,
--	CONSTRAINT FK_Assignment_Stduent FOREIGN KEY(StudentId) REFERENCES Students(Id),
--	CONSTRAINT FK_Assignment_Exercise FOREIGN KEY(ExerciseId) REFERENCES Exercises(Id),
--	CONSTRAINT FK_Assignment_Instructor FOREIGN KEY(InstructorId) REFERENCES Instructors(Id)
--);

----Populate each table with data

--INSERT INTO Exercises(Name, CodeLanguage) VALUES ('Nutshell React', 'JavaScript')
--INSERT INTO Exercises(Name, CodeLanguage) VALUES ('Celebrity Tribute', 'HTML')
--INSERT INTO Exercises(Name, CodeLanguage) VALUES ('ChickenMonkey', 'JavaScript')
--INSERT INTO Exercises(Name, CodeLanguage) VALUES ('Kennel', 'ReactJS')
--INSERT INTO Exercises(Name, CodeLanguage) VALUES ('City Planning', 'C#')
--INSERT INTO Exercises(Name, CodeLanguage) VALUES ('Music Database', 'SQL')

--INSERT INTO Cohorts(Name) VALUES ('DayTime Cohort 33')
--INSERT INTO Cohorts(Name) VALUES ('DayTime Cohort 34')
--INSERT INTO Cohorts(Name) VALUES ('Evening Cohort 15')

--INSERT INTO Students(FirstName, LastName, SlackHandle, CohortId) VALUES ('Curtis', 'Crutchfield', 'Curtis Crutchfield', 1)
--INSERT INTO Students(FirstName, LastName, SlackHandle, CohortId) VALUES ('Brian', 'Wilson', 'Brian Wilson', 1)
--INSERT INTO Students(FirstName, LastName, SlackHandle, CohortId) VALUES ('Shelly', 'Thomas', 'Shelly Thomas', 2)
--INSERT INTO Students(FirstName, LastName, SlackHandle, CohortId) VALUES ('John', 'Adams', 'John Adams', 3)

--INSERT INTO Instructors(FirstName, LastName, SlackHandle, Speciality, CohortId) VALUES('Andy', 'Collins', 'Andy Collins', 'Dry Humor/C#', 1)
--INSERT INTO Instructors(FirstName, LastName, SlackHandle, Speciality, CohortId) VALUES('Steve', 'Brownlee', 'Steve Brownlee', 'Dad Jokes/JavaScript', 2)
--INSERT INTO Instructors(FirstName, LastName, SlackHandle, Speciality, CohortId) VALUES('Brenda', 'Long', 'Brenda Long', 'UI/UX', 3)

--INSERT INTO StudentExercises(StudentId, ExerciseId, InstructorId) VALUES(1, 5, 1)
--INSERT INTO StudentExercises(StudentId, ExerciseId, InstructorId) VALUES(1, 6, 1)
--INSERT INTO StudentExercises(StudentId, ExerciseId, InstructorId) VALUES(2, 6, 1)
--INSERT INTO StudentExercises(StudentId, ExerciseId, InstructorId) VALUES(2, 6, 1)
--INSERT INTO StudentExercises(StudentId, ExerciseId, InstructorId) VALUES(3, 1, 2)
--INSERT INTO StudentExercises(StudentId, ExerciseId, InstructorId) VALUES(3, 3, 2)
--INSERT INTO StudentExercises(StudentId, ExerciseId, InstructorId) VALUES(4, 4, 3)
--INSERT INTO StudentExercises(StudentId, ExerciseId, InstructorId) VALUES(4, 5, 3)

--Write a query to return all student first and last names with their cohort's name.

--SELECT s.FirstName, s.LastName, c.Name
--FROM Students s LEFT JOIN Cohorts c on s.CohortId = c.Id;

--Write a query to return student first and last names with their cohort's name only for a single cohort.

--SELECT s.FirstName, s.LastName, c.Name as Cohort_Name
--FROM Students s LEFT JOIN Cohorts c on s.CohortId = c.Id
--WHERE c.Id = 2;

--Write a query to return all instructors ordered by their last name.
--NOTE: SQL offers the ability to order by columns in a table.

--SELECT FirstName, LastName
--FROM Instructors
--ORDER BY LastName;

--Write a query to return a list of unique instructor specialties.
--NOTE: Take a look at SQL SELECT DISTINCT Statement for some guidance.

--SELECT DISTINCT Speciality as InstructorSpeciality
--FROM Instructors;

--Write a query to return a list of all student names along with the names of the exercises they have been assigned. If an exercise has not been assigned, it should not be in the result.
--NOTE: sometimes you need to join more than two tables in a query.

--SELECT s.FirstName, s.LastName, e.Name
--FROM StudentExercises se 
--	INNER JOIN Students s on se.StudentId = s.Id
--    INNER JOIN Exercises e on se.ExerciseID = e.Id;

--Return a list of student names along with the count of exercises assigned to each student.
--NOTE: SQL has a group by just like LINQ does.

SELECT COUNT (se.ExerciseId) NumOfExercisesAssigned, s.FirstName, s.LastName
FROM StudentExercises se INNER JOIN Students s on se.StudentId = s.Id
GROUP BY s.FirstName, s.LastName;

