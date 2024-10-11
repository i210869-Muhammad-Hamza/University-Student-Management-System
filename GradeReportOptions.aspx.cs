using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class GradeReportOptions : System.Web.UI.Page
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
        Response.Redirect("Home.aspx?userID=" + USERID);

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

        USERID = Convert.ToInt32(Request.QueryString["USERID"]);
        course = subject.Value;
        Response.Redirect("GradeReport.aspx?userID=" + USERID + "&course=" + course);
    }

    protected void Button8_Click(object sender, EventArgs e)
    {
        AppendToTextFile("TEACHER VIEWED COUNT OF GRADE SUCCESSFULLY ;");
        USERID = Convert.ToInt32(Request.QueryString["USERID"]);
        course = subject.Value;
        Response.Redirect("CountGradeReport.aspx?userID=" + USERID + "&course=" + course);
    }

}
