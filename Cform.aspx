<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cform.aspx.cs" Inherits="Cform" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<%--<head runat="server">--%>
   
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
  .container {
    display: flex;
    justify-content: center;
    align-items: center;
    height: 90%;
   
  }

  /* Add styles for form wrapper here */
  .form-wrapper {
    max-width: 1100px;
    width: 100%;
    padding: 0px;
    /*border: 1px solid #ccc;
    border-radius: 2px;*/
    background-color: lightblue;
    /*justify-content: center;
     align-items: center;
      margin-top: 0;*/
       font-size: 20px;
 
  }
  .form-content {
    padding-top: 20px; /* Adjust the value as needed */
    font-size: 16px; /* Increase font size as needed */
}
  .form-box {
  max-width: 750px;
  width: 100%;
  margin: 0px auto;
  margin-left: 0px; /* adjust this value as needed */
  padding: 20px;
  border: 1px solid #ccc;
  border-radius: 5px;
  background-color: lightgrey;
}

</style>


  <header>
  <form id="form2" runat="server">
      <h1>Flex</h1>
  <div class="user-info">
    <div class="username">Hello <asp:TextBox ID="user" runat="server" Style="font-weight:bold; width: 250px;"></asp:TextBox>
    <div class="logout">
         <a href="student_login.aspx">Logout</a>
       
    </div>
  </div>
</header>
       <div class="title">
      <h2>Course Feedback </h2>
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
          =
    <main>
  
 <div class="container">
  <div class="form-wrapper">

    <main>
        <%--<input type="text" id="rollnumber" name="rollnumber" placeholder="Enter Roll Number" style="float:right;margin-top:5px;">--%>
        <h2>Teacher Assessment Form</h2>
      <label for="date">   Date:</label>
      <input type="date" id="date" name="date"><br><br>
      <label for="teacher-name">Name of Teacher:</label>
      <input type="text" id="teacher-name" name="teacher-name"><br><br>
      <label for="subject">Subject:</label>
      <input type="text" id="subject" name="subject"><br><br>
      <label for="schedule">Schedule:</label>
      <input type="text" id="schedule" name="schedule"><br><br>
      <label for="room-number">Room Number:</label>
      <input type="text" id="room-number" name="room-number"><br><br>
      <label for="school-year">School Year:</label>
      <input type="text" id="school-year" name="school-year"><br><br>
       
  <p>Please fill out the form in evaluating your instructor for the semester. After completion, please press the submit button.</p>
<p>For reference, the metric are as follows:</p>
<ul>
<li>1  - Poor</li>
<li>2 - Below Average</li>
<li>3 - Average</li>
<li>4 - Good</li>
<li>5 - Excellent</li>
    </ul>
        <br>
        <h3>Appearance and Personal Presentation: *</h3>
         <div class="form-box">
<label for="attends">Teacher attends class in a well presentable manner:</label>
<input type="radio" id="attends1" name="attends" value="1">
<label for="attends1">1</label>
<input type="radio" id="attends2" name="attends" value="2">
<label for="attends2">2</label>
<input type="radio" id="attends3" name="attends" value="3">
<label for="attends3">3</label>
<input type="radio" id="attends4" name="attends" value="4">
<label for="attends4">4</label>
<input type="radio" id="attends5" name="attends" value="5">
<label for="attends5">5</label><br>

<label for="enthusiasm">Teacher shows enthusiasm when teaching in class :</label>
<input type="radio" id="enthusiasm1" name="enthusiasm" value="1">
<label for="enthusiasm1">1</label>
<input type="radio" id="enthusiasm2" name="enthusiasm" value="2">
<label for="enthusiasm2">2</label>
<input type="radio" id="enthusiasm3" name="enthusiasm" value="3">
<label for="enthusiasm3">3</label>
<input type="radio" id="enthusiasm4" name="enthusiasm" value="4">
<label for="enthusiasm4">4</label>
<input type="radio" id="enthusiasm5" name="enthusiasm" value="5">
<label for="enthusiasm5">5</label><br>

<label for="initiative">Teacher shows initiative and flexibility in teaching:</label>
<input type="radio" id="initiative1" name="initiative" value="1">
<label for="initiative1">1</label>
<input type="radio" id="initiative2" name="initiative" value="2">
<label for="initiative2">2</label>
<input type="radio" id="initiative3" name="initiative" value="3">
<label for="initiative3">3</label>
<input type="radio" id="initiative4" name="initiative" value="4">
<label for="initiative4">4</label>
<input type="radio" id="initiative5" name="initiative" value="5">
<label for="initiative5">5</label><br>
 <label for="articulated">Teacher is well articulated and shows full knowledge
     <br>of the subject in teaching...........................................</label>
  <input type="radio" id="articulated1" name="articulated" value="1">
  <label for="articulated1">1</label>
  <input type="radio" id="articulated2" name="articulated" value="2">
  <label for="articulated2">2</label>
  <input type="radio" id="articulated3" name="articulated" value="3">
  <label for="articulated3">3</label>
  <input type="radio" id="articulated4" name="articulated" value="4">
  <label for="articulated4">4</label>
  <input type="radio" id="articulated5" name="articulated" value="5">
  <label for="articulated5">5</label><br>
  
  <label for="speaks">Teacher speaks loud and clear enough to be heard by <br >
        the whole class............................................................</label>
  <input type="radio" id="speaks1" name="speaks" value="1">
  <label for="speaks1">1</label>
  <input type="radio" id="speaks2" name="speaks" value="2">
  <label for="speaks2">2</label>
  <input type="radio" id="speaks3" name="speaks" value="3">
  <label for="speaks3">3</label>
  <input type="radio" id="speaks4" name="speaks" value="4">
  <label for="speaks4">4</label>
  <input type="radio" id="speaks5" name="speaks" value="5">
  <label for="speaks5">5</label><br>
             </div>
        <br>
         <h3>Professional Practices: *</h3>
    <div class="form-box">
 <label for="professionalism">Teacher shows professionalism in class...............</label>
<input type="radio" id="professionalism1" name="professionalism" value="1">
<label for="professionalism1">1</label>
<input type="radio" id="professionalism2" name="professionalism" value="2">
<label for="professionalism2">2</label>
<input type="radio" id="professionalism3" name="professionalism" value="3">
<label for="professionalism3">3</label>
<input type="radio" id="professionalism4" name="professionalism" value="4">
<label for="professionalism4">4</label>
<input type="radio" id="professionalism5" name="professionalism" value="5">
 <label for="professionalism5">5</label><br>

<label for="commitment">Teacher shows commitment to teaching the class</label>
<input type="radio" id="commitment1" name="commitment" value="1">
<label for="commitment1">1</label>
<input type="radio" id="commitment2" name="commitment" value="2">
<label for="commitment2">2</label>
<input type="radio" id="commitment3" name="commitment" value="3">
<label for="commitment3">3</label>
<input type="radio" id="commitment4" name="commitment" value="4">
<label for="commitment4">4</label>
<input type="radio" id="commitment5" name="commitment" value="5">
<label for="commitment5">5</label><br>

<label for="encourages">Teacher encourages students to engage in class<br 
    > discussions and ask questions...............................</label>
<input type="radio" id="encourages1" name="encourages" value="1">
<label for="encourages1">1</label>
<input type="radio" id="encourages2" name="encourages" value="2">
<label for="encourages2">2</label>
<input type="radio" id="encourages3" name="encourages" value="3">
<label for="encourages3">3</label>
<input type="radio" id="encourages4" name="encourages" value="4">
<label for="encourages4">4</label>
<input type="radio" id="encourages5" name="encourages" value="5">
<label for="encourages5">5</label><br>

<label for="criticisms">Teacher handles criticisms and suggestions <br >
    professionally........................................................</label>
<input type="radio" id="criticisms1" name="criticisms" value="1">
<label for="criticisms1">1</label>
<input type="radio" id="criticisms2" name="criticisms" value="2">
<label for="criticisms2">2</label>
<input type="radio" id="criticisms3" name="criticisms" value="3">
<label for="criticisms3">3</label>
<input type="radio" id="criticisms4" name="criticisms" value="4">
<label for="criticisms4">4</label>
<input type="radio" id="criticisms5" name="criticisms" value="5">
<label for="criticism5">5</label><br>
 <label for="ontime">Teacher comes to class on time.............................</label>
<input type="radio" id="ontime1" name="ontime" value="1">
<label for="ontime1">1</label>
<input type="radio" id="ontime2" name="ontime" value="2">
<label for="ontime2">2</label>
<input type="radio" id="ontime3" name="ontime" value="3">
<label for="ontime3">3</label>
<input type="radio" id="ontime4" name="ontime" value="4">
<label for="ontime4">4</label>
<input type="radio" id="ontime5" name="ontime" value="5">
<label for="ontime5">5</label><br>

<label for="ontime-end">Teacher ends class on time....................................</label>
<input type="radio" id="ontime-end1" name="ontime-end" value="1">
<label for="ontime-end1">1</label>
<input type="radio" id="ontime-end2" name="ontime-end" value="2">
<label for="ontime-end2">2</label>
<input type="radio" id="ontime-end3" name="ontime-end" value="3">
<label for="ontime-end3">3</label>
<input type="radio" id="ontime-end4" name="ontime-end" value="4">
<label for="ontime-end4">4</label>
<input type="radio" id="ontime-end5" name="ontime-end" value="5">
<label for="ontime-end5">5</label><br>

            </div>
        <br>
        <h3>Teaching Methods: *</h3>
    <div class="form-box">
        <label for="knowledge">Teacher shows well-rounded knowledge over the subject matter</label>
<input type="radio" id="knowledge1" name="knowledge" value="1">
<label for="knowledge1">1</label>
<input type="radio" id="knowledge2" name="knowledge" value="2">
<label for="knowledge2">2</label>
<input type="radio" id="knowledge3" name="knowledge" value="3">
<label for="knowledge3">3</label>
<input type="radio" id="knowledge4" name="knowledge" value="4">
<label for="knowledge4">4</label>
<input type="radio" id="knowledge5" name="knowledge" value="5">
<label for="knowledge5">5</label><br>

<label for="organization">Teacher has organized the lesson conducive for easy understanding<br>
    of students.....................................................................................</label>
<input type="radio" id="organization1" name="organization" value="1">
<label for="organization1">1</label>
<input type="radio" id="organization2" name="organization" value="2">
<label for="organization2">2</label>
<input type="radio" id="organization3" name="organization" value="3">
<label for="organization3">3</label>
<input type="radio" id="organization4" name="organization" value="4">
<label for="organization4">4</label>
<input type="radio" id="organization5" name="organization" value="5">
<label for="organization5">5</label><br>

<label for="dynamism">Teacher shows dynamism and enthusiasm...................................</label>
<input type="radio" id="dynamism1" name="dynamism" value="1">
<label for="dynamism1">1</label>
<input type="radio" id="dynamism2" name="dynamism" value="2">
<label for="dynamism2">2</label>
<input type="radio" id="dynamism3" name="dynamism" value="3">
<label for="dynamism3">3</label>
<input type="radio" id="dynamism4" name="dynamism" value="4">
<label for="dynamism4">4</label>
<input type="radio" id="dynamism5" name="dynamism" value="5">
<label for="dynamism5">5</label><br>
<label for="critical-thinking">Teacher stimulates the critical thinking of students......................</label>
  <input type="radio" id="critical-thinking1" name="critical-thinking" value="1">
  <label for="critical-thinking1">1</label>
  <input type="radio" id="critical-thinking2" name="critical-thinking" value="2">
  <label for="critical-thinking2">2</label>
  <input type="radio" id="critical-thinking3" name="critical-thinking" value="3">
  <label for="critical-thinking3">3</label>
  <input type="radio" id="critical-thinking4" name="critical-thinking" value="4">
  <label for="critical-thinking4">4</label>
  <input type="radio" id="critical-thinking5" name="critical-thinking" value="5">
  <label for="critical-thinking5">5</label><br>

  <label for="class-environment">Teacher handles the class environment conducive for learning....</label>
  <input type="radio" id="class-environment1" name="class-environment" value="1">
  <label for="class-environment1">1</label>
  <input type="radio" id="class-environment2" name="class-environment" value="2">
  <label for="class-environment2">2</label>
  <input type="radio" id="class-environment3" name="class-environment" value="3">
  <label for="class-environment3">3</label>
  <input type="radio" id="class-environment4" name="class-environment" value="4">
  <label for="class-environment4">4</label>
  <input type="radio" id="class-environment5" name="class-environment" value="5">
  <label for="class-environment5">5</label><br>
        </div>
        <br>
        <h3>Disposition Towards Students: *</h3>
    <div class="form-box">
        <label for="belief">Teacher believes that students can learn from the class:</label>
  <input type="radio" id="belief1" name="belief" value="1">
  <label for="belief1">1</label>
  <input type="radio" id="belief2" name="belief" value="2">
  <label for="belief2">2</label>
  <input type="radio" id="belief3" name="belief" value="3">
  <label for="belief3">3</label>
  <input type="radio" id="belief4" name="belief" value="4">
  <label for="belief4">4</label>
  <input type="radio" id="belief5" name="belief" value="5">
  <label for="belief5">5</label><br>

  <label for="respect">Teacher shows equal respect to various cultural <br > 
      backgrounds, individuals, religion, and race.................</label>
  <input type="radio" id="respect1" name="respect" value="1">
  <label for="respect1">1</label>
  <input type="radio" id="respect2" name="respect" value="2">
  <label for="respect2">2</label>
  <input type="radio" id="respect3" name="respect" value="3">
  <label for="respect3">3</label>
  <input type="radio" id="respect4" name="respect" value="4">
<label for="respect4">4</label>
<input type="radio" id="respect5" name="respect" value="5">
<label for="respect5">5</label><br>

<label for="strengths">Teacher finds the students strengths as basis for
    growth<br > and weaknesses for opportunities for improvement......</label>
<input type="radio" id="strengths1" name="strengths" value="1">
<label for="strengths1">1</label>
<input type="radio" id="strengths2" name="strengths" value="2">
<label for="strengths2">2</label>
<input type="radio" id="strengths3" name="strengths" value="3">
<label for="strengths3">3</label>
<input type="radio" id="strengths4" name="strengths" value="4">
<label for="strengths4">4</label>
<input type="radio" id="strengths5" name="strengths" value="5">
<label for="strengths5">5</label><br>
  <label for="understands">Teacher understands the weakness of a student and <br >helps in 
      the student's improvement............................</label>
<input type="radio" id="understands1" name="understands" value="1">
<label for="understands1">1</label>
<input type="radio" id="understands2" name="understands" value="2">
<label for="understands2">2</label>
<input type="radio" id="understands3" name="understands" value="3">
<label for="understands3">3</label>
<input type="radio" id="understands4" name="understands" value="4">
<label for="understands4">4</label>
<input type="radio" id="understands5" name="understands" value="5">
<label for="understands5">5</label><br>
        </div>
        <br>
        <label for="comments">Comments:</label>
        <br />

<textarea id="comments" name="comments" rows="6" cols="50"></textarea>
<br>
        <br >
<SUBMIT_BUTTON>
		<asp:Button ID="btnSubmit" runat="server" CssClass="button" style="font-size: 20px;margin-left:220px; text-align: center;" Text="Submit" OnClick="btnSubmit_Click" />
             
  </div>
</div>
         <div style="text-align: center; font-size: 25px;">
         <div class="green-box">
    <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
</div>
        </form>
    </main>
  </body>
</html>






