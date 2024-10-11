using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Activities.Expressions;
using System.Activities.Statements;
using System.Text.RegularExpressions;
using System.IO;

public partial class Marks : System.Web.UI.Page
{

    private int USERID;
    public static void AppendToTextFile(string text)
    {
        string filePath = "C:\\Users\\hp\\OneDrive\\Desktop\\db project\\db project\\Audit.txt";

        using (StreamWriter writer = File.AppendText(filePath))
        {
            writer.WriteLine(text);
        }
    }
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

            string selectAssignmentsCommand = "SELECT d.AssignmentWeightage, a.obtained_marks, AVG(a.obtained_marks) AS avg_marks FROM ASSIGNMENTS a JOIN DISTRIBUTION d ON a.courseid = d.CourseID JOIN student s ON a.studentid = s.ROLLNO WHERE s.USERID = @USERID GROUP BY d.AssignmentWeightage, a.obtained_marks";
           
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(selectAssignmentsCommand, connection))
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
            string selectQuizCommand = "SELECT d.QuizWeightage, a.obtained_marks FROM QUIZZES a JOIN DISTRIBUTION d ON a.courseid = d.CourseID JOIN student s ON a.studentid = s.ROLLNO WHERE s.USERID = @USERID GROUP BY d.QuizWeightage, a.obtained_marks";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(selectQuizCommand, connection))
                {
                    command.Parameters.AddWithValue("@userID", USERID);
                    connection.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable d = new DataTable();
                        adapter.Fill(d);

                        GridView2.DataSource = d;
                        GridView2.DataBind();
                    }
                }
            }
            GridView2.Visible = false;
            string selects1Command = "SELECT d.Sessional1Weightage, a.obtained_marks FROM SESSIONAL1 a JOIN DISTRIBUTION d ON a.courseid = d.CourseID JOIN student s ON a.studentid = s.ROLLNO WHERE s.USERID = @USERID GROUP BY d.Sessional1Weightage, a.obtained_marks";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(selects1Command, connection))
                {
                    command.Parameters.AddWithValue("@userID", USERID);
                    connection.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable d = new DataTable();
                        adapter.Fill(d);

                        GridView3.DataSource = d;
                        GridView3.DataBind();
                    }
                }
            }
            GridView3.Visible = false;
            string selects2Command = "SELECT d.Sessional2Weightage, a.obtained_marks FROM SESSIONAL2 a JOIN DISTRIBUTION d ON a.courseid = d.CourseID JOIN student s ON a.studentid = s.ROLLNO WHERE s.USERID = @USERID GROUP BY d.Sessional2Weightage, a.obtained_marks";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(selects2Command, connection))
                {
                    command.Parameters.AddWithValue("@userID", USERID);
                    connection.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable d = new DataTable();
                        adapter.Fill(d);

                        GridView4.DataSource = d;
                        GridView4.DataBind();
                    }
                }
            }
            GridView4.Visible = false;

            string selectfinalCommand = "SELECT d.FinalExamWeightage, a.obtained_marks FROM FINALEXAM a JOIN DISTRIBUTION d ON a.courseid = d.CourseID JOIN student s ON a.studentid = s.ROLLNO WHERE s.USERID = @USERID GROUP BY d.FinalExamWeightage, a.obtained_marks";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(selectfinalCommand, connection))
                {
                    command.Parameters.AddWithValue("@userID", USERID);
                    connection.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable d = new DataTable();
                        adapter.Fill(d);

                        GridView5.DataSource = d;
                        GridView5.DataBind();
                    }
                }
            }
            GridView5.Visible = false;
        }
    }

    protected void btnFetchmarks_Click(object sender, EventArgs e)

    {
        USERID = Convert.ToInt32(Request.QueryString["USERID"]);
      
        BindGridViews();
        GridView1.Visible = true;
        GridView2.Visible = true;
        GridView3.Visible = true;
        GridView4.Visible = true;
        GridView5.Visible = true;
        AppendToTextFile("STUDENT VIEWED MARKED SUCCESSFULLY;");
    }
  protected void BindGridViews()
        {
            USERID = Convert.ToInt32(Request.QueryString["USERID"]);
        string connectionString = "Data Source=DESKTOP-VOMCOEB;Initial Catalog=Flex;Integrated Security=True"; // replace with your actual connection string
        string courseId = ddlCourse.SelectedValue;

        string selectAssignmentsCommand = "SELECT d.AssignmentWeightage, a.obtained_marks, AVG(a.obtained_marks) AS avg_marks FROM ASSIGNMENTS a JOIN DISTRIBUTION d ON a.courseid = d.CourseID JOIN student s ON a.studentid = s.ROLLNO WHERE s.USERID = @USERID AND a.courseid = @COURSEID GROUP BY d.AssignmentWeightage, a.obtained_marks";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(selectAssignmentsCommand, connection))
            {
                command.Parameters.AddWithValue("@USERID", USERID);
                command.Parameters.AddWithValue("@COURSEID", courseId);
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

        string selectQuizCommand = "SELECT d.QuizWeightage, a.obtained_marks FROM QUIZZES a JOIN DISTRIBUTION d ON a.courseid = d.CourseID JOIN student s ON a.studentid = s.ROLLNO WHERE s.USERID = @USERID AND a.courseid = @COURSEID GROUP BY d.QuizWeightage, a.obtained_marks";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(selectQuizCommand, connection))
            {
                command.Parameters.AddWithValue("@USERID", USERID);
                command.Parameters.AddWithValue("@COURSEID", courseId);
                connection.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable d = new DataTable();
                    adapter.Fill(d);

                    GridView2.DataSource = d;
                    GridView2.DataBind();
                }
            }
        }

        string selects1Command = "SELECT d.Sessional1Weightage, a.obtained_marks FROM SESSIONAL1 a JOIN DISTRIBUTION d ON a.courseid = d.CourseID JOIN student s ON a.studentid = s.ROLLNO WHERE s.USERID = @USERID AND a.courseid = @COURSEID GROUP BY d.Sessional1Weightage, a.obtained_marks";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(selects1Command, connection))
            {
                command.Parameters.AddWithValue("@USERID", USERID);
                command.Parameters.AddWithValue("@COURSEID", courseId);
                connection.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable d = new DataTable();
                    adapter.Fill(d);

                    GridView3.DataSource = d;
                    GridView3.DataBind();
                }
            }
        }

        string selects2Command = "SELECT d.Sessional2Weightage, a.obtained_marks FROM SESSIONAL2 a JOIN DISTRIBUTION d ON a.courseid = d.CourseID JOIN student s ON a.studentid = s.ROLLNO WHERE s.USERID = @USERID AND a.courseid = @COURSEID GROUP BY d.Sessional2Weightage, a.obtained_marks";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(selects2Command, connection))
            {
                command.Parameters.AddWithValue("@USERID", USERID);
                command.Parameters.AddWithValue("@COURSEID", courseId);
                connection.Open();
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable d = new DataTable();
                    adapter.Fill(d);

                    GridView4.DataSource = d;
                    GridView4.DataBind();
                }
            }
        }
        string selectfinalCommand = "SELECT d.FinalExamWeightage, a.obtained_marks FROM FINALEXAM a JOIN DISTRIBUTION d ON a.courseid = d.CourseID JOIN student s ON a.studentid = s.ROLLNO WHERE s.USERID = @USERID AND a.courseid = @COURSEID GROUP BY d.FinalExamWeightage, a.obtained_marks";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(selectfinalCommand, connection))
            {
                command.Parameters.AddWithValue("@USERID", USERID);
                command.Parameters.AddWithValue("@COURSEID", courseId);
                connection.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable d = new DataTable();
                    adapter.Fill(d);

                    GridView5.DataSource = d;
                    GridView5.DataBind();
                }
            }
        }


    }
}