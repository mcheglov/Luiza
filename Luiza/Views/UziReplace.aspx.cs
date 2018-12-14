using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_UziReplace : System.Web.UI.Page
{
    string rights;
    toSQLDataContext db = new toSQLDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["Visitor"] == null)
        {
            Response.Redirect("/Views/403.aspx");
        }
        var name = (from o in db.Users
                    where o.Login == Request.Cookies["Visitor"]["user"]
                    select o);
        rights = name.ToList().ElementAt(0).Rights.ToString();
        var zapis = from z in db.Uzi_Zapisi
                    where z.ID == Convert.ToInt32(Request.QueryString["ID"])
                    select z;
        if (zapis.ToList().ElementAt(0).accept.ToString() == "False")
        {
            name_1LBL.BackColor = System.Drawing.Color.Yellow;
        }
        else
        {
            name_1LBL.BackColor = System.Drawing.Color.Green;
            name_1LBL.ForeColor = System.Drawing.Color.White;
        }
        name_1LBL.Text = zapis.ToList().ElementAt(0).name_1.ToString();
        name_2LBL.Text = zapis.ToList().ElementAt(0).name_2.ToString();
        name_3LBL.Text = zapis.ToList().ElementAt(0).name_3.ToString();
        dateLBL.Text = zapis.ToList().ElementAt(0).date.ToString();
        timeLBL.Text = zapis.ToList().ElementAt(0).time.ToString();
        cityLBL.Text = zapis.ToList().ElementAt(0).city.ToString();
        moLBL.Text = zapis.ToList().ElementAt(0).mo.ToString();
        doctorLBL.Text = zapis.ToList().ElementAt(0).doctor.ToString();
        testLBL.Text = zapis.ToList().ElementAt(0).services.ToString();
        IDLBL.Text = Request.QueryString["ID"];
        commentLBL.Text = zapis.ToList().ElementAt(0).comment.ToString();
        phoneLBL.Text = zapis.ToList().ElementAt(0).phone.ToString();
    }

    protected void Button3_Click(object sender, EventArgs e)
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        Uzi_Zapisi editZapis = db.Uzi_Zapisi.SingleOrDefault(x => x.ID == Convert.ToInt32(Request.QueryString["ID"]));
        editZapis.accept = true;
        db.SubmitChanges();
        Response.Redirect(Request.Url.AbsoluteUri);
    }

    protected void Button2_Click(object sender, EventArgs e)
    {

    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Uzi_Zapisi editZapis = db.Uzi_Zapisi.SingleOrDefault(x => x.ID == Convert.ToInt32(Request.QueryString["ID"]));
        editZapis.name_1 = "";
        editZapis.name_2 = "";
        editZapis.name_3 = "";
        editZapis.phone = "";
        editZapis.age = "";
        editZapis.sex = "";
        editZapis.services = "";
        editZapis.accept = false;
        editZapis.admin = "";
        editZapis.comment = "";
        db.SubmitChanges();
        Response.Redirect(Request.Url.AbsoluteUri);
    }
}