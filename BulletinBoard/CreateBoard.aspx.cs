using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Configuration;

namespace BulletinBoard
{
    public partial class CreateBoard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null) Response.Redirect("Default.aspx"); // Checks that the user is logged in
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

        protected void btnCreateBoard_Click(object sender, EventArgs e)
        {
            string subject = txtSubject.Text;
            DateTime dt = DateTime.Now; //gets current Date and Time from the system
            //Session["BoardName"] = subject; //stores the boardname in a session for later use


            if (txtSubject.Text == String.Empty) // validation for empty textboxes
            {
                lblCreateBoardMessage.Text = "You have not completed one or more required fields";
                lblCreateBoardMessage.Visible = true;
                return;
            }

            SQLDatabase.DatabaseTable tBoards = new SQLDatabase.DatabaseTable("Boards");

            SQLDatabase.DatabaseRow row = tBoards.NewRow();

            row.Add("ID", tBoards.GetNextID().ToString()); // adds all the info needed to create a new board in the db
            row.Add("Name", subject);
            row.Add("CreatorID", Session["UserID"].ToString()); //need to make it so it displays the user ID.
            row.Add("CreatorName", Session["Name"].ToString());
            row.Add("DateCreated", dt.ToString("dddd, dd MMMM yyyy"));
            row.Add("TimeCreated", dt.ToString("h: mm tt"));

            tBoards.Insert(row);

            Response.Redirect("Boards.aspx");
        }
    }
}