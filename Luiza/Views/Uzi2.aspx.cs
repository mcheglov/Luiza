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
        clearInfo();
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
        clearInfo();
    }

    protected void addService_Click(object sender, EventArgs e)
    {
        if (testList.SelectedIndex != -1)
        {
            test.Text = (testList.SelectedItem.Text);
        }

    }

    protected void UziGV_SelectedIndexChanged(object sender, EventArgs e)
    {
        time.Text = UziGV.SelectedRow.Cells[1].Text;
        doctor.Text = UziGV.SelectedRow.Cells[11].Text;
        var tests = from o in db.Uzi_Doctor
                    where o.DOCTOR == doctor.Text
                    where o.MO == MoDL.SelectedValue
                    select o;
        if (tests.ToList().ElementAt(0).RESTRICTION is null)
        {
            ogran.Text = "нет ограничений";
        }
        else
        {
            ogran.Text = tests.ToList().ElementAt(0).RESTRICTION.ToString();
        }
        var emptyForname = (from ef in db.Uzi_Zapisi
                            where ef.ID == Convert.ToInt64(UziGV.SelectedRow.Cells[13].Text)
                            select ef.name_1).ToList();
        if (emptyForname[0].ToString() == "")
        {
            SubmitBT.Visible = true;
            EditBT.Visible = false;
            test.Text = "";
        }
        else
        {
            SubmitBT.Visible = false;
            EditBT.Visible = true;
            if (UziGV.SelectedRow.Cells[8].Text != "")
            {
                var testinfo = (from t in db.Uzi_Price
                                where t.test == UziGV.SelectedRow.Cells[8].Text
                                select t.description).ToList();
                test.Text = UziGV.SelectedRow.Cells[8].Text + "-" + testinfo[0].ToString();
            }
        }
        clearInfo2();
    }

    protected void Button3_Click(object sender, EventArgs e)
    {

    }

    protected void Button3_Click1(object sender, EventArgs e)
    {
        testList.Items.Clear();
        var tests = from o in db.Uzi_Doctor
                    where o.DOCTOR == doctor.Text
                    where o.MO == MoDL.SelectedValue
                    select o;
        for (int i = 0; i < tests.Count(); i++)
        {
            var testsdescription = from o in db.Uzi_Price
                                   where o.test == tests.ToList().ElementAt(i).TEST.ToString()
                                   select o;
            testList.Items.Add(testsdescription.ToList().ElementAt(0).test.ToString() + "-" + testsdescription.ToList().ElementAt(0).description.ToString());
        }
        testList.SelectedIndex = -1;
        var searchresult = new List<string>();

        for (int i = 0; i < testList.Items.Count; i++)
        {
            string tosearch = searchBox.Text.ToLower();
            string tocheck = testList.Items[i].Text.ToLower();
            if (tocheck.Contains(tosearch))
            {
                searchresult.Add(testList.Items[i].Text);
            }
        }
        searchresult = searchresult.OrderByDescending(d => d).ToList();
        searchresult.Reverse();
        testList.Items.Clear();
        for (int i = 0; i < searchresult.Count; i++)
        {
            testList.Items.Add(searchresult[i]);
        }
        searchBox.Text = "";
        foreach (ListItem item in testList.Items)
        {
            item.Attributes["title"] = item.Text;
        }
    }

    protected void testList_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (ListItem item in testList.Items)
        {
            item.Attributes["title"] = item.Text;
        }
        if (testList.SelectedIndex == -1)
        {
            price.Text = "0";
        }
        else
        {
            var test = testList.SelectedItem.Text.Split('-');
            string testCode = test[0];
            var testprice = from o in db.Uzi_Price
                            where o.test == testCode
                            select o;
            if (CityDL.Text == "Новосибирск")
            {
                price.Text = testprice.ToList().ElementAt(0).nsk_price.ToString();
                prepare.Text = testprice.ToList().ElementAt(0).common_prep.ToString();
                var docDur = (from o in db.Uzi_Doctor
                              where o.DOCTOR == doctor.Text
                              where o.TEST == testCode
                              where o.MO == MoDL.SelectedValue.ToString()
                              select o);
                dur.Text = docDur.ToList().ElementAt(0).DURATION.ToString() + " мин.";
            }
            else if (CityDL.Text == "Красноярск")
            {
                price.Text = testprice.ToList().ElementAt(0).krs_price.ToString();
                prepare.Text = testprice.ToList().ElementAt(0).common_prep.ToString();
                var docDur = (from o in db.Uzi_Doctor
                              where o.DOCTOR == doctor.Text
                              where o.TEST == testCode
                              where o.MO == MoDL.SelectedValue.ToString()
                              select o);
                dur.Text = docDur.ToList().ElementAt(0).DURATION.ToString() + " мин.";
            }
            else if (CityDL.Text == "Томск")
            {
                price.Text = testprice.ToList().ElementAt(0).tomsk_price.ToString();
                prepare.Text = testprice.ToList().ElementAt(0).tomsk_prep.ToString();
                var docDur = (from o in db.Uzi_Doctor
                              where o.DOCTOR == doctor.Text
                              where o.TEST == testCode
                              where o.MO == MoDL.SelectedValue.ToString()
                              select o);
                dur.Text = docDur.ToList().ElementAt(0).DURATION.ToString() + " мин.";
            }
            else if (CityDL.Text == "Омск")
            {
                price.Text = testprice.ToList().ElementAt(0).omsk_price.ToString();
                prepare.Text = testprice.ToList().ElementAt(0).common_prep.ToString();
                var docDur = (from o in db.Uzi_Doctor
                              where o.DOCTOR == doctor.Text
                              where o.TEST == testCode
                              where o.MO == MoDL.SelectedValue.ToString()
                              select o);
                dur.Text = docDur.ToList().ElementAt(0).DURATION.ToString() + " мин.";

            }
            else if (CityDL.Text == "Иркутск")
            {
                price.Text = testprice.ToList().ElementAt(0).irk_price.ToString();
                prepare.Text = testprice.ToList().ElementAt(0).common_prep.ToString();
                var docDur = (from o in db.Uzi_Doctor
                              where o.DOCTOR == doctor.Text
                              where o.TEST == testCode
                              where o.MO == MoDL.SelectedValue.ToString()
                              select o);
                dur.Text = docDur.ToList().ElementAt(0).DURATION.ToString() + " мин.";
            }
        }
    }

    public void clearInfo()
    {
        doctor.Text = "";
        dur.Text = "";
        price.Text = "";
        ogran.Text = "";
        test.Text = "";
        time.Text = "";
        testList.Items.Clear();
        prepare.Text = "";
        searchBox.Text = "";
    }
    public void clearInfo2()
    {
        dur.Text = "";
        price.Text = "";
        testList.Items.Clear();
        prepare.Text = "";
        searchBox.Text = "";
    }

    protected void DateDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        clearInfo();
    }
}