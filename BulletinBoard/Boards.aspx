<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Boards.aspx.cs" Inherits="BulletinBoard.Boards" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Boards</title>
    <link href="CSS.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    	<header>
		<p class="logo"><img src="images/bnlogo.jpg" alt="" width="79" height="70"></p>
		<h1 class="subtitle"> Bolton Now Forum - Boards&nbsp;&nbsp;
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
        <br />
        <br />
        <br />
        <asp:Label ID="lblWelcome" runat="server" ForeColor="White"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Button ID="btnCreateBoard" runat="server" OnClick="btnCreateBoard_Click" Text="Create Board" style="margin-right: 0px" Height="70px" Width="225px" />
        <br />
        <br />
        <asp:DataList ID="DataList1" runat="server" CellPadding="4" ForeColor="#333333" DataKeyField="ID" DataSourceID="SqlDataSource1" OnItemCommand="DataList1_ItemCommand" Height="621px" Width="1000px">
                  <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                  <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                  <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                  <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" />
                  <ItemTemplate>
                      <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                      <br />
                      <br />
                      <p class="small">
                      Created By:
                      <asp:Label ID="CreatorNameLabel" runat="server" Text='<%# Eval("CreatorName") %>' />
                      on
                      <asp:Label ID="DateCreatedLabel" runat="server" Text='<%# Eval("DateCreated") %>' />
                      &nbsp;at
                      <asp:Label ID="TimeCreatedLabel" runat="server" Text='<%# Eval("TimeCreated") %>' />
                      <br />
                      </p>
                      <asp:Button ID="Button1" runat="server" CommandName="openBoard" Text="View Board" CommandArgument='<%# Eval("id") %>' />
                      <br />
                </ItemTemplate>
                  <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        </asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Boards]"></asp:SqlDataSource>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
