using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_SpermSettings : System.Web.UI.Page
{
    toSQLDataContext db = new toSQLDataContext();
    string rights;
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
        if (spermCity.Items.Count == 0)
        {
            var cities = (from o in db.Sperm_Cities
                          select new { o.City }).Distinct();
            spermCity.Items.Clear();
            for (int i = 0; i < cities.Count(); i++)
            {
                spermCity.Items.Add(cities.ToList().ElementAt(i).City.ToString());
            }
            var mos = from o in db.Sperm_Cities
                      where o.City == spermCity.SelectedValue.ToString()
                      select o;
            spermMo.Items.Clear();
            for (int i = 0; i < mos.Count(); i++)
            {
                spermMo.Items.Add(mos.ToList().ElementAt(i).MO.ToString());
            }
            var doctor = from o in db.Sperm_Doctor
                         where o.city == spermCity.SelectedValue.ToString()
                         where o.mo == spermMo.SelectedValue.ToString()
                         select o;
            spermDoctor.Items.Clear();
            if (doctor.Count() > 0)
            {
                for (int i = 0; i < doctor.Count(); i++)
                {
                    spermDoctor.Items.Add(doctor.ToList().ElementAt(i).name.ToString());
                }

            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            priem(doctorStart.Text, doctorEnd.Text, Convert.ToInt16(doctorTimespan.Text), spermCity.SelectedValue.ToString(), spermDate.Text, spermMo.SelectedValue.ToString(), spermDoctor.SelectedValue.ToString());
        }
        catch
        {
            errorLabel.ForeColor = System.Drawing.Color.Red;
            errorLabel.Text = "Ошибка";
        }
    }

    public void priem(string startTime, string endTime, int visitTime, string City, string Date, string MO, string Doctor)
    {
        errorLabel.ForeColor = System.Drawing.Color.Red;
        errorLabel.Text = "";
        try
        {
            var visits = from o in db.Sperm_Zapisi
                         where o.city == spermCity.SelectedValue.ToString()
                         where o.mo == spermMo.SelectedValue.ToString()
                         where o.date == spermDate.Text
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
                var end = Convert.ToDateTime(endTime);
                List<string> vs = new List<string>();
                for (int i = 0; start.Add(ts) < end; i++)
                {
                    Sperm_Zapisi sz = new Sperm_Zapisi();
                    if (i > 0)
                    {
                        start = start.Add(ts);
                    }
                    vs.Add(start.ToShortTimeString());
                    sz.name_1 = "";
                    sz.name_2 = "";
                    sz.name_3 = "";
                    sz.administrator = "";
                    sz.call = false;
                    sz.visit = false;
                    sz.city = City;
                    sz.date = Date;
                    sz.doctor = Doctor;
                    sz.mo = MO;
                    sz.phone = "";
                    sz.time = vs.ElementAt(i).ToString();
                    sz.usluga = "";
                    db.GetTable<Sperm_Zapisi>().InsertOnSubmit(sz);
                    db.SubmitChanges();
                }
                errorLabel.ForeColor = System.Drawing.Color.Lime;
                errorLabel.Text = "Расписание создано";
            }
        }
        catch
        {
            errorLabel.ForeColor = System.Drawing.Color.Red;
            errorLabel.Text = "Ошибка";
        }

    }



    protected void spermMO_SelectedIndexChanged(object sender, EventArgs e)
    {
        var doctor = from o in db.Sperm_Doctor
                     where o.city == spermCity.SelectedValue.ToString()
                     where o.mo == spermMo.SelectedValue.ToString()
                     select o;
        spermDoctor.Items.Clear();
        if (doctor.Count() > 0)
        {
            for (int i = 0; i < doctor.Count(); i++)
            {
                spermDoctor.Items.Add(doctor.ToList().ElementAt(i).name.ToString());
            }

        }
    }

    protected void spermCalendar_SelectionChanged(object sender, EventArgs e)
    {
        spermDate.Text = spermCalendar.SelectedDate.ToShortDateString();
        errorLabel.Text = "";
    }

    protected void spermCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        var mos = from o in db.Sperm_Cities
                  where o.City == spermCity.SelectedValue.ToString()
                  select o;
        spermMo.Items.Clear();
        for (int i = 0; i < mos.Count(); i++)
        {
            spermMo.Items.Add(mos.ToList().ElementAt(i).MO.ToString());
        }
        var doctor = from o in db.Sperm_Doctor
                     where o.city == spermCity.SelectedValue.ToString()
                     where o.mo == spermMo.SelectedValue.ToString()
                     select o;
        spermDoctor.Items.Clear();
        if (doctor.Count() > 0)
        {
            for (int i = 0; i < doctor.Count(); i++)
            {
                spermDoctor.Items.Add(doctor.ToList().ElementAt(i).name.ToString());
            }

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
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
}