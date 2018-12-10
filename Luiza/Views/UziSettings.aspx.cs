using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_UziSettings : System.Web.UI.Page
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
    }

    protected void uziCalendar_SelectionChanged(object sender, EventArgs e)
    {
        uziDate.Text = uziCalendar.SelectedDate.ToShortDateString();
        errorLabel.Text = "";
    }

    protected void UziShedGV_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void UziShedGV_PreRender(object sender, EventArgs e)
    {
        if (UziShedGV.Rows.Count > 0)
        {
            Button1.Visible = false;
            Button3.Visible = true;
        }
        else
        {
            Button1.Visible = true;
            Button3.Visible = false;
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        var day = from o in db.Uzi_Zapisi
                  where o.date == uziDate.Text
                  where o.city == uziCity.SelectedValue
                  where o.mo == uziMo.SelectedValue
                  where o.doctor == uziDoctor.SelectedValue
                  select o;
        foreach (var zapis in day)
        {
            db.Uzi_Zapisi.DeleteOnSubmit(zapis);
            db.SubmitChanges();
        }
        UziShedGV.DataBind();
        errorLabel.Text = "Расписание удалено";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        var dur = from o in db.Uzi_Cities
                  where o.city == uziCity.SelectedValue
                  where o.mo == uziMo.SelectedValue
                  select o;
        priem(doctorStart.Text, doctorEnd.Text, Convert.ToInt16(dur.ToList().ElementAt(0).duration.ToString()), uziCity.SelectedValue, uziDate.Text, uziMo.SelectedValue, uziDoctor.SelectedValue);
    }

    protected void Button2_Click(object sender, EventArgs e)
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

    public void priem(string startTime, string endTime, int visitTime, string City, string Date, string MO, string Doctor)
    {
        errorLabel.ForeColor = System.Drawing.Color.Red;
        errorLabel.Text = "";
        try
        {
            var visits = from o in db.Uzi_Zapisi
                         where o.city == uziCity.SelectedValue.ToString()
                         where o.mo == uziMo.SelectedValue.ToString()
                         where o.date == uziDate.Text
                         where o.doctor == uziDoctor.SelectedValue
                         select o;
            if (visits.Count() > 0)
            {
                errorLabel.ForeColor = System.Drawing.Color.Red;
                errorLabel.Text = "На этот день уже есть расписание!";
            }
            else
            {
                TimeSpan ts = new TimeSpan(0, visitTime, 0);
                var start = Convert.ToDateTime(startTime);
                var end = Convert.ToDateTime("20:00");
                List<string> vs = new List<string>();
                for (int i=0;  start >= Convert.ToDateTime("7:30"); i++)
                {
                    start = start - ts;
                }
                for (int i = 0; start.Add(ts) < end; i++)
                {
                    Uzi_Zapisi uz = new Uzi_Zapisi();
                    if (i > 0)
                    {
                        start = start.Add(ts);
                    }
                    vs.Add(start.ToShortTimeString());
                    uz.name_1 = "";
                    uz.name_2 = "";
                    uz.name_3 = "";
                    uz.admin= "";
                    uz.city = City;
                    uz.date = Date;
                    uz.age = "";
                    uz.sex = "";
                    uz.services = "";
                    uz.accept = false;
                    uz.doctor = Doctor;
                    uz.mo = MO;
                    uz.phone = "";
                    uz.time = vs.ElementAt(i).ToString();
                    uz.comment = "";
                    if (Convert.ToDateTime(vs.ElementAt(i)) >= Convert.ToDateTime(startTime) && Convert.ToDateTime(vs.ElementAt(i)) < Convert.ToDateTime(endTime))
                    {
                        uz.hidden = false;
                    }
                    else
                    {
                        uz.hidden = true;
                    }
                    db.GetTable<Uzi_Zapisi>().InsertOnSubmit(uz);
                    db.SubmitChanges();
                }
                errorLabel.ForeColor = System.Drawing.Color.Green;
                errorLabel.Text = "Расписание создано";
                UziShedGV.DataBind();
            }
        }
        catch
        {
            errorLabel.ForeColor = System.Drawing.Color.Red;
            errorLabel.Text = "Ошибка";
        }

    }

    protected void UziShedGV_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
}