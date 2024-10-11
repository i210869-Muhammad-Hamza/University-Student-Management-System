using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class USER : System.Web.UI.Page
{
    public static void AppendToTextFile(string text)
    {
        string filePath = "C:\\Users\\hp\\OneDrive\\Desktop\\db project\\db project\\Audit.txt";

        using (StreamWriter writer = File.AppendText(filePath))
        {
            writer.WriteLine(text);
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string selectedOption = Request.Form["options"];
        if (selectedOption == "student")
        {
            Response.Redirect("student_login.aspx");
          
        }
        else if (selectedOption == "faculty")
        {
            Response.Redirect("facultylogin.aspx");
            
        }
        else if (selectedOption == "academic-officer")
        {
           
            Response.Redirect("academic-officer.aspx");
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}