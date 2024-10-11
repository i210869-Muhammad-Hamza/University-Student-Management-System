<%@ Page Language="C#" AutoEventWireup="true" CodeFile="academic_officer_generate_report.aspx.cs" Inherits="academic_officer_generate_report" %>

<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>--%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head >
    <title></title>
    <style>
      /*  .sidebar {
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
        }

        .main-content {
            margin-left: 170px;
            padding: 20px;
        }*/
        table {
            border-collapse: collapse;
            width: 70%;
            margin-left: 20%;
        }

        th, td {
            padding: 8px;
            text-align: left;
            border-bottom: 1px solid #ddd;
        }

        th {
            background-color: #f2f2f2;
        }

        input[type="text"] {
            width: 100%;
            padding: 6px 10px;
            box-sizing: border-box;
        }

        .submit-btn {
            margin-top: 10px;
            padding: 8px 16px;
            background-color: #4CAF50;
            color: white;
            border: none;
            cursor: pointer;
        }

        .submit-btn:hover {
            background-color: #45a049;
        }
         .report-button {
        padding: 10px 20px;
        font-size: 18px;
        background-color: lightblue;
        color: white;
        border: none;
        border-radius: 5px;
        cursor: pointer;
    }

    .report-button:hover {
        background-color: blue;
    }
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
       Add styles for the main content 
    main {
        display: flex;
        flex-direction: column;
        justify-content: center;
        align-items: center;
        height: 100vh;
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
      <h2>Reports</h2>
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
     <div class="main-content">
    <h2 style="text-align: center;">Generate Reports</h2>
    <br />
    <div style="text-align: center;">
        <asp:Button ID="Button5" runat="server" CssClass="button" style="font-size: 20px;" Text="Offered Courses Report" OnClick="offer_course" />       
        <asp:Button ID="Button6" runat="server" CssClass="button" style="font-size: 20px;" Text="Sections Report" OnClick="section" />       
        <asp:Button ID="Button7" runat="server" CssClass="button" style="font-size: 20px;" Text="Teachers Allocation Report" OnClick="allocation" /><br /><br /><br /><br /><br /><br /><br /><br />        
        <div>
        </div>
    </div>
         <table>
            <asp:Literal ID="reportTable" runat="server"></asp:Literal>
        </table>

</div>
<script type="text/javascript">
    function offer_course() {
        $('#reportTable').show();
    }

    function section() {
        $('#reportTable').show();
    }

    function allocation() {
        $('#reportTable').show();
    }
         </script>
    </form>
</body>
</html>
