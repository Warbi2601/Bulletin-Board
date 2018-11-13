<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="BulletinBoard.AdminPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Page</title>
    <link href="CSS.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
    	<header>
		<p class="logo"><img src="images/bnlogo.jpg" alt="" width="79" height="70"></p>
		<h1 class="subtitle"> Bolton Now Forum - User Management&nbsp;&nbsp;
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
            <div>
                <p class="heading">
                    <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" DataKeyField="ID" Height="856px" Width="1291px" CellPadding="4" ForeColor="#333333" OnItemCommand="DataList1_ItemCommand">
                        <AlternatingItemStyle BackColor="White" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <ItemStyle BackColor="#EFF3FB" />
                        <ItemTemplate>
          <table>
            <tr>
                <th>ID</th> 
                <th>Name</th>
                <th>Username</th>
                <th>Password</th> 
                <th>User Type</th> 
                <th>Last Login Date</th> 
                <th>Last Login Time</th>
                <th><asp:Button ID="btnDeleteUser" runat="server" Text="DeleteUser" CommandName="deleteUser" CommandArgument='<%# Eval("id") %>'/></th>
            </tr>
            <tr>
                <td><asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' /></td>
                <td><asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' /></td>
                <td><asp:Label ID="UsernameLabel" runat="server" Text='<%# Eval("Username") %>' /></td> 
                <td><asp:Label ID="PasswordLabel" runat="server" Text='<%# Eval("Password") %>' /></td> 
                <td><asp:Label ID="UserTypeLabel" runat="server" Text='<%# Eval("UserType") %>' /></td> 
                <td><asp:Label ID="LastLoginDateLabel" runat="server" Text='<%# Eval("LastLoginDate") %>' /></td> 
                <td><asp:Label ID="LastLoginTimeLabel" runat="server" Text='<%# Eval("LastLoginTime") %>' /></td> 
            </tr>
          </table>
                        </ItemTemplate>
                        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SeparatorTemplate>
                            <hr />
                        </SeparatorTemplate>
                    </asp:DataList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Users]"></asp:SqlDataSource>
    </div>
                    </form>
</body>
</html>
