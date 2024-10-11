using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
 public partial class facultyhome : System.Web.UI.Page
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
                    string query = "SELECT * FROM User_ WHERE USERID = @USERID";
                    cm = new SqlCommand(query, conn);
                    cm.Parameters.AddWithValue("@USERID", USERID);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    username.Text = dr["USERNAME"].ToString();
                    name.Text = dr["NAME"].ToString();
                    dob.Text = dr["DOB"].ToString();
                    email.Text = dr["EMAIL"].ToString();
                    phone.Text = dr["PHONE"].ToString();
                    campus.Text = dr["CAMPUS"].ToString();




                    dr.Close();
                    query = "SELECT * FROM Faculty WHERE USERID = @userId";
                    cm = new SqlCommand(query, conn);
                    cm.Parameters.AddWithValue("@userId", USERID);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    //string ba = dr["BATCH"].ToString();

                    fac.Text = dr["Facultyid"].ToString();
                    Emp.Text = dr["employeedsince"].ToString();
                    dept.Text = dr["department"].ToString();
                    post.Text = dr["post"].ToString();
                    //rollno.Text = rollNo;

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

    }
