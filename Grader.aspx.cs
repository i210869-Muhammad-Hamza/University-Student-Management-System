using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.IO;


    public partial class Grader : System.Web.UI.Page
    {
    public static void AppendToTextFile(string text)
    {
        string filePath = "C:\\Users\\hp\\OneDrive\\Desktop\\db project\\db project\\Audit.txt";

        using (StreamWriter writer = File.AppendText(filePath))
        {
            writer.WriteLine(text);
        }
    }
    protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                int USERID;
                USERID = Convert.ToInt32(Request.QueryString["USERID"]);
                string q = "SELECT Facultyid FROM Faculty WHERE USERID= " + USERID;
                string X = null;
                using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-VOMCOEB;Initial Catalog=Flex;Integrated Security=True"))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(q, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                X = reader.GetString(0);
                            }
                        }
                    }
                }


                // Define your SQL query to retrieve the course names
                string query = "SELECT course.Cname FROM course INNER JOIN Section s ON course.course_ID = s.CourseID WHERE s.FacultyID = @X";

                //  string query = "SELECT Course.CourseName FROM Course INNER JOIN Course_Allocation ON Course.CourseID = Course_Allocation.CourseID WHERE Course_Allocation.FacultyID = X";

                string connectionString = "Data Source=DESKTOP-VOMCOEB;Initial Catalog=Flex;Integrated Security=True";

                // Create a new SQL connection and command
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@X", SqlDbType.VarChar).Value = X;
                    // Open the SQL connection and execute the command
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    // Loop through the results and add each course name as an option in the select element
                    while (reader.Read())
                    {
                        string courseName = reader.GetString(0);
                        ListItem item = new ListItem(courseName, courseName);
                        subject.Items.Add(item);
                    }

                    // Close the reader and connection
                    reader.Close();
                    connection.Close();
                }


                // string connectionString = "Data Source=DESKTOP-MA76B76\\SQLEXPRESS;Initial Catalog=try2;Integrated Security=True";




            }
        }

        private int USERID;
        protected void Button0_Click(object sender, EventArgs e)
        {
            USERID = Convert.ToInt32(Request.QueryString["USERID"]);
            Response.Redirect("facultyome.aspx?userID=" + USERID);

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            USERID = Convert.ToInt32(Request.QueryString["USERID"]);
            Response.Redirect("distribution.aspx?userID=" + USERID);

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            USERID = Convert.ToInt32(Request.QueryString["USERID"]);
            Response.Redirect("ManageEvaluations.aspx?userID=" + USERID);
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            USERID = Convert.ToInt32(Request.QueryString["USERID"]);
            Response.Redirect("ManageAttendence.aspx?userID=" + USERID);
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            USERID = Convert.ToInt32(Request.QueryString["USERID"]);
            Response.Redirect("FacultyReports.aspx?userID=" + USERID);
        }
        protected void Button5_Click(object sender, EventArgs e)
        {
            USERID = Convert.ToInt32(Request.QueryString["USERID"]);
            Response.Redirect("Grader.aspx?userID=" + USERID);
        }
        protected void Button6_Click(object sender, EventArgs e)
        {
            USERID = Convert.ToInt32(Request.QueryString["USERID"]);
            Response.Redirect("FacultyFeedback.aspx?userID=" + USERID);
        }
        string course;

        protected void Button7_Click(object sender, EventArgs e)
        {
            string cours = "";
            course = subject.Value;
            string cname = subject.Value;
            //string cname = Request.Form["select"];
            string q = "SELECT course_ID FROM course WHERE Cname = @cname";
            string connectionString = "Data Source=DESKTOP-VOMCOEB;Initial Catalog=Flex;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(q, connection);
                command.Parameters.AddWithValue("@cname", cname);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    cours = reader.GetString(0);
                }
                reader.Close();
                // use courseID after the loop
                // Console.WriteLine("The course ID for {0} is {1}", cname);
            }
            string courseid = cours;

            // replace with the actual course ID

            // get all the students enrolled in the course
            string query = "SELECT studentid FROM registered_Courses WHERE courseID = @courseid";
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-VOMCOEB;Initial Catalog=Flex;Integrated Security=True"))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@courseid", courseid);
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable studentIdsTable = new DataTable();
                    adapter.Fill(studentIdsTable);

                    foreach (DataRow row in studentIdsTable.Rows)
                    {
                        string studentid = row.Field<string>("studentid");
                        int total_marks = 0;

                        // calculate the total marks for the student from each table
                        string[] tableNames = { "FINALEXAM", "SESSIONAL1", "SESSIONAL2", "ASSIGNMENTS", "QUIZZES" };
                        foreach (string tableName in tableNames)
                        {
                            query = "SELECT obtained_marks FROM " + tableName + " WHERE studentid = @studentid AND courseid = @courseid";
                            using (SqlCommand subcommand = new SqlCommand(query, connection))
                            {
                                subcommand.Parameters.AddWithValue("@studentid", studentid);
                                subcommand.Parameters.AddWithValue("@courseid", courseid);

                                SqlDataAdapter subAdapter = new SqlDataAdapter(subcommand);
                                DataTable subTable = new DataTable();
                                subAdapter.Fill(subTable);

                                if (subTable.Rows.Count > 0)
                                {
                                    int obtained_marks = subTable.Rows[0].Field<int>("obtained_marks");
                                    total_marks += obtained_marks;
                                }
                            }
                        }

                        // determine the grade based on the total marks
                        string grade = "";
                        if (total_marks >= 90)
                        {
                            grade = "A+";
                        }
                        else if (total_marks >= 86 && total_marks <= 89)
                        {
                            grade = "A";
                        }
                        else if (total_marks >= 82 && total_marks <= 85)
                        {
                            grade = "A-";
                        }
                        else if (total_marks >= 78 && total_marks <= 81)
                        {
                            grade = "B+";
                        }
                        else if (total_marks >= 74 && total_marks <= 77)
                        {
                            grade = "B";
                        }
                        else if (total_marks >= 70 && total_marks <= 73)
                        {
                            grade = "B-";
                        }
                        else if (total_marks >= 66 && total_marks <= 69)
                        {
                            grade = "C+";
                        }
                        else if (total_marks >= 62 && total_marks <= 65)
                        {
                            grade = "C";
                        }
                        else if (total_marks >= 58 && total_marks <= 61)
                        {
                            grade = "C-";
                        }
                        else if (total_marks >= 54 && total_marks <= 57)
                        {
                            grade = "D+";
                        }
                        else if (total_marks >= 50 && total_marks <= 53)
                        {
                            grade = "D";
                        }
                        else
                        {
                            grade = "F";
                        }

                        // insert the grade into the Grade table
                        using (SqlCommand subcommand = new SqlCommand("INSERT INTO Grade (grade, courseid, studentid) VALUES (@grade, @courseid, @studentid)", connection))
                        {
                            subcommand.Parameters.AddWithValue("@grade", grade);
                            subcommand.Parameters.AddWithValue("@courseid", courseid);
                            subcommand.Parameters.AddWithValue("@studentid", studentid);
                            subcommand.ExecuteNonQuery();
                        }
                    }
                }
                        AppendToTextFile("TEACHER MARKED GRADES SUCCESSFULLY ;");
        }
            USERID = Convert.ToInt32(Request.QueryString["USERID"]);
            Response.Redirect("grade.aspx?userID=" + USERID + "&course=" + course);
        }





        //protected void Button7_Click(object sender, EventArgs e)
        //{
        //    string courseid = "C001"; // replace with the actual course ID

        //    // get all the students enrolled in the course
        //    string query = "SELECT studentid FROM registered_Courses WHERE courseID = @courseid";
        //    using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-MA76B76\\SQLEXPRESS;Initial Catalog=try2;Integrated Security=True"))
        //    {
        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@courseid", courseid);
        //            connection.Open();
        //            SqlDataReader reader=null; 
        //            using ( reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    string studentid = reader.GetString(0);
        //                    int total_marks = 0;

        //                    // calculate the total marks for the student from each table
        //                    string[] tableNames = { "FINALEXAM", "SESSIONAL1", "SESSIONAL2", "ASSIGNMENTS", "QUIZZES" };
        //                    foreach (string tableName in tableNames)
        //                    {
        //                        reader.Close();
        //                        query = "SELECT obtained_marks FROM " + tableName + " WHERE studentid = @studentid AND courseid = @courseid";
        //                        using (SqlCommand subcommand = new SqlCommand(query, connection))
        //                        {
        //                            subcommand.Parameters.AddWithValue("@studentid", studentid);
        //                            subcommand.Parameters.AddWithValue("@courseid", courseid);

        //                            using (SqlDataReader subreader = subcommand.ExecuteReader())
        //                            {
        //                                if (subreader.Read())
        //                                {
        //                                    int obtained_marks = subreader.GetInt32(0);
        //                                    total_marks += obtained_marks;
        //                                }
        //                                subreader.Close();
        //                            }

        //                        }
        //                        reader = command.ExecuteReader();
        //                    }

        //                    // determine the grade based on the total marks
        //                    string grade = "";
        //                    if (total_marks >= 90)
        //                    {
        //                        grade = "A+";
        //                    }
        //                    else if (total_marks >= 86 && total_marks <= 89)
        //                    {
        //                        grade = "A";
        //                    }
//                            else if (total_marks >= 82 && total_marks <= 85)
//                            {
//                                grade = "A-";
//                            }
//                            else if (total_marks >= 78 && total_marks <= 81)
//                            {
//                                grade = "B+";
//                            }
//                            else if (total_marks >= 74 && total_marks <= 77)
//{
//    grade = "B";
//}
//else if (total_marks >= 70 && total_marks <= 73)
//{
//    grade = "B-";
//}
//else if (total_marks >= 66 && total_marks <= 69)
//{
//    grade = "C+";
//}
//else if (total_marks >= 62 && total_marks <= 65)
//{
//    grade = "C";
//}
//else if (total_marks >= 58 && total_marks <= 61)
//{
//    grade = "C-";
//}
//else if (total_marks >= 54 && total_marks <= 57)
//{
//    grade = "D+";
//}
//else if (total_marks >= 50 && total_marks <= 53)
//{
//    grade = "D";
//}
        //                    else
        //                    {
        //                        grade = "F";
        //                    }
        //                    SqlConnection co = new SqlConnection("Data Source=DESKTOP-MA76B76\\SQLEXPRESS;Initial Catalog=try2;Integrated Security=True");
        //                    // insert the grade into the Grade table
        //                    string q = "INSERT INTO Grade (grade, courseid, studentid) VALUES (@grade, @courseid, @studentid)";
        //                    co.Open();
        //                    using (SqlCommand subcommand = new SqlCommand(q, co))
        //                    {
        //                        subcommand.Parameters.AddWithValue("@grade", grade);
        //                        subcommand.Parameters.AddWithValue("@courseid", courseid);
        //                        subcommand.Parameters.AddWithValue("@studentid", studentid);
        //                        subcommand.ExecuteNonQuery();
        //                    }
        //                    co.Close();

        //                    //reader = command.ExecuteReader();
        //                }
        //                reader.Close();

        //                USERID = Convert.ToInt32(Request.QueryString["USERID"]);
        //                course = subject.Value;


        //                //Response.Redirect("grade.aspx?userID=" + USERID + "&course=" + course);
        //            }
        //        }
        //    }
        //}
    }
