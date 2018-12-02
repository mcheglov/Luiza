using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Sperm : System.Web.UI.Page
{
    toSQLDataContext db = new toSQLDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["param1"] == "1")
        {
            dayRemoverBT.Visible = true;
            SettingsBT.Visible = true;
        }
        else
        {
            dayRemoverBT.Visible = false;
            SettingsBT.Visible = false;
        }
        if (CityDL.Items.Count == 0)
        {
            var cities = (from o in db.Sperm_Cities
                          select new { o.City }).Distinct();
            CityDL.Items.Clear();
            for (int i = 0; i < cities.Count(); i++)
            {
                CityDL.Items.Add(cities.ToList().ElementAt(i).City.ToString());
            }
            var mos = from o in db.Sperm_Cities
                      where o.City == CityDL.SelectedValue.ToString()
                      select o;
            MoDL.Items.Clear();
            for (int i = 0; i < mos.Count(); i++)
            {
                MoDL.Items.Add(mos.ToList().ElementAt(i).MO.ToString());
            }

        }
        if (DateDL.Items.Count == 0)
        {
            var days = (from d in db.Sperm_Zapisi
                        where d.city == CityDL.SelectedValue.ToString()
                        where d.mo == MoDL.SelectedValue.ToString()
                        where (d.date.Contains(DateTime.Now.ToString("M.yyyy")))
                        || d.date.Contains(DateTime.Now.AddMonths(1).ToString("M.yyyy"))
                        select d.date).Distinct();
            DateDL.Items.Clear();
            DateTime[] dates = new DateTime[days.Count()];
            for (int i = 0; i < days.Count(); i++)
            {
                dates[i] = DateTime.ParseExact(days.ToList().ElementAt(i).ToString(), "dd.M.yyyy", null);
            }
            dates = dates.OrderByDescending(d => d).ToArray();
            for (int i = 0; i < dates.Count(); i++)
            {
                DateDL.Items.Add(dates[i].ToShortDateString());
            }
        }
        gvUpdate();
    }

    protected void MoDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        var days = (from d in db.Sperm_Zapisi
                    where d.city == CityDL.SelectedValue.ToString()
                    where d.mo == MoDL.SelectedValue.ToString()
                    where (d.date.Contains(DateTime.Now.ToString("M.yyyy")))
                    || d.date.Contains(DateTime.Now.AddMonths(1).ToString("M.yyyy"))
                    select d.date).Distinct();
        DateDL.Items.Clear();
        DateTime[] dates = new DateTime[days.Count()];
        for (int i = 0; i < days.Count(); i++)
        {
            dates[i] = DateTime.ParseExact(days.ToList().ElementAt(i).ToString(), "dd.M.yyyy", null);
        }
        dates = dates.OrderByDescending(d => d).ToArray();
        for (int i = 0; i < dates.Count(); i++)
        {
            DateDL.Items.Add(dates[i].ToShortDateString());
        }
        gvUpdate();
    }

    public void gvUpdate()
    {

        var zapisi = from z in db.Sperm_Zapisi
                     where z.date == DateDL.SelectedValue
                     where z.city == CityDL.Text
                     where z.mo == MoDL.Text
                     select z;
        SpermGV.DataSource = zapisi;
        SpermGV.DataBind();
    }

    protected void CityDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        var mos = from o in db.Sperm_Cities
                  where o.City == CityDL.SelectedValue.ToString()
                  select o;
        MoDL.Items.Clear();
        for (int i = 0; i < mos.Count(); i++)
        {
            MoDL.Items.Add(mos.ToList().ElementAt(i).MO.ToString());
        }
        var days = (from d in db.Sperm_Zapisi
                    where d.city == CityDL.SelectedValue.ToString()
                    where d.mo == MoDL.SelectedValue.ToString()
                    where (d.date.Contains(DateTime.Now.ToString("M.yyyy")))
                    || d.date.Contains(DateTime.Now.AddMonths(1).ToString("M.yyyy"))
                    select d.date).Distinct();
        DateDL.Items.Clear();
        DateTime[] dates = new DateTime[days.Count()];
        for (int i = 0; i < days.Count(); i++)
        {
            dates[i] = DateTime.ParseExact(days.ToList().ElementAt(i).ToString(), "dd.M.yyyy", null);
        }
        dates = dates.OrderByDescending(d => d).ToArray();
        for (int i = 0; i < dates.Count(); i++)
        {
            DateDL.Items.Add(dates[i].ToShortDateString());
        }
        gvUpdate();
    }

    protected void DateDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvUpdate();
    }

    protected void SpermGV_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.Cells[9].Text == "True")
        {
            e.Row.Cells[9].BackColor = System.Drawing.ColorTranslator.FromHtml("#66FF66");
            e.Row.Cells[9].ForeColor = System.Drawing.Color.Red;
            e.Row.Cells[9].Text = "Подтвержден";
        }
        else if (e.Row.Cells[9].Text == "False")
        {
            e.Row.Cells[9].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFF66");
            e.Row.Cells[9].ForeColor = System.Drawing.Color.Red;
            e.Row.Cells[9].Text = "Не подтвержден";
        }
    }

    protected void AcceptBT_Click(object sender, EventArgs e)
    {
        int index = SpermGV.SelectedIndex;
        if (index > -1)
        {
            string d = SpermGV.Rows[index].Cells[10].Text.ToString();
            Sperm_Zapisi editZapis = db.Sperm_Zapisi.SingleOrDefault(x => x.id == Convert.ToInt32(d));
            editZapis.visit = true;
            editZapis.call = true;
            db.SubmitChanges();
            gvUpdate();
        }
        SpermGV.SelectedIndex = -1;
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

    protected void SubmitBT_Click(object sender, EventArgs e)
    {
        try
        {
            spermStatus.Text = "";
            int index = SpermGV.SelectedIndex;
            string d = SpermGV.Rows[index].Cells[10].Text;
            if (index > -1)
            {
                var zapis = from z in db.Sperm_Zapisi
                            where z.id == Convert.ToInt32(d)
                            select z;
                if (zapis.ToList().ElementAt(0).name_1.ToString().Length > 0)
                {
                    spermStatus.ForeColor = System.Drawing.Color.Red;
                    spermStatus.Text = "Запись уже занята";

                }
                else
                {
                    if (PhoneTB.Text.Length < 16)
                    {
                        spermStatus.ForeColor = System.Drawing.Color.Red;
                        spermStatus.Text = "Неверно введен номер телефона";
                    }
                    else
                    {
                        try
                        {
                            string t = (DateTime.ParseExact(SpermGV.Rows[index].Cells[1].Text, "HH:mm:ss", null)).ToShortTimeString();
                            var address = from a in db.Sperm_Cities
                                          where a.City == CityDL.SelectedValue
                                          where a.MO == MoDL.SelectedValue
                                          select a;
                            string phone = PhoneTB.Text;
                            phone = phone.Remove(13, 1);
                            phone = phone.Remove(10, 1);
                            phone = phone.Remove(5, 2);
                            phone = phone.Remove(1, 1);
                            toSend(phone: phone, message: "Запись спермограмма " + DateDL.Text + " в " + t + " по адресу " + CityDL.SelectedValue.ToString() + " " + address.ToList().ElementAt(0).Address.ToString() + " т. 8-800-234-40-50");
                            SpermGV.SelectedIndex = -1;
                            Sperm_Zapisi editZapis = db.Sperm_Zapisi.SingleOrDefault(x => x.id == Convert.ToInt32(d));
                            editZapis.name_1 = FornameTB.Text;
                            editZapis.name_2 = NameTB.Text;
                            editZapis.name_3 = MiddlenameTB.Text;
                            editZapis.phone = phone;
                            editZapis.mo = MoDL.SelectedValue.ToString();
                            editZapis.city = CityDL.SelectedValue.ToString();
                            editZapis.administrator = Request.Cookies["Visitor"]["user"];
                            editZapis.usluga = TestDL.SelectedValue.ToString();
                            db.SubmitChanges();
                            gvUpdate();
                            FornameTB.Text = "";
                            NameTB.Text = "";
                            MiddlenameTB.Text = "";
                            PhoneTB.Text = "";
                            spermStatus.ForeColor = System.Drawing.Color.LimeGreen;
                            spermStatus.Text = "Запись добавлена";
                        }
                        catch (Exception ex)
                        {
                            spermStatus.ForeColor = System.Drawing.Color.Red;
                            spermStatus.Text = "Ошибка";
                        }
                    }
                }
            }
        }
        catch
        {
            spermStatus.Text = "Что-то пошло не так";
        }
    }

    protected void YesDelBT_Click(object sender, EventArgs e)
    {
        int index = SpermGV.SelectedIndex;
        if (index > -1)
        {
            string d = SpermGV.Rows[index].Cells[10].Text.ToString();
            Sperm_Zapisi editZapis = db.Sperm_Zapisi.SingleOrDefault(x => x.id == Convert.ToInt32(d));
            editZapis.name_1 = "";
            editZapis.name_2 = "";
            editZapis.name_3 = "";
            editZapis.phone = "";
            editZapis.usluga = "";
            editZapis.visit = false;
            editZapis.call = false;
            editZapis.administrator = "";
            db.SubmitChanges();
            gvUpdate();
        }
        SpermGV.SelectedIndex = -1;
    }

    protected void YesDelDayBT_Click(object sender, EventArgs e)
    {
        var day = from o in db.Sperm_Zapisi
                  where o.date == DateDL.Text
                  where o.city == CityDL.SelectedValue.ToString()
                  where o.mo == MoDL.SelectedValue.ToString()
                  select o;
        foreach (var zapis in day)
        {
            db.Sperm_Zapisi.DeleteOnSubmit(zapis);
            db.SubmitChanges();
        }
        db.SubmitChanges();
        gvUpdate();
    }

    protected void SettingsBT_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Views/SpermSettings.aspx");
    }


    protected void SpermGV_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

}