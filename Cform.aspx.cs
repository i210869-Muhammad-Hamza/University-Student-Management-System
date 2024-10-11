using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cform : System.Web.UI.Page
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

        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        USERID = Convert.ToInt32(Request.QueryString["USERID"]);
        string date, teacherName, subject, schedule, roomNumber, schoolYear, comments;
        int attends, enthusiasm, initiative, articulated, speaks, professionalism, commitment, encourages, criticisms, ontime, ontime_end, knowledge, organization, dynamism, critical, classenvironment, belief, respect, strengths, understands;

        date = Request.Form["date"];
        teacherName = Request.Form["teacher-name"];
        subject = Request.Form["subject"];
        schedule = Request.Form["schedule"];
        roomNumber = Request.Form["room-number"];
        schoolYear = Request.Form["school-year"];
        attends = int.Parse(Request.Form["attends"]);
        enthusiasm = int.Parse(Request.Form["enthusiasm"]);
        initiative = int.Parse(Request.Form["initiative"]);
        articulated = int.Parse(Request.Form["articulated"]);
        speaks = int.Parse(Request.Form["speaks"]);
        professionalism = int.Parse(Request.Form["professionalism"]);
        commitment = int.Parse(Request.Form["commitment"]);
        encourages = int.Parse(Request.Form["encourages"]);
        criticisms = int.Parse(Request.Form["criticisms"]);
        ontime = int.Parse(Request.Form["ontime"]);
        ontime_end = int.Parse(Request.Form["ontime-end"]);
        knowledge = int.Parse(Request.Form["knowledge"]);
        organization = int.Parse(Request.Form["organization"]);
        dynamism = int.Parse(Request.Form["dynamism"]);
        critical = int.Parse(Request.Form["critical-thinking"]);
        classenvironment = int.Parse(Request.Form["class-environment"]);
        belief = int.Parse(Request.Form["belief"]);
        respect = int.Parse(Request.Form["respect"]);
        strengths = int.Parse(Request.Form["strengths"]);
        understands = int.Parse(Request.Form["understands"]);
        comments = Request.Form["Comments"];

        string connectionString = "Data Source=DESKTOP-VOMCOEB;Initial Catalog=Flex;Integrated Security=True";



        // Retrieve the student ID based on the user ID
        string queryStudentId = "SELECT ROLLNO FROM Student WHERE USERID = @USERID";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand commandStudentId = new SqlCommand(queryStudentId, connection))
            {
                commandStudentId.Parameters.AddWithValue("@USERID", USERID);
                string studentId = (string)commandStudentId.ExecuteScalar();

                string queryFeedbackCount = "SELECT COUNT(*) FROM FEEDBACK WHERE rollno = @ROLLNO";
                using (SqlCommand commandFeedbackCount = new SqlCommand(queryFeedbackCount, connection))
                {
                    commandFeedbackCount.Parameters.AddWithValue("@ROLLNO", studentId);
                    int feedbackCount = (int)commandFeedbackCount.ExecuteScalar();

                    if (feedbackCount >= 5)
                    {

                        // The user has already submitted 5 feedbacks, display an error message
                        //Console.WriteLine("You have already submitted 5 feedbacks. You cannot submit any more feedbacks.");
                        string script = "alert('You cannot submit any more Feedbacks!');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", script, true);
                        //ClearForm();
                    }
                    else
                    {
                        // Auto-incrementing Feedback ID
                        int feedbackId;
                        SqlCommand cmd = new SqlCommand("SELECT TOP(1) feedbackid FROM FEEDBACK ORDER BY feedbackid DESC", connection);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            reader.Read();
                            feedbackId = Convert.ToInt32(reader["feedbackid"]) + 1;
                        }
                        else
                        {
                            feedbackId = 1;
                        }
                        reader.Close();
                        cmd.Dispose();



                        // SQL query to insert data into the Feedback table
                        string query = "INSERT INTO Feedback (feedbackid, rollno, Date, TeacherName, Subject, Schedule, RoomNumber, SchoolYear, attends, enthusiasm, initiative, articulated, speaks, professionalism, commitment, encourages, criticisms, ontime, ontime_end, knowledge, organization, dynamism, critical, classenvironment, belief, respect, strengths, understands, comments) VALUES (@feedbackid, @rollno, @Date, @TeacherName, @Subject, @Schedule, @RoomNumber, @SchoolYear, @attends, @enthusiasm, @initiative, @articulated, @speaks, @professionalism, @commitment, @encourages, @criticisms, @ontime, @ontime_end, @knowledge, @organization, @dynamism, @critical, @classenvironment, @belief, @respect, @strengths, @understands, @comments)";

                        // create a new SqlCommand using the query and the SqlConnection
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            // add parameters to the SqlCommand
                            command.Parameters.AddWithValue("@feedbackid", feedbackId);
                            command.Parameters.AddWithValue("@rollno", studentId);
                            command.Parameters.AddWithValue("@Date", date);
                            command.Parameters.AddWithValue("@TeacherName", teacherName);
                            command.Parameters.AddWithValue("@Subject", subject);
                            command.Parameters.AddWithValue("@Schedule", schedule);
                            command.Parameters.AddWithValue("@RoomNumber", roomNumber);
                            command.Parameters.AddWithValue("@SchoolYear", schoolYear);
                            command.Parameters.AddWithValue("@attends", attends);
                            command.Parameters.AddWithValue("@enthusiasm", enthusiasm);
                            command.Parameters.AddWithValue("@initiative", initiative);
                            command.Parameters.AddWithValue("@articulated", articulated);
                            command.Parameters.AddWithValue("@speaks", speaks);
                            command.Parameters.AddWithValue("@professionalism", professionalism);
                            command.Parameters.AddWithValue("@commitment", commitment);
                            command.Parameters.AddWithValue("@encourages", encourages);
                            command.Parameters.AddWithValue("@criticisms", criticisms);
                            command.Parameters.AddWithValue("@ontime", ontime);
                            command.Parameters.AddWithValue("@ontime_end", ontime_end);
                            command.Parameters.AddWithValue("@knowledge", knowledge);
                            command.Parameters.AddWithValue("@organization", organization);
                            command.Parameters.AddWithValue("@dynamism", dynamism);
                            command.Parameters.AddWithValue("@critical", critical);
                            command.Parameters.AddWithValue("@classenvironment", classenvironment);
                            command.Parameters.AddWithValue("@belief", belief);
                            command.Parameters.AddWithValue("@respect", respect);
                            command.Parameters.AddWithValue("@strengths", strengths);
                            command.Parameters.AddWithValue("@understands", understands);
                            command.Parameters.AddWithValue("@comments", comments);

                            command.ExecuteNonQuery();
                        }

                    }
                }
            }
        }
        AppendToTextFile("STUDENT SUBMITTED FEEDBACK SUCESSFULLY;");
    }
}