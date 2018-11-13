using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BulletinBoard
{
    public partial class CreatePost : System.Web.UI.Page
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

        protected void btnCreatePost_Click(object sender, EventArgs e)
        {
            string text = txtPost.Text;
            DateTime dt = DateTime.Now;     //gets current Date and Time from the system

            if (txtPost.Text == String.Empty)   //validation to make sure the textbox has been filled in
            {
                lblCreatePostMessage.Text = "You have not completed one or more required fields";
                lblCreatePostMessage.Visible = true;
                return;
            }

            SQLDatabase.DatabaseTable tPosts = new SQLDatabase.DatabaseTable("Posts");

            SQLDatabase.DatabaseRow row = tPosts.NewRow();

            row.Add("ID", tPosts.GetNextID().ToString());   // adding all the information neccessary to create a post in the db
            row.Add("Text", text);
            row.Add("CreatorID", Session["UserID"].ToString()); //need to make it so it displays the user ID.
            row.Add("CreatorName", Session["Name"].ToString());
            row.Add("BoardID", Session["BoardID"].ToString()); //need to make it so it displays the user ID.
            row.Add("BoardName", Session["BoardName"].ToString());
            row.Add("DateCreated", dt.ToString("dddd, dd MMMM yyyy"));
            row.Add("TimeCreated", dt.ToString("h: mm tt"));

            tPosts.Insert(row);

            Response.Redirect("Boards.aspx"); // takes you back to the boards page after you have created the post
        }
    }

}