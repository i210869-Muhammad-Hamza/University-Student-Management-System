using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;

public partial class distribution : System.Web.UI.Page
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
            string query = "SELECT course.Cname FROM course INNER JOIN section s ON course.course_ID = s.CourseID WHERE s.FacultyID = @X";

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
    protected void submitForm(object sender, EventArgs e)
    {
        //string Cname = Request.Form["select"];
        //string courseID = "";
        //string queryString = "SELECT course_ID FROM course WHERE Cname = @Cname";
        //string connectionString = "Data Source=DESKTOP-MA76B76\\SQLEXPRESS;Initial Catalog=try2;Integrated Security=True";

        //using (SqlConnection connection = new SqlConnection(connectionString))
        //{
        //    SqlCommand command = new SqlCommand(queryString, connection);
        //    command.Parameters.AddWithValue("@Cname", Cname);

        //    try
        //    {
        //        connection.Open();
        //        courseID = (string)command.ExecuteScalar();
        //        Console.WriteLine("The student's cname is: " + courseID);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}

        // Get a reference to the dropdown list control
        string cname = subject.Value;


        string USERID = null;
        //string cname = Request.Form["select"];
        string q = "SELECT course_ID FROM course WHERE Cname = @cname";
        string connectionString = "Data Source=DESKTOP-VOMCOEB;Initial Catalog=Flex;Integrated Security=True";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(q, connection);
            command.Parameters.AddWithValue("@cname", cname);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            //string courseID = null; // declare courseID before the loop
            while (reader.Read())
            {
                USERID = reader.GetString(0);
            }
            reader.Close();
            // use courseID after the loop
            Console.WriteLine("The course ID for {0} is {1}", cname, USERID);
        }



        // Get the user inputs for marks
        int quizMarks = int.Parse(Request.Form["quiz"]);
        int sessional2Marks = 20;
        int sessional1Marks = 20;
        int assignmentMarks = int.Parse(Request.Form["assignment"]);
        //int sessional1Marks = int.Parse(Request.Form["sessional-1"]);
        //int sessional2Marks = int.Parse(Request.Form["sessional-2"]);
        int finalExamMarks = int.Parse(Request.Form["final-exam"]);


        // Define your SQL query to insert the marks into the Marks Distribution table
        string query = "INSERT INTO DISTRIBUTION (CourseID, QuizWeightage, AssignmentWeightage, Sessional1Weightage, Sessional2Weightage, FinalExamWeightage) " +
                   "VALUES (@USERID, @QuizMarks, @AssignmentMarks, @Sessional1Marks, @Sessional2Marks, @FinalExamMarks)";

        // Create a new SqlConnection object using the connection string
        using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-VOMCOEB;Initial Catalog=Flex;Integrated Security=True"))
        {
            connection.Open();
            // Create a new SqlCommand object with the query and connection
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Add the parameter values for the query
                command.Parameters.AddWithValue("@USERID", USERID);
                command.Parameters.AddWithValue("@QuizMarks", quizMarks);
                command.Parameters.AddWithValue("@AssignmentMarks", assignmentMarks);
                command.Parameters.AddWithValue("@Sessional1Marks", sessional1Marks);
                command.Parameters.AddWithValue("@Sessional2Marks", sessional2Marks);
                command.Parameters.AddWithValue("@FinalExamMarks", finalExamMarks);

                // Open the connection to the database
                //connection.Open();

                // Execute the query
                command.ExecuteNonQuery();

                // Close the connection
                connection.Close();
            }
        }
        AppendToTextFile("TEACHER ADDED MARKS DISTRIBUTION;");
    }
   

}