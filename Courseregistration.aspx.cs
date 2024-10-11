using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.IO;

public partial class Courseregistration : System.Web.UI.Page
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

    protected void name_load(object sender, EventArgs e) 
    
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["USERID"]))
            {
                USERID = Convert.ToInt32(Request.QueryString["USERID"]);
                SqlDataReader dr;
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-VOMCOEB;Initial Catalog=Flex;Integrated Security=True");
                conn.Open();
                SqlCommand cm;
                string query = "SELECT NAME FROM User_ WHERE USERID = @userId";
                cm = new SqlCommand(query, conn);
                cm.Parameters.AddWithValue("@userId", USERID);
                dr = cm.ExecuteReader();
                dr.Read();
                user.Text = dr["NAME"].ToString();
                  dr.Close();
                conn.Close();
            }
        }
            }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string connectionString = "Data Source=DESKTOP-VOMCOEB;Initial Catalog=Flex;Integrated Security=True"; // replace
            if (!string.IsNullOrEmpty(Request.QueryString["USERID"]))
            {
                int userId = Convert.ToInt32(Request.QueryString["USERID"]);

                // Retrieve the name from the database using the USERID
                ;
                string selectCommand = "SELECT NAME FROM User_ WHERE USERID = @userId";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(selectCommand, connection))
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
            
            string selectCommand2 = "SELECT courseid,cname FROM offered_course"; // your SQL query here

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(selectCommand2, connection))
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


    private bool CheckPrerequisite(string courseID, string studentID)
    {
        string connectionString = "Data Source=DESKTOP-VOMCOEB;Initial Catalog=Flex;Integrated Security=True";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Check if the course has a prerequisite
            SqlCommand commandPrerequisite = new SqlCommand("SELECT Pre_Req FROM course WHERE course_ID = @courseID", connection);
            commandPrerequisite.Parameters.AddWithValue("@courseID", courseID);
            object preReqResult = commandPrerequisite.ExecuteScalar();

            if (preReqResult == DBNull.Value)
            {
                // If the course doesn't have a prerequisite, return true
                return true;
            }
            else
            {
                // Get the prerequisite course ID
                string prerequisiteID = (string)preReqResult;

                // Check if the student has passed the prerequisite course
                SqlCommand commandGrade = new SqlCommand("SELECT grade FROM Transcript WHERE studentid = @studentID AND courseid = @prerequisiteID", connection);
                commandGrade.Parameters.AddWithValue("@studentID", studentID);
                commandGrade.Parameters.AddWithValue("@prerequisiteID", prerequisiteID);
                object gradeResult = commandGrade.ExecuteScalar();

                if (gradeResult == null)
                {
                    // If there is no record of the student taking the prerequisite course, return true
                    return true;
                }
                else
                {
                    string grade = (string)gradeResult;
                    return grade != "F"; // Return false if the grade is F, true otherwise
                }
            }
        }
    }


    protected void btnRegister_Click(object sender, EventArgs e)
    {
        int userID = Convert.ToInt32(Request.QueryString["USERID"]);

        string connectionString = "Data Source=DESKTOP-VOMCOEB;Initial Catalog=Flex;Integrated Security=True";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            foreach (GridViewRow row in GridView1.Rows)
            {
                RadioButtonList rbl = (RadioButtonList)row.FindControl("RadioButtonList1");
                string courseID = row.Cells[0].Text;
                string register = rbl.SelectedValue;

                if (register == "Yes")
                {
                    // Check the number of registered courses for the current student
                    SqlCommand commandFeedbackCount = new SqlCommand("SELECT COUNT(*) FROM registered_Courses WHERE Studentid = @studentID", connection);
                    SqlCommand commandStudentID = new SqlCommand("SELECT ROLLNO FROM Student WHERE USERID = @userID", connection);
                    commandStudentID.Parameters.AddWithValue("@userID", 51);
                    string studentID = (string)commandStudentID.ExecuteScalar();
                    commandFeedbackCount.Parameters.AddWithValue("@studentID", studentID);
                    int registeredCount = (int)commandFeedbackCount.ExecuteScalar();

                    // If the student has already registered 5 courses, display an alert message
                    if (registeredCount >= 5)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Sorry, you have already registered 5 courses. You cannot register again');", true);
                        return;
                    }

                    // check the pre-requisite of the course
                    if (!CheckPrerequisite(courseID, studentID))
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Sorry, you have not passed the prerequisite course. You cannot register for this course" + courseID + "');", true);
                        return;
                    }

                    // check whether the course has already been registered for the current student
                    SqlCommand commandRegisteredCount = new SqlCommand("SELECT COUNT(*) FROM registered_Courses WHERE Studentid = @studentID AND courseID = @courseID", connection);
                    commandRegisteredCount.Parameters.AddWithValue("@studentID", studentID);
                    commandRegisteredCount.Parameters.AddWithValue("@courseID", courseID);
                    int alreadyRegisteredCount = (int)commandRegisteredCount.ExecuteScalar();

                    if (alreadyRegisteredCount > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You have already registered for course " + courseID + "');", true);
                        return;

                    }

                    // register the course
                    SqlCommand insertCommand = new SqlCommand("INSERT INTO registered_Courses (courseID, Studentid, RegisterCourse) VALUES (@courseID, @studentID, @register)", connection);
                    insertCommand.Parameters.AddWithValue("@courseID", courseID);
                    insertCommand.Parameters.AddWithValue("@studentID", studentID);
                    insertCommand.Parameters.AddWithValue("@register", register);
                    insertCommand.ExecuteNonQuery();
                }
            }

            // Hide the button and the grid
            btnRegister.Visible = false;
            GridView1.Visible = false;

            // Show a success message
            lblMessage.Text = "You have successfully registered!";
            lblMessage.Visible = true;
        }
        AppendToTextFile("STUDENT REGISTERD COURSE SUCCESSFULLY ;");
    }


}