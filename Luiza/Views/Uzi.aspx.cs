using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Uzi : System.Web.UI.Page
{
    toSQLDataContext db = new toSQLDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["param1"] == "1")
        {
            SettingsBT.Visible = true;
        }
        else
        {
            SettingsBT.Visible = false;
        }
        delBT.Visible = false;
        ChangeBT.Visible = false;
        ConfirmBT.Visible = false;
        SubmitBT.Text = "ЗАПИСАТЬ";
        //DoctorTimeLB1.Items[0].Attributes.Add("style", "background-color: Lime; color: Red");
        //DoctorTimeLB1.Items[1].Attributes.Add("style", "background-color: Yellow; color: Red");
        if (!IsPostBack)
        {

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
            var days = (from d in db.Uzi_Zapisi
                        where d.city == CityDL.SelectedValue.ToString()
                        where d.mo == MoDL.SelectedValue.ToString()
                        where d.date.Contains(dt1.ToShortDateString().Remove(0, 6))
                        select d.date).Distinct();
            DateDL.Items.Clear();
            DateTime[] dates = new DateTime[days.Count()];
            for (int i = 0; i < days.Count(); i++)
            {
                dates[i] = DateTime.ParseExact(days.ToList().ElementAt(i).ToString(), "dd.M.yyyy", null);
            }
            dates = dates.OrderByDescending(d => d).ToArray();
            for (int i = 0; i < days.Count(); i++)
            {
                DateDL.Items.Add(dates[i].ToShortDateString());
            }
        }
        if (DoctorRB1.Text == "" && DoctorRB2.Text == "" && DoctorRB3.Text == "" && DoctorRB4.Text == "" && DoctorRB5.Text == "")
        {
            var docs = (from d in db.Uzi_Zapisi
                        where d.city == CityDL.SelectedValue.ToString()
                        where d.mo == MoDL.SelectedValue.ToString()
                        where d.date == DateDL.SelectedValue
                        select d.doctor).Distinct();
            DoctorRB1.Text = "";
            DoctorRB2.Text = "";
            DoctorRB3.Text = "";
            DoctorRB4.Text = "";
            DoctorRB5.Text = "";
            block1.Style["background-color"] = "White";
            block2.Style["background-color"] = "White";
            block3.Style["background-color"] = "White";
            block4.Style["background-color"] = "White";
            block5.Style["background-color"] = "White";
            DoctorRB1.Checked = false;
            DoctorRB2.Checked = false;
            DoctorRB3.Checked = false;
            DoctorRB4.Checked = false;
            DoctorRB5.Checked = false;
            if (docs.Count() == 0)
            {
                block1.Visible = false;
                block2.Visible = false;
                block3.Visible = false;
                block4.Visible = false;
                block5.Visible = false;
            }
            else if(docs.Count() == 1)
            {
                DoctorRB1.Text =  docs.ToList().ElementAt(0).ToString();
                block1.Visible = true;
                block2.Visible = false;
                block3.Visible = false;
                block4.Visible = false;
                block5.Visible = false;
                var time = (from t in db.Uzi_Zapisi
                            where t.date == DateDL.SelectedValue
                            where t.mo == MoDL.SelectedValue
                            where t.city == CityDL.SelectedValue
                            where t.doctor== docs.ToList().ElementAt(0).ToString()
                            select t);
                for (int i=0;i<time.Count();i++)
                {
                    if (time.ToList().ElementAt(i).fio.Length > 0)
                    {
                        DoctorTimeLB1.Items.Add(time.ToList().ElementAt(i).time + " - " + time.ToList().ElementAt(i).fio);
                    }
                    else
                    {
                        DoctorTimeLB1.Items.Add(time.ToList().ElementAt(i).time);
                    }
                }
            }
            else if (docs.Count() == 2)
            {
                DoctorRB1.Text = docs.ToList().ElementAt(0).ToString();
                DoctorRB2.Text = docs.ToList().ElementAt(1).ToString();
                block1.Visible = true;
                block2.Visible = true;
                block3.Visible = false;
                block4.Visible = false;
                block5.Visible = false;
                var time = (from t in db.Uzi_Zapisi
                            where t.date == DateDL.SelectedValue
                            where t.mo == MoDL.SelectedValue
                            where t.city == CityDL.SelectedValue
                            where t.doctor == docs.ToList().ElementAt(0).ToString()
                            select t);
                for (int i = 0; i < time.Count(); i++)
                {
                    if (time.ToList().ElementAt(i).fio.Length > 0)
                    {
                        DoctorTimeLB1.Items.Add(time.ToList().ElementAt(i).time + " - " + time.ToList().ElementAt(i).fio);
                    }
                    else
                    {
                        DoctorTimeLB1.Items.Add(time.ToList().ElementAt(i).time);
                    }
                }
                var time2 = (from t in db.Uzi_Zapisi
                            where t.date == DateDL.SelectedValue
                            where t.mo == MoDL.SelectedValue
                            where t.city == CityDL.SelectedValue
                            where t.doctor == docs.ToList().ElementAt(1).ToString()
                            select t);
                for (int i = 0; i < time2.Count(); i++)
                {
                    if (time2.ToList().ElementAt(i).fio.Length > 0)
                    {
                        DoctorTimeLB2.Items.Add(time2.ToList().ElementAt(i).time + " - " + time2.ToList().ElementAt(i).fio);
                    }
                    else
                    {
                        DoctorTimeLB2.Items.Add(time2.ToList().ElementAt(i).time);
                    }
                }

            }
            else if (docs.Count() == 3)
            {
                DoctorRB1.Text = docs.ToList().ElementAt(0).ToString();
                DoctorRB2.Text = docs.ToList().ElementAt(1).ToString();
                DoctorRB3.Text = docs.ToList().ElementAt(2).ToString();
                block1.Visible = true;
                block2.Visible = true;
                block3.Visible = true;
                block4.Visible = false;
                block5.Visible = false;
            }
            else if (docs.Count() == 4)
            {
                DoctorRB1.Text = docs.ToList().ElementAt(0).ToString();
                DoctorRB2.Text = docs.ToList().ElementAt(1).ToString();
                DoctorRB3.Text = docs.ToList().ElementAt(2).ToString();
                DoctorRB4.Text = docs.ToList().ElementAt(3).ToString();
                block1.Visible = true;
                block2.Visible = true;
                block3.Visible = true;
                block4.Visible = true;
                block5.Visible = false;
            }
            else if (docs.Count() == 5)
            {
                DoctorRB1.Text = docs.ToList().ElementAt(0).ToString();
                DoctorRB2.Text = docs.ToList().ElementAt(1).ToString();
                DoctorRB3.Text = docs.ToList().ElementAt(2).ToString();
                DoctorRB4.Text = docs.ToList().ElementAt(3).ToString();
                DoctorRB5.Text = docs.ToList().ElementAt(4).ToString();
                block1.Visible = true;
                block2.Visible = true;
                block3.Visible = true;
                block4.Visible = true;
                block5.Visible = true;
            }
        }
        }

    }

    protected void SettingsBT_Click(object sender, EventArgs e)
    {

    }

    protected void SubmitBT_Click(object sender, EventArgs e)
    {

    }

    protected void MiddlenameTB_TextChanged(object sender, EventArgs e)
    {

    }

    protected void DoctorRB1_CheckedChanged(object sender, EventArgs e)
    {
        if (DoctorRB1.Checked)
        {
            block1.Style["background-color"] = "#CCFFCC";
            block2.Style["background-color"] = "White";
            block3.Style["background-color"] = "White";
            block4.Style["background-color"] = "White";
            block5.Style["background-color"] = "White";
            block1hide.Visible = false;
            block2hide.Visible = true;
            block3hide.Visible = true;
            block4hide.Visible = true;
            block5hide.Visible = true;
            DoctorTimeLB2.SelectedIndex = -1;
            SearchTB2.Text = "";
            TestLB2.Text = "";
            TestLabel2.Text = "";
            DoctorTimeLB3.SelectedIndex = -1;
            SearchTB3.Text = "";
            TestLB3.Text = "";
            TestLabel3.Text = "";
            DoctorTimeLB4.SelectedIndex = -1;
            SearchTB4.Text = "";
            TestLB4.Text = "";
            TestLabel4.Text = "";
            DoctorTimeLB5.SelectedIndex = -1;
            SearchTB5.Text = "";
            TestLB5.Text = "";
            TestLabel5.Text = "";

        }

    }

    protected void DoctorRB2_CheckedChanged(object sender, EventArgs e)
    {
        if (DoctorRB2.Checked)
        {
            block1.Style["background-color"] = "White";
            block2.Style["background-color"] = "#CCFFCC";
            block3.Style["background-color"] = "White";
            block4.Style["background-color"] = "White";
            block5.Style["background-color"] = "White";
            block1hide.Visible = true;
            block2hide.Visible = false;
            block3hide.Visible = true;
            block4hide.Visible = true;
            block5hide.Visible = true;
            DoctorTimeLB1.SelectedIndex = -1;
            SearchTB1.Text = "";
            TestLB1.Text = "";
            TestLabel1.Text = "";
            DoctorTimeLB3.SelectedIndex = -1;
            SearchTB3.Text = "";
            TestLB3.Text = "";
            TestLabel3.Text = "";
            DoctorTimeLB4.SelectedIndex = -1;
            SearchTB4.Text = "";
            TestLB4.Text = "";
            TestLabel4.Text = "";
            DoctorTimeLB5.SelectedIndex = -1;
            SearchTB5.Text = "";
            TestLB5.Text = "";
            TestLabel5.Text = "";
        }

    }

    protected void DoctorRB3_CheckedChanged(object sender, EventArgs e)
    {
        if (DoctorRB3.Checked)
        {
            block1.Style["background-color"] = "White";
            block2.Style["background-color"] = "White";
            block3.Style["background-color"] = "#CCFFCC";
            block4.Style["background-color"] = "White";
            block5.Style["background-color"] = "White";
            block1hide.Visible = true;
            block2hide.Visible = true;
            block3hide.Visible = false;
            block4hide.Visible = true;
            block5hide.Visible = true;
            DoctorTimeLB1.SelectedIndex = -1;
            SearchTB1.Text = "";
            TestLB1.Text = "";
            TestLabel1.Text = "";
            DoctorTimeLB2.SelectedIndex = -1;
            SearchTB2.Text = "";
            TestLB2.Text = "";
            TestLabel2.Text = "";
            DoctorTimeLB4.SelectedIndex = -1;
            SearchTB4.Text = "";
            TestLB4.Text = "";
            TestLabel4.Text = "";
            DoctorTimeLB5.SelectedIndex = -1;
            SearchTB5.Text = "";
            TestLB5.Text = "";
            TestLabel5.Text = "";
        }
    }

    protected void DoctorRB4_CheckedChanged(object sender, EventArgs e)
    {
        if (DoctorRB4.Checked)
        {
            block1.Style["background-color"] = "White";
            block2.Style["background-color"] = "White";
            block3.Style["background-color"] = "White";
            block4.Style["background-color"] = "#CCFFCC";
            block5.Style["background-color"] = "White";
            block1hide.Visible = true;
            block2hide.Visible = true;
            block3hide.Visible = true;
            block4hide.Visible = false;
            block5hide.Visible = true;
            DoctorTimeLB1.SelectedIndex = -1;
            SearchTB1.Text = "";
            TestLB1.Text = "";
            TestLabel1.Text = "";
            DoctorTimeLB2.SelectedIndex = -1;
            SearchTB2.Text = "";
            TestLB2.Text = "";
            TestLabel2.Text = "";
            DoctorTimeLB3.SelectedIndex = -1;
            SearchTB3.Text = "";
            TestLB3.Text = "";
            TestLabel3.Text = "";
            DoctorTimeLB5.SelectedIndex = -1;
            SearchTB5.Text = "";
            TestLB5.Text = "";
            TestLabel5.Text = "";
        }
    }

    protected void DoctorRB5_CheckedChanged(object sender, EventArgs e)
    {
        if (DoctorRB5.Checked)
        {
            block1.Style["background-color"] = "White";
            block2.Style["background-color"] = "White";
            block3.Style["background-color"] = "White";
            block4.Style["background-color"] = "White";
            block5.Style["background-color"] = "#CCFFCC";
            block1hide.Visible = true;
            block2hide.Visible = true;
            block3hide.Visible = true;
            block4hide.Visible = true;
            block5hide.Visible = false;
            DoctorTimeLB1.SelectedIndex = -1;
            SearchTB1.Text = "";
            TestLB1.Text = "";
            TestLabel1.Text = "";
            DoctorTimeLB2.SelectedIndex = -1;
            SearchTB2.Text = "";
            TestLB2.Text = "";
            TestLabel2.Text = "";
            DoctorTimeLB3.SelectedIndex = -1;
            SearchTB3.Text = "";
            TestLB3.Text = "";
            TestLabel3.Text = "";
            DoctorTimeLB4.SelectedIndex = -1;
            SearchTB4.Text = "";
            TestLB4.Text = "";
            TestLabel4.Text = "";
        }

    }

    protected void DoctorTimeLB1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DoctorRB1.Checked)
        {
            if (DoctorTimeLB1.SelectedValue.Contains("-"))
            {
                SubmitBT.Text = "ИЗМЕНИТЬ";
                delBT.Visible = true;
                ChangeBT.Visible = true;
                ConfirmBT.Visible = true;
            }
            else
            {
                SubmitBT.Text = "ЗАПИСАТЬ";
                delBT.Visible = false;
                ChangeBT.Visible = false;
                ConfirmBT.Visible = false;
            }
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
        var days = (from d in db.Uzi_Zapisi
                    where d.city == CityDL.SelectedValue.ToString()
                    where d.mo == MoDL.SelectedValue.ToString()
                    where d.date.Contains(dt1.ToShortDateString().Remove(0, 6))
                    select d.date).Distinct();
        DateDL.Items.Clear();
        DateTime[] dates = new DateTime[days.Count()];
        for (int i = 0; i < days.Count(); i++)
        {
            dates[i] = DateTime.ParseExact(days.ToList().ElementAt(i).ToString(), "dd.M.yyyy", null);
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
        var days = (from d in db.Uzi_Zapisi
                    where d.city == CityDL.SelectedValue.ToString()
                    where d.mo == MoDL.SelectedValue.ToString()
                    where d.date.Contains(dt1.ToShortDateString().Remove(0, 6))
                    select d.date).Distinct();
        DateDL.Items.Clear();
        DateTime[] dates = new DateTime[days.Count()];
        for (int i = 0; i < days.Count(); i++)
        {
            dates[i] = DateTime.ParseExact(days.ToList().ElementAt(i).ToString(), "dd.M.yyyy", null);
        }
        dates = dates.OrderByDescending(d => d).ToArray();
        for (int i = 0; i < days.Count(); i++)
        {
            DateDL.Items.Add(dates[i].ToShortDateString());
        }
    }

    protected void DateDL_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
