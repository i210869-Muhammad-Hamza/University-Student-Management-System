using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;

public partial class Academic_officer_home : System.Web.UI.Page
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
                string query = "select * from  User_ where ('" + USERID + "'= USERID )";
                cm = new SqlCommand(query, conn);
                dr = cm.ExecuteReader();
                dr.Read();
                username.Text = dr["USERNAME"].ToString();
                name.Text= dr["NAME"].ToString();
                dob.Text= dr["DOB"].ToString();
                phone.Text = dr["phone"].ToString();
                email.Text = dr["email"].ToString();
                dr.Close();
                query= "select * from  academic_officer where ('" + USERID + "'= A_ID )";
                cm = new SqlCommand(query, conn);
                dr= cm.ExecuteReader();
                dr.Read();
                //qualification.Text = dr["QUALIFICATION"].ToString();
                //position.Text = dr["position"].ToString();
                //experience.Text = dr["experience"].ToString();
                conn.Close();
            }
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
        Response.Redirect("Academic_officer_home_generate_report.aspx?userID=" + USERID);
    }
}