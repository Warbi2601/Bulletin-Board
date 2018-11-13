using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

using System.Data.SqlClient;
using System.Configuration;

namespace BulletinBoard
{
    public partial class Boards : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string welcomeMessage = "";

            if (Session["UserID"] == null) Response.Redirect("Default.aspx"); // Checks that the user is logged in

            if (Session["UserType"].ToString() != "Admin")      //checks to see if the user is an admin so 
                                                                //it knows whether to display the button that goes to Admin page
            {
                btnAdmin.Visible = false;
            }

            if (Session["tempLastLoginDate"].ToString() == "" && Session["tempLastLoginTime"].ToString() == "") // checks if this is the first time the user has logged in and outputs the relevent message
            {
                welcomeMessage = "Welcome to the Bolton Now Forum " + Session["Name"].ToString() + ". This is the first time you have logged in.";
            }
            else
            {
                welcomeMessage = "Welcome to the Bolton Now Forum " + Session["Name"].ToString() + " You last logged in on " + Session["tempLastLoginDate"].ToString() + " at " + Session["tempLastLoginTime"].ToString();
            }

            btnBoards.Attributes.Add("onMouseOver", "this.className='hoverbutton'");        // shows pointer when it hovers over the buttons
            btnMyAccount.Attributes.Add("onMouseOver", "this.className='hoverbutton'");
            btnLogout.Attributes.Add("onMouseOver", "this.className='hoverbutton'");
            btnAdmin.Attributes.Add("onMouseOver", "this.className='hoverbutton'");

            lblWelcome.Text = welcomeMessage;
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

        protected void btnCreateBoard_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("CreateBoard.aspx");
        }

        protected void btnBoards_Click(object sender, EventArgs e)
        {
            Response.Redirect("Boards.aspx");
        }

        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPage.aspx");
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "openBoard")   //stores the boardID of the board that has been clicked into a session for later use
            {
                Session["BoardID"] = e.CommandArgument.ToString();
                SQLDatabase.DatabaseTable boardName = new SQLDatabase.DatabaseTable("Boards", "SELECT * FROM Boards");

                int i = Convert.ToInt32(e.CommandArgument.ToString());

                Session["BoardName"] = boardName.FindRow("ID", e.CommandArgument.ToString())["Name"];

                Response.Redirect("posts.aspx?id=" + Session["BoardID"]);
            }
        }

        protected void btnMyAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("account.aspx?id=" + Session["UserID"]);
        }
    }
}