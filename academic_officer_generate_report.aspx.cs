using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
//using Microsoft.Reporting.WebForms;
using System.Web.Configuration;
using System.IO;

public partial class academic_officer_generate_report : System.Web.UI.Page
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
    protected void home_button(object sender, EventArgs e)
    {
         USERID = Convert.ToInt32(Request.QueryString["USERID"]);
        Response.Redirect("Academic_officer_home.aspx?userID=" + USERID);
    }
    protected void offer_course_button(object sender, EventArgs e)
    {
        USERID = Convert.ToInt32(Request.QueryString["USERID"]);
        Response.Redirect("Academic_officer_offer_course.aspx?userID=" + USERID);
    }
    protected void create_section_button(object sender, EventArgs e)
    {
        USERID = Convert.ToInt32(Request.QueryString["USERID"]);
        Response.Redirect("Academic_officer_create_section.aspx?userID=" + USERID);
    }
    protected void assign_teacher_button(object sender, EventArgs e)
    {
        USERID = Convert.ToInt32(Request.QueryString["USERID"]);
        Response.Redirect("Academic_officer_assign_course.aspx?userID=" + USERID);
    }
    protected void generate_report_button(object sender, EventArgs e)
    {
        USERID = Convert.ToInt32(Request.QueryString["USERID"]);
        Response.Redirect("Academic_officer_generate_report.aspx?userID=" + USERID);
    }
    protected void  Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
        }
    }
    
    protected void offer_course(object sender , EventArgs e)
    {
        string connectionString = "Data Source=DESKTOP-VOMCOEB;Initial Catalog=Flex;Integrated Security=True";

        // SQL query to retrieve data
        string query = "SELECT courseid,course.cname,credits FROM offered_course,course where courseid=course_id";

        // Create a SqlConnection object and open the connection
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Create a SqlCommand object with the query and the connection
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Execute the query and obtain a SqlDataReader
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Generate the HTML table dynamically
                    string table = "";
                    table += "<tr>\r\n        <th>Course ID</th>\r\n        <th>Course Names</th>\r\n        <th>Credit Hours</th>\r\n    </tr>";
                    while (reader.Read())
                    {
                        table += "<tr>";
                        table += "<td>" + reader["courseid"] + "</td>";
                        table += "<td>" + reader["cname"] + "</td>";
                        table += "<td>" + reader["credits"] + "</td>";
                        table += "</tr>";
                    }

                    // Assign the generated table HTML to the Literal control
                    reportTable.Text = table;
                }
            }
        }
        AppendToTextFile(" ADMIN  CREATED OFFER COURSES REPORT  SUCESSFULLY;");

    }
    protected void section(object sender, EventArgs e)
    {
        string connectionString = "Data Source=DESKTOP-VOMCOEB;Initial Catalog=Flex;Integrated Security=True";

        // SQL query to retrieve data
        string query = "SELECT cname,s.sectionname,Studentid FROM section s,course,registered_courses where s.courseid=course.course_id and registered_courses.courseid=s.courseid";

        // Create a SqlConnection object and open the connection
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Create a SqlCommand object with the query and the connection
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Execute the query and obtain a SqlDataReader
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Generate the HTML table dynamically
                    string table = "";
                    table += "<tr>\r\n        <th>Course Name</th>\r\n        <th>Section ID</th>\r\n        <th>Student ID</th>\r\n    </tr>";
                    while (reader.Read())
                    {
                        table += "<tr>";
                        table += "<td>" + reader["cname"] + "</td>";
                        table += "<td>" + reader["sectionname"] + "</td>";
                        table += "<td>" + reader["Studentid"] + "</td>";
                        table += "</tr>";
                    }

                    // Assign the generated table HTML to the Literal control
                    reportTable.Text = table;
                }
            }
        }
        AppendToTextFile(" ADMIN  CREATED SECTIONS REPORT  SUCESSFULLY;");


    }
    protected void allocation(object sender, EventArgs e)
    {
        string connectionString = "Data Source=DESKTOP-VOMCOEB;Initial Catalog=Flex;Integrated Security=True";

        // SQL query to retrieve data
        string query = "SELECT courseid,cname,credits,sectionname,section.facultyID,username FROM section,course,faculty,user_ where section.courseid=course.course_id and section.facultyid=faculty.facultyid and faculty.userid=user_.userid";

        // Create a SqlConnection object and open the connection
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Create a SqlCommand object with the query and the connection
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Execute the query and obtain a SqlDataReader
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Generate the HTML table dynamically
                    string table = "";
                    table += "<tr>\r\n        <th>Course Code</th>\r\n <th>Course</th>\r\n   <th>Credits</th>\r\n        <th>Section</th>\r\n  <th>Instructor</th>\r\n  <th>Course Coordinator</th>\r\n </tr>";
                    while (reader.Read())
                    {
                        table += "<tr>";
                        table += "<td>" + reader["courseid"] + "</td>";
                        table += "<td>" + reader["Cname"] + "</td>";
                        table += "<td>" + reader["Credits"] + "</td>";
                        table += "<td>" + reader["sectionname"] + "</td>";
                        table += "<td>" + reader["username"] + "</td>";
                        table += "<td>" + reader["username"] + "</td>";
                        //table += "<td>" + reader["sid"] + "</td>";
                        table += "</tr>";
                    }

                    // Assign the generated table HTML to the Literal control
                    reportTable.Text = table;
                }
            }
        }
        AppendToTextFile(" ADMIN  COURSE ALLOCATION REPORT  SUCESSFULLY;");

    }

}