using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Security.Policy;
using System.Xml.Linq;
using System.IO;

public partial class Home : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["USERID"]))
            {
                USERID = Convert.ToInt32(Request.QueryString["USERID"]);
                SqlDataReader dr;
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-VOMCOEB;Initial Catalog=Flex;Integrated Security=True");
                conn.Open();
                SqlCommand cm;
                string query = "SELECT * FROM User_ WHERE USERID = @userId";
                cm = new SqlCommand(query, conn);
                cm.Parameters.AddWithValue("@userId", USERID);
                dr = cm.ExecuteReader();
                dr.Read();
                user.Text = dr["NAME"].ToString();
                username.Text = dr["USERNAME"].ToString();
                name.Text = dr["NAME"].ToString();
                dob.Text = dr["DOB"].ToString();
                phone.Text = dr["PHONE"].ToString();
                email.Text = dr["EMAIL"].ToString();
                campus.Text= dr["CAMPUS"].ToString();

                dr.Close();
                query = "SELECT * FROM Student WHERE USERID = @userId";
                cm = new SqlCommand(query, conn);
                cm.Parameters.AddWithValue("@userId", USERID);
                dr = cm.ExecuteReader();
                dr.Read();
                //string ba = dr["BATCH"].ToString();
                rollno.Text =  dr["ROLLNO"].ToString();
                dept.Text = dr["DEPT"].ToString();
                //rollno.Text = rollNo;
                degree.Text = dr["DEGREE"].ToString();
                batch.Text = dr["BATCH"].ToString();
                dr.Close();
                conn.Close();
            }
        }
    }
    private int USERID;
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
}