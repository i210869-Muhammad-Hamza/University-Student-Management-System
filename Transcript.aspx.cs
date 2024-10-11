using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Transcript : System.Web.UI.Page
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
            string selectCommand = "SELECT rc.courseID, c.Cname, g.grade FROM registered_Courses rc JOIN Student s ON rc.Studentid = s.ROLLNO JOIN course c ON rc.courseID = c.course_ID LEFT JOIN Grade g ON rc.courseID = g.courseid AND rc.Studentid = g.studentid WHERE s.USERID =  @USERID";

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

                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
        }
    }
}
