<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FacultyReports.aspx.cs" Inherits="FacultyReports" %>

<!DOCTYPE html>
<html>
  <head>
   
    <style>
      /* Add styles for the header */
      header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  background-color: steelblue;
  color: white;
  padding: 10px;
  left:0px;
  width: 100%;
}
.sidebar {
            position: absolute;
            top:100;
            left: 10;
            height: 100%;
            width: 195px;
            background-color: gray; ;
            padding: 30px;
        }

        .sidebar ul {
            list-style: none;
            margin: 0;
            padding: 0;
        }
.user-info {
  display: flex;
  align-items: center;
}

.username {
  margin: 0;
  margin-right: 10px;
}

.logout {
  display: flex;
}

.logout a {
  color: white;
  text-decoration: none;
  margin-right: 10px;


}

.logout a:hover {
  text-decoration: underline;
}

      }
      header h1 {
        margin: 0;
        font-size: 25px;
  font-weight: bold;
      }

      header .username {
        position: absolute;
        top: 10px;
        right: 10px;
font-size: 23px;
  font-weight: bold;}
    
.title {
  background-color: white;
  padding: 11px;
  text-align: center;
  position: absolute;
  top: 130px;
  left: 58%;
  font-size: 29px;
  transform: translateX(-50%);
}

.title h2 {
  margin: 0;
  font-size: 27px;
  font-weight: bold;
}
       
        .sidebar ul li a {
  background-color: grey;
  padding: 10px;
  background-color: #fff;
  color: #333;
  text-decoration: none;
  border-radius: 5px;
  line-height: 2em; /* added line-height property */
}

.sidebar ul li a:hover {
  background-color: #333;
  color: #fff;
}
      /* Add styles for the main content */
      main {
        margin-left: 220px; /* Add left margin to avoid overlap with side menu */
        margin-top: 100px;
      }
    .info-box {
    border: 1px solid blue;
    padding: 10px;
    margin: 0 auto;
    width: 90%;
  }
  .info-box h2 {
  margin-top: 0;
  background-color: steelblue;
  color: white;
  padding: 6px;
}

  .info-row {
    display: flex;
    justify-content: space-between;
    margin-bottom: 6px;
    align-items: flex-end;
  }
  .info-label {
    font-size: 20px;
    font-weight: bold;
    padding-right: 10px;
    margin-bottom: 0;
  }
  .info-value {
    font-size: 20px;
    margin-left: 0;
    margin-bottom: 0;
    padding: 6px;
    border: 1px solid #ccc;
  }
  .button-container {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  height: 45vh;
}

.btn {
  padding: 16px 32px;
  border-radius: 8px;
  background-color: #4CAF50;
  color: #FFFFFF;
  font-size: 24px;
  font-weight: bold;
  text-align: center;
  text-decoration: none;
  margin: 16px 0;
  cursor: pointer;
  transition: background-color 0.3s ease;
  width: 200px; /* set the width of the button */
}

/* Add margin between the buttons */
.btn:not(:last-child) {
  margin-bottom: 20px;
}

		/* Hover effect on buttons */
		.btn:hover {
			background-color: #3E8E41;
		}
        .large-button {
        font-size: 20px;
       
    }
</style>


  <header>
  <form id="form1" runat="server">
  <h1>Flex</h1>
  <div class="username">Hello <asp:TextBox ID="user" runat="server" Style="font-weight:bold; width: 250px;"></asp:TextBox>
    <div class="logout">
         <a href="facultylogin.aspx">Logout</a>
    </div>
      </div>
</header>
     
    <div class="sidebar">
            <ul>
                 <li><asp:Button ID="btnSubmit" runat="server" CssClass="button" style="font-size: 21px;" Text="Home" OnClick="Button0_Click" /></li>
                <br />
                <li><asp:Button ID="Button1" runat="server" CssClass="button" style="font-size: 21px;" Text="Set Marks Distribution" OnClick="Button1_Click" /></li>
                <br />
                <li><asp:Button ID="Button2" runat="server" CssClass="button" style="font-size: 21px;" Text="Manage Evaluations" OnClick="Button2_Click" /></li>
                <br />
                <li><asp:Button ID="Button3" runat="server" CssClass="button" style="font-size: 21px;" Text="Manage Attendence" OnClick="Button3_Click" /></li>
                <br />
                <li><asp:Button ID="Button4" runat="server" CssClass="button" style="font-size: 21px;" Text="Faculty Reports"  OnClick="Button4_Click"/></li>
                <br />
                 <li><asp:Button ID="Button5" runat="server" CssClass="button" style="font-size: 21px;" Text="Grader" OnClick="Button5_Click"/></li>
                <br />
                <li><asp:Button ID="Button6" runat="server" CssClass="button" style="font-size: 21px;" Text="Faculty Feedback"  OnClick="Button6_Click"/></li>
                <br />
            </ul>
        </div>
           <div class="title">
      <h2>Report Options</h2>
    </div>
          
    <main>
    <div class="button-container">
    <a href="#" class="btn"><asp:Button ID="button7" runat="server" Text="Attendance Report" CssClass="large-button" OnClick="Button7_Click"/></a>
    <a href="#" class="btn"><asp:Button ID="button8" runat="server" Text="Evaluation Report" CssClass="large-button" OnClick="Button8_Click"/></a>
    <a href="#" class="btn"><asp:Button ID="button9" runat="server" Text="Grade Reports" CssClass="large-button" OnClick="Button9_Click"/></a>
</div>


    </main>
      </form>
  </body>
</html>