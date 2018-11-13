using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BulletinBoard
{
    public partial class Default : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            DateTime dt = DateTime.Now; //gets current Date and Time from the system

            SQLDatabase.DatabaseTable usernames = new SQLDatabase.DatabaseTable("Users", "SELECT * FROM Users");

            for (int i = 0; i < usernames.RowCount; i++) //loops through the users table to validate if the username and password are linked to a user in the db
            {
                SQLDatabase.DatabaseRow row = usernames.GetRow(i);
                if (row["Username"] == email && row["Password"] == password)
                {
                    Session["TempLastLoginDate"] = row["LastLoginDate"];    //stores the last login date/time before they log in and it is updated.
                    Session["TempLastLoginTime"] = row["LastLoginTime"];    //this is to show them their last login date/time after they login


                    row.Add("LastLoginDate", dt.ToString("dddd, dd MMMM yyyy")); //updates their last login date/time to the current date/time
                    row.Add("LastLoginTime", dt.ToString("h: mm tt"));
                    usernames.Update(row);



                    Session["UserID"] = row["ID"]; //stores all their info in sessions for easy access later.
                    Session["Name"] = row["Name"];
                    Session["Username"] = row["Username"];
                    Session["UserType"] = row["UserType"];
                    Session["LastLoginDate"] = row["LastLoginDate"];
                    Session["LastLoginTime"] = row["LastLoginTime"];

                    Response.Redirect("Boards.aspx");
                }
            }

            lblLogMessage.Text = "Username or Password not valid";
            lblLogMessage.Visible = true;
        }
    }
}