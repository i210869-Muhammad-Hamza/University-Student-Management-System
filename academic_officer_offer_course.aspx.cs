using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class academic_officer_offer_course : System.Web.UI.Page
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
            string connectionString = "Data Source=DESKTOP-VOMCOEB;Initial Catalog=Flex;Integrated Security=True"; // replace with your actual connection string
            string selectCommand = "SELECT course_ID,Cname,CDept,credits,pre_req FROM course"; // your SQL query here

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(selectCommand, connection))
                {
                    connection.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
        }
    }

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {


        foreach (GridViewRow row in GridView1.Rows)
        {
            RadioButtonList rbl = row.FindControl("RadioButtonList1") as RadioButtonList;

        }

        foreach (GridViewRow row in GridView1.Rows)
        {
            RadioButtonList rbl = row.FindControl("RadioButtonList1") as RadioButtonList;

        }
    }


    protected void btnRegister_Click(object sender, EventArgs e)
    {
        USERID = Convert.ToInt32(Request.QueryString["USERID"]);

        string connectionString = "Data Source=DESKTOP-VOMCOEB;Initial Catalog=Flex;Integrated Security=True";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            foreach (GridViewRow row in GridView1.Rows)
            {
                RadioButtonList rbl = (RadioButtonList)row.FindControl("RadioButtonList1");
                string courseID = row.Cells[0].Text;
                string cname = row.Cells[1].Text;
                string offered = "N";
                string yes = rbl.SelectedValue;

                if (yes == "Yes")
                {
                    SqlCommand insertCommand = new SqlCommand("INSERT INTO offered_course VALUES (@courseID, @cname, @offered)", connection);
                    insertCommand.Parameters.AddWithValue("@courseID", courseID);
                    insertCommand.Parameters.AddWithValue("@cname", cname);
                    insertCommand.Parameters.AddWithValue("@offered", offered);
                    insertCommand.ExecuteNonQuery();
                }

            }
        }
        AppendToTextFile(" ADMIN  OFFERED COURSES  SUCESSFULLY;");


        // Hide the button and the grid
        btnRegister.Visible = false;
        GridView1.Visible = false;

        // Show a success message
        lblMessage.Text = "You have successfully registered!";
        lblMessage.Visible = true;
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
}