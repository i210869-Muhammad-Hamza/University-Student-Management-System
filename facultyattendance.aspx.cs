using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class facultyattendance : System.Web.UI.Page
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
        string selectCommand = "select u.NAME, s.ROLLNO from User_ u join Student s on s.USERID= u.USERID join registered_Courses r on r.Studentid = s.ROLLNO join course c on r.courseID = c.course_ID where Cname= @course "; // your SQL query here

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
        USERID = Convert.ToInt32(Request.QueryString["USERID"]);
        DateTime selectedDate = DateTime.Parse(Request.Form["date"] ?? DateTime.Today.ToString());

        //DateTime selectedDate = DateTime.Parse(Request.Form["date"]);
        string Cname = Request.QueryString["course"];

        string connectionString = "Data Source=DESKTOP-VOMCOEB;Initial Catalog=Flex;Integrated Security=True";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {

            connection.Open();
            foreach (GridViewRow row in GridView1.Rows)
            {
                RadioButtonList rbl = (RadioButtonList)row.FindControl("RadioButtonList1");
                //TextBox txtObtainedMarks = (TextBox)row.FindControl("TextBox1");
                //string register = txtObtainedMarks.Text.Trim();
                string studentID = row.Cells[1].Text;
                string register = rbl.SelectedValue;
                string courseID = null;
                SqlCommand command = new SqlCommand("SELECT course_ID FROM course WHERE Cname =@Cname", connection);
                command.Parameters.AddWithValue("@Cname", Cname);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    courseID = reader["course_ID"].ToString();
                }

                reader.Close();
                //if (string.IsNullOrEmpty(register)) // if register is empty
                //{
                //    register = "P"; // give register the value 'P'
                //}
                if (string.IsNullOrEmpty(register)) // if register is empty
                {
                    register = (new Random().Next(0, 2) == 0) ? "P" : "A";
                }
                //if (studentID != null)
                // {
                SqlCommand insertCommand = new SqlCommand("INSERT INTO attendance (date_, studentid, courseid, status) VALUES (@selectedDate, @studentID, @courseID, @register)", connection);
                insertCommand.Parameters.AddWithValue("@selectedDate", selectedDate);
                insertCommand.Parameters.AddWithValue("@studentID", studentID);
                insertCommand.Parameters.AddWithValue("@courseID", courseID);
                insertCommand.Parameters.AddWithValue("@register", register);
                insertCommand.ExecuteNonQuery();
                // }
            }
        }

        // Hide the button and the grid
        // btnRegister.Visible = false;
        GridView1.Visible = false;
        btnRegister.Visible = false;
        // Show a success message
        lblMessage.Text = "Attendance Marked!";
        lblMessage.Visible = true;
        AppendToTextFile("TEACHER MARKED ATTENDANCE SUCCESSFULLY ;");
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int count = 0;

        foreach (GridViewRow row in GridView1.Rows)
        {
            RadioButtonList rbl = row.FindControl("RadioButtonList1") as RadioButtonList;

            if (rbl != null && rbl.SelectedValue == "Yes")
            {
                count++;
            }
        }

        foreach (GridViewRow row in GridView1.Rows)
        {
            RadioButtonList rbl = row.FindControl("RadioButtonList1") as RadioButtonList;

            if (count == 5 && rbl != null && rbl.SelectedValue != "Yes")
            {
                rbl.Enabled = false;
            }
            else
            {
                rbl.Enabled = true;
            }
        }

    }

}
