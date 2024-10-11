<%@ Page Language="C#" AutoEventWireup="true" CodeFile="academic_officer_signup.aspx.cs" Inherits="academic_officer_signup" %>

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
            <label style="font-size: 40px;margin-left:220px; text-align: center;">Signup</label>
            <br /><br />
            <label style="font-size: 20px;margin-left:220px; text-align: center;">UserName:</label>
            <input type="text" name="Username" />
            <br /><br />
            <label style="font-size: 20px;margin-left:220px; text-align: center;">Password:</label>
            <input style="width:154px"; type="password" name="password" />
            <br /><br />
            <label style="font-size: 20px;margin-left:220px; text-align: center;">Name:</label>
            <input type="text" name="name" />
            <br /><br />
            <label style="font-size: 20px;margin-left:220px; text-align: center;">DOB:</label>
            <input style="width:154px"; type="date" name="DOB" />
            <br /><br />
            <label style="font-size: 20px;margin-left:220px; text-align: center;">PHONE:</label>
            <input style="width:154px"; type="text" name="Number" />
            <br /><br />
            <label style="font-size: 20px;margin-left:220px; text-align: center;">Email:</label>
            <input style="width:154px"; type="email" name="Email" />
            <br /><br />
            <label style="font-size: 20px;margin-left:220px; text-align: center;">Qualification:</label>
            <input type="text" name="Qualification" />
            <br /><br />
            <label style="font-size: 20px;margin-left:220px; text-align: center;">Position:</label>
            <input type="text" name="Position" />
             <br /><br />
            <label style="font-size: 20px;margin-left:220px; text-align: center;">Experience:</label>
            <input type="text" name="Experience" />
            <br /><br />
            <SUBMIT_BUTTON>
		<asp:Button ID="btnSubmit" runat="server" CssClass="button" style="font-size: 20px;margin-left:220px; text-align: center;" Text="Submit" OnClick="btnRegister_Click" />
    </SUBMIT_BUTTON> 
   
    <div>
        <br /><br />
    <a style="font-size: 20px;margin-left:220px; text-align: center" ; href="academic-officer.aspx">If you are registered then login!</a>
    </div>
        </admin-login-form>
        </flex-academic-suite-img>
        
    </form>
</body>
</html>
