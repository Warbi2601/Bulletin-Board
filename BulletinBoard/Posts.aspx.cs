using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BulletinBoard
{
    public partial class Posts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string boardName = "";

            if (Session["UserID"] == null) Response.Redirect("Default.aspx"); // Checks that the user is logged in

            if (Session["UserType"].ToString() != "Admin")      //checks to see if the user is an admin so 
                                                                //it knows whether to display the button that goes to Admin page
            {
                btnAdmin.Visible = false;
            }

            SQLDatabase.DatabaseTable boardID = new SQLDatabase.DatabaseTable("Boards", "SELECT * FROM Boards");

            for (int i = 0; i < boardID.RowCount; i++) // loops through the boards db to get the BoardID and store it in a session
            {
                if (boardID.GetRow(i)["ID"] == Session["BoardID"].ToString())
                {
                boardName = boardID.GetRow(i)["Name"].ToString(); // sets the board name variable to the board name stored in the db
                break;
                }
            }

            btnBoards.Attributes.Add("onMouseOver", "this.className='hoverbutton'"); // shows pointer when it hovers over the buttons
            btnMyAccount.Attributes.Add("onMouseOver", "this.className='hoverbutton'");
            btnLogout.Attributes.Add("onMouseOver", "this.className='hoverbutton'");
            btnAdmin.Attributes.Add("onMouseOver", "this.className='hoverbutton'");

            lblCurrentBoard.Text = boardName;
        }

        protected void btnCreatePost_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreatePost.aspx");
        }

        protected void btnBoards_Click(object sender, EventArgs e)
        {
            Response.Redirect("Boards.aspx");
        }

        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPage.aspx");
        }

        protected void btnMyAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("account.aspx?id=" + Session["UserID"]);
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("UserID"); // removes all sessions
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
    }
}