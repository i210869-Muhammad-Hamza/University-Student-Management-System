<%@ Page Language="C#" AutoEventWireup="true" CodeFile="academic_officer_offer_course.aspx.cs" Inherits="academic_officer_offer_course" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <style>
       
        .table-container {
            background-color: #f2f2f2;
            padding: 20px;
            border-radius: 5px;
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.3);
            width: 80%;
            max-width: 800px;
        }
        table {
            border-collapse: collapse;
            width: 100%;
            margin-bottom: 20px;
        }
        th, td {
            border: 1px solid black;
            padding: 8px;
            text-align: left;
        }
        th {
            background-color: #e6e6e6;
            font-weight: bold;
        }
        /*.sidebar {
            position: fixed;
            top: 0;
            left: 0;
            height: 100%;
            width: 150px;
            background-color: lightblue;
            padding: 20px;
        }

        .sidebar ul {
            list-style: none;
            margin: 0;
            padding: 0;
        }

        .sidebar ul li {
            margin-bottom: 10px;
        }

        .sidebar ul li a {
            display: block;
            padding: 10px;
            background-color: #fff;
            color: #333;
            text-decoration: none;
            border-radius: 5px;
        }

        .sidebar ul li a:hover {
            background-color: #333;
            color: #fff;
        }*/

        .main-content {
            margin-left: 170px;
            padding: 20px;
        }
        .course-id {
        background-color: #c8e1ff;
        font-size: 18px;
    }

    .row-alternate {
        background-color: #eff3fb;
        font-size: 18px;
    }  
    /*  new*/
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
   .center {
        display: flex;
        justify-content: center;
        align-items: center;
    }

    /* increase the size of the button */
    .large-button {
        font-size: 20px;
        padding: 10px 15px;
          margin-top: 20px;
    }
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
      <h2>Course Offer</h2>
    </div>
</head>
<body>
    
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
 <%--<div class="main-content">
            <H2>
                <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />OFFER COURSES
            </H2>--%>
         <main>
 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" style="margin: 10px auto; text-align: center; width: 80%">
    <HeaderStyle CssClass="header-text" />
    <RowStyle CssClass="row-alternate" />
    <AlternatingRowStyle CssClass="row-alternate" />

    <Columns>
        <asp:BoundField DataField="course_ID" HeaderText="Course ID" HeaderStyle-CssClass="header-text" ItemStyle-CssClass="course-id" />
        <asp:BoundField DataField="Cname" HeaderText="Course Name" HeaderStyle-CssClass="header-text" ItemStyle-CssClass="course-id" />
        <asp:BoundField DataField="CDept" HeaderText="Course Dept" HeaderStyle-CssClass="header-text" ItemStyle-CssClass="course-id" />
        <asp:BoundField DataField="credits" HeaderText="Course Credits" HeaderStyle-CssClass="header-text" ItemStyle-CssClass="course-id" />
        <asp:BoundField DataField="Pre_Req" HeaderText="Pre Req" HeaderStyle-CssClass="header-text" ItemStyle-CssClass="course-id" />
        <asp:TemplateField HeaderText="Register" HeaderStyle-CssClass="header-text" ItemStyle-CssClass="course-id">
            <ItemTemplate>
                 <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                    <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                    <asp:ListItem Text="No" Value="No" Selected="True"></asp:ListItem>
                </asp:RadioButtonList>
            </ItemTemplate>
            <FooterTemplate>
            </FooterTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

<div class="center">
    <asp:Button ID="btnRegister" runat="server" Text="Offer Courses" CssClass="large-button" OnClick="btnRegister_Click" ValidationGroup="CourseRegistration" /><br />
   </div>
        <br />
    <div style="text-align: center; font-size: 25px;">
         <div class="green-box">
    <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
</div>
        </div>

</main>
      
    </form>
</body>
</html>
