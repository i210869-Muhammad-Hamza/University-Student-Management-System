<%@ Page Language="C#" AutoEventWireup="true" CodeFile="USER.aspx.cs" Inherits="USER" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Flex</title>
	<style>
		body 
		{
			border-top: 8px double navy;
			margin: 0;
			padding: 0;
			height: 100vh;
			display: flex;
			flex-direction: column;
			justify-content: center;
			align-items: center;
			background-image: url('fastnuces.png');
			background-repeat: no-repeat;
			background-attachment: fixed;
			background-size: cover;
		}
		
		.container {
			display: flex;
			flex-direction: column;
			justify-content: center;
			align-items: center;
			margin-bottom: 20px;
		}
		
		img  
		{
			max-width: 100%;
			max-height: 100%;
			margin-bottom: 100px;
		}
		
		select {
			padding: 10px;
			font-size: 16px;
			border: 1px solid #ccc;
			border-radius: 5px;
			background-color: #fff;
			box-shadow: 0px 0px 5px rgba(0, 0, 0, 0.1);
		}
		
		select option {
			font-size: 16px;
			background-color: #fff;
			color: #333;
		}
		.button {
  margin-top: 20px;
  margin-bottom: 10px;
  margin-left: 5px;
  margin-right: 5px;
  padding: 2px 2px;
  background-color: blue;
  color: white;
  border: none;
  border-radius: 5px;
  font-size: 16px;
  cursor: pointer;
				}
		
	</style>

</head>
<body>
    <form id="form1" runat="server">  
    
	<FLEX_IMAGE class="container">
		<img src="fleximg.png" alt="Your image description here"  />
	</FLEX_IMAGE>
	<DROP_DOWN_MENU class="container">
		<select id="options" name="options">
			<option value="">--Select an option--</option>
			<option value="student">STUDENT</option>
			<option value="faculty">FACULTY</option>
			<option value="academic-officer">ACADEMIC OFFICER</option>
		</select>
	
	<SUBMIT_BUTTON class="button">
		<asp:Button ID="btnSubmit" runat="server" CssClass="button" Text="Submit" OnClick="btnSubmit_Click" />
    </SUBMIT_BUTTON>
		<br /><br />
	</DROP_DOWN_MENU>
	</form>
</body>
</html>
