using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Layout : System.Web.UI.MasterPage
{
    toSQLDataContext db = new toSQLDataContext();
    string rights;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["Visitor"] == null)
        {
            Response.Redirect("403.aspx");
        }
        var name = (from o in db.Users
                    where o.Login == Request.Cookies["Visitor"]["user"]
                    select o);
        userLabel.Text = "Вы вошли как : " + name.ToList().ElementAt(0).Username.ToString();
        rights = name.ToList().ElementAt(0).Rights.ToString();
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Cookies["Visitor"].Expires = DateTime.Now.AddDays(-1);
        Response.Redirect("http://suz.invitro.ru");
    }

    protected void Unnamed3_Click(object sender, EventArgs e)
    {
        if (rights == "Admin")
        {
            Response.Redirect("/Views/Sperm.aspx?param1=1");
        }
        else
        {
            Response.Redirect("/Views/Sperm.aspx?param1=0");
        }
    }

    protected void Unnamed5_Click(object sender, EventArgs e)
    {

    }

    protected void UziBT_Click(object sender, EventArgs e)
    {
        if (rights == "Admin")
        {
            Response.Redirect("/Views/Uzi.aspx?param1=1");
        }
        else
        {
            Response.Redirect("/Views/Uzi.aspx?param1=0");
        }
    }
}
