using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Data;
using System.IO;

public partial class Attendance : System.Web.UI.Page
{
    public static void AppendToTextFile(string text)
    {
        string filePath = "C:\\Users\\hp\\OneDrive\\Desktop\\db project\\db project\\Audit.txt";

        using (StreamWriter writer = File.AppendText(filePath))
        {
            writer.WriteLine(text);
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
        Response.Redirect("Courseregistration.aspx?userID=" + USERID);

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        USERID = Convert.ToInt32(Request.QueryString["USERID"]);
        Response.Redirect("Attendance.aspx?userID=" + USERID);
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        USERID = Convert.ToInt32(Request.QueryString["USERID"]);
        Response.Redirect("Marks.aspx?userID=" + USERID);
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        USERID = Convert.ToInt32(Request.QueryString["USERID"]);
        Response.Redirect("Transcript.aspx?userID=" + USERID);
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        USERID = Convert.ToInt32(Request.QueryString["USERID"]);
        Response.Redirect("Cform.aspx?userID=" + USERID);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        USERID = Convert.ToInt32(Request.QueryString["USERID"]);
        if (!IsPostBack)
        {
            string connectionString = "Data Source=DESKTOP-VOMCOEB;Initial Catalog=Flex;Integrated Security=True";
            if (!string.IsNullOrEmpty(Request.QueryString["USERID"]))
            {
                int userId = Convert.ToInt32(Request.QueryString["USERID"]);

                // Retrieve the name from the database using the USERID
                ;
                string selectCommand0 = "SELECT NAME FROM User_ WHERE USERID = @userId";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(selectCommand0, connection))
                    {
                        command.Parameters.AddWithValue("@userId", userId);

                        connection.Open();

                        string name = command.ExecuteScalar()?.ToString();

                        if (!string.IsNullOrEmpty(name))
                        {
                            user.Text = name;
                        }
                    }
                }
            }

            string selectCommand = "SELECT courseID FROM registered_Courses r join Student s on r.Studentid=s.ROLLNO WHERE s.USERID = @USERID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(selectCommand, connection))
                {
                    command.Parameters.AddWithValue("@USERID", USERID); // Add the parameter here
                    connection.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        ddlCourse.DataSource = dt;
                        ddlCourse.DataTextField = "courseID";
                        ddlCourse.DataValueField = "courseID";
                        ddlCourse.DataBind();
                    }
                }
            }

        

        // Fetch attendance data for the student
        string selectAttendanceCommand = "SELECT lecture_no, date_, status FROM attendance WHERE studentid = (SELECT ROLLNO FROM Student WHERE USERID =@USERID)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(selectAttendanceCommand, connection))
                {
                    command.Parameters.AddWithValue("@userID", USERID);
                    connection.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
            GridView1.Visible = false;
        }
    }

   protected void btnFetchAttendance_Click(object sender, EventArgs e)
{
        GridView1.Visible = true;
        string connectionString = "Data Source=DESKTOP-VOMCOEB;Initial Catalog=Flex;Integrated Security=True"; // replace with your actual connection string
    string courseId = ddlCourse.SelectedValue;
    string selectCommand = "SELECT lecture_no, date_, status FROM attendance WHERE courseid = @CourseId AND studentid = (SELECT ROLLNO FROM Student WHERE USERID =@USERID)"; // modified SQL query here

    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        using (SqlCommand command = new SqlCommand(selectCommand, connection))
        {
            command.Parameters.AddWithValue("@CourseId", courseId);
            command.Parameters.AddWithValue("@USERID", USERID);
            connection.Open();

            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
    }
        AppendToTextFile("STUDENT VIEWED ATTENDANCE ;");
    }




}