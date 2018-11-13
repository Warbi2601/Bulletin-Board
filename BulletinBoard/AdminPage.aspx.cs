using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BulletinBoard
{
    public partial class AdminPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null) Response.Redirect("Default.aspx"); // Checks that the user is logged in

            if (Session["UserType"].ToString() != "Admin") Response.Redirect("Boards.aspx"); //checks to see if the user is an admin so 
                                                                                             //it knows whether to display the button that goes to Admin page

            btnBoards.Attributes.Add("onMouseOver", "this.className='hoverbutton'");        // shows pointer when it hovers over the buttons
            btnMyAccount.Attributes.Add("onMouseOver", "this.className='hoverbutton'");
            btnLogout.Attributes.Add("onMouseOver", "this.className='hoverbutton'");
            btnAdmin.Attributes.Add("onMouseOver", "this.className='hoverbutton'");
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
                if (e.CommandName == "deleteUser") //functionality for deleting a user
                {
                SQLDatabase.DatabaseTable tUsers = new SQLDatabase.DatabaseTable("Users", "DELETE FROM Users WHERE ID = " + e.CommandArgument.ToString());

                Response.Redirect("AdminPage.aspx"); //refreshes page to show that the user has been deleted
                }
        }

        protected void btnBoards_Click(object sender, EventArgs e)
        {
            Response.Redirect("Boards.aspx");
        }

        protected void btnMyAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("account.aspx?id=" + Session["UserID"]);
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("UserID");
            Session.Remove("BoardID");
            Session.Remove("BoardName");
            Session.Remove("Name");
            Session.Remove("Username");
            Session.Remove("UserType");
            Session.Remove("tempLastLoginDate");
            Session.Remove("tempLastLoginTime");
            Session.Remove("LastLoginDate");
            Session.Remove("LastLoginTime");
            Response.Redirect("Default.aspx");
        }

        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPage.aspx");
        }
    }
}