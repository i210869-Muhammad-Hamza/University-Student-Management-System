<%@ Page Language="C#" AutoEventWireup="true" CodeFile="student_login.aspx.cs" Inherits="student_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Flex_Academic_Officer</title>
    <style>
        .img {
            display: flex;
            justify-content: center;
            align-items: center;
        }

        .img img {
            
            max-width: 20%;
            max-height: 20%;
            margin-top:10%;
            margin-left: -30%;
        }
       
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <flex-academic-suite-img class="img">
            <img src="flex-academic-suite.png" alt="Your image description here" />

        <admin-login-form id="login">
            <br /><br />
            <label style="font-size: 40px;margin-left:220px; text-align: center;">Login</label>
            <br /><br /><br />
            <label style="font-size: 20px;margin-left:220px; text-align: center;">User Name:</label>
            <input type="text" name="username" />
            <br /><br /><br />
            <label style="font-size: 20px;margin-left:220px; text-align: center;">Password:</label>
            <input style="width:154px"; type="password" name="password" />
            <br /><br /><br /><br />
    <SUBMIT_BUTTON>
		<asp:Button ID="btnSubmit" runat="server" CssClass="button" style="font-size: 20px;margin-left:220px; text-align: center;" Text="Submit" OnClick="btnSubmit_Click" />
            <br /><br /><br />
   
        </admin-login-form>
        </flex-academic-suite-img>
        
    </form>
</body>
</html>