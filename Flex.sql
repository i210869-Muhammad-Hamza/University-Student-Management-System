use Flex
----------user
CREATE TABLE User_
(
  USERID INT NOT NULL PRIMARY KEY,
  USERNAME VARCHAR(50),
  PASSWORD VARCHAR(30),
  NAME VARCHAR(50),
  ROLE VARCHAR(20),
  CAMPUS VARCHAR(30),
  DOB VARCHAR(20),
  PHONE VARCHAR(20),
  EMAIL VARCHAR(60)
);
--------student
CREATE TABLE Student
(
  ROLLNO VARCHAR(30) NOT NULL PRIMARY KEY,
  USERID INT,
  DEPT VARCHAR(30),
  BATCH VARCHAR(30),
  DEGREE VARCHAR(30),
  FOREIGN KEY (USERID) REFERENCES User_(USERID)
);

----course
create table course
(
course_ID VARCHAR(30) NOT NULL PRIMARY KEY,
Cname varchar(70),
CDept varchar(20),
credits int,
Pre_Req VARCHAR(30)
);
-----OFFERED COURSE
Create table offered_course
(
courseid VARCHAR(30),
cname varchar(50),
OfferCourse VARCHAR(3) 
);
--register course
CREATE TABLE registered_Courses (
    courseID VARCHAR(30) NOT NULL ,
    Studentid VARCHAR(30) NOT NULL,
    RegisterCourse VARCHAR(4) NOT NULL,
	sectionname  VARCHAR(10)
    );
	
-----faculty
Create table Faculty(
Facultyid VARCHAR(30) NOT NULL PRIMARY KEY,
  USERID INT,
  employeedsince Date,
  department VARCHAR(50),
  post VARCHAR(50),
  FOREIGN KEY (USERID) REFERENCES User_(USERID)
);

----feedback
CREATE TABLE FEEDBACK(
feedbackid INT PRIMARY KEY,
rollno VARCHAR(30),
     Date DATE,
    TeacherName NVARCHAR(50),
    Subject NVARCHAR(50),
    Schedule NVARCHAR(50),
    RoomNumber NVARCHAR(50),
    SchoolYear NVARCHAR(50),
	 attends INT NOT NULL,
    enthusiasm INT NOT NULL,
    initiative INT NOT NULL,
    articulated INT NOT NULL,
    speaks INT NOT NULL,
professionalism INT NOT NULL,
 commitment INT NOT NULL,
 encourages INT NOT NULL,
 criticisms INT NOT NULL,
 ontime INT NOT NULL,
 ontime_end INT NOT NULL,
 knowledge INT NOT NULL,
organization INT NOT NULL,
dynamism INT NOT NULL,
critical INT NOT NULL,
classenvironment INT NOT NULL,
belief INT NOT NULL,
respect INT NOT NULL,
strengths INT NOT NULL,
understands INT NOT NULL,
  comments TEXT,
  FOREIGN KEY (rollno) REFERENCES Student(ROLLNO)
);

-----------section
CREATE TABLE Section (
  SectionName VARCHAR(10)NOT NULL,
  FacultyID VARCHAR(30) NOT NULL,
  CourseID VARCHAR(30),
  
);
  ------marks distribution
  select * from ASSIGNMENTS
  CREATE TABLE DISTRIBUTION (
  CourseID VARCHAR(30) NOT NULL,
  QuizWeightage FLOAT,
  AssignmentWeightage FLOAT,
  Sessional1Weightage FLOAT,
  Sessional2Weightage FLOAT ,
  FinalExamWeightage FLOAT ,
  PRIMARY KEY ( CourseID),
  FOREIGN KEY (CourseID) REFERENCES course(course_ID),
);

  
----------------transcript
Create table Transcript
(
courseid VARCHAR(30),
coursename VARCHAR(30),
studentid VARCHAR(30),
grade VARCHAR(30),
)

--------grade
Create table Grade
(
grade VARCHAR(30),
courseid VARCHAR(30),
studentid VARCHAR(30),
)

-----academic officer
create table Academic_Officer
(
USERID INT,
QUALIFICATION VARCHAR(30),
A_ID varchar(30),
POSITION VARCHAR(30),
EXPERIENCE INT,
FOREIGN KEY (USERID) REFERENCES User_(USERID)
);

----ATTENDANCE
create table attendance(
lecture_no int,
date_ Date,
studentid VARCHAR(30),
courseid VARCHAR(30),
status VARCHAR(10)
FOREIGN KEY (studentid) REFERENCES Student(ROLLNO)
);

----EVALUATIONS
USE Flex
CREATE TABLE evaluations (
  evaluation VARCHAR(20)
);
---Final exam
CREATE TABLE FINALEXAM(
studentid VARCHAR(30),
obtained_marks int,
courseid VARCHAR(30),
FOREIGN KEY (studentid) REFERENCES Student(ROLLNO)
);

---SESSIONAL1
CREATE TABLE SESSIONAL1(
studentid VARCHAR(30),
obtained_marks int,
courseid VARCHAR(30),
FOREIGN KEY (studentid) REFERENCES Student(ROLLNO)
);

----SESSIONAL2
CREATE TABLE SESSIONAL2(
studentid VARCHAR(30),
obtained_marks int,
courseid VARCHAR(30),
FOREIGN KEY (studentid) REFERENCES Student(ROLLNO)
);

----ASSIGNMENTS
CREATE TABLE ASSIGNMENTS(
studentid VARCHAR(30),
obtained_marks int,
courseid VARCHAR(30),
FOREIGN KEY (studentid) REFERENCES Student(ROLLNO)
);

----SESSIONAL2
CREATE TABLE QUIZZES(
studentid VARCHAR(30),
obtained_marks int,
courseid VARCHAR(30),
FOREIGN KEY (studentid) REFERENCES Student(ROLLNO)
);

---------------------------------END Tables
-- Insert data into the table
INSERT INTO evaluations (evaluation)
VALUES ('QUIZZES'), ('ASSIGNMENTS'), ('SESSIONAL1'), ('SESSIONAL2'), ('FINALEXAM');
------------------------------Add constraints 
ALTER TABLE Offered_Course ADD CONSTRAINT FK_Offered_Course_Course FOREIGN KEY (courseid) REFERENCES Course(course_ID);
ALTER TABLE Offered_Course ADD CONSTRAINT FK_Offered_Course_CourseName FOREIGN KEY (cname) REFERENCES Course(Cname);
-------
ALTER TABLE Registered_Courses ADD CONSTRAINT FK_Registered_Courses_Course FOREIGN KEY (courseID) REFERENCES Course(course_ID);
ALTER TABLE Registered_Courses ADD CONSTRAINT FK_Registered_Courses_Student FOREIGN KEY (Studentid) REFERENCES Student(ROLLNO);

-------
ALTER TABLE Feedback ADD CONSTRAINT FK_Feedback_Teacher FOREIGN KEY (TeacherName) REFERENCES User_(Name);
ALTER TABLE Feedback ADD CONSTRAINT FK_Feedback_Subject FOREIGN KEY (Subject) REFERENCES Course(Cname);
-----
ALTER TABLE Section ADD CONSTRAINT FK_Section_Faculty FOREIGN KEY (FacultyID) REFERENCES Faculty(Facultyid);