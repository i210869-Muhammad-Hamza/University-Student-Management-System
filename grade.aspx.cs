using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

    public partial class grade : System.Web.UI.Page
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
            string course = Request.QueryString["course"];
            Console.WriteLine(course);
            string connectionString = "Data Source=DESKTOP-VOMCOEB;Initial Catalog=Flex;Integrated Security=True"; // replace with your actual connection string
            string selectCommand = "select u.NAME, s.ROLLNO , Grade.grade from User_ u join Student s on s.USERID= u.USERID join registered_Courses r on r.Studentid = s.ROLLNO join course c on r.courseID = c.course_ID join Grade on s.ROLLNO=Grade.studentid where Cname= @course"; // your SQL query here

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(selectCommand, connection))
                {
                    command.Parameters.AddWithValue("@course", course);
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
