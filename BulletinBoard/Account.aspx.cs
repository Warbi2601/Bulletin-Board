using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BulletinBoard
{
    public partial class Account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null) Response.Redirect("Default.aspx"); // Checks that the user is logged in

            if (Session["UserType"].ToString() != "Admin")  //checks to see if the user is an admin so 
                                                            //it knows whether to display the button that goes to Admin page
            {
                btnAdmin.Visible = false;
            }

            if (DataList1.Items.Count == 0) // checks if the user doesnt have any posts and outputs a message
            {
                lblNoPosts.Visible = true;
            }

            btnBoards.Attributes.Add("onMouseOver", "this.className='hoverbutton'");    // shows pointer when it hovers over the buttons
            btnMyAccount.Attributes.Add("onMouseOver", "this.className='hoverbutton'");
            btnLogout.Attributes.Add("onMouseOver", "this.className='hoverbutton'");
            btnAdmin.Attributes.Add("onMouseOver", "this.className='hoverbutton'");
        }

        protected void btnPass_Click(object sender, EventArgs e)
        {
            {
                string newPassword = txtNewPass.Text;

                if (txtNewPass.Text == String.Empty || txtOldPass.Text == String.Empty)  //validation for empty textboxes
                {
                    lblPassMessage.Text = "You have not completed one or more required fields";
                    lblPassMessage.Visible = true;
                    return;
                }

                SQLDatabase.DatabaseTable usernames = new SQLDatabase.DatabaseTable("Users", "SELECT * FROM Users");


                for (int i = 0; i < usernames.RowCount; i++) // loops through the users table to find the row of the
                                                             // current user stored on the session
                {
                    if (usernames.GetRow(i)["ID"] == Session["UserID"].ToString())
                    {
                        if (txtOldPass.Text == usernames.GetRow(i)["Password"]) // validation that the old password was correct
                        {
                            usernames.GetRow(i)["Password"] = newPassword; //changes password
                            usernames.Update(usernames.GetRow(i));
                            lblPassMessage.Text = "Password Successfully Changed";
                            lblPassMessage.Visible = true;
                            txtNewPass.Text = "";
                            txtOldPass.Text = "";
                            break;
                        }
                        else
                        {
                            lblPassMessage.Text = "Incorrect Password";
                            lblPassMessage.Visible = true;
                        }
                    }
                }
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
            Session.Remove("UserID"); //removes all sessions
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