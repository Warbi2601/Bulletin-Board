<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreatePost.aspx.cs" Inherits="BulletinBoard.CreatePost" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create Post</title>
    <link href="CSS.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class = "centerbox">
            <div class = "boxcont">
                <h2>Create Post</h2>

                <p class="heading">Type your Post below</p>
                <asp:TextBox ID="txtPost" runat="server" type="text" Height="188px" MaxLength="300" TextMode="MultiLine" Width="470px"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="btnCreatePost" runat="server" Text="Create Post" OnClick="btnCreatePost_Click" />
                <br />
                <br />
                <asp:Label ID="lblCreatePostMessage" runat="server" Text="Create Post Message" Visible="False"></asp:Label>
                <br />
                <br />
        <asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Logout" />
                </div>
            
            </div>
    </form>
</body>
</html>
