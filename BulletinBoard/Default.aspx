<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BulletinBoard.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
<link href="CSS.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">

<div class = "centerbox">
    <div class = "boxcont">
        <h2>Bolton Now Forum - Login</h2>

        <p class="heading">Email</p>
        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
        
        <p class="heading">Password</p>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
         
        <br />
        <br />

        <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" />
        <br />
        <br />

        <asp:Label ID="lblLogMessage" runat="server" Text="LoginMessage" Visible="False"></asp:Label>
        <br />
        <br />
        
        <p style="margin-bottom: 0px">Don&#39;t have an account? Register<a href="Register.aspx">here!</a></p>

    </div>
            
</div>

        


    
        
        
        
    </form>

		</body>
</html>