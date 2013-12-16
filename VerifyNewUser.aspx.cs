using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace sismografoenlinea
{
    public partial class VerifyNewUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                Label1.Text = "No User ID was Specified";

            }
            else
            {
                Guid userid;

                try
                {
                    userid = new Guid(Request.QueryString["ID"]);
                }
                catch
                {
                    Label1.Text = "The User ID that was Specified is not in proper format";
                    return;

                }
                MembershipUser user = Membership.GetUser(userid);

                if (user == null)
                {
                    Label1.Text = "No correspond user account could be found";

                
                }
                else if (user.IsApproved == true)
                {
                    Label1.Text = "User account already exists.....";

                }
                else
                {
                    user.IsApproved = true;
                    Membership.UpdateUser(user);
                    Label1.Text = "Your Account has been approbed.......";
                
                }

            
            }

           


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/login.aspx");
        }
    }
}