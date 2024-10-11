<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>
<!DOCTYPE html>
<html>
  <head>
     
    <title>Page Title</title>
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
      <h2>Student|Profile</h2>
    </div>

    
    <div class="sidebar">
            <ul>
                <li><asp:Button ID="button0" runat="server" CssClass="button" style="font-size: 21px;" Text="Home"  OnClick="Button0_Click"/></li>
                <br/>
                <li>
                    <asp:Button ID="Button1" runat="server" CssClass="button" style="font-size: 21px;" Text="Course Register" OnClick="Button1_Click" /></li>
                <br/>
                 <li>
                 <asp:Button ID="Button2" runat="server" CssClass="button" style="font-size: 21px;" Text="Attendance" OnClick="Button2_Click" /></li>
                <br/>
                <li><asp:Button ID="Button3" runat="server" CssClass="button" style="font-size: 21px;" Text="Marks" OnClick="Button3_Click" /></li>
                <br/>
                <li><asp:Button ID="Button4" runat="server" CssClass="button" style="font-size: 21px;" Text="Transcript" OnClick="Button4_Click" /></li>
                <br/>
                <li><asp:Button ID="Button5" runat="server" CssClass="button" style="font-size: 21px;" Text="Course Feedback" OnClick="Button5_Click"/></li>
                <br/>
            </ul>
        </div>
        
    <main>
        
   <div class="info-box">
  <h2>University Information</h2>
 <div class="info-row">
  Username:<asp:TextBox ID="username" runat="server" Style="font-weight:bold; width: 250px;"></asp:TextBox>
   Section:<asp:TextBox ID="section" runat="server" Style="font-weight:bold; width: 250px;"></asp:TextBox>
</div>
<div class="info-row">
Campus  :<asp:TextBox ID="campus" runat="server" Style="font-weight:bold; width: 250px;"></asp:TextBox>
   Degree:<asp:TextBox ID="degree" runat="server" Style="font-weight:bold; width: 250px;"></asp:TextBox>
</div>
<div class="info-row">
Department:<asp:TextBox ID="dept" runat="server" Style="font-weight:bold; width: 250px;"></asp:TextBox>
  Batch:<asp:TextBox ID="batch" runat="server" Style="font-weight:bold; width: 250px;"></asp:TextBox></div>
</div>
<div class="info-box" style="margin-top: 30px; margin-bottom: 60px;">
  <h2>Personal Information</h2>
  <div class="info-row">
    FullName:<asp:TextBox ID="name" runat="server" Style="font-weight:bold; width: 250px;"></asp:TextBox>
   Roll-Number:<asp:TextBox ID="rollno" runat="server" Style="font-weight:bold; width: 250px;"></asp:TextBox>
  </div>
  <div class="info-row">
Email:<asp:TextBox ID="email" runat="server" Style="font-weight:bold; width: 250px;"></asp:TextBox>
Phone:<asp:TextBox ID="phone" runat="server" Style="font-weight:bold; width: 250px;"></asp:TextBox>
  </div>
  <div class ="dob" >
Date of Birth(as per cnic):<asp:TextBox ID="dob" runat="server" Style="font-weight:bold; width:250px;"></asp:TextBox>
  </div>
</div>

    </main>
   </form>
      <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
     <canvas id="myChart"></canvas>

<script>
    var ctx = document.getElementById('myChart').getContext('2d');
    var chart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: ['Semester 1', 'Semester 2', 'Semester 3', 'Semester 4'],
            datasets: [{
                label: 'GPA',
                data: [3.2, 3.5, 3.8, 3.9],
                backgroundColor: [
                    'rgba(255, 99, 132, 0.2)', // red
                    'rgba(54, 162, 235, 0.2)', // blue
                    'rgba(255, 206, 86, 0.2)', // yellow
                    'rgba(75, 192, 192, 0.2)', // green
                ],
                borderColor: [
                    'rgba(255, 99, 132, 1)', // red
                    'rgba(54, 162, 235, 1)', // blue
                    'rgba(255, 206, 86, 1)', // yellow
                    'rgba(75, 192, 192, 1)', // green
                ],
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }]
            }
        }
    });
</script>
  </body>
</html>
