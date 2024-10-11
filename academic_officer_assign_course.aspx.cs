using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class academic_officer_assign_course : System.Web.UI.Page
{
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
        int USERID = Convert.ToInt32(Request.QueryString["USERID"]);
        Response.Redirect("Academic_officer_home.aspx?userID=" + USERID);
    }
    protected void offer_course_button(object sender, EventArgs e)
    {
        int USERID = Convert.ToInt32(Request.QueryString["USERID"]);
        Response.Redirect("Academic_officer_offer_course.aspx?userID=" + USERID);
    }
    protected void create_section_button(object sender, EventArgs e)
    {
        int USERID = Convert.ToInt32(Request.QueryString["USERID"]);
        Response.Redirect("Academic_officer_create_section.aspx?userID=" + USERID);
    }
    protected void assign_teacher_button(object sender, EventArgs e)
    {
        int USERID = Convert.ToInt32(Request.QueryString["USERID"]);
        Response.Redirect("Academic_officer_assign_course.aspx?userID=" + USERID);
    }
    protected void generate_report_button(object sender, EventArgs e)
    {
        int USERID = Convert.ToInt32(Request.QueryString["USERID"]);
        Response.Redirect("Academic_officer_generate_report.aspx?userID=" + USERID);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GenerateTable();
        }
    }
    List<string> dropdownOptions;
    protected void GenerateTable()
    {
        // Connection string to your SQL database
        string connectionString = "Data Source=DESKTOP-VOMCOEB;Initial Catalog=Flex;Integrated Security=True";

        // SQL query to retrieve data
        string query = "SELECT * FROM offered_course JOIN section ON offered_course.courseId = section.courseID";

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
                        table += "<td>" + reader["SectionName"] + "</td>";
                        table += "<td>";

                        // Retrieve the options for the dropdown menu from the database
                        dropdownOptions = GetDropdownOptionsFromDatabase();

                        // Generate the select element with options
                        table += "<select name='dropdown'>";
                        foreach (string option in dropdownOptions)
                        {
                            table += "<option value='" + option + "'>" + option + "</option>";
                        }
                        table += "</select>";
                        table += "</td>";
                        table += "</tr>";
                    }

                    // Assign the generated table HTML to the Literal control
                    tableData.Text = table;
                }
            }
        }
    }

    private List<string> GetDropdownOptionsFromDatabase()
    {
        string connectionString = "Data Source=DESKTOP-VOMCOEB;Initial Catalog=Flex;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();


        List<string> options = new List<string>();

        // SQL query to retrieve dropdown options
        string query = "SELECT username OptionColumn FROM faculty,user_ where faculty.userid=user_.userid";

        // Create a SqlCommand object with the query and the connection
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            // Execute the query and obtain a SqlDataReader
            using (SqlDataReader reader = command.ExecuteReader())
            {
                // Read the values and add them to the options list
                while (reader.Read())
                {
                    string optionValue = reader["OptionColumn"].ToString();
                    options.Add(optionValue);
                }
            }
        }
        connection.Close();
        return options;
    }
    private List<string> GetTeacherID(List<string> teachers)
    {
        string connectionString = "Data Source=DESKTOP-VOMCOEB;Initial Catalog=Flex;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();


        List<string> options = new List<string>();

        for (int i = 0; i < teachers.Count; i++)
        {
            string matcher = teachers[i];
            string query = "SELECT * FROM faculty,user_ where faculty.userid=user_.userid and '" + matcher + "'= user_.USERNAME";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            string optionValue = reader["facultyid"].ToString();
            options.Add(optionValue);
            reader.Close();
        }
        connection.Close();
        return options;
    }
    private void getCourseid(ref List<string> teachers)
    {
        string connectionString = "Data Source=DESKTOP-VOMCOEB;Initial Catalog=Flex;Integrated Security=True";

        // SQL query to retrieve data
        string query = "SELECT courseid FROM offered_course";

        // Create a SqlConnection object and open the connection
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Create a SqlCommand object with the query and the connection
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        teachers.Add(reader["courseid"].ToString());
                    }
                }
            }
        }
    }

    public List<string> ProcessCommaSeparatedString(string input)
    {
        List<string> stringVector = input.Split(',').ToList();
        return stringVector;
    }
    bool CheckDistinctElementOccurrences(ref List<string> list)
    {
        Dictionary<string, int> elementCount = new Dictionary<string, int>();

        foreach (string element in list)
        {
            // If the element already exists in the dictionary, increment its count
            if (elementCount.ContainsKey(element))
            {
                elementCount[element]++;
            }
            // Otherwise, add the element to the dictionary with a count of 1
            else
            {
                elementCount[element] = 1;
            }
        }

        // Check if any element count exceeds three
        foreach (int count in elementCount.Values)
        {
            if (count > 3)
            {
                return false; // At least one element occurs more than three times
            }
        }

        return true; // All distinct elements occur three times or less
    }
    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        string selectedOption = Request.Form["dropdown"];
        List<string> teachers = ProcessCommaSeparatedString(selectedOption);
        List<string> teacher_id = GetTeacherID(teachers);
        if (CheckDistinctElementOccurrences(ref teacher_id))
        {
            List<string> cid = new List<string>();
            getCourseid(ref cid);
            string connectionString = "Data Source=DESKTOP-VOMCOEB;Initial Catalog=Flex;Integrated Security=True";

            // SQL query to retrieve data

            // Create a SqlConnection object and open the connection
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            for (int i = 0; i < teacher_id.Count; i++)
            {
                string query = "update section set facultyid = '" + teacher_id[i] + "'where courseid = '" + cid[i] + "' ";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                reader.Close();
            }
            AppendToTextFile(" ADMIN ASSIGNED COURSES  SUCESSFULLY;");
        }
        else
        {
        AppendToTextFile("ADMIN COULD NOT ASSIGN COURSES;");

            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Sorry, more than 3 courses are taught by a Single instructor');", true);
        }
    }

}



