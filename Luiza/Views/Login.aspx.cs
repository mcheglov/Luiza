using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Login : System.Web.UI.Page
{
    toSQLDataContext db = new toSQLDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void loginBtn_Click(object sender, EventArgs e)
    {
        var toCheck = (from u in db.Users
                       where u.Login == loginTextbox.Text
                       where u.Password == passwordTextbox.Text
                       select u);
        if (toCheck.Count() == 0)
        {
            errorLabel.Text = "Ошибка авторизации";
        }
        if (toCheck.Count() == 1)
        {
            errorLabel.Text = "";
            Response.Cookies["Visitor"]["user"] = toCheck.ToList().ElementAt(0).Login.ToString();
            Response.Cookies["Visitor"]["rights"] = toCheck.ToList().ElementAt(0).Rights.ToString();
            Response.Cookies["Visitor"].Expires = DateTime.Now.AddDays(1);
            Response.Redirect("/Views/Default.aspx");
        }
    }
}