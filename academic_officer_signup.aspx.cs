using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class academic_officer_signup : System.Web.UI.Page
{
    public static void AppendToTextFile(string text)
    {
        string filePath = "C:\\Users\\hp\\OneDrive\\Desktop\\db project\\db project\\Audit.txt";

        using (StreamWriter writer = File.AppendText(filePath))
        {
            writer.WriteLine(text);
        }
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        string username, password, name,number, dob, email, qualification, position, experience;
        username = Request.Form["Username"];
        password = Request.Form["password"];
        name = Request.Form["name"];
        dob = Request.Form["DOB"];
        number = Request.Form["Number"];
        email = Request.Form["Email"];
        qualification = Request.Form["Qualification"];
        position = Request.Form["Position"];
        experience = Request.Form["Experience"];

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(name)
            || string.IsNullOrEmpty(dob) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(number)
            || string.IsNullOrEmpty(qualification) || string.IsNullOrEmpty(position) || string.IsNullOrEmpty(position))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Sorry, please enter all credientials');", true);
            AppendToTextFile(" ADMIN  COULD NOT SIGN UP;");

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
            bool flag = dr.Read();
            if (flag)
            {
               ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Sorry, username & password are already taken');", true);
                AppendToTextFile(" ADMIN SIGNUP FAILED ;");

            }
            else
            {
                dr.Close();
                query = "select TOP(1) *  from  User_ ORDER BY USERID DESC";
                cm = new SqlCommand(query, conn);
                dr = cm.ExecuteReader();
                dr.Read();
                int userID = Convert.ToInt32(dr["USERID"]);
                userID += 1;
                string query2 = "insert into User_ values ('" + userID + "','" + username + "','" + password + "','" + name + "','" + "AO" + "','" + dob + "','" + number + "','" + email + "')";
                string query3 = "insert into Academic_Officer values ('" + userID + "','" + qualification + "','" + userID + "','" + position + "','" + experience + "')";
                dr.Close();
                cm = new SqlCommand(query2, conn);
                cm.ExecuteNonQuery();
                cm.Dispose();
                dr.Close();
                cm = new SqlCommand(query3, conn);
                cm.ExecuteNonQuery();
                cm.Dispose();
                conn.Close();
                Response.Redirect("Academic-officer.aspx");
                AppendToTextFile(" ADMIN SIGN UP SUCESSFULLY ;");
            }

        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}