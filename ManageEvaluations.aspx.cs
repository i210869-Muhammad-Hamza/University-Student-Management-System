using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Data.SqlClient;
using static System.Collections.Specialized.BitVector32;
using System.Collections;
using System.Security.Cryptography;
using System.IO;


   public partial class ManageEvaluations : System.Web.UI.Page
    {
    public static void AppendToTextFile(string text)
    {
        string filePath = "C:\\Users\\hp\\OneDrive\\Desktop\\db project\\db project\\Audit.txt";

        using (StreamWriter writer = File.AppendText(filePath))
        {
            writer.WriteLine(text);
        }
    }
    //void create_dictionary(ref List<string> cid, ref List<string> sid, ref Dictionary<string, string> dict)
    //{
    //    string connectionString = "Data Source=DESKTOP-VOMCOEB;Initial Catalog=Flex;Integrated Security=True";
    //    string query = " select * from Section";
    //    using (SqlConnection connection = new SqlConnection(connectionString))
    //    {
    //        connection.Open();  
    //        using (SqlCommand command = new SqlCommand(query, connection))
    //        {
    //            using (SqlDataReader reader = command.ExecuteReader())
    //            {
    //                while (reader.Read())
    //                {
    //                    cid.Add(reader["courseid"].ToString());
    //                    sid.Add(reader["sectionname"].ToString());
    //                }

    //            }

    //        }
    //    }

        
    //    for (int i = 0; i < cid.Count; i++)
    //    {
    //        dict.Add(cid[i], sid[i]);
    //    }
    //}

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
            string query = "SELECT course.Cname FROM course INNER JOIN Section ON course.course_ID = Section.CourseID WHERE Section.FacultyID = @X";

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

            string y = null;

            string qu = "SELECT Section.SectionName FROM course INNER JOIN Section ON course.course_ID = Section.CourseID WHERE Section.FacultyID = @X";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(qu, connection))
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
                    Section.Items.Add(item);
                }

                // Close the reader and connection
                reader.Close();
                connection.Close();
            }



            // string connectionString = "Data Source=DESKTOP-MA76B76\\SQLEXPRESS;Initial Catalog=try2;Integrated Security=True";
            string que = "SELECT evaluation FROM evaluations";
            // Create a new SQL connection and command
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(que, connection))
            {
                // Open the SQL connection and execute the command
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                // Loop through the results and add each course name as an option in the select element
                while (reader.Read())
                {
                    string evaluation = reader.GetString(0);
                    ListItem item = new ListItem(evaluation, evaluation);
                    Evaluation.Items.Add(item);
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
            Response.Redirect("faculty.aspx?userID=" + USERID);

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

         AppendToTextFile("TEACHER MARKED ATTENDANCE ;");
         USERID = Convert.ToInt32(Request.QueryString["USERID"]);
            course = subject.Value;
            string evaluation = Evaluation.Value;
            Response.Redirect("evaluation.aspx?userID=" + USERID + "&course=" + course + "&evaluation=" + evaluation);
        }

    }
