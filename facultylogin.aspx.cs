using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class facultylogin : System.Web.UI.Page
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

    }
    private int USERID;
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string username = Request.Form["username"];
        string password = Request.Form["password"];
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Sorry, please enter both username and password.');", true);
                 AppendToTextFile("TEACHER LOG IN FAILED ;"); 
        }
        else
        {
            SqlDataReader dr;
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-VOMCOEB;Initial Catalog=Flex;Integrated Security=True");
            conn.Open();
            SqlCommand cm;
            string query = "select * from  User_ where ('" + username + "'= USERNAME and '" + password + "'= PASSWORD )";
            cm = new SqlCommand(query, conn);
            dr = cm.ExecuteReader();
            if (dr.Read())
            {

                int userID = Convert.ToInt32(dr["USERID"]);
                Response.Redirect("facultyhome.aspx?userID=" + userID);

            }
            else
            {
                AppendToTextFile("TEACHER LOG IN SUCCESSFULL ;");
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Sorry, Login was not sucessful.');", true);
            }

        }







    }
    }