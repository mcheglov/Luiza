using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Vnd : System.Web.UI.Page
{
    toSQLDataContext db = new toSQLDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        var streets = from o in db.Vnd_Nsk
                      select o;
        for (int i=0;i< streets.Count(); i++)
        {
            streetDL.Items.Add(streets.ToList().ElementAt(i).formalname.ToString() + " " + streets.ToList().ElementAt(i).shortname.ToString());
        }
    }
}