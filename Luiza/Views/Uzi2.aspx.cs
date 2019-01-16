using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Uzi2 : System.Web.UI.Page
{
    toSQLDataContext db = new toSQLDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["param1"] == "1")
        {
            adminMenu.Visible = true;
        }
        else
        {
            adminMenu.Visible = false;
        }
        if (!IsPostBack)
        {

            SubmitBT.Text = "ЗАПИСАТЬ";
            if (CityDL.Items.Count == 0)
            {
                var cities = (from o in db.Uzi_Cities
                              select new { o.city }).Distinct();
                CityDL.Items.Clear();
                for (int i = 0; i < cities.Count(); i++)
                {
                    CityDL.Items.Add(cities.ToList().ElementAt(i).city.ToString());
                }
                var mos = from o in db.Uzi_Cities
                          where o.city == CityDL.SelectedValue.ToString()
                          select o;
                MoDL.Items.Clear();
                for (int i = 0; i < mos.Count(); i++)
                {
                    MoDL.Items.Add(mos.ToList().ElementAt(i).mo.ToString());
                }
            }
            if (DateDL.Items.Count == 0)
            {
                DateTime dt1 = DateTime.Now;
                var temp = (from d in db.Uzi_Zapisi
                            where d.city == CityDL.SelectedValue.ToString()
                            where d.mo == MoDL.SelectedValue.ToString()
                            select d.date).Distinct();
                var days = temp.ToList();
                DateDL.Items.Clear();
                DateTime[] dates = new DateTime[days.Count()];
                for (int i = 0; i < days.Count(); i++)
                {
                    dates[i] = DateTime.ParseExact(days[i].ToString(), "dd.M.yyyy", null);
                }
                dates = dates.OrderByDescending(d => d).ToArray();
                for (int i = 0; i < days.Count(); i++)
                {
                    DateDL.Items.Add(dates[i].ToShortDateString());
                }
            }
        }

    }

    protected void SettingsBT_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Views/UziSettings.aspx");
    }

    protected void SubmitBT_Click(object sender, EventArgs e)
    {

    }

    protected void UziGV_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.Cells[10].Text == "True")
        {
            e.Row.Cells[10].BackColor = System.Drawing.ColorTranslator.FromHtml("#66FF66");
            e.Row.Cells[10].ForeColor = System.Drawing.Color.Red;
            e.Row.Cells[10].Text = "Подтвержден";
        }
        else if (e.Row.Cells[10].Text == "False")
        {
            e.Row.Cells[10].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFF66");
            e.Row.Cells[10].ForeColor = System.Drawing.Color.Red;
            e.Row.Cells[10].Text = "Не подтвержден";
        }
    }

    protected void CityDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        var mos = from o in db.Uzi_Cities
                  where o.city == CityDL.SelectedValue.ToString()
                  select o;
        MoDL.Items.Clear();
        for (int i = 0; i < mos.Count(); i++)
        {
            MoDL.Items.Add(mos.ToList().ElementAt(i).mo.ToString());
        }
        DateTime dt1 = DateTime.Now;
        var temp = (from d in db.Uzi_Zapisi
                    where d.city == CityDL.SelectedValue.ToString()
                    where d.mo == MoDL.SelectedValue.ToString()
                    select d.date).Distinct();
        var days = temp.ToList();
        DateDL.Items.Clear();
        DateTime[] dates = new DateTime[days.Count()];
        for (int i = 0; i < days.Count(); i++)
        {
            dates[i] = DateTime.ParseExact(days[i].ToString(), "dd.M.yyyy", null);
        }
        dates = dates.OrderByDescending(d => d).ToArray();
        for (int i = 0; i < days.Count(); i++)
        {
            DateDL.Items.Add(dates[i].ToShortDateString());
        }
    }

    protected void MoDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        DateTime dt1 = DateTime.Now;
        var temp = (from d in db.Uzi_Zapisi
                    where d.city == CityDL.SelectedValue.ToString()
                    where d.mo == MoDL.SelectedValue.ToString()
                    select d.date).Distinct();
        var days = temp.ToList();
        DateDL.Items.Clear();
        DateTime[] dates = new DateTime[days.Count()];
        for (int i = 0; i < days.Count(); i++)
        {
            dates[i] = DateTime.ParseExact(days[i].ToString(), "dd.M.yyyy", null);
        }
        dates = dates.OrderByDescending(d => d).ToArray();
        for (int i = 0; i < days.Count(); i++)
        {
            DateDL.Items.Add(dates[i].ToShortDateString());
        }
    }
}