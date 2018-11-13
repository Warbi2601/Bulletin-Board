<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateBoard.aspx.cs" Inherits="BulletinBoard.CreateBoard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create Board</title>
    <link href="CSS.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class = "centerbox">
            <div class = "boxcont">
                <h2>Create Board</h2>

                <p class="heading">Board Subject Name</p>
                <asp:TextBox ID="txtSubject" runat="server" type="text" Height="54px" TextMode="MultiLine" Width="323px"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="btnCreateBoard" runat="server" Text="Create Board" OnClick="btnCreateBoard_Click" />
                <br />
                <br />
                <asp:Label ID="lblCreateBoardMessage" runat="server" Text="Create Board Message" Visible="False"></asp:Label>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
        <asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Logout" />
                </div>
            
            </div>
    </form>
</body>
</html>
