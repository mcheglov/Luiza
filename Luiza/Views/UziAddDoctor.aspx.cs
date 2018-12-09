using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_UziAddDoctor : System.Web.UI.Page
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
            MODL.Items.Clear();
            for (int i = 0; i < mos.Count(); i++)
            {
                MODL.Items.Add(mos.ToList().ElementAt(i).mo.ToString());
            }
            TestDL.Items.Clear();
            if (CityDL.Text == "Новосибирск")
            {
                var tests = (from o in db.Uzi_Price
                             where o.nsk_price.Length > 0
                             select o);
                var orderedtests = new List<string>();
                for (int i = 0; i < tests.Count(); i++)
                {
                    orderedtests.Add(tests.ToList().ElementAt(i).test.ToString() + "-" + tests.ToList().ElementAt(i).description.ToString());
                }
                orderedtests = orderedtests.OrderByDescending(d => d).ToList();
                orderedtests.Reverse();
                for (int i = 0; i < orderedtests.Count; i++)
                {
                    TestDL.Items.Add(orderedtests[i]);
                }
            }
            else if (CityDL.Text == "Красноярск")
            {
                var tests = (from o in db.Uzi_Price
                             where o.krs_price.Length > 0
                             select o);
                var orderedtests = new List<string>();
                for (int i = 0; i < tests.Count(); i++)
                {
                    orderedtests.Add(tests.ToList().ElementAt(i).test.ToString() + "-" + tests.ToList().ElementAt(i).description.ToString());
                }
                orderedtests = orderedtests.OrderByDescending(d => d).ToList();
                orderedtests.Reverse();
                for (int i = 0; i < orderedtests.Count; i++)
                {
                    TestDL.Items.Add(orderedtests[i]);
                }
            }
            else if (CityDL.Text == "Томск")
            {
                var tests = (from o in db.Uzi_Price
                             where o.tomsk_price.Length > 0
                             select o);
                var orderedtests = new List<string>();
                for (int i = 0; i < tests.Count(); i++)
                {
                    orderedtests.Add(tests.ToList().ElementAt(i).test.ToString() + "-" + tests.ToList().ElementAt(i).description.ToString());
                }
                orderedtests = orderedtests.OrderByDescending(d => d).ToList();
                orderedtests.Reverse();
                for (int i = 0; i < orderedtests.Count; i++)
                {
                    TestDL.Items.Add(orderedtests[i]);
                }
            }
            else if (CityDL.Text == "Омск")
            {
                var tests = (from o in db.Uzi_Price
                             where o.omsk_price.Length > 0
                             select o);
                var orderedtests = new List<string>();
                for (int i = 0; i < tests.Count(); i++)
                {
                    orderedtests.Add(tests.ToList().ElementAt(i).test.ToString() + "-" + tests.ToList().ElementAt(i).description.ToString());
                }
                orderedtests = orderedtests.OrderByDescending(d => d).ToList();
                orderedtests.Reverse();
                for (int i = 0; i < orderedtests.Count; i++)
                {
                    TestDL.Items.Add(orderedtests[i]);
                }
            }
            else if (CityDL.Text == "Иркутск")
            {
                var tests = (from o in db.Uzi_Price
                             where o.irk_price.Length > 0
                             select o);
                var orderedtests = new List<string>();
                for (int i = 0; i < tests.Count(); i++)
                {
                    orderedtests.Add(tests.ToList().ElementAt(i).test.ToString() + "-" + tests.ToList().ElementAt(i).description.ToString());
                }
                orderedtests = orderedtests.OrderByDescending(d => d).ToList();
                orderedtests.Reverse();
                for (int i = 0; i < orderedtests.Count; i++)
                {
                    TestDL.Items.Add(orderedtests[i]);
                }
            }
            DurDL.Items.Clear();
            var duration = (from o in db.Uzi_Cities
                            where o.city == CityDL.SelectedItem.Text
                            where o.mo == MODL.SelectedItem.Text
                            select o);
            DurDL.Items.Add(duration.ToList().ElementAt(0).duration.ToString());
            DurDL.Items.Add(Convert.ToString((Convert.ToInt16(duration.ToList().ElementAt(0).duration.ToString())) * 2));
            DurDL.Items.Add(Convert.ToString((Convert.ToInt16(duration.ToList().ElementAt(0).duration.ToString())) * 3));
        }
    }

    protected void AddBT_Click(object sender, EventArgs e)
    {
        if (AddedLB.Items.Count == 0)
        {
            AddedLB.Items.Add(TestDL.SelectedItem.ToString() + "-" + DurDL.SelectedItem.ToString());
        }
        else
        {
            bool found = false;

            foreach (var item in AddedLB.Items)
            {
                if (item.ToString().Contains(TestDL.SelectedItem.ToString()))
                {
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                AddedLB.Items.Add(TestDL.SelectedItem.ToString() + "-" + DurDL.SelectedItem.ToString());
            }
        }
    }

    protected void CityDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        var mos = from o in db.Uzi_Cities
                  where o.city == CityDL.SelectedValue.ToString()
                  select o;
        MODL.Items.Clear();
        for (int i = 0; i < mos.Count(); i++)
        {
            MODL.Items.Add(mos.ToList().ElementAt(i).mo.ToString());
        }
        AddedLB.Items.Clear();
        TestDL.Items.Clear();
        if (CityDL.Text == "Новосибирск")
        {
            var tests = (from o in db.Uzi_Price
                         where o.nsk_price.Length > 0
                         select o);
            var orderedtests = new List<string>();
            for (int i = 0; i < tests.Count(); i++)
            {
                orderedtests.Add(tests.ToList().ElementAt(i).test.ToString() + "-" + tests.ToList().ElementAt(i).description.ToString());
            }
            orderedtests = orderedtests.OrderByDescending(d => d).ToList();
            orderedtests.Reverse();
            for (int i = 0; i < orderedtests.Count; i++)
            {
                TestDL.Items.Add(orderedtests[i]);
            }
        }
        else if (CityDL.Text == "Красноярск")
        {
            var tests = (from o in db.Uzi_Price
                         where o.krs_price.Length > 0
                         select o);
            var orderedtests = new List<string>();
            for (int i = 0; i < tests.Count(); i++)
            {
                orderedtests.Add(tests.ToList().ElementAt(i).test.ToString() + "-" + tests.ToList().ElementAt(i).description.ToString());
            }
            orderedtests = orderedtests.OrderByDescending(d => d).ToList();
            orderedtests.Reverse();
            for (int i = 0; i < orderedtests.Count; i++)
            {
                TestDL.Items.Add(orderedtests[i]);
            }
        }
        else if (CityDL.Text == "Томск")
        {
            var tests = (from o in db.Uzi_Price
                         where o.tomsk_price.Length > 0
                         select o);
            var orderedtests = new List<string>();
            for (int i = 0; i < tests.Count(); i++)
            {
                orderedtests.Add(tests.ToList().ElementAt(i).test.ToString() + "-" + tests.ToList().ElementAt(i).description.ToString());
            }
            orderedtests = orderedtests.OrderByDescending(d => d).ToList();
            orderedtests.Reverse();
            for (int i = 0; i < orderedtests.Count; i++)
            {
                TestDL.Items.Add(orderedtests[i]);
            }
        }
        else if (CityDL.Text == "Омск")
        {
            var tests = (from o in db.Uzi_Price
                         where o.omsk_price.Length > 0
                         select o);
            var orderedtests = new List<string>();
            for (int i = 0; i < tests.Count(); i++)
            {
                orderedtests.Add(tests.ToList().ElementAt(i).test.ToString() + "-" + tests.ToList().ElementAt(i).description.ToString());
            }
            orderedtests = orderedtests.OrderByDescending(d => d).ToList();
            orderedtests.Reverse();
            for (int i = 0; i < orderedtests.Count; i++)
            {
                TestDL.Items.Add(orderedtests[i]);
            }
        }
        else if (CityDL.Text == "Иркутск")
        {
            var tests = (from o in db.Uzi_Price
                         where o.irk_price.Length > 0
                         select o);
            var orderedtests = new List<string>();
            for (int i = 0; i < tests.Count(); i++)
            {
                orderedtests.Add(tests.ToList().ElementAt(i).test.ToString() + "-" + tests.ToList().ElementAt(i).description.ToString());
            }
            orderedtests = orderedtests.OrderByDescending(d => d).ToList();
            orderedtests.Reverse();
            for (int i = 0; i < orderedtests.Count; i++)
            {
                TestDL.Items.Add(orderedtests[i]);
            }
        }
        DurDL.Items.Clear();
        var duration = (from o in db.Uzi_Cities
                        where o.city == CityDL.SelectedItem.Text
                        where o.mo == MODL.SelectedItem.Text
                        select o);
        DurDL.Items.Add(duration.ToList().ElementAt(0).duration.ToString());
        DurDL.Items.Add(Convert.ToString((Convert.ToInt16(duration.ToList().ElementAt(0).duration.ToString())) * 2));
        DurDL.Items.Add(Convert.ToString((Convert.ToInt16(duration.ToList().ElementAt(0).duration.ToString())) * 3));
    }

    protected void DellBT_Click(object sender, EventArgs e)
    {
        AddedLB.Items.Remove(AddedLB.SelectedItem);
    }


    protected void Back_Click(object sender, EventArgs e)
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

    protected void AddDocBT_Click(object sender, EventArgs e)
    {
        var doc = from o in db.Uzi_Doctor
                  where o.CITY == CityDL.SelectedValue.ToString()
                  where o.MO == MODL.SelectedValue.ToString()
                  where o.DOCTOR == DoctorTB.Text
                  select o;
        if (doc.Count() > 0)
        {
            errorLabel.ForeColor = System.Drawing.Color.Red;
            errorLabel.Text = "Доктор уже есть";
        }
        else
        {
            for (int i = 0; i < AddedLB.Items.Count; i++)
            {
                var test = AddedLB.Items[i].ToString().Split('-');
                priem(CityDL.SelectedValue, MODL.SelectedValue, DoctorTB.Text, RestTB.Text, test[0], test[2]);
            }
        }
    }

    public void priem(string city, string mo, string doctor, string rest, string test, string duration)
    {
        errorLabel.ForeColor = System.Drawing.Color.Red;
        errorLabel.Text = "";
        try
        {
            Uzi_Doctor newDoc = new Uzi_Doctor();
            newDoc.DOCTOR = doctor;
            newDoc.CITY = city;
            newDoc.MO = mo;
            newDoc.RESTRICTION = rest;
            newDoc.TEST = test;
            newDoc.DURATION = duration;
            db.GetTable<Uzi_Doctor>().InsertOnSubmit(newDoc);
            db.SubmitChanges();
            errorLabel.ForeColor = System.Drawing.Color.Green;
            errorLabel.Text = "Доктор добавлен";
        }
        catch (Exception ex)
        {
            errorLabel.ForeColor = System.Drawing.Color.Red;
            errorLabel.Text = ex.ToString();
        }

    }
}