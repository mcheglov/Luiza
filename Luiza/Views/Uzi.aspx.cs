using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
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
            adminMenu.Visible = true;
        }
        else
        {
            adminMenu.Visible = false;
        }
        if (!IsPostBack)
        {

            ChangeBT.Visible = false;
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
        TestLB1.Items.Clear();
        TestLB2.Items.Clear();
        TestLB3.Items.Clear();
        TestLB4.Items.Clear();
        TestLB5.Items.Clear();
        uziStatus.Text = "";
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
                    where t.hidden == false
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
        DoctorTimeLB2.Items.Clear();
        DoctorRB2.Text = doctor;
        var time = (from t in db.Uzi_Zapisi
                    where t.date == DateDL.SelectedValue
                    where t.mo == MoDL.SelectedValue
                    where t.city == CityDL.SelectedValue
                    where t.doctor == doctor
                    where t.hidden == false
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
                DoctorTimeLB2.Items.Add(time.ToList().ElementAt(i).time + " - " + time.ToList().ElementAt(i).name_1 + " - " + accept);
                if (time.ToList().ElementAt(i).accept.ToString() == "True")
                {
                    DoctorTimeLB2.Items[i].Attributes.Add("style", "background-color: Lime; color: Red");
                }
                else
                {
                    DoctorTimeLB2.Items[i].Attributes.Add("style", "background-color: Yellow; color: Red");
                }

            }
            else
            {
                DoctorTimeLB2.Items.Add(time.ToList().ElementAt(i).time);
            }
        }
    }

    private void time3(string doctor)
    {
        DoctorTimeLB3.Items.Clear();
        DoctorRB3.Text = doctor;
        var time = (from t in db.Uzi_Zapisi
                    where t.date == DateDL.SelectedValue
                    where t.mo == MoDL.SelectedValue
                    where t.city == CityDL.SelectedValue
                    where t.doctor == doctor
                    where t.hidden == false
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
                DoctorTimeLB3.Items.Add(time.ToList().ElementAt(i).time + " - " + time.ToList().ElementAt(i).name_1 + " - " + accept);
                if (time.ToList().ElementAt(i).accept.ToString() == "True")
                {
                    DoctorTimeLB3.Items[i].Attributes.Add("style", "background-color: Lime; color: Red");
                }
                else
                {
                    DoctorTimeLB3.Items[i].Attributes.Add("style", "background-color: Yellow; color: Red");
                }

            }
            else
            {
                DoctorTimeLB3.Items.Add(time.ToList().ElementAt(i).time);
            }
        }
    }

    private void time4(string doctor)
    {
        DoctorTimeLB4.Items.Clear();
        DoctorRB4.Text = doctor;
        var time = (from t in db.Uzi_Zapisi
                    where t.date == DateDL.SelectedValue
                    where t.mo == MoDL.SelectedValue
                    where t.city == CityDL.SelectedValue
                    where t.doctor == doctor
                    where t.hidden == false
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
                DoctorTimeLB4.Items.Add(time.ToList().ElementAt(i).time + " - " + time.ToList().ElementAt(i).name_1 + " - " + accept);
                if (time.ToList().ElementAt(i).accept.ToString() == "True")
                {
                    DoctorTimeLB4.Items[i].Attributes.Add("style", "background-color: Lime; color: Red");
                }
                else
                {
                    DoctorTimeLB4.Items[i].Attributes.Add("style", "background-color: Yellow; color: Red");
                }

            }
            else
            {
                DoctorTimeLB4.Items.Add(time.ToList().ElementAt(i).time);
            }
        }
    }

    private void time5(string doctor)
    {
        DoctorTimeLB5.Items.Clear();
        DoctorRB5.Text = doctor;
        var time = (from t in db.Uzi_Zapisi
                    where t.date == DateDL.SelectedValue
                    where t.mo == MoDL.SelectedValue
                    where t.city == CityDL.SelectedValue
                    where t.doctor == doctor
                    where t.hidden == false
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
                DoctorTimeLB5.Items.Add(time.ToList().ElementAt(i).time + " - " + time.ToList().ElementAt(i).name_1 + " - " + accept);
                if (time.ToList().ElementAt(i).accept.ToString() == "True")
                {
                    DoctorTimeLB5.Items[i].Attributes.Add("style", "background-color: Lime; color: Red");
                }
                else
                {
                    DoctorTimeLB5.Items[i].Attributes.Add("style", "background-color: Yellow; color: Red");
                }

            }
            else
            {
                DoctorTimeLB5.Items.Add(time.ToList().ElementAt(i).time);
            }
        }
    }

    protected void SettingsBT_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Views/UziSettings.aspx");
    }

    protected void SubmitBT_Click(object sender, EventArgs e)
    {
        if (DoctorRB1.Checked)
        {
            if (DoctorTimeLB1.SelectedIndex != -1)
            {
                var zapis = from z in db.Uzi_Zapisi
                            where z.ID == Convert.ToInt32(recordID.Text)
                            select z;
                if (zapis.ToList().ElementAt(0).name_1.ToString().Length > 0)
                {
                    uziStatus.ForeColor = System.Drawing.Color.Red;
                    uziStatus.Text = "Запись уже занята";

                }
                else
                {
                    if (PhoneTB.Text.Length < 16 || FornameTB.Text =="" || NameTB.Text =="" || TestLabel1.Text =="")
                    {
                        uziStatus.ForeColor = System.Drawing.Color.Red;
                        uziStatus.Text = "Проверьте правильность введенных данных";
                    }
                    else
                    {
                        try
                        {
                            string t = DoctorTimeLB1.SelectedValue;
                            var address = from a in db.Uzi_Cities
                                          where a.city == CityDL.SelectedValue.ToString()
                                          where a.mo == MoDL.SelectedValue.ToString()
                                          select a;
                            string phone = PhoneTB.Text;
                            phone = phone.Remove(13, 1);
                            phone = phone.Remove(10, 1);
                            phone = phone.Remove(5, 2);
                            phone = phone.Remove(1, 1);
                            Uzi_Zapisi editZapis = db.Uzi_Zapisi.SingleOrDefault(x => x.ID == Convert.ToInt32(recordID.Text));
                            editZapis.name_1 = FornameTB.Text;
                            editZapis.name_2 = NameTB.Text;
                            editZapis.name_3 = MiddlenameTB.Text;
                            editZapis.phone = PhoneTB.Text;
                            editZapis.age = AgeDL.SelectedValue;
                            editZapis.sex = SexDL.SelectedValue;
                            editZapis.mo = MoDL.SelectedValue;
                            editZapis.city = CityDL.SelectedValue;
                            editZapis.comment = CommentTB.Text;
                            editZapis.services = TestLabel1.Text;
                            editZapis.admin = Request.Cookies["Visitor"]["user"];
                            int err = 0;
                            var duration = (from o in db.Uzi_Doctor
                                            where o.DOCTOR == DoctorRB1.Text
                                            where o.TEST == TestLabel1.Text
                                            select o);
                            if (duration.ToList().ElementAt(0).DURATION.ToString() == "40" || duration.ToList().ElementAt(0).DURATION.ToString() == "30")
                            {
                                var zapis2 = from z in db.Uzi_Zapisi
                                             where z.ID == Convert.ToInt32(recordID.Text) + 1
                                             select z;
                                if (zapis2.ToList().ElementAt(0).name_1.ToString().Length > 0 || zapis2.ToList().ElementAt(0).hidden.ToString() == "True")
                                {
                                    uziStatus.ForeColor = System.Drawing.Color.Red;
                                    uziStatus.Text = "Невозможно записать! ";
                                    err = 1;
                                }
                                else
                                {
                                    Uzi_Zapisi editZapis2 = db.Uzi_Zapisi.SingleOrDefault(x => x.ID == Convert.ToInt32(recordID.Text) + 1);
                                    editZapis2.name_1 = "Продолжение ID:" + recordID.Text;
                                    db.SubmitChanges();
                                }
                            }
                            if (duration.ToList().ElementAt(0).DURATION.ToString() == "60" || duration.ToList().ElementAt(0).DURATION.ToString() == "45")
                            {
                                var zapis2 = from z in db.Uzi_Zapisi
                                             where z.ID == Convert.ToInt32(recordID.Text) + 1
                                             select z;
                                if (zapis2.ToList().ElementAt(0).name_1.ToString().Length > 0 || zapis2.ToList().ElementAt(0).hidden.ToString() == "True")
                                {
                                    uziStatus.ForeColor = System.Drawing.Color.Red;
                                    uziStatus.Text = "Невозможно записать! ";
                                    err = 1;
                                }
                                else
                                {
                                    var zapis3 = from z in db.Uzi_Zapisi
                                                 where z.ID == Convert.ToInt32(recordID.Text) + 2
                                                 select z;
                                    if (zapis3.ToList().ElementAt(0).name_1.ToString().Length > 0 || zapis3.ToList().ElementAt(0).hidden.ToString() == "True")
                                    {
                                        uziStatus.ForeColor = System.Drawing.Color.Red;
                                        uziStatus.Text = "Невозможно записать! ";
                                        err = 1;
                                    }
                                    else
                                    {
                                        Uzi_Zapisi editZapis2 = db.Uzi_Zapisi.SingleOrDefault(x => x.ID == Convert.ToInt32(recordID.Text) + 1);
                                        editZapis2.name_1 = "Продолжение ID:" + recordID.Text;
                                        db.SubmitChanges();
                                        Uzi_Zapisi editZapis3 = db.Uzi_Zapisi.SingleOrDefault(x => x.ID == Convert.ToInt32(recordID.Text) + 2);
                                        editZapis3.name_1 = "Продолжение ID:" + recordID.Text;
                                        db.SubmitChanges();
                                    }
                                }
                            }

                            if (err == 0)
                            {
                                db.SubmitChanges();
                                RbUpdate();
                                NameTB.Text = "";
                                FornameTB.Text = "";
                                MiddlenameTB.Text = "";
                                PhoneTB.Text = "";
                                DoctorTimeLB1.SelectedIndex = -1;
                                TestLabel1.Text = "";
                                TestLB1.Items.Clear();
                                CommentTB.Text = "";
                                AgeDL.SelectedIndex = 0;
                                SexDL.SelectedIndex = 0;
                                recordID.Text = "";
                                toSend(phone: phone, message: "Запись УЗИ " + DateDL.SelectedValue + " в " + t + " по адресу " + CityDL.SelectedValue.ToString() + " " + address.ToList().ElementAt(0).address.ToString() + " т. 8-800-234-40-50");
                            }
                            else
                            {
                                uziStatus.ForeColor = System.Drawing.Color.Red;
                                uziStatus.Text = "Ошибка";
                            }
                        }
                        catch (Exception ex)
                        {
                            uziStatus.ForeColor = System.Drawing.Color.Red;
                            uziStatus.Text = ex.ToString();
                        }
                    }
                }
            }
        }

        if (DoctorRB2.Checked)
        {
            if (DoctorTimeLB2.SelectedIndex != -1)
            {
                var zapis = from z in db.Uzi_Zapisi
                            where z.ID == Convert.ToInt32(recordID.Text)
                            select z;
                if (zapis.ToList().ElementAt(0).name_1.ToString().Length > 0)
                {
                    uziStatus.ForeColor = System.Drawing.Color.Red;
                    uziStatus.Text = "Запись уже занята";

                }
                else
                {
                    if (PhoneTB.Text.Length < 16 || FornameTB.Text == "" || NameTB.Text == "" || TestLabel2.Text == "")
                    {
                        uziStatus.ForeColor = System.Drawing.Color.Red;
                        uziStatus.Text = "Проверьте правильность введенных данных";
                    }
                    else
                    {
                        try
                        {
                            string t = DoctorTimeLB2.SelectedValue;
                            var address = from a in db.Uzi_Cities
                                          where a.city == CityDL.SelectedValue.ToString()
                                          where a.mo == MoDL.SelectedValue.ToString()
                                          select a;
                            string phone = PhoneTB.Text;
                            phone = phone.Remove(13, 1);
                            phone = phone.Remove(10, 1);
                            phone = phone.Remove(5, 2);
                            phone = phone.Remove(1, 1);
                            Uzi_Zapisi editZapis = db.Uzi_Zapisi.SingleOrDefault(x => x.ID == Convert.ToInt32(recordID.Text));
                            editZapis.name_1 = FornameTB.Text;
                            editZapis.name_2 = NameTB.Text;
                            editZapis.name_3 = MiddlenameTB.Text;
                            editZapis.phone = PhoneTB.Text;
                            editZapis.age = AgeDL.SelectedValue;
                            editZapis.sex = SexDL.SelectedValue;
                            editZapis.mo = MoDL.SelectedValue;
                            editZapis.city = CityDL.SelectedValue;
                            editZapis.comment = CommentTB.Text;
                            editZapis.services = TestLabel1.Text;
                            editZapis.admin = Request.Cookies["Visitor"]["user"];
                            int err = 0;
                            var duration = (from o in db.Uzi_Doctor
                                            where o.DOCTOR == DoctorRB2.Text
                                            where o.TEST == TestLabel2.Text
                                            select o);
                            if (duration.ToList().ElementAt(0).DURATION.ToString() == "40" || duration.ToList().ElementAt(0).DURATION.ToString() == "30")
                            {
                                var zapis2 = from z in db.Uzi_Zapisi
                                             where z.ID == Convert.ToInt32(recordID.Text) + 1
                                             select z;
                                if (zapis2.ToList().ElementAt(0).name_1.ToString().Length > 0 || zapis2.ToList().ElementAt(0).hidden.ToString() == "True")
                                {
                                    uziStatus.ForeColor = System.Drawing.Color.Red;
                                    uziStatus.Text = "Невозможно записать! ";
                                    err = 1;
                                }
                                else
                                {
                                    Uzi_Zapisi editZapis2 = db.Uzi_Zapisi.SingleOrDefault(x => x.ID == Convert.ToInt32(recordID.Text) + 1);
                                    editZapis2.name_1 = "Продолжение ID:" + recordID.Text;
                                    db.SubmitChanges();
                                }
                            }
                            if (duration.ToList().ElementAt(0).DURATION.ToString() == "60" || duration.ToList().ElementAt(0).DURATION.ToString() == "45")
                            {
                                var zapis2 = from z in db.Uzi_Zapisi
                                             where z.ID == Convert.ToInt32(recordID.Text) + 1
                                             select z;
                                if (zapis2.ToList().ElementAt(0).name_1.ToString().Length > 0 || zapis2.ToList().ElementAt(0).hidden.ToString() == "True")
                                {
                                    uziStatus.ForeColor = System.Drawing.Color.Red;
                                    uziStatus.Text = "Невозможно записать! ";
                                    err = 1;
                                }
                                else
                                {
                                    var zapis3 = from z in db.Uzi_Zapisi
                                                 where z.ID == Convert.ToInt32(recordID.Text) + 2
                                                 select z;
                                    if (zapis3.ToList().ElementAt(0).name_1.ToString().Length > 0 || zapis3.ToList().ElementAt(0).hidden.ToString() == "True")
                                    {
                                        uziStatus.ForeColor = System.Drawing.Color.Red;
                                        uziStatus.Text = "Невозможно записать! ";
                                        err = 1;
                                    }
                                    else
                                    {
                                        Uzi_Zapisi editZapis2 = db.Uzi_Zapisi.SingleOrDefault(x => x.ID == Convert.ToInt32(recordID.Text) + 1);
                                        editZapis2.name_1 = "Продолжение ID:" + recordID.Text;
                                        db.SubmitChanges();
                                        Uzi_Zapisi editZapis3 = db.Uzi_Zapisi.SingleOrDefault(x => x.ID == Convert.ToInt32(recordID.Text) + 2);
                                        editZapis3.name_1 = "Продолжение ID:" + recordID.Text;
                                        db.SubmitChanges();
                                    }
                                }
                            }

                            if (err == 0)
                            {
                                db.SubmitChanges();
                                RbUpdate();
                                NameTB.Text = "";
                                FornameTB.Text = "";
                                MiddlenameTB.Text = "";
                                PhoneTB.Text = "";
                                DoctorTimeLB2.SelectedIndex = -1;
                                TestLabel2.Text = "";
                                TestLB2.Items.Clear();
                                CommentTB.Text = "";
                                AgeDL.SelectedIndex = 0;
                                SexDL.SelectedIndex = 0;
                                recordID.Text = "";
                                toSend(phone: phone, message: "Запись УЗИ " + DateDL.SelectedValue + " в " + t + " по адресу " + CityDL.SelectedValue.ToString() + " " + address.ToList().ElementAt(0).address.ToString() + " т. 8-800-234-40-50");
                            }
                            else
                            {
                                uziStatus.ForeColor = System.Drawing.Color.Red;
                                uziStatus.Text = "Ошибка";
                            }
                        }
                        catch (Exception ex)
                        {
                            uziStatus.ForeColor = System.Drawing.Color.Red;
                            uziStatus.Text = ex.ToString();
                        }
                    }
                }
            }
        }

        if (DoctorRB3.Checked)
        {
            if (DoctorTimeLB3.SelectedIndex != -1)
            {
                var zapis = from z in db.Uzi_Zapisi
                            where z.ID == Convert.ToInt32(recordID.Text)
                            select z;
                if (zapis.ToList().ElementAt(0).name_1.ToString().Length > 0)
                {
                    uziStatus.ForeColor = System.Drawing.Color.Red;
                    uziStatus.Text = "Запись уже занята";

                }
                else
                {
                    if (PhoneTB.Text.Length < 16 || FornameTB.Text == "" || NameTB.Text == "" || TestLabel3.Text == "")
                    {
                        uziStatus.ForeColor = System.Drawing.Color.Red;
                        uziStatus.Text = "Проверьте правильность введенных данных";
                    }
                    else
                    {
                        try
                        {
                            string t = DoctorTimeLB3.SelectedValue;
                            var address = from a in db.Uzi_Cities
                                          where a.city == CityDL.SelectedValue.ToString()
                                          where a.mo == MoDL.SelectedValue.ToString()
                                          select a;
                            string phone = PhoneTB.Text;
                            phone = phone.Remove(13, 1);
                            phone = phone.Remove(10, 1);
                            phone = phone.Remove(5, 2);
                            phone = phone.Remove(1, 1);
                            Uzi_Zapisi editZapis = db.Uzi_Zapisi.SingleOrDefault(x => x.ID == Convert.ToInt32(recordID.Text));
                            editZapis.name_1 = FornameTB.Text;
                            editZapis.name_2 = NameTB.Text;
                            editZapis.name_3 = MiddlenameTB.Text;
                            editZapis.phone = PhoneTB.Text;
                            editZapis.age = AgeDL.SelectedValue;
                            editZapis.sex = SexDL.SelectedValue;
                            editZapis.mo = MoDL.SelectedValue;
                            editZapis.city = CityDL.SelectedValue;
                            editZapis.comment = CommentTB.Text;
                            editZapis.services = TestLabel3.Text;
                            editZapis.admin = Request.Cookies["Visitor"]["user"];
                            int err = 0;
                            var duration = (from o in db.Uzi_Doctor
                                            where o.DOCTOR == DoctorRB3.Text
                                            where o.TEST == TestLabel3.Text
                                            select o);
                            if (duration.ToList().ElementAt(0).DURATION.ToString() == "40" || duration.ToList().ElementAt(0).DURATION.ToString() == "30")
                            {
                                var zapis2 = from z in db.Uzi_Zapisi
                                             where z.ID == Convert.ToInt32(recordID.Text) + 1
                                             select z;
                                if (zapis2.ToList().ElementAt(0).name_1.ToString().Length > 0 || zapis2.ToList().ElementAt(0).hidden.ToString() == "True")
                                {
                                    uziStatus.ForeColor = System.Drawing.Color.Red;
                                    uziStatus.Text = "Невозможно записать! ";
                                    err = 1;
                                }
                                else
                                {
                                    Uzi_Zapisi editZapis2 = db.Uzi_Zapisi.SingleOrDefault(x => x.ID == Convert.ToInt32(recordID.Text) + 1);
                                    editZapis2.name_1 = "Продолжение ID:" + recordID.Text;
                                    db.SubmitChanges();
                                }
                            }
                            if (duration.ToList().ElementAt(0).DURATION.ToString() == "60" || duration.ToList().ElementAt(0).DURATION.ToString() == "45")
                            {
                                var zapis2 = from z in db.Uzi_Zapisi
                                             where z.ID == Convert.ToInt32(recordID.Text) + 1
                                             select z;
                                if (zapis2.ToList().ElementAt(0).name_1.ToString().Length > 0 || zapis2.ToList().ElementAt(0).hidden.ToString() == "True")
                                {
                                    uziStatus.ForeColor = System.Drawing.Color.Red;
                                    uziStatus.Text = "Невозможно записать! ";
                                    err = 1;
                                }
                                else
                                {
                                    var zapis3 = from z in db.Uzi_Zapisi
                                                 where z.ID == Convert.ToInt32(recordID.Text) + 2
                                                 select z;
                                    if (zapis3.ToList().ElementAt(0).name_1.ToString().Length > 0 || zapis3.ToList().ElementAt(0).hidden.ToString() == "True")
                                    {
                                        uziStatus.ForeColor = System.Drawing.Color.Red;
                                        uziStatus.Text = "Невозможно записать! ";
                                        err = 1;
                                    }
                                    else
                                    {
                                        Uzi_Zapisi editZapis2 = db.Uzi_Zapisi.SingleOrDefault(x => x.ID == Convert.ToInt32(recordID.Text) + 1);
                                        editZapis2.name_1 = "Продолжение ID:" + recordID.Text;
                                        db.SubmitChanges();
                                        Uzi_Zapisi editZapis3 = db.Uzi_Zapisi.SingleOrDefault(x => x.ID == Convert.ToInt32(recordID.Text) + 2);
                                        editZapis3.name_1 = "Продолжение ID:" + recordID.Text;
                                        db.SubmitChanges();
                                    }
                                }
                            }

                            if (err == 0)
                            {
                                db.SubmitChanges();
                                RbUpdate();
                                NameTB.Text = "";
                                FornameTB.Text = "";
                                MiddlenameTB.Text = "";
                                PhoneTB.Text = "";
                                DoctorTimeLB3.SelectedIndex = -1;
                                TestLabel3.Text = "";
                                TestLB3.Items.Clear();
                                CommentTB.Text = "";
                                AgeDL.SelectedIndex = 0;
                                SexDL.SelectedIndex = 0;
                                recordID.Text = "";
                                toSend(phone: phone, message: "Запись УЗИ " + DateDL.SelectedValue + " в " + t + " по адресу " + CityDL.SelectedValue.ToString() + " " + address.ToList().ElementAt(0).address.ToString() + " т. 8-800-234-40-50");
                            }
                            else
                            {
                                uziStatus.ForeColor = System.Drawing.Color.Red;
                                uziStatus.Text = "Ошибка";
                            }
                        }
                        catch (Exception ex)
                        {
                            uziStatus.ForeColor = System.Drawing.Color.Red;
                            uziStatus.Text = ex.ToString();
                        }
                    }
                }
            }
        }

        if (DoctorRB4.Checked)
        {
            if (DoctorTimeLB4.SelectedIndex != -1)
            {
                var zapis = from z in db.Uzi_Zapisi
                            where z.ID == Convert.ToInt32(recordID.Text)
                            select z;
                if (zapis.ToList().ElementAt(0).name_1.ToString().Length > 0)
                {
                    uziStatus.ForeColor = System.Drawing.Color.Red;
                    uziStatus.Text = "Запись уже занята";

                }
                else
                {
                    if (PhoneTB.Text.Length < 16 || FornameTB.Text == "" || NameTB.Text == "" || TestLabel4.Text == "")
                    {
                        uziStatus.ForeColor = System.Drawing.Color.Red;
                        uziStatus.Text = "Проверьте правильность введенных данных";
                    }
                    else
                    {
                        try
                        {
                            string t = DoctorTimeLB4.SelectedValue;
                            var address = from a in db.Uzi_Cities
                                          where a.city == CityDL.SelectedValue.ToString()
                                          where a.mo == MoDL.SelectedValue.ToString()
                                          select a;
                            string phone = PhoneTB.Text;
                            phone = phone.Remove(13, 1);
                            phone = phone.Remove(10, 1);
                            phone = phone.Remove(5, 2);
                            phone = phone.Remove(1, 1);
                            Uzi_Zapisi editZapis = db.Uzi_Zapisi.SingleOrDefault(x => x.ID == Convert.ToInt32(recordID.Text));
                            editZapis.name_1 = FornameTB.Text;
                            editZapis.name_2 = NameTB.Text;
                            editZapis.name_3 = MiddlenameTB.Text;
                            editZapis.phone = PhoneTB.Text;
                            editZapis.age = AgeDL.SelectedValue;
                            editZapis.sex = SexDL.SelectedValue;
                            editZapis.mo = MoDL.SelectedValue;
                            editZapis.city = CityDL.SelectedValue;
                            editZapis.comment = CommentTB.Text;
                            editZapis.services = TestLabel4.Text;
                            editZapis.admin = Request.Cookies["Visitor"]["user"];
                            int err = 0;
                            var duration = (from o in db.Uzi_Doctor
                                            where o.DOCTOR == DoctorRB4.Text
                                            where o.TEST == TestLabel4.Text
                                            select o);
                            if (duration.ToList().ElementAt(0).DURATION.ToString() == "40" || duration.ToList().ElementAt(0).DURATION.ToString() == "30")
                            {
                                var zapis2 = from z in db.Uzi_Zapisi
                                             where z.ID == Convert.ToInt32(recordID.Text) + 1
                                             select z;
                                if (zapis2.ToList().ElementAt(0).name_1.ToString().Length > 0 || zapis2.ToList().ElementAt(0).hidden.ToString() == "True")
                                {
                                    uziStatus.ForeColor = System.Drawing.Color.Red;
                                    uziStatus.Text = "Невозможно записать! ";
                                    err = 1;
                                }
                                else
                                {
                                    Uzi_Zapisi editZapis2 = db.Uzi_Zapisi.SingleOrDefault(x => x.ID == Convert.ToInt32(recordID.Text) + 1);
                                    editZapis2.name_1 = "Продолжение ID:" + recordID.Text;
                                    db.SubmitChanges();
                                }
                            }
                            if (duration.ToList().ElementAt(0).DURATION.ToString() == "60" || duration.ToList().ElementAt(0).DURATION.ToString() == "45")
                            {
                                var zapis2 = from z in db.Uzi_Zapisi
                                             where z.ID == Convert.ToInt32(recordID.Text) + 1
                                             select z;
                                if (zapis2.ToList().ElementAt(0).name_1.ToString().Length > 0 || zapis2.ToList().ElementAt(0).hidden.ToString() == "True")
                                {
                                    uziStatus.ForeColor = System.Drawing.Color.Red;
                                    uziStatus.Text = "Невозможно записать! ";
                                    err = 1;
                                }
                                else
                                {
                                    var zapis3 = from z in db.Uzi_Zapisi
                                                 where z.ID == Convert.ToInt32(recordID.Text) + 2
                                                 select z;
                                    if (zapis3.ToList().ElementAt(0).name_1.ToString().Length > 0 || zapis3.ToList().ElementAt(0).hidden.ToString() == "True")
                                    {
                                        uziStatus.ForeColor = System.Drawing.Color.Red;
                                        uziStatus.Text = "Невозможно записать! ";
                                        err = 1;
                                    }
                                    else
                                    {
                                        Uzi_Zapisi editZapis2 = db.Uzi_Zapisi.SingleOrDefault(x => x.ID == Convert.ToInt32(recordID.Text) + 1);
                                        editZapis2.name_1 = "Продолжение ID:" + recordID.Text;
                                        db.SubmitChanges();
                                        Uzi_Zapisi editZapis3 = db.Uzi_Zapisi.SingleOrDefault(x => x.ID == Convert.ToInt32(recordID.Text) + 2);
                                        editZapis3.name_1 = "Продолжение ID:" + recordID.Text;
                                        db.SubmitChanges();
                                    }
                                }
                            }

                            if (err == 0)
                            {
                                db.SubmitChanges();
                                RbUpdate();
                                NameTB.Text = "";
                                FornameTB.Text = "";
                                MiddlenameTB.Text = "";
                                PhoneTB.Text = "";
                                DoctorTimeLB4.SelectedIndex = -1;
                                TestLabel4.Text = "";
                                TestLB4.Items.Clear();
                                CommentTB.Text = "";
                                AgeDL.SelectedIndex = 0;
                                SexDL.SelectedIndex = 0;
                                recordID.Text = "";
                                toSend(phone: phone, message: "Запись УЗИ " + DateDL.SelectedValue + " в " + t + " по адресу " + CityDL.SelectedValue.ToString() + " " + address.ToList().ElementAt(0).address.ToString() + " т. 8-800-234-40-50");
                            }
                            else
                            {
                                uziStatus.ForeColor = System.Drawing.Color.Red;
                                uziStatus.Text = "Ошибка";
                            }
                        }
                        catch (Exception ex)
                        {
                            uziStatus.ForeColor = System.Drawing.Color.Red;
                            uziStatus.Text = ex.ToString();
                        }
                    }
                }
            }
        }

        if (DoctorRB5.Checked)
        {
            if (DoctorTimeLB5.SelectedIndex != -1)
            {
                var zapis = from z in db.Uzi_Zapisi
                            where z.ID == Convert.ToInt32(recordID.Text)
                            select z;
                if (zapis.ToList().ElementAt(0).name_1.ToString().Length > 0)
                {
                    uziStatus.ForeColor = System.Drawing.Color.Red;
                    uziStatus.Text = "Запись уже занята";

                }
                else
                {
                    if (PhoneTB.Text.Length < 16 || FornameTB.Text == "" || NameTB.Text == "" || TestLabel5.Text == "")
                    {
                        uziStatus.ForeColor = System.Drawing.Color.Red;
                        uziStatus.Text = "Проверьте правильность введенных данных";
                    }
                    else
                    {
                        try
                        {
                            string t = DoctorTimeLB5.SelectedValue;
                            var address = from a in db.Uzi_Cities
                                          where a.city == CityDL.SelectedValue.ToString()
                                          where a.mo == MoDL.SelectedValue.ToString()
                                          select a;
                            string phone = PhoneTB.Text;
                            phone = phone.Remove(13, 1);
                            phone = phone.Remove(10, 1);
                            phone = phone.Remove(5, 2);
                            phone = phone.Remove(1, 1);
                            Uzi_Zapisi editZapis = db.Uzi_Zapisi.SingleOrDefault(x => x.ID == Convert.ToInt32(recordID.Text));
                            editZapis.name_1 = FornameTB.Text;
                            editZapis.name_2 = NameTB.Text;
                            editZapis.name_3 = MiddlenameTB.Text;
                            editZapis.phone = PhoneTB.Text;
                            editZapis.age = AgeDL.SelectedValue;
                            editZapis.sex = SexDL.SelectedValue;
                            editZapis.mo = MoDL.SelectedValue;
                            editZapis.city = CityDL.SelectedValue;
                            editZapis.comment = CommentTB.Text;
                            editZapis.services = TestLabel5.Text;
                            editZapis.admin = Request.Cookies["Visitor"]["user"];
                            int err = 0;
                            var duration = (from o in db.Uzi_Doctor
                                            where o.DOCTOR == DoctorRB5.Text
                                            where o.TEST == TestLabel5.Text
                                            select o);
                            if (duration.ToList().ElementAt(0).DURATION.ToString() == "40" || duration.ToList().ElementAt(0).DURATION.ToString() == "30")
                            {
                                var zapis2 = from z in db.Uzi_Zapisi
                                             where z.ID == Convert.ToInt32(recordID.Text) + 1
                                             select z;
                                if (zapis2.ToList().ElementAt(0).name_1.ToString().Length > 0 || zapis2.ToList().ElementAt(0).hidden.ToString() == "True")
                                {
                                    uziStatus.ForeColor = System.Drawing.Color.Red;
                                    uziStatus.Text = "Невозможно записать! ";
                                    err = 1;
                                }
                                else
                                {
                                    Uzi_Zapisi editZapis2 = db.Uzi_Zapisi.SingleOrDefault(x => x.ID == Convert.ToInt32(recordID.Text) + 1);
                                    editZapis2.name_1 = "Продолжение ID:" + recordID.Text;
                                    db.SubmitChanges();
                                }
                            }
                            if (duration.ToList().ElementAt(0).DURATION.ToString() == "60" || duration.ToList().ElementAt(0).DURATION.ToString() == "45")
                            {
                                var zapis2 = from z in db.Uzi_Zapisi
                                             where z.ID == Convert.ToInt32(recordID.Text) + 1
                                             select z;
                                if (zapis2.ToList().ElementAt(0).name_1.ToString().Length > 0 || zapis2.ToList().ElementAt(0).hidden.ToString() == "True")
                                {
                                    uziStatus.ForeColor = System.Drawing.Color.Red;
                                    uziStatus.Text = "Невозможно записать! ";
                                    err = 1;
                                }
                                else
                                {
                                    var zapis3 = from z in db.Uzi_Zapisi
                                                 where z.ID == Convert.ToInt32(recordID.Text) + 2
                                                 select z;
                                    if (zapis3.ToList().ElementAt(0).name_1.ToString().Length > 0 || zapis3.ToList().ElementAt(0).hidden.ToString() == "True")
                                    {
                                        uziStatus.ForeColor = System.Drawing.Color.Red;
                                        uziStatus.Text = "Невозможно записать! ";
                                        err = 1;
                                    }
                                    else
                                    {
                                        Uzi_Zapisi editZapis2 = db.Uzi_Zapisi.SingleOrDefault(x => x.ID == Convert.ToInt32(recordID.Text) + 1);
                                        editZapis2.name_1 = "Продолжение ID:" + recordID.Text;
                                        db.SubmitChanges();
                                        Uzi_Zapisi editZapis3 = db.Uzi_Zapisi.SingleOrDefault(x => x.ID == Convert.ToInt32(recordID.Text) + 2);
                                        editZapis3.name_1 = "Продолжение ID:" + recordID.Text;
                                        db.SubmitChanges();
                                    }
                                }
                            }

                            if (err == 0)
                            {
                                db.SubmitChanges();
                                RbUpdate();
                                NameTB.Text = "";
                                FornameTB.Text = "";
                                MiddlenameTB.Text = "";
                                PhoneTB.Text = "";
                                DoctorTimeLB5.SelectedIndex = -1;
                                TestLabel5.Text = "";
                                TestLB5.Items.Clear();
                                CommentTB.Text = "";
                                AgeDL.SelectedIndex = 0;
                                SexDL.SelectedIndex = 0;
                                recordID.Text = "";
                                toSend(phone: phone, message: "Запись УЗИ " + DateDL.SelectedValue + " в " + t + " по адресу " + CityDL.SelectedValue.ToString() + " " + address.ToList().ElementAt(0).address.ToString() + " т. 8-800-234-40-50");
                            }
                            else
                            {
                                uziStatus.ForeColor = System.Drawing.Color.Red;
                                uziStatus.Text = "Ошибка";
                            }
                        }
                        catch (Exception ex)
                        {
                            uziStatus.ForeColor = System.Drawing.Color.Red;
                            uziStatus.Text = ex.ToString();
                        }
                    }
                }
            }
        }
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
            RbUpdate();

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
            RbUpdate();
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
                        where i.DOCTOR == DoctorRB3.Text
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
            RbUpdate();
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
            RbUpdate();
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
            RbUpdate();
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
                SubmitBT.Visible = false;
                ChangeBT.Visible = true;

            }
            else
            {
                SubmitBT.Visible = true;
                ChangeBT.Visible = false;
            }
            for (int i = 0; i < DoctorTimeLB1.Items.Count; i++)
            {
                if (DoctorTimeLB1.Items[i].Text.Contains("Подтвержден"))
                {
                    DoctorTimeLB1.Items[i].Attributes.Add("style", "background-color: Lime; color: Red");
                }
                else if (DoctorTimeLB1.Items[i].Text.Contains("Не подтвержден"))
                {
                    DoctorTimeLB1.Items[i].Attributes.Add("style", "background-color: Yellow; color: Red");
                }
            }
        }
    }

    protected void DoctorTimeLB2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DoctorRB2.Checked)
        {
            if (DoctorTimeLB2.SelectedIndex != -1)
            {
                var time = DoctorTimeLB2.SelectedItem.Text.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
                var delRecord = (from z in db.Uzi_Zapisi
                                 where z.doctor == DoctorRB2.Text
                                 where z.date == DateDL.SelectedValue
                                 where z.mo == MoDL.SelectedValue
                                 where z.city == CityDL.SelectedValue
                                 where z.time == time[0]
                                 select z);
                recordID.Text = delRecord.ToList().ElementAt(0).ID.ToString();

            }
            if (DoctorTimeLB2.SelectedValue.Contains(" - "))
            {
                SubmitBT.Visible = false;
                ChangeBT.Visible = true;

            }
            else
            {
                SubmitBT.Visible = true;
                ChangeBT.Visible = false;
            }
            for (int i = 0; i < DoctorTimeLB2.Items.Count; i++)
            {
                if (DoctorTimeLB2.Items[i].Text.Contains("Подтвержден"))
                {
                    DoctorTimeLB2.Items[i].Attributes.Add("style", "background-color: Lime; color: Red");
                }
                else if (DoctorTimeLB2.Items[i].Text.Contains("Не подтвержден"))
                {
                    DoctorTimeLB2.Items[i].Attributes.Add("style", "background-color: Yellow; color: Red");
                }
            }
        }
    }

    protected void DoctorTimeLB3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DoctorRB3.Checked)
        {
            if (DoctorTimeLB3.SelectedIndex != -1)
            {
                var time = DoctorTimeLB3.SelectedItem.Text.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
                var delRecord = (from z in db.Uzi_Zapisi
                                 where z.doctor == DoctorRB3.Text
                                 where z.date == DateDL.SelectedValue
                                 where z.mo == MoDL.SelectedValue
                                 where z.city == CityDL.SelectedValue
                                 where z.time == time[0]
                                 select z);
                recordID.Text = delRecord.ToList().ElementAt(0).ID.ToString();

            }
            if (DoctorTimeLB3.SelectedValue.Contains(" - "))
            {
                SubmitBT.Visible = false;
                ChangeBT.Visible = true;

            }
            else
            {
                SubmitBT.Visible = true;
                ChangeBT.Visible = false;
            }
            for (int i = 0; i < DoctorTimeLB3.Items.Count; i++)
            {
                if (DoctorTimeLB3.Items[i].Text.Contains("Подтвержден"))
                {
                    DoctorTimeLB3.Items[i].Attributes.Add("style", "background-color: Lime; color: Red");
                }
                else if (DoctorTimeLB3.Items[i].Text.Contains("Не подтвержден"))
                {
                    DoctorTimeLB3.Items[i].Attributes.Add("style", "background-color: Yellow; color: Red");
                }
            }
        }
    }

    protected void DoctorTimeLB4_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DoctorRB4.Checked)
        {
            if (DoctorTimeLB4.SelectedIndex != -1)
            {
                var time = DoctorTimeLB4.SelectedItem.Text.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
                var delRecord = (from z in db.Uzi_Zapisi
                                 where z.doctor == DoctorRB4.Text
                                 where z.date == DateDL.SelectedValue
                                 where z.mo == MoDL.SelectedValue
                                 where z.city == CityDL.SelectedValue
                                 where z.time == time[0]
                                 select z);
                recordID.Text = delRecord.ToList().ElementAt(0).ID.ToString();

            }
            if (DoctorTimeLB4.SelectedValue.Contains(" - "))
            {
                SubmitBT.Visible = false;
                ChangeBT.Visible = true;
            }
            else
            {
                SubmitBT.Visible = true;
                ChangeBT.Visible = false;
            }
            for (int i = 0; i < DoctorTimeLB4.Items.Count; i++)
            {
                if (DoctorTimeLB4.Items[i].Text.Contains("Подтвержден"))
                {
                    DoctorTimeLB4.Items[i].Attributes.Add("style", "background-color: Lime; color: Red");
                }
                else if (DoctorTimeLB4.Items[i].Text.Contains("Не подтвержден"))
                {
                    DoctorTimeLB4.Items[i].Attributes.Add("style", "background-color: Yellow; color: Red");
                }
            }
        }
    }

    protected void DoctorTimeLB5_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DoctorRB5.Checked)
        {
            if (DoctorTimeLB5.SelectedIndex != -1)
            {
                var time = DoctorTimeLB5.SelectedItem.Text.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
                var delRecord = (from z in db.Uzi_Zapisi
                                 where z.doctor == DoctorRB5.Text
                                 where z.date == DateDL.SelectedValue
                                 where z.mo == MoDL.SelectedValue
                                 where z.city == CityDL.SelectedValue
                                 where z.time == time[0]
                                 select z);
                recordID.Text = delRecord.ToList().ElementAt(0).ID.ToString();

            }
            if (DoctorTimeLB5.SelectedValue.Contains(" - "))
            {
                SubmitBT.Visible = false;
                ChangeBT.Visible = true;

            }
            else
            {
                SubmitBT.Visible = true;
                ChangeBT.Visible = false;
            }
            for (int i = 0; i < DoctorTimeLB5.Items.Count; i++)
            {
                if (DoctorTimeLB5.Items[i].Text.Contains("Подтвержден"))
                {
                    DoctorTimeLB5.Items[i].Attributes.Add("style", "background-color: Lime; color: Red");
                }
                else if (DoctorTimeLB5.Items[i].Text.Contains("Не подтвержден"))
                {
                    DoctorTimeLB5.Items[i].Attributes.Add("style", "background-color: Yellow; color: Red");
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
        RbUpdate();
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
        if (DoctorRB1.Checked)
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
                currentTest.Text = TestLB1.SelectedItem.Text;
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
                currentTest.Text = TestLB1.SelectedItem.Text;
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
                currentTest.Text = TestLB1.SelectedItem.Text;
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
                currentTest.Text = TestLB1.SelectedItem.Text;
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
                currentTest.Text = TestLB1.SelectedItem.Text;
            }
        }
        }

    }

    protected void TestLB2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DoctorRB2.Checked)
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
                    currentTest.Text = TestLB2.SelectedItem.Text;
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
                    currentTest.Text = TestLB2.SelectedItem.Text;

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
                    currentTest.Text = TestLB2.SelectedItem.Text;

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
                    currentTest.Text = TestLB2.SelectedItem.Text;

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
                    currentTest.Text = TestLB2.SelectedItem.Text;

                }
            }
        }
    }

    protected void TestLB3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DoctorRB3.Checked)
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
                currentTest.Text = TestLB3.SelectedItem.Text;

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
                currentTest.Text = TestLB3.SelectedItem.Text;

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
                currentTest.Text = TestLB3.SelectedItem.Text;

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
                currentTest.Text = TestLB3.SelectedItem.Text;

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
                currentTest.Text = TestLB3.SelectedItem.Text;

            }
        }
        }
    }

    protected void TestLB4_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DoctorRB4.Checked)
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
                    currentTest.Text = TestLB4.SelectedItem.Text;

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
                    currentTest.Text = TestLB4.SelectedItem.Text;
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
                    currentTest.Text = TestLB4.SelectedItem.Text;
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
                    currentTest.Text = TestLB4.SelectedItem.Text;
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
                    currentTest.Text = TestLB4.SelectedItem.Text;
                }
            }
        }
    }

    protected void TestLB5_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DoctorRB5.Checked)
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
                    currentTest.Text = TestLB5.SelectedItem.Text;
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
                    currentTest.Text = TestLB5.SelectedItem.Text;

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
                    currentTest.Text = TestLB5.SelectedItem.Text;

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
                    currentTest.Text = TestLB5.SelectedItem.Text;

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
                    currentTest.Text = TestLB5.SelectedItem.Text;

                }
            }
        }
    }

    protected void AddBT1_Click(object sender, EventArgs e)
    {
        if (TestLB1.SelectedIndex != -1)
        {
            var tosplit = TestLB1.SelectedItem.Text.Split('-');
            TestLabel1.Text = tosplit[0];
        }
    }

    protected void AddBT2_Click(object sender, EventArgs e)
    {
        if (TestLB2.SelectedIndex != -1)
        {
            var tosplit = TestLB2.SelectedItem.Text.Split('-');
            TestLabel2.Text = tosplit[0];
        }
    }

    protected void AddBT3_Click(object sender, EventArgs e)
    {
        if (TestLB3.SelectedIndex != -1)
        {
            var tosplit = TestLB3.SelectedItem.Text.Split('-');
            TestLabel3.Text = tosplit[0];
        }
    }

    protected void AddBT4_Click(object sender, EventArgs e)
    {
        if (TestLB4.SelectedIndex != -1)
        {
            var tosplit = TestLB4.SelectedItem.Text.Split('-');
            TestLabel4.Text = tosplit[0];
        }
    }

    protected void AddBT5_Click(object sender, EventArgs e)
    {
        if (TestLB4.SelectedIndex != -1)
        {
            var tosplit = TestLB4.SelectedItem.Text.Split('-');
            TestLabel4.Text = tosplit[0];
        }
    }

    protected void AgeDL_SelectedIndexChanged(object sender, EventArgs e)
    {

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

    protected void DoctorBT_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Views/UziAddDoctor.aspx");
    }

    private void toSend(string phone, string message)
    {
        string toCode = message + ";suz;" + phone + ";INVITRO;474c70f277e6f";
        byte[] bytes = Encoding.UTF8.GetBytes(toCode);
        var sha1 = SHA1.Create();
        byte[] hashBytes = sha1.ComputeHash(bytes);
        var sb = new StringBuilder(hashBytes.Length * 2);
        foreach (byte b in hashBytes)
        {
            sb.Append(b.ToString("x2"));
        }
        MD5 md5 = System.Security.Cryptography.MD5.Create();
        byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(sb.ToString());
        byte[] hash = md5.ComputeHash(inputBytes);
        StringBuilder sb1 = new StringBuilder();
        for (int i = 0; i < hash.Length; i++)
        {
            sb1.Append(hash[i].ToString("x2"));
        }
        string toSend = "https://mainsms.ru/api/mainsms/message/send?project=suz&sender=INVITRO&message=" + message + "&recipients=" + phone + "&sign=" + sb1.ToString();
        WebRequest req = WebRequest.Create(toSend);
        WebResponse resp = req.GetResponse();
    }

    protected void ChangeBT_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Views/UziReplace.aspx?id=" + recordID.Text);
    }
}
