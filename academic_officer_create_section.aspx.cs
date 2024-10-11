using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


public partial class academic_officer_create_section : System.Web.UI.Page
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
        Response.Redirect("Academic_officer_home_generate_report.aspx?userID=" + USERID);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GenerateTable();
        }
    }

    protected void finalize_courses(object sender, EventArgs e)
    {
        List<string> cancelledcourse = new List<string>();
        // Connection string to your SQL database
        string connectionString = "Data Source=DESKTOP-VOMCOEB;Initial Catalog=Flex;Integrated Security=True";

        // SQL query to insert data into the database
        string query = "SELECT COURSEID FROM REGISTERED_COURSES GROUP BY COURSEID HAVING COUNT >10";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Create a SqlCommand object with the query and the connection
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Execute the query and obtain a SqlDataReader
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        while (reader.Read())
                        {
                            cancelledcourse.Add(reader["COURSEID"].ToString());
                        }
                    }
                    reader.Close();
                }

            }
        }

        for (int i = 0; i < cancelledcourse.Count; i++)
        {
            query = " delete from offered_courses where '" + cancelledcourse[i] + "' = courseid ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        reader.Close();
                    }

                }
            }

        }

        for (int i = 0; i < cancelledcourse.Count; i++)
        {
            query = " delete from registered_courses where '" + cancelledcourse[i] + "' = courseid ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        reader.Close();
                    }

                }
            }

        }
    }
    protected void GenerateTable()
    {
        // Connection string to your SQL database
        string connectionString = "Data Source=DESKTOP-VOMCOEB;Initial Catalog=Flex;Integrated Security=True";

        // SQL query to retrieve data
        string query = "SELECT * FROM offered_course";

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

                    while (reader.Read())
                    {
                        table += "<tr>";
                        table += "<td>" + reader["courseid"] + "</td>";
                        table += "<td>" + reader["cname"] + "</td>";
                        table += "<td><input type='text' name='inputBox' /></td>";
                        table += "</tr>";
                    }

                    // Assign the generated table HTML to the Literal control
                    tableData.Text = table;
                }
            }
        }

    }
    public List<string> ProcessCommaSeparatedString(string input)
    {
        List<string> stringVector = input.Split(',').ToList();
        return stringVector;
    }
    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        int count = 0;
       // finalize_courses(sender,  e);
        string inputBoxValue = Request.Form["inputBox"];
        List<string> sections = ProcessCommaSeparatedString(inputBoxValue);
        // Connection string to your SQL database
        string connectionString = "Data Source=DESKTOP-VOMCOEB;Initial Catalog=Flex;Integrated Security=True";

        // SQL query to insert data into the database
        string insertQuery = "INSERT INTO section VALUES (@sectionname, '', @courseid)";

        // Retrieve the HTML generated by the Literal control
        string tableHtml = tableData.Text;

        // Create a regex pattern to match the table rows and capture the cell values
        string pattern = "<tr>(.*?)<\\/tr>";
        MatchCollection matches = Regex.Matches(tableHtml, pattern, RegexOptions.Singleline);

        // Create a SqlConnection object and open the connection
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Loop through the matched table rows
            foreach (Match match in matches)
            {
                string rowHtml = match.Groups[1].Value;

                // Create a regex pattern to match the table cells and capture the cell values
                string cellPattern = "<td>(.*?)<\\/td>";
                MatchCollection cellMatches = Regex.Matches(rowHtml, cellPattern, RegexOptions.Singleline);

                // Check if there are enough cells (columns) in the row
                if (cellMatches.Count >= 3)
                {
                    string column2Value = cellMatches[0].Groups[1].Value;
                    // Create a SqlCommand object with the insert query and the connection
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Add parameters to the SqlCommand object
                        command.Parameters.AddWithValue("@sectionname", sections[count]);
                        command.Parameters.AddWithValue("@courseid", column2Value);

                        // Execute the insert query
                        command.ExecuteNonQuery();
                    }
                }
                count++;
            }
        }
        AppendToTextFile(" ADMIN CREATED SECTIONS SUCESSFULLY;");
    }


}