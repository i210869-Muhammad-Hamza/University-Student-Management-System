<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FacultyFeedback.aspx.cs" Inherits="FacultyFeedback" %>


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
  left: 21%;
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

  /*table {
			border-collapse: collapse;
			width: 100%;
			margin: 20px 0;
            margin-left: 2%;
			font-size: 18px;
			text-align: left;
		}
		table th,
		table td {
			padding: 12px 15px;
			border: 1px solid #ddd;
		}
		table th {
			background-color: #4CAF50;
			color: white;
		}
		table tr:nth-child(even) td {
			background-color: #f2f2f2;
		}*/
		.select-section,
		.select-option {
			display: inline-block;
			margin-right: 10px;
            margin-left: 3%;
		}
		.select-section label,
		.select-option label {
			font-size: 16px;
			font-weight: bold;
			margin-right: 5px;
		}
		.select-section select,
		.select-option select {
			padding: 8px;
			border-radius: 5px;
			border: 1px solid #ccc;
			font-size: 16px;
		}

        select-course,
		.select-option {
			display: inline-block;
			margin-right: 10px;
            margin-left: 3%;
		}
		.select-course label,
		.select-option label {
			font-size: 16px;
			font-weight: bold;
			margin-right: 5px;
		}
		.select- select,
		.select-option select {
			padding: 8px;
			border-radius: 5px;
			border: 1px solid #ccc;
			font-size: 16px;
		}
		.student-marks td {
			border: none;
			background-color: transparent;
			padding: 0;
			text-align: center;
		}
		.student-marks input[type="number"] {
			width: 70px;
			padding: 5px;
			border-radius: 5px;
			border: 1px solid #ccc;
			font-size: 16px;
			text-align: center;
		}
		.student-marks input[type="number"]:focus {
			outline: none;
			border: 1px solid #4CAF50;
		}
		.btn-save {
			display: block;
			margin: 20px auto 0;
			padding: 10px 20px;
			background-color: #4CAF50;
			color: white;
			font-size: 16px;
			font-weight: bold;
			border: none;
			border-radius: 5px;
			cursor: pointer;
		}
		.btn-save:hover {
			background-color: #3e8e41;
		}

         caption {
  background-color: white;
  padding: 11px;
  text-align: center;
  position: absolute;
  top: 130px;
  left: 55%; /* Change the left position to 50% */
  transform: translateX(-50%); /* Center the text using transform */
  font-size: 28px;
  font-weight: bold;
  color: steelblue; /* Change the font color */
  border: 2px solid steelblue; /* Add a border */
  border-radius: 5px; /* Add border radius */
  box-shadow: 0px 0px 5px 0px rgba(0,0,0,0.75); /* Add a box shadow */
}
		 .container {
			display: flex;
			justify-content: center;
			align-items: center;
			height: 50vh;
		}
		 .b {
      display: inline-block;
      padding: 20px 40px;
      font-size: 24px;
      font-weight: bold;
      text-align: center;
      text-decoration: none;
      background-color: #4CAF50;
      color: white;
      border-radius: 10px;
      box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
      transition: background-color 0.3s ease;
    }
    
    .button:hover {
      background-color: #45a049;
    }
    
    .button-container {
      display: flex;
      justify-content: center;
      align-items: center;
      height: 100vh;
	  padding: 20px 30px
    }

	bo {
			display: flex;
			align-items: center;
			justify-content: center;
			height: 70vh;
		}
		
		select {
			padding: 20px;
			border-radius: 10px;
			border: 2px solid #ccc;
			font-size: 24px;
			color: #555;
			width: 300px;
			-webkit-appearance: none;
			-moz-appearance: none;
			appearance: none;
			background-image: url('data:image/svg+xml;utf8,<svg viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path d="M7 10l5 5 5-5z"/></svg>');
			background-repeat: no-repeat;
			background-position-x: 97%;
			background-position-y: 50%;
			background-size: 30px;
		}
		
		but {
			padding: 20px 40px;
			background-color: #4CAF50;
			color: #fff;
			border: none;
			border-radius: 10px;
			font-size: 24px;
			cursor: pointer;
			margin-left: 20px;
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
      
		</div>
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
         <bo>
	

	<table style="margin-left: 15%">
		<div style="text-align: center;">
		<caption>Feedbacks Obtained</caption>
        
        <tr>
            <td>Subject</td>
                <td>
                    <select id="subject" name="select" runat="server">
                        <option value="">--Select Subject--</option>
                    </select>
                </td>
			<td>Section</td>
                <td>
                    <select id="Section" name="select" runat="server">
                        <option value="">--Select Section--</option>
						 <option value="">--Section A--</option>
                    </select>
                </td>
        </tr>

	</div> </table>

			 <but><asp:Button ID="Button7" runat="server" Text="Enter" CssClass="button3" OnClick="Button7_Click" /></but>

	
</bo>
	 </form>

  
  </body>
</html>



