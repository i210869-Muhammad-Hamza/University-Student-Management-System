using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class EvaluationReport : System.Web.UI.Page
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

        string connectionString = "Data Source=DESKTOP-VOMCOEB;Initial Catalog=Flex;Integrated Security=True"; // replace with your actual connection string
        string selectCommand = "SELECT s.ROLLNO, u.NAME,COALESCE(f.obtained_marks, 0) as F,COALESCE(s1.obtained_marks, 0) as S1,COALESCE(s2.obtained_marks, 0) as S2, COALESCE(a.obtained_marks, 0) as A, COALESCE(q.obtained_marks, 0) as Q, (COALESCE(f.obtained_marks, 0) + COALESCE(s1.obtained_marks, 0) + COALESCE(s2.obtained_marks, 0) + COALESCE(a.obtained_marks, 0) + COALESCE(q.obtained_marks, 0)) as T FROM Student s JOIN User_ u ON u.USERID = s.USERID LEFT JOIN FINALEXAM f ON s.ROLLNO = f.studentid LEFT JOIN SESSIONAL1 s1 ON s.ROLLNO = s1.studentid AND f.courseid = s1.courseid LEFT JOIN SESSIONAL2 s2 ON s.ROLLNO = s2.studentid AND f.courseid = s2.courseid LEFT JOIN ASSIGNMENTS a ON s.ROLLNO = a.studentid AND f.courseid = a.courseid LEFT JOIN QUIZZES q ON s.ROLLNO = q.studentid AND f.courseid = q.courseid"; // your SQL query here

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(selectCommand, connection))
            {
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

    }
    int USERID;
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
    protected void btnRegister_Click(object sender, EventArgs e)
    {

    }

}