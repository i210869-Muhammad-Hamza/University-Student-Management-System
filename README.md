# University-Student-Management-System
# FLEX System - University Student Management System
![fleximg - Copy](https://github.com/user-attachments/assets/5438ba53-6f74-4053-b01d-e7760a194f39)
![ERD DIAGRAM - Copy](https://github.com/user-attachments/assets/82555c5d-0038-41b8-a508-5e48dc140066)
![loginSS - Copy](https://github.com/user-attachments/assets/039c0215-d82c-49a7-ab44-8717e919e6d7)
![STUDENT SS - Copy](https://github.com/user-attachments/assets/aaf24ade-b52f-4670-886c-ea8632c9dce4)
FLEX System is a comprehensive database management system developed for FAST NUCES to manage and schedule students' academic information. The system allows seamless handling of various operations such as student enrollment, course registration, scheduling, and performance tracking through dedicated user interfaces for Academic Officers, Faculty, and Students.
Project Overview

This project focuses on improving the academic experience for students while optimizing university operations. It includes:

    Efficient data processing
    User-friendly interfaces for different roles
    Scalability and security features
    Integration with other systems as needed
    Audit trails for user actions

Roles and User Interfaces:

    Academic Officers:
        Offer courses each semester.
        Manage course prerequisites, student enrollment, and section creation.
        Assign courses to instructors and enforce constraints (max courses, section limits).
        Generate various reports (e.g., offered courses, student section reports, course allocation reports).

    Faculty:
        View assigned courses.
        Set marks distribution and manage attendance.
        Record evaluation marks, finalize grades, and generate evaluation and grade reports.
        Review student feedback and attendance reports.

    Students:
        View registered courses, attendance, evaluation marks, and grades.
        Compare previous semester CGPAs using visual graphs.
        Provide feedback to instructors via a dedicated form.

Features
Academic Office Interface:

    Course Management: Offer courses, assign students to sections, allocate courses to instructors.
    Prerequisite Validation: Ensure students meet prerequisites before enrolling.
    Section Management: Ensure sections have a minimum of 10 students and a maximum of 50.
    Course Allocation: Manage faculty workload, allowing up to 3 courses per instructor.
    Report Generation: Automatically generate:
        Offered Courses Report
        Student Section Report
        Course Allocation Report

Faculty Interface:

    Course Management: View assigned courses with credit hours.
    Attendance and Evaluation Management: Record attendance and evaluations, ensuring marks distribution sums to 100.
    Grading: Apply absolute grading policy.
    Report Generation:
        Attendance Sheet Report
        Evaluation Report
        Grade Report
        Count of Grades Report
        Student Feedback Report

Student Interface:

    View Academic Information: Access course details, attendance, marks, and grades.
    Feedback Submission: Submit feedback via a form. Faculty can view percentage-based feedback along with comments.

Security and Audit Trails

The system includes robust security features such as:

    User authentication via login and password.
    Role-based access control to ensure correct privileges for each user role.
    Audit Trail: Logs all user actions, recording operations, user details, and timestamps.

Technologies Used

    C# (Back-end programming)
    Visual Studio 2019 (Development environment)
    SQL Server (Database management)
    Excel Sheet Integration (For importing data)

Database Design

The system utilizes a relational database with entities such as Users, Courses, Sections, Students, Faculty, and Evaluations. The following diagrams detail the relationships between these entities:

    Entity Relationship Diagram (ERD)
    Schema Diagram
    Mappings of Relationships

Reports

    Offered Courses Report: Lists all courses with course codes and credit hours.
    Student Section Report: Displays student registration numbers and names in each section.
    Course Allocation Report: Shows which instructors and coordinators are teaching specific sections.
    Attendance Sheet Report: Lists attendance records with percentages for all students.
    Evaluation Report: Displays marks obtained by students in evaluations.
    Grade Report: Lists student grades in each course.
    Count of Grades Report: Displays the number of students who obtained each grade.
    Student Feedback Report: Shows feedback comments and percentage-based feedback for faculty.
