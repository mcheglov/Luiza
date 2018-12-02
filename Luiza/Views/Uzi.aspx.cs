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
        if (!IsPostBack)
        {

            delBT.Visible = false;
            ChangeBT.Visible = false;
            ConfirmBT.Visible = false;
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
                RbUpdate();
            }
        }

    }

    private void RbUpdate()
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
        DoctorRB1.Checked = false;
        DoctorRB2.Checked = false;
        DoctorRB3.Checked = false;
        DoctorRB4.Checked = false;
        DoctorRB5.Checked = false;
        if (docs.Count() == 0)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
        }
        else if (docs.Count() == 1)
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
            time1(docs.ToList().ElementAt(0).ToString());

        }
        else if (docs.Count() == 2)
        {
            Panel1.Visible = true;
            Panel2.Visible = true;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
            time1(docs.ToList().ElementAt(0).ToString());
            time2(docs.ToList().ElementAt(1).ToString());
        }
        else if (docs.Count() == 3)
        {
            Panel1.Visible = true;
            Panel2.Visible = true;
            Panel3.Visible = true;
            Panel4.Visible = false;
            Panel5.Visible = false;
            time1(docs.ToList().ElementAt(0).ToString());
            time2(docs.ToList().ElementAt(1).ToString());
            time3(docs.ToList().ElementAt(2).ToString());
        }
        else if (docs.Count() == 4)
        {
            Panel1.Visible = true;
            Panel2.Visible = true;
            Panel3.Visible = true;
            Panel4.Visible = true;
            Panel5.Visible = false;
            time1(docs.ToList().ElementAt(0).ToString());
            time2(docs.ToList().ElementAt(1).ToString());
            time3(docs.ToList().ElementAt(2).ToString());
            time4(docs.ToList().ElementAt(3).ToString());
        }
        else if (docs.Count() == 5)
        {
            Panel1.Visible = true;
            Panel2.Visible = true;
            Panel3.Visible = true;
            Panel4.Visible = true;
            Panel5.Visible = true;
            time1(docs.ToList().ElementAt(0).ToString());
            time2(docs.ToList().ElementAt(1).ToString());
            time3(docs.ToList().ElementAt(2).ToString());
            time4(docs.ToList().ElementAt(3).ToString());
            time5(docs.ToList().ElementAt(4).ToString());
        }
    }

    private void testupdate1()
    {
        TestLB1.Items.Clear();
        var tests = from o in db.Uzi_Doctor
                    where o.DOCTOR == DoctorRB1.Text
                    where o.MO == MoDL.SelectedValue
                    select o;
        for (int i = 0; i < tests.Count(); i++)
        {
            var testsdescription = from o in db.Uzi_Price
                                   where o.test == tests.ToList().ElementAt(i).TEST.ToString()
                                   select o;
            TestLB1.Items.Add(testsdescription.ToList().ElementAt(0).test.ToString() + "-" + testsdescription.ToList().ElementAt(0).description.ToString());
        }
        TestLB1.SelectedIndex = -1;
        var searchresult = new List<string>();

        for (int i = 0; i < TestLB1.Items.Count; i++)
        {
            string tosearch = SearchTB1.Text.ToLower();
            string tocheck = TestLB1.Items[i].Text.ToLower();
            if (tocheck.Contains(tosearch))
            {
                searchresult.Add(TestLB1.Items[i].Text);
            }
        }
        searchresult = searchresult.OrderByDescending(d => d).ToList();
        searchresult.Reverse();
        TestLB1.Items.Clear();
        for (int i = 0; i < searchresult.Count; i++)
        {
            TestLB1.Items.Add(searchresult[i]);
        }
        SearchTB1.Text = "";
    }

    private void testupdate2()
    {
        TestLB2.Items.Clear();
        var tests = from o in db.Uzi_Doctor
                    where o.DOCTOR == DoctorRB2.Text
                    where o.MO == MoDL.SelectedValue
                    select o;
        for (int i = 0; i < tests.Count(); i++)
        {
            var testsdescription = from o in db.Uzi_Price
                                   where o.test == tests.ToList().ElementAt(i).TEST.ToString()
                                   select o;
            TestLB2.Items.Add(testsdescription.ToList().ElementAt(0).test.ToString() + "-" + testsdescription.ToList().ElementAt(0).description.ToString());
        }
        TestLB2.SelectedIndex = -1;
        var searchresult = new List<string>();

        for (int i = 0; i < TestLB2.Items.Count; i++)
        {
            string tosearch = SearchTB2.Text.ToLower();
            string tocheck = TestLB2.Items[i].Text.ToLower();
            if (tocheck.Contains(tosearch))
            {
                searchresult.Add(TestLB2.Items[i].Text);
            }
        }
        searchresult = searchresult.OrderByDescending(d => d).ToList();
        searchresult.Reverse();
        TestLB2.Items.Clear();
        for (int i = 0; i < searchresult.Count; i++)
        {
            TestLB2.Items.Add(searchresult[i]);
        }
        SearchTB2.Text = "";
    }

    private void testupdate3()
    {
        TestLB3.Items.Clear();
        var tests = from o in db.Uzi_Doctor
                    where o.DOCTOR == DoctorRB3.Text
                    where o.MO == MoDL.SelectedValue
                    select o;
        for (int i = 0; i < tests.Count(); i++)
        {
            var testsdescription = from o in db.Uzi_Price
                                   where o.test == tests.ToList().ElementAt(i).TEST.ToString()
                                   select o;
            TestLB3.Items.Add(testsdescription.ToList().ElementAt(0).test.ToString() + "-" + testsdescription.ToList().ElementAt(0).description.ToString());
        }
        TestLB3.SelectedIndex = -1;
        var searchresult = new List<string>();

        for (int i = 0; i < TestLB3.Items.Count; i++)
        {
            string tosearch = SearchTB3.Text.ToLower();
            string tocheck = TestLB3.Items[i].Text.ToLower();
            if (tocheck.Contains(tosearch))
            {
                searchresult.Add(TestLB3.Items[i].Text);
            }
        }
        searchresult = searchresult.OrderByDescending(d => d).ToList();
        searchresult.Reverse();
        TestLB3.Items.Clear();
        for (int i = 0; i < searchresult.Count; i++)
        {
            TestLB3.Items.Add(searchresult[i]);
        }
        SearchTB3.Text = "";
    }

    private void testupdate4()
    {
        TestLB4.Items.Clear();
        var tests = from o in db.Uzi_Doctor
                    where o.DOCTOR == DoctorRB4.Text
                    where o.MO == MoDL.SelectedValue
                    select o;
        for (int i = 0; i < tests.Count(); i++)
        {
            var testsdescription = from o in db.Uzi_Price
                                   where o.test == tests.ToList().ElementAt(i).TEST.ToString()
                                   select o;
            TestLB4.Items.Add(testsdescription.ToList().ElementAt(0).test.ToString() + "-" + testsdescription.ToList().ElementAt(0).description.ToString());
        }
        TestLB4.SelectedIndex = -1;
        var searchresult = new List<string>();

        for (int i = 0; i < TestLB4.Items.Count; i++)
        {
            string tosearch = SearchTB4.Text.ToLower();
            string tocheck = TestLB4.Items[i].Text.ToLower();
            if (tocheck.Contains(tosearch))
            {
                searchresult.Add(TestLB4.Items[i].Text);
            }
        }
        searchresult = searchresult.OrderByDescending(d => d).ToList();
        searchresult.Reverse();
        TestLB4.Items.Clear();
        for (int i = 0; i < searchresult.Count; i++)
        {
            TestLB4.Items.Add(searchresult[i]);
        }
        SearchTB4.Text = "";
    }

    private void testupdate5()
    {
        TestLB5.Items.Clear();
        var tests = from o in db.Uzi_Doctor
                    where o.DOCTOR == DoctorRB5.Text
                    where o.MO == MoDL.SelectedValue
                    select o;
        for (int i = 0; i < tests.Count(); i++)
        {
            var testsdescription = from o in db.Uzi_Price
                                   where o.test == tests.ToList().ElementAt(i).TEST.ToString()
                                   select o;
            TestLB5.Items.Add(testsdescription.ToList().ElementAt(0).test.ToString() + "-" + testsdescription.ToList().ElementAt(0).description.ToString());
        }
        TestLB5.SelectedIndex = -1;
        var searchresult = new List<string>();

        for (int i = 0; i < TestLB5.Items.Count; i++)
        {
            string tosearch = SearchTB5.Text.ToLower();
            string tocheck = TestLB5.Items[i].Text.ToLower();
            if (tocheck.Contains(tosearch))
            {
                searchresult.Add(TestLB5.Items[i].Text);
            }
        }
        searchresult = searchresult.OrderByDescending(d => d).ToList();
        searchresult.Reverse();
        TestLB5.Items.Clear();
        for (int i = 0; i < searchresult.Count; i++)
        {
            TestLB5.Items.Add(searchresult[i]);
        }
        SearchTB5.Text = "";
    }

    private void time1(string doctor)
    {
        DoctorTimeLB1.Items.Clear();
        DoctorRB1.Text = doctor;
        var time = (from t in db.Uzi_Zapisi
                    where t.date == DateDL.SelectedValue
                    where t.mo == MoDL.SelectedValue
                    where t.city == CityDL.SelectedValue
                    where t.doctor == doctor
                    select t);
        for (int i = 0; i < time.Count(); i++)
        {
            if (time.ToList().ElementAt(i).name_1.Length > 0)
            {
                string accept = "";
                if (time.ToList().ElementAt(i).accept.ToString() == "True")
                {
                    accept = "Подтвержден";
                }
                else
                {
                    accept = "Не подтвержден";
                }
                DoctorTimeLB1.Items.Add(time.ToList().ElementAt(i).time + " - " + time.ToList().ElementAt(i).name_1 + " - " + accept);
                if (time.ToList().ElementAt(i).accept.ToString() == "True")
                {
                    DoctorTimeLB1.Items[i].Attributes.Add("style", "background-color: Lime; color: Red");
                }
                else
                {
                    DoctorTimeLB1.Items[i].Attributes.Add("style", "background-color: Yellow; color: Red");
                }

            }
            else
            {
                DoctorTimeLB1.Items.Add(time.ToList().ElementAt(i).time);
            }
        }
    }

    private void time2(string doctor)
    {
        DoctorRB2.Text = doctor;
        var time = (from t in db.Uzi_Zapisi
                    where t.date == DateDL.SelectedValue
                    where t.mo == MoDL.SelectedValue
                    where t.city == CityDL.SelectedValue
                    where t.doctor == doctor
                    select t);
        for (int i = 0; i < time.Count(); i++)
        {
            if (time.ToList().ElementAt(i).name_1.Length > 0)
            {
                DoctorTimeLB2.Items.Add(time.ToList().ElementAt(i).time + " - " + time.ToList().ElementAt(i).name_1);
            }
            else
            {
                DoctorTimeLB2.Items.Add(time.ToList().ElementAt(i).time);
            }
        }
        for (int j = 0; j < DoctorTimeLB2.Items.Count; j++)
        {
            if (time.ToList().ElementAt(j).accept.ToString() == "False")
            {
                DoctorTimeLB2.Items[j].Attributes.Add("style", "background-color: Yellow; color: Red");
            }
            else
            {
                DoctorTimeLB2.Items[j].Attributes.Add("style", "background-color: Lime; color: Red");
            }
        }
    }

    private void time3(string doctor)
    {
        DoctorRB3.Text = doctor;
        var time = (from t in db.Uzi_Zapisi
                    where t.date == DateDL.SelectedValue
                    where t.mo == MoDL.SelectedValue
                    where t.city == CityDL.SelectedValue
                    where t.doctor == doctor
                    select t);
        for (int i = 0; i < time.Count(); i++)
        {
            if (time.ToList().ElementAt(i).name_1.Length > 0)
            {
                DoctorTimeLB3.Items.Add(time.ToList().ElementAt(i).time + "-" + time.ToList().ElementAt(i).name_1);
            }
            else
            {
                DoctorTimeLB3.Items.Add(time.ToList().ElementAt(i).time);
            }
        }
        for (int j = 0; j < DoctorTimeLB3.Items.Count; j++)
        {
            if (time.ToList().ElementAt(j).accept.ToString() == "False")
            {
                DoctorTimeLB3.Items[j].Attributes.Add("style", "background-color: Yellow; color: Red");
            }
            else
            {
                DoctorTimeLB3.Items[j].Attributes.Add("style", "background-color: Lime; color: Red");
            }
        }
    }

    private void time4(string doctor)
    {
        DoctorRB4.Text = doctor;
        var time = (from t in db.Uzi_Zapisi
                    where t.date == DateDL.SelectedValue
                    where t.mo == MoDL.SelectedValue
                    where t.city == CityDL.SelectedValue
                    where t.doctor == doctor
                    select t);
        for (int i = 0; i < time.Count(); i++)
        {
            if (time.ToList().ElementAt(i).name_1.Length > 0)
            {
                DoctorTimeLB4.Items.Add(time.ToList().ElementAt(i).time + "-" + time.ToList().ElementAt(i).name_1);
            }
            else
            {
                DoctorTimeLB4.Items.Add(time.ToList().ElementAt(i).time);
            }
        }
        for (int j = 0; j < DoctorTimeLB4.Items.Count; j++)
        {
            if (time.ToList().ElementAt(j).accept.ToString() == "False")
            {
                DoctorTimeLB4.Items[j].Attributes.Add("style", "background-color: Yellow; color: Red");
            }
            else
            {
                DoctorTimeLB4.Items[j].Attributes.Add("style", "background-color: Lime; color: Red");
            }
        }
    }

    private void time5(string doctor)
    {
        DoctorRB5.Text = doctor;
        var time = (from t in db.Uzi_Zapisi
                    where t.date == DateDL.SelectedValue
                    where t.mo == MoDL.SelectedValue
                    where t.city == CityDL.SelectedValue
                    where t.doctor == doctor
                    select t);
        for (int i = 0; i < time.Count(); i++)
        {
            if (time.ToList().ElementAt(i).name_1.Length > 0)
            {
                DoctorTimeLB5.Items.Add(time.ToList().ElementAt(i).time + "-" + time.ToList().ElementAt(i).name_1);
            }
            else
            {
                DoctorTimeLB5.Items.Add(time.ToList().ElementAt(i).time);
            }
        }
        for (int j = 0; j < DoctorTimeLB5.Items.Count; j++)
        {
            if (time.ToList().ElementAt(j).accept.ToString() == "False")
            {
                DoctorTimeLB5.Items[j].Attributes.Add("style", "background-color: Yellow; color: Red");
            }
            else
            {
                DoctorTimeLB5.Items[j].Attributes.Add("style", "background-color: Lime; color: Red");
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
            DoctorRB1.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF6A13");
            DoctorRB1.ForeColor = System.Drawing.Color.White;
            DoctorRB2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF6A13");
            DoctorRB2.BackColor = System.Drawing.Color.White;
            DoctorRB3.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF6A13");
            DoctorRB3.BackColor = System.Drawing.Color.White;
            DoctorRB4.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF6A13");
            DoctorRB4.BackColor = System.Drawing.Color.White;
            DoctorRB5.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF6A13");
            DoctorRB5.BackColor = System.Drawing.Color.White;
            var info = (from i in db.Uzi_Doctor
                        where i.DOCTOR == DoctorRB1.Text
                        where i.CITY == CityDL.SelectedValue
                        where i.MO == MoDL.SelectedValue
                        select i.RESTRICTION);
            restrictionLabel.Text = info.ToList().ElementAt(0).ToString();

            block1hide.Visible = false;
            block2hide.Visible = true;
            block3hide.Visible = true;
            block4hide.Visible = true;
            block5hide.Visible = true;
            recordID.Text = "";
            DoctorTimeLB2.SelectedIndex = -1;
            SearchTB2.Text = "";
            TestLB2.Items.Clear();
            TestLabel2.Text = "";
            DoctorTimeLB3.SelectedIndex = -1;
            SearchTB3.Text = "";
            TestLB3.Items.Clear();
            TestLabel3.Text = "";
            DoctorTimeLB4.SelectedIndex = -1;
            SearchTB4.Text = "";
            TestLB4.Items.Clear();
            TestLabel4.Text = "";
            DoctorTimeLB5.SelectedIndex = -1;
            SearchTB5.Text = "";
            TestLB5.Items.Clear();
            TestLabel5.Text = "";

        }

    }

    protected void DoctorRB2_CheckedChanged(object sender, EventArgs e)
    {
        if (DoctorRB2.Checked)
        {
            DoctorRB2.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF6A13");
            DoctorRB2.ForeColor = System.Drawing.Color.White;
            DoctorRB1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF6A13");
            DoctorRB1.BackColor = System.Drawing.Color.White;
            DoctorRB3.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF6A13");
            DoctorRB3.BackColor = System.Drawing.Color.White;
            DoctorRB4.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF6A13");
            DoctorRB4.BackColor = System.Drawing.Color.White;
            DoctorRB5.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF6A13");
            DoctorRB5.BackColor = System.Drawing.Color.White;
            var info = (from i in db.Uzi_Doctor
                        where i.DOCTOR == DoctorRB2.Text
                        where i.CITY == CityDL.SelectedValue
                        where i.MO == MoDL.SelectedValue
                        select i.RESTRICTION);
            restrictionLabel.Text = info.ToList().ElementAt(0).ToString();
            block1hide.Visible = true;
            block2hide.Visible = false;
            block3hide.Visible = true;
            block4hide.Visible = true;
            block5hide.Visible = true;
            recordID.Text = "";
            DoctorTimeLB1.SelectedIndex = -1;
            SearchTB1.Text = "";
            TestLB1.Items.Clear();
            TestLabel1.Text = "";
            DoctorTimeLB3.SelectedIndex = -1;
            SearchTB3.Text = "";
            TestLB3.Items.Clear();
            TestLabel3.Text = "";
            DoctorTimeLB4.SelectedIndex = -1;
            SearchTB4.Text = "";
            TestLB4.Items.Clear();
            TestLabel4.Text = "";
            DoctorTimeLB5.SelectedIndex = -1;
            SearchTB5.Text = "";
            TestLB5.Items.Clear();
            TestLabel5.Text = "";
        }

    }

    protected void DoctorRB3_CheckedChanged(object sender, EventArgs e)
    {
        if (DoctorRB3.Checked)
        {
            DoctorRB3.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF6A13");
            DoctorRB3.ForeColor = System.Drawing.Color.White;
            DoctorRB1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF6A13");
            DoctorRB1.BackColor = System.Drawing.Color.White;
            DoctorRB2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF6A13");
            DoctorRB2.BackColor = System.Drawing.Color.White;
            DoctorRB4.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF6A13");
            DoctorRB4.BackColor = System.Drawing.Color.White;
            DoctorRB5.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF6A13");
            DoctorRB5.BackColor = System.Drawing.Color.White;
            var info = (from i in db.Uzi_Doctor
                        where i.DOCTOR == DoctorRB4.Text
                        where i.CITY == CityDL.SelectedValue
                        where i.MO == MoDL.SelectedValue
                        select i.RESTRICTION);
            restrictionLabel.Text = info.ToList().ElementAt(0).ToString();
            block1hide.Visible = true;
            block2hide.Visible = true;
            block3hide.Visible = false;
            block4hide.Visible = true;
            block5hide.Visible = true;
            recordID.Text = "";
            DoctorTimeLB1.SelectedIndex = -1;
            SearchTB1.Text = "";
            TestLB1.Items.Clear();
            TestLabel1.Text = "";
            DoctorTimeLB2.SelectedIndex = -1;
            SearchTB2.Text = "";
            TestLB2.Items.Clear();
            TestLabel2.Text = "";
            DoctorTimeLB4.SelectedIndex = -1;
            SearchTB4.Text = "";
            TestLB4.Items.Clear();
            TestLabel4.Text = "";
            DoctorTimeLB5.SelectedIndex = -1;
            SearchTB5.Text = "";
            TestLB5.Items.Clear();
            TestLabel5.Text = "";
        }
    }

    protected void DoctorRB4_CheckedChanged(object sender, EventArgs e)
    {
        if (DoctorRB4.Checked)
        {
            DoctorRB4.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF6A13");
            DoctorRB4.ForeColor = System.Drawing.Color.White;
            DoctorRB1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF6A13");
            DoctorRB1.BackColor = System.Drawing.Color.White;
            DoctorRB3.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF6A13");
            DoctorRB3.BackColor = System.Drawing.Color.White;
            DoctorRB2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF6A13");
            DoctorRB2.BackColor = System.Drawing.Color.White;
            DoctorRB5.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF6A13");
            DoctorRB5.BackColor = System.Drawing.Color.White;
            var info = (from i in db.Uzi_Doctor
                        where i.DOCTOR == DoctorRB4.Text
                        where i.CITY == CityDL.SelectedValue
                        where i.MO == MoDL.SelectedValue
                        select i.RESTRICTION);
            restrictionLabel.Text = info.ToList().ElementAt(0).ToString();
            block1hide.Visible = true;
            block2hide.Visible = true;
            block3hide.Visible = true;
            block4hide.Visible = false;
            block5hide.Visible = true;
            recordID.Text = "";
            DoctorTimeLB1.SelectedIndex = -1;
            SearchTB1.Text = "";
            TestLB1.Items.Clear();
            TestLabel1.Text = "";
            DoctorTimeLB2.SelectedIndex = -1;
            SearchTB2.Text = "";
            TestLB2.Items.Clear();
            TestLabel2.Text = "";
            DoctorTimeLB3.SelectedIndex = -1;
            SearchTB3.Text = "";
            TestLB3.Items.Clear();
            TestLabel3.Text = "";
            DoctorTimeLB5.SelectedIndex = -1;
            SearchTB5.Text = "";
            TestLB5.Items.Clear();
            TestLabel5.Text = "";
        }
    }

    protected void DoctorRB5_CheckedChanged(object sender, EventArgs e)
    {
        if (DoctorRB5.Checked)
        {
            DoctorRB5.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF6A13");
            DoctorRB5.ForeColor = System.Drawing.Color.White;
            DoctorRB1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF6A13");
            DoctorRB1.BackColor = System.Drawing.Color.White;
            DoctorRB3.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF6A13");
            DoctorRB3.BackColor = System.Drawing.Color.White;
            DoctorRB4.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF6A13");
            DoctorRB4.BackColor = System.Drawing.Color.White;
            DoctorRB2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF6A13");
            DoctorRB2.BackColor = System.Drawing.Color.White;
            var info = (from i in db.Uzi_Doctor
                        where i.DOCTOR == DoctorRB5.Text
                        where i.CITY == CityDL.SelectedValue
                        where i.MO == MoDL.SelectedValue
                        select i.RESTRICTION);
            restrictionLabel.Text = info.ToList().ElementAt(0).ToString();
            block1hide.Visible = true;
            block2hide.Visible = true;
            block3hide.Visible = true;
            block4hide.Visible = true;
            block5hide.Visible = false;
            recordID.Text = "";
            DoctorTimeLB1.SelectedIndex = -1;
            SearchTB1.Text = "";
            TestLB1.Items.Clear();
            TestLabel1.Text = "";
            DoctorTimeLB2.SelectedIndex = -1;
            SearchTB2.Text = "";
            TestLB2.Items.Clear();
            TestLabel2.Text = "";
            DoctorTimeLB3.SelectedIndex = -1;
            SearchTB3.Text = "";
            TestLB3.Items.Clear();
            TestLabel3.Text = "";
            DoctorTimeLB4.SelectedIndex = -1;
            SearchTB4.Text = "";
            TestLB4.Items.Clear();
            TestLabel4.Text = "";
        }

    }

    protected void DoctorTimeLB1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DoctorRB1.Checked)
        {
            if (DoctorTimeLB1.SelectedIndex != -1)
            {
                var time = DoctorTimeLB1.SelectedItem.Text.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
                var delRecord = (from z in db.Uzi_Zapisi
                                 where z.doctor == DoctorRB1.Text
                                 where z.date == DateDL.SelectedValue
                                 where z.mo == MoDL.SelectedValue
                                 where z.city == CityDL.SelectedValue
                                 where z.time == time[0]
                                 select z);
                recordID.Text = delRecord.ToList().ElementAt(0).ID.ToString();

            }
            if (DoctorTimeLB1.SelectedValue.Contains(" - "))
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
            for (int i=0; i<DoctorTimeLB1.Items.Count;i++)
            {
                if (DoctorTimeLB1.Items[i].Text.Contains("Подтвержден"))
                {
                    DoctorTimeLB1.Items[i].Attributes.Add("style", "background-color: Lime; color: Red");
                }
                else if(DoctorTimeLB1.Items[i].Text.Contains("Не подтвержден"))
                {
                    DoctorTimeLB1.Items[i].Attributes.Add("style", "background-color: Yellow; color: Red");
                }
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
        RbUpdate();
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
        RbUpdate();
    }

    protected void DateDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        RbUpdate();
    }

    protected void SearchBT1_Click(object sender, EventArgs e)
    {
        testupdate1();
    }

    protected void SearchBT2_Click(object sender, EventArgs e)
    {
        testupdate2();
    }

    protected void SearchBT3_Click(object sender, EventArgs e)
    {
        testupdate3();
    }

    protected void SearchBT4_Click(object sender, EventArgs e)
    {
        testupdate4();
    }

    protected void SearchBT5_Click(object sender, EventArgs e)
    {
        testupdate5();
    }

    protected void TestLB1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (TestLB1.SelectedIndex != -1)
        {
            var test = TestLB1.SelectedItem.Text.Split('-');
            string testCode = test[0];
            var testprice = from o in db.Uzi_Price
                            where o.test == testCode
                            select o;
            if (CityDL.Text == "Новосибирск")
            {
                priceLabel.Text = testprice.ToList().ElementAt(0).nsk_price.ToString();
                PrepTB.Text = testprice.ToList().ElementAt(0).common_prep.ToString();
                var docDur = (from o in db.Uzi_Doctor
                              where o.DOCTOR == DoctorRB1.Text
                              where o.TEST == testCode
                              where o.MO == MoDL.SelectedValue.ToString()
                              select o);
                durationLabel.Text = docDur.ToList().ElementAt(0).DURATION.ToString() + " мин.";
            }
            else if (CityDL.Text == "Красноярск")
            {
                priceLabel.Text = testprice.ToList().ElementAt(0).krs_price.ToString();
                PrepTB.Text = testprice.ToList().ElementAt(0).common_prep.ToString();
                var docDur = (from o in db.Uzi_Doctor
                              where o.DOCTOR == DoctorRB1.Text
                              where o.TEST == testCode
                              where o.MO == MoDL.SelectedValue.ToString()
                              select o);
                durationLabel.Text = docDur.ToList().ElementAt(0).DURATION.ToString() + " мин.";
            }
            else if (CityDL.Text == "Томск")
            {
                priceLabel.Text = testprice.ToList().ElementAt(0).tomsk_price.ToString();
                PrepTB.Text = testprice.ToList().ElementAt(0).tomsk_prep.ToString();
                var docDur = (from o in db.Uzi_Doctor
                              where o.DOCTOR == DoctorRB1.Text
                              where o.TEST == testCode
                              where o.MO == MoDL.SelectedValue.ToString()
                              select o);
                durationLabel.Text = docDur.ToList().ElementAt(0).DURATION.ToString() + " мин.";
            }
            else if (CityDL.Text == "Омск")
            {
                priceLabel.Text = testprice.ToList().ElementAt(0).omsk_price.ToString();
                PrepTB.Text = testprice.ToList().ElementAt(0).common_prep.ToString();
                var docDur = (from o in db.Uzi_Doctor
                              where o.DOCTOR == DoctorRB1.Text
                              where o.TEST == testCode
                              where o.MO == MoDL.SelectedValue.ToString()
                              select o);
                durationLabel.Text = docDur.ToList().ElementAt(0).DURATION.ToString() + " мин.";
            }
            else if (CityDL.Text == "Иркутск")
            {
                priceLabel.Text = testprice.ToList().ElementAt(0).irk_price.ToString();
                PrepTB.Text = testprice.ToList().ElementAt(0).common_prep.ToString();
                var docDur = (from o in db.Uzi_Doctor
                              where o.DOCTOR == DoctorRB1.Text
                              where o.TEST == testCode
                              where o.MO == MoDL.SelectedValue.ToString()
                              select o);
                durationLabel.Text = docDur.ToList().ElementAt(0).DURATION.ToString() + " мин.";
            }
        }
    }

    protected void TestLB2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (TestLB2.SelectedIndex != -1)
        {
            var test = TestLB2.SelectedItem.Text.Split('-');
            string testCode = test[0];
            var testprice = from o in db.Uzi_Price
                            where o.test == testCode
                            select o;
            if (CityDL.Text == "Новосибирск")
            {
                priceLabel.Text = testprice.ToList().ElementAt(0).nsk_price.ToString();
                PrepTB.Text = testprice.ToList().ElementAt(0).common_prep.ToString();
                var docDur = (from o in db.Uzi_Doctor
                              where o.DOCTOR == DoctorRB2.Text
                              where o.TEST == testCode
                              where o.MO == MoDL.SelectedValue.ToString()
                              select o);
                durationLabel.Text = docDur.ToList().ElementAt(0).DURATION.ToString() + " мин.";
            }
            else if (CityDL.Text == "Красноярск")
            {
                priceLabel.Text = testprice.ToList().ElementAt(0).krs_price.ToString();
                PrepTB.Text = testprice.ToList().ElementAt(0).common_prep.ToString();
                var docDur = (from o in db.Uzi_Doctor
                              where o.DOCTOR == DoctorRB2.Text
                              where o.TEST == testCode
                              where o.MO == MoDL.SelectedValue.ToString()
                              select o);
                durationLabel.Text = docDur.ToList().ElementAt(0).DURATION.ToString() + " мин.";
            }
            else if (CityDL.Text == "Томск")
            {
                priceLabel.Text = testprice.ToList().ElementAt(0).tomsk_price.ToString();
                PrepTB.Text = testprice.ToList().ElementAt(0).tomsk_prep.ToString();
                var docDur = (from o in db.Uzi_Doctor
                              where o.DOCTOR == DoctorRB2.Text
                              where o.TEST == testCode
                              where o.MO == MoDL.SelectedValue.ToString()
                              select o);
                durationLabel.Text = docDur.ToList().ElementAt(0).DURATION.ToString() + " мин.";
            }
            else if (CityDL.Text == "Омск")
            {
                priceLabel.Text = testprice.ToList().ElementAt(0).omsk_price.ToString();
                PrepTB.Text = testprice.ToList().ElementAt(0).common_prep.ToString();
                var docDur = (from o in db.Uzi_Doctor
                              where o.DOCTOR == DoctorRB2.Text
                              where o.TEST == testCode
                              where o.MO == MoDL.SelectedValue.ToString()
                              select o);
                durationLabel.Text = docDur.ToList().ElementAt(0).DURATION.ToString() + " мин.";
            }
            else if (CityDL.Text == "Иркутск")
            {
                priceLabel.Text = testprice.ToList().ElementAt(0).irk_price.ToString();
                PrepTB.Text = testprice.ToList().ElementAt(0).common_prep.ToString();
                var docDur = (from o in db.Uzi_Doctor
                              where o.DOCTOR == DoctorRB2.Text
                              where o.TEST == testCode
                              where o.MO == MoDL.SelectedValue.ToString()
                              select o);
                durationLabel.Text = docDur.ToList().ElementAt(0).DURATION.ToString() + " мин.";
            }
        }
    }

    protected void TestLB3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (TestLB3.SelectedIndex != -1)
        {
            var test = TestLB3.SelectedItem.Text.Split('-');
            string testCode = test[0];
            var testprice = from o in db.Uzi_Price
                            where o.test == testCode
                            select o;
            if (CityDL.Text == "Новосибирск")
            {
                priceLabel.Text = testprice.ToList().ElementAt(0).nsk_price.ToString();
                PrepTB.Text = testprice.ToList().ElementAt(0).common_prep.ToString();
                var docDur = (from o in db.Uzi_Doctor
                              where o.DOCTOR == DoctorRB3.Text
                              where o.TEST == testCode
                              where o.MO == MoDL.SelectedValue.ToString()
                              select o);
                durationLabel.Text = docDur.ToList().ElementAt(0).DURATION.ToString() + " мин.";
            }
            else if (CityDL.Text == "Красноярск")
            {
                priceLabel.Text = testprice.ToList().ElementAt(0).krs_price.ToString();
                PrepTB.Text = testprice.ToList().ElementAt(0).common_prep.ToString();
                var docDur = (from o in db.Uzi_Doctor
                              where o.DOCTOR == DoctorRB3.Text
                              where o.TEST == testCode
                              where o.MO == MoDL.SelectedValue.ToString()
                              select o);
                durationLabel.Text = docDur.ToList().ElementAt(0).DURATION.ToString() + " мин.";
            }
            else if (CityDL.Text == "Томск")
            {
                priceLabel.Text = testprice.ToList().ElementAt(0).tomsk_price.ToString();
                PrepTB.Text = testprice.ToList().ElementAt(0).tomsk_prep.ToString();
                var docDur = (from o in db.Uzi_Doctor
                              where o.DOCTOR == DoctorRB3.Text
                              where o.TEST == testCode
                              where o.MO == MoDL.SelectedValue.ToString()
                              select o);
                durationLabel.Text = docDur.ToList().ElementAt(0).DURATION.ToString() + " мин.";
            }
            else if (CityDL.Text == "Омск")
            {
                priceLabel.Text = testprice.ToList().ElementAt(0).omsk_price.ToString();
                PrepTB.Text = testprice.ToList().ElementAt(0).common_prep.ToString();
                var docDur = (from o in db.Uzi_Doctor
                              where o.DOCTOR == DoctorRB3.Text
                              where o.TEST == testCode
                              where o.MO == MoDL.SelectedValue.ToString()
                              select o);
                durationLabel.Text = docDur.ToList().ElementAt(0).DURATION.ToString() + " мин.";
            }
            else if (CityDL.Text == "Иркутск")
            {
                priceLabel.Text = testprice.ToList().ElementAt(0).irk_price.ToString();
                PrepTB.Text = testprice.ToList().ElementAt(0).common_prep.ToString();
                var docDur = (from o in db.Uzi_Doctor
                              where o.DOCTOR == DoctorRB3.Text
                              where o.TEST == testCode
                              where o.MO == MoDL.SelectedValue.ToString()
                              select o);
                durationLabel.Text = docDur.ToList().ElementAt(0).DURATION.ToString() + " мин.";
            }
        }
    }

    protected void TestLB4_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (TestLB4.SelectedIndex != -1)
        {
            var test = TestLB4.SelectedItem.Text.Split('-');
            string testCode = test[0];
            var testprice = from o in db.Uzi_Price
                            where o.test == testCode
                            select o;
            if (CityDL.Text == "Новосибирск")
            {
                priceLabel.Text = testprice.ToList().ElementAt(0).nsk_price.ToString();
                PrepTB.Text = testprice.ToList().ElementAt(0).common_prep.ToString();
                var docDur = (from o in db.Uzi_Doctor
                              where o.DOCTOR == DoctorRB4.Text
                              where o.TEST == testCode
                              where o.MO == MoDL.SelectedValue.ToString()
                              select o);
                durationLabel.Text = docDur.ToList().ElementAt(0).DURATION.ToString() + " мин.";
            }
            else if (CityDL.Text == "Красноярск")
            {
                priceLabel.Text = testprice.ToList().ElementAt(0).krs_price.ToString();
                PrepTB.Text = testprice.ToList().ElementAt(0).common_prep.ToString();
                var docDur = (from o in db.Uzi_Doctor
                              where o.DOCTOR == DoctorRB4.Text
                              where o.TEST == testCode
                              where o.MO == MoDL.SelectedValue.ToString()
                              select o);
                durationLabel.Text = docDur.ToList().ElementAt(0).DURATION.ToString() + " мин.";
            }
            else if (CityDL.Text == "Томск")
            {
                priceLabel.Text = testprice.ToList().ElementAt(0).tomsk_price.ToString();
                PrepTB.Text = testprice.ToList().ElementAt(0).tomsk_prep.ToString();
                var docDur = (from o in db.Uzi_Doctor
                              where o.DOCTOR == DoctorRB4.Text
                              where o.TEST == testCode
                              where o.MO == MoDL.SelectedValue.ToString()
                              select o);
                durationLabel.Text = docDur.ToList().ElementAt(0).DURATION.ToString() + " мин.";
            }
            else if (CityDL.Text == "Омск")
            {
                priceLabel.Text = testprice.ToList().ElementAt(0).omsk_price.ToString();
                PrepTB.Text = testprice.ToList().ElementAt(0).common_prep.ToString();
                var docDur = (from o in db.Uzi_Doctor
                              where o.DOCTOR == DoctorRB4.Text
                              where o.TEST == testCode
                              where o.MO == MoDL.SelectedValue.ToString()
                              select o);
                durationLabel.Text = docDur.ToList().ElementAt(0).DURATION.ToString() + " мин.";
            }
            else if (CityDL.Text == "Иркутск")
            {
                priceLabel.Text = testprice.ToList().ElementAt(0).irk_price.ToString();
                PrepTB.Text = testprice.ToList().ElementAt(0).common_prep.ToString();
                var docDur = (from o in db.Uzi_Doctor
                              where o.DOCTOR == DoctorRB4.Text
                              where o.TEST == testCode
                              where o.MO == MoDL.SelectedValue.ToString()
                              select o);
                durationLabel.Text = docDur.ToList().ElementAt(0).DURATION.ToString() + " мин.";
            }
        }
    }

    protected void TestLB5_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (TestLB5.SelectedIndex != -1)
        {
            var test = TestLB5.SelectedItem.Text.Split('-');
            string testCode = test[0];
            var testprice = from o in db.Uzi_Price
                            where o.test == testCode
                            select o;
            if (CityDL.Text == "Новосибирск")
            {
                priceLabel.Text = testprice.ToList().ElementAt(0).nsk_price.ToString();
                PrepTB.Text = testprice.ToList().ElementAt(0).common_prep.ToString();
                var docDur = (from o in db.Uzi_Doctor
                              where o.DOCTOR == DoctorRB5.Text
                              where o.TEST == testCode
                              where o.MO == MoDL.SelectedValue.ToString()
                              select o);
                durationLabel.Text = docDur.ToList().ElementAt(0).DURATION.ToString() + " мин.";
            }
            else if (CityDL.Text == "Красноярск")
            {
                priceLabel.Text = testprice.ToList().ElementAt(0).krs_price.ToString();
                PrepTB.Text = testprice.ToList().ElementAt(0).common_prep.ToString();
                var docDur = (from o in db.Uzi_Doctor
                              where o.DOCTOR == DoctorRB5.Text
                              where o.TEST == testCode
                              where o.MO == MoDL.SelectedValue.ToString()
                              select o);
                durationLabel.Text = docDur.ToList().ElementAt(0).DURATION.ToString() + " мин.";
            }
            else if (CityDL.Text == "Томск")
            {
                priceLabel.Text = testprice.ToList().ElementAt(0).tomsk_price.ToString();
                PrepTB.Text = testprice.ToList().ElementAt(0).tomsk_prep.ToString();
                var docDur = (from o in db.Uzi_Doctor
                              where o.DOCTOR == DoctorRB5.Text
                              where o.TEST == testCode
                              where o.MO == MoDL.SelectedValue.ToString()
                              select o);
                durationLabel.Text = docDur.ToList().ElementAt(0).DURATION.ToString() + " мин.";
            }
            else if (CityDL.Text == "Омск")
            {
                priceLabel.Text = testprice.ToList().ElementAt(0).omsk_price.ToString();
                PrepTB.Text = testprice.ToList().ElementAt(0).common_prep.ToString();
                var docDur = (from o in db.Uzi_Doctor
                              where o.DOCTOR == DoctorRB5.Text
                              where o.TEST == testCode
                              where o.MO == MoDL.SelectedValue.ToString()
                              select o);
                durationLabel.Text = docDur.ToList().ElementAt(0).DURATION.ToString() + " мин.";
            }
            else if (CityDL.Text == "Иркутск")
            {
                priceLabel.Text = testprice.ToList().ElementAt(0).irk_price.ToString();
                PrepTB.Text = testprice.ToList().ElementAt(0).common_prep.ToString();
                var docDur = (from o in db.Uzi_Doctor
                              where o.DOCTOR == DoctorRB5.Text
                              where o.TEST == testCode
                              where o.MO == MoDL.SelectedValue.ToString()
                              select o);
                durationLabel.Text = docDur.ToList().ElementAt(0).DURATION.ToString() + " мин.";
            }
        }
    }

    protected void AddBT1_Click(object sender, EventArgs e)
    {
        TestLabel1.Text = TestLB1.SelectedItem.Text;
    }

    protected void AddBT2_Click(object sender, EventArgs e)
    {
        TestLabel2.Text = TestLB2.SelectedItem.Text;
    }

    protected void AddBT3_Click(object sender, EventArgs e)
    {
        TestLabel3.Text = TestLB3.SelectedItem.Text;
    }

    protected void AddBT4_Click(object sender, EventArgs e)
    {
        TestLabel4.Text = TestLB4.SelectedItem.Text;
    }

    protected void AddBT5_Click(object sender, EventArgs e)
    {
        TestLabel5.Text = TestLB5.SelectedItem.Text;
    }

    protected void AgeDL_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void YesDelBT_Click(object sender, EventArgs e)
    {
        Uzi_Zapisi editZapis = db.Uzi_Zapisi.SingleOrDefault(x => x.ID == Convert.ToInt32(recordID.Text));
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
        var docs = (from d in db.Uzi_Zapisi
                    where d.city == CityDL.SelectedValue.ToString()
                    where d.mo == MoDL.SelectedValue.ToString()
                    where d.date == DateDL.SelectedValue
                    select d.doctor).Distinct();
        if (DoctorRB1.Checked)
        {
            time1(docs.ToList().ElementAt(0).ToString());
        }
        else if (DoctorRB2.Checked)
        {
            time2(docs.ToList().ElementAt(1).ToString());
        }
        else if (DoctorRB3.Checked)
        {
            time3(docs.ToList().ElementAt(2).ToString());
        }
        else if (DoctorRB4.Checked)
        {
            time4(docs.ToList().ElementAt(3).ToString());
        }
        else if (DoctorRB5.Checked)
        {
            time5(docs.ToList().ElementAt(4).ToString());
        }

    }

    protected void SexDL_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void ConfirmBT_Click(object sender, EventArgs e)
    {
        Uzi_Zapisi editZapis = db.Uzi_Zapisi.SingleOrDefault(x => x.ID == Convert.ToInt32(recordID.Text));
        editZapis.accept = true;
        db.SubmitChanges();
        var docs = (from d in db.Uzi_Zapisi
                    where d.city == CityDL.SelectedValue.ToString()
                    where d.mo == MoDL.SelectedValue.ToString()
                    where d.date == DateDL.SelectedValue
                    select d.doctor).Distinct();
        if (DoctorRB1.Checked)
        {
            time1(docs.ToList().ElementAt(0).ToString());
        }
        else if (DoctorRB2.Checked)
        {
            time2(docs.ToList().ElementAt(1).ToString());
        }
        else if (DoctorRB3.Checked)
        {
            time3(docs.ToList().ElementAt(2).ToString());
        }
        else if (DoctorRB4.Checked)
        {
            time4(docs.ToList().ElementAt(3).ToString());
        }
        else if (DoctorRB5.Checked)
        {
            time5(docs.ToList().ElementAt(4).ToString());
        }
    }
}
