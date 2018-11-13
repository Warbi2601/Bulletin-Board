<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="BulletinBoard.Account" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Account</title>
    <link href="CSS.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    	<header>
		<p class="logo"><img src="images/bnlogo.jpg" alt="" width="79" height="70"></p>
		<h1 class="subtitle"> Bolton Now Forum - My Account&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;
            </h1>
		<nav>
			<ul >
				<li><asp:Button ID="btnBoards" runat="server" OnClick="btnBoards_Click" Text="Boards" Width="133px" BackColor="Transparent" BorderColor="Transparent" ForeColor="White" Font-Size="20px" /></li>
				<li>|</li>
                <li><asp:Button ID="btnMyAccount" runat="server" OnClick="btnMyAccount_Click" Text="My Account" Width="133px" BackColor="Transparent" BorderColor="Transparent" ForeColor="White" Font-Size="20px" /></li>
				<li>|</li>
			    <li><asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Logout" Width="133px" BackColor="Transparent" BorderColor="Transparent" Font-Size="20px" ForeColor="White" /></li>
                <li>|</li>
                <li><asp:Button ID="btnAdmin" runat="server" OnClick="btnAdmin_Click" Text="Admin Page" Width="133px" BackColor="Transparent" BorderColor="Transparent" ForeColor="White" Font-Size="20px" /></li>
			</ul>
		</nav>
	</header>
        <div class="white">
            <br />
            <br />
            <p>Change Password</p>
            <br />
            <p>Current Password</p>
            <p>
                <asp:TextBox ID="txtOldPass" runat="server" TextMode="Password"></asp:TextBox>
            </p>
            <p>New Password</p>
            <asp:TextBox ID="txtNewPass" runat="server" type="text" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnPass" runat="server" OnClick="btnPass_Click" Text="Change Password" />
            <br />
            <br />
            <asp:Label ID="lblPassMessage" runat="server" Text="Change Pass Message" Visible="False"></asp:Label>
            <br />
            <br />
            <h2 class="title">
                <asp:Label ID="lblYourPosts" runat="server" Text="Your Posts"></asp:Label>
            </h2>
            <p class="title">
                <asp:Label ID="lblNoPosts" runat="server" ForeColor="Red" Text="You haven't posted anything yet! Head over to the Boards page to post now" Visible="False"></asp:Label>
            </p>
            <br />
            <asp:DataList ID="DataList1" runat="server" CellPadding="4" DataKeyField="ID" DataSourceID="SqlDataSource1" ForeColor="#333333" Width="1000px">
                <AlternatingItemStyle BackColor="White" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <ItemStyle BackColor="#EFF3FB" />
                <ItemTemplate>
                    Board Posted to:&nbsp;<asp:Label ID="BoardNameLabel" runat="server" Text='<%# Eval("BoardName") %>' />
                    <br />
                    <br />
                    <asp:Label ID="TextLabel" runat="server" Text='<%# Eval("Text") %>' />
                    <br />
                    <br />
                    <p class="small">
                    Posted By:
                    <asp:Label ID="CreatorNameLabel" runat="server" Text='<%# Eval("CreatorName") %>' />
                        on
                    <asp:Label ID="DateCreatedLabel" runat="server" Text='<%# Eval("DateCreated") %>' />
                        &nbsp;at
                    <asp:Label ID="TimeCreatedLabel" runat="server" Text='<%# Eval("TimeCreated") %>' />
                    </p>
                    <br />
                </ItemTemplate>
                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            </asp:DataList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Posts] WHERE ([CreatorID] = @CreatorID)">
                <SelectParameters>
                    <asp:QueryStringParameter Name="CreatorID" QueryStringField="id" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
         </div>
    </form>
</body>
</html>