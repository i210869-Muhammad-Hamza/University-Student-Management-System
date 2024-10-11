<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Academic_officer_home.aspx.cs" Inherits="Academic_officer_home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <style>
        
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
            width: 160px;
            background-color: gray; 
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
#myChart {
    width: 500px;
    height: 400px;
    margin: 0 auto;
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
  left: 25%;
  font-size: 28px;
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
    font-weight: bold;
    font-size: 21px;

  }
  .dob {
  
    display:contents;
    justify-content: space-between;
    margin-bottom: 6px;
    
    font-weight: bold;
    font-size: 21px;

  }
  .canvas {
  width: 400px;
  height: 300px;
}
    justify-content: space-between;
    margin-bottom: 6px;
    
    font-weight: bold;
    font-size: 21px;

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

    </style>
    </style>

 <form id="form1" runat="server">
  <header>
  <h1>Flex</h1>
  <div class="user-info">
    <div class="username">Hello <asp:TextBox ID="user" runat="server" Style="font-weight:bold; width: 250px;"></asp:TextBox>
    <div class="logout">
         <a href="student_login.aspx">Logout</a>
       
    </div>
  </div>
</header>
       <div class="title">
      <h2>Personal|Profile</h2>
    </div>
     <div class="sidebar">
            <ul>

           
                <li><asp:Button ID="btnSubmit" runat="server" CssClass="button" style="font-size: 20px;" Text="Home" OnClick="home_button" /></li>
                <br />
                <li><asp:Button ID="Button1" runat="server" CssClass="button" style="font-size: 20px;" Text="Offer Courses" OnClick="offer_course_button" /></li>
                <br />
                <li><asp:Button ID="Button2" runat="server" CssClass="button" style="font-size: 20px;" Text="Create Sections" OnClick="create_section_button" /></li>
                <br />
                <li><asp:Button ID="Button3" runat="server" CssClass="button" style="font-size: 20px;" Text="Assign Teachers" OnClick="assign_teacher_button" /></li>
                <br />
                <li><asp:Button ID="Button4" runat="server" CssClass="button" style="font-size: 20px;" Text="Generate Reports" OnClick="generate_report_button" /></li>
            </ul>
        </div>
     
    <main>
        <div class="info-box">
      <h2>Personal Information</h2>
              <div class="info-row">
                USERNAME:<asp:TextBox ID="username" runat="server"></asp:TextBox>
                NAME:<asp:TextBox ID="name" runat="server"></asp:TextBox>
     </div>
            <div class="info-row">
                DOB:<asp:TextBox ID="dob" runat="server"></asp:TextBox>
              PHONE:<asp:TextBox ID="phone" runat="server"></asp:TextBox>
                </div>
            </div>
          <div class="info-box" style="margin-top: 30px;">
              <h2>Academic Information</h2>
            <div class="info-row">
                EMAIL:<asp:TextBox ID="email" runat="server"></asp:TextBox>
                QUALIFICATION:<asp:TextBox ID="qualification" runat="server"></asp:TextBox>
             </div>
                <div class="info-row">
                POSITION:<asp:TextBox ID="position" runat="server"></asp:TextBox>
                EXPERIENCE:<asp:TextBox ID="experience" runat="server"></asp:TextBox>
             </div>
        </div>
    </form>
    </main>
</body>
</html>

