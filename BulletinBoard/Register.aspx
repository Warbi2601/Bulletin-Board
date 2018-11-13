<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="BulletinBoard.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
    <link href="CSS.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
        <div class = "centerbox">
            <div class = "boxcont">
                <h2>Bolton Now Forum - Register</h2>

                <p class="heading">Email</p>
                <asp:TextBox ID="txtEmail" runat="server" type="text" TextMode="Email"></asp:TextBox>
        
                <p class="heading">Password</p>
                <asp:TextBox ID="txtPassword" runat="server" type="text" TextMode="Password"></asp:TextBox>
                <br />
                <p class="heading">Display Name</p>
                <asp:TextBox ID="txtDisplayName" runat="server" type="text"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="btnRegister" runat="server" OnClick="btnRegister_Click1" Text="Register" />
                <br />
                <br />
                <asp:Label ID="lblRegMessage" runat="server" Text="Register Message" Visible="False"></asp:Label>
                <p>Already have an account? Login<a href="Default.aspx">here!</a></p>
                </div>
            
            </div>
    </form>
</body>
</html>
