using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Signup : System.Web.UI.Page
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
        string username, password, name, number, dob, email, dept, batch, degree;
        username = Request.Form["Username"];
        password = Request.Form["password"];
        name = Request.Form["name"];
        dob = Request.Form["DOB"];
        number = Request.Form["Number"];
        email = Request.Form["Email"];
        dept = Request.Form["Department"];
        batch = Request.Form["Batch"];
        degree = Request.Form["Degree"];

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(name)
            || string.IsNullOrEmpty(dob) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(number)
            || string.IsNullOrEmpty(dept) || string.IsNullOrEmpty(batch) || string.IsNullOrEmpty(degree))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Sorry, please enter all credientials');", true);
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
                string query3 = "insert into Student values ('" + userID + "','" + dept + "','"  + batch + "','" + degree + "')";
                dr.Close();
                cm = new SqlCommand(query2, conn);
                cm.ExecuteNonQuery();
                cm.Dispose();
                dr.Close();
                cm = new SqlCommand(query3, conn);
                cm.ExecuteNonQuery();
                cm.Dispose();
                conn.Close();
                Response.Redirect("student_login.aspx");
            }

        }
    }
}