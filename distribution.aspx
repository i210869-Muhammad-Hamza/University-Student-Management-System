<%@ Page Language="C#" AutoEventWireup="true" Codefile="distribution.aspx.cs" Inherits="distribution" %>

<!DOCTYPE html>
<html>
  <head>
   <title>Marks Distribution Table</title>
    <style>
     caption {
  background-color: white;
  padding: 11px;
  text-align: center;
  position: absolute;
  top: 135px;
  left: 55%; /* Change the left position to 50% */
  transform: translateX(-50%); /* Center the text using transform */
  font-size: 28px;
  font-weight: bold;
  color: steelblue; /* Change the font color */
  border: 2px solid steelblue; /* Add a border */
  border-radius: 5px; /* Add border radius */
  box-shadow: 0px 0px 5px 0px rgba(0,0,0,0.75); /* Add a box shadow */
}
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
  font-size: 39px;
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

 table {
            border-collapse: collapse;
            width: 100%;
            margin: 20px 0;
            font-size: 18px;
        }
        table th,
        table td {
            text-align: center;
            padding: 10px;
            border: 1px solid #ddd;
        }
        table th {
            background-color: #4CAF50;
            color: white;
        }
        table td select {
            width: 100%;
            height: 40px;
            font-size: 16px;
            padding: 5px;
            border-radius: 5px;
        }
        table td input[type="number"] {
            width: 100%;
            height: 40px;
            font-size: 16px;
            padding: 5px;
            border-radius: 5px;
            text-align: center;
            border: 1px solid #ddd;
            outline: none;
        }
        table td input[type="submit"] {
            background-color: #4CAF50;
            color: white;
            border: none;
            border-radius: 5px;
            padding: 10px;
            cursor: pointer;
            font-size: 16px;
        }
        table td input[type="submit"]:hover {
            background-color: #3e8e41;
        }

</style>


  <header>
      <form id="form2" runat="server">
  <h1>Flex</h1>
   <div class="username">Hello <asp:TextBox ID="user" runat="server" Style="font-weight:bold; width: 250px;"></asp:TextBox>
    <div class="logout">
         <a href="facultylogin.aspx">Logout</a>
    </div>
  </div>
</header>
       <%--<div class="title">
    </div>--%>
     
    <div class="sidebar">
            <ul>
                <li><asp:Button ID="btnSubmit" runat="server" CssClass="button" style="font-size: 21px;" Text="Home"  OnClick="Button0_Click"/></li>
                <br />
                <li><asp:Button ID="Button1" runat="server" CssClass="button" style="font-size: 21px;" Text="Set Marks Distribution" OnClick="Button1_Click" /></li>
                <br />
                <li><asp:Button ID="Button2" runat="server" CssClass="button" style="font-size: 21px;" Text="Manage Evaluations"  OnClick="Button2_Click"/></li>
                <br />
                <li><asp:Button ID="Button3" runat="server" CssClass="button" style="font-size: 21px;" Text="Manage Attendence"  OnClick="Button3_Click"/></li>
                <br />
                <li><asp:Button ID="Button4" runat="server" CssClass="button" style="font-size: 21px;" Text="Faculty Reports"  OnClick="Button4_Click" /></li>
                <br />
                 <li><asp:Button ID="Button5" runat="server" CssClass="button" style="font-size: 21px;" Text="Grader" OnClick="Button5_Click"/></li>
                <br />
                <li><asp:Button ID="Button6" runat="server" CssClass="button" style="font-size: 21px;" Text="Faculty Feedback" OnClick="Button6_Click" /></li>
                <br />
            </ul>
        </div>
          <%--</form>--%>
    <main>
       
       <%--<h2>Marks Distribution Table</h2>--%>
    <table>
        <caption>Marks Distribution Table</caption>
        <tr>
            <th>Category</th>
            <th>Marks</th>
        </tr>
        <tr>
            <td>Subject</td>
                <td>
                    <select id="subject" name="select" runat="server">
                        <option value="">--Select Subject--</option>
                    </select>
                </td>

        </tr>

        <tr>
            <td>Quiz</td>
            <td><input type="number" name = "quiz" id="quiz" min="0" max="100"></td>
        </tr>
        <tr>
            <td>Final Exam</td>
            <td><input type="number" name= "final-exam" id="final-exam" min="0" max="100"></td>
        </tr>
        <tr>
            <td>Assignment</td>
            <td><input type="number"  name="assignment" id="assignment" min="0" max="100"></td>
        </tr>
        <tr>
            <td>Sessional 1</td>
            <td><input type="number"  name="sessional-1" id="sessional-1" min="0" max="100"></td>
        </tr>
        <tr>
             <td>Sessional 2</td>
            <td><input type="number"  name="sessional-1" id="sessional-2" min="0" max="100"></td>
        </tr>
        <tr>
            <td>
            <asp:Button ID="submitBtn" runat="server" Text="Submit" OnClick="submitForm" />
            </td>
          <%--<td colspan="2"><input type="submit" value="Submit" onclick="submitForm()"></td>--%>
        </tr>
    </table>
        </form>

<script>
    function submitForm() {
        var subject = document.getElementById('subject').value;
        var quiz = document.getElementById('quiz').value;
        var finalExam = document.getElementById('final-exam').value;
        var assignment = document.getElementById('assignment').value;
        var sessional1 = document.getElementById('sessional-1').value;
        var sessional2 = document.getElementById('sessional-2').value;

        if (subject == '') {
            alert('Please select a subject');
            return false;
        }
        if (quiz == '') {
            alert('Please enter quiz marks');
            return false;
        }
        if (finalExam == '') {
            alert('Please enter final exam marks');
            return false;
        }
        if (assignment == '') {
            alert('Please enter assignment marks');
            return false;
        }
        if (sessional1 == '') {
            alert('Please enter sessional 1 marks');
            return false;
        }
        if (sessional2 == '') {
            alert('Please enter sessional 2 marks');
            return false;
        }

        var totalMarks = parseFloat(quiz) + parseFloat(finalExam) + parseFloat(assignment) + parseFloat(sessional1) + parseFloat(sessional2);
        if (totalMarks != 100) {
            alert('Total marks should be 100');
            return false;
        }

        alert('Marks distribution submitted successfully');
        return true;
    }

</script>
 

    </main>
  </body>
</html>
