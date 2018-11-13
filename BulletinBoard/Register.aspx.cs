using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BulletinBoard
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click1(object sender, EventArgs e)
        {
            string id;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string displayName = txtDisplayName.Text;
            string userType = "User";
            bool emailFound = false;
            bool nameFound = false;


            if (txtDisplayName.Text == String.Empty || txtEmail.Text == String.Empty || txtPassword.Text == String.Empty) //validation for empty textboxes
            {
                lblRegMessage.Text = "You have not completed one or more required fields";
                lblRegMessage.Visible = true;
                return;
            }

            SQLDatabase.DatabaseTable tUsers = new SQLDatabase.DatabaseTable("Users");

            SQLDatabase.DatabaseRow row = tUsers.NewRow();

            row.Add("ID", tUsers.GetNextID().ToString()); // adds all required details to create a user
            row.Add("Name", displayName);
            row.Add("Username", email);
            row.Add("Password", password);
            row.Add("UserType", userType);

            SQLDatabase.DatabaseTable usernames = new SQLDatabase.DatabaseTable("Users", "SELECT * FROM Users");

            for (int i = 0; i < usernames.RowCount; i++) //loops through the user table to check if the inputted email is already taken by another user
            {
                if (usernames.GetRow(i)["Username"] == email)
                {
                    emailFound = true;
                    break;
                }
            }

            for (int n = 0; n < usernames.RowCount; n++) //loops through the user table to check if the inputted email is already taken by another user
            {
                if (usernames.GetRow(n)["Name"] == displayName)
                {
                    nameFound = true;
                    break;
                }
            }
        
            if (!emailFound && !nameFound) // if neither are duplicates then add the user
            {
                tUsers.Insert(row);
            }
            else
            {
                if(emailFound && !nameFound) //if email is taken but display name not, tell the user
                {
                    lblRegMessage.Text = "That Email Address is already taken, please enter a different one.";
                }
                if (nameFound && !emailFound) //if display name is taken but email not, tell the user
                {
                    lblRegMessage.Text = "That Display Name is already taken, please enter a different one.";
                }
                if (nameFound && emailFound) //if display name  and email are taken, tell the user
                {
                    lblRegMessage.Text = "That Display Name and Email Address is already taken, please enter a different one.";

                }

                lblRegMessage.Visible = true;
                return;
            }

            SQLDatabase.User u = tUsers.GetUser(0); // stores the users into a class incase they are needed in the future

            id = u.ID;
            displayName = u.displayName;
            email = u.email;
            password = u.password;
            u.userType = userType;

            Response.Redirect("Default.aspx");
            

        }
    }
}