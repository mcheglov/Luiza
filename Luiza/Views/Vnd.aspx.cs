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
        streetDL.Visible = false;
    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        streetDL.Items.Clear();
        if (TextBox1.Text.Length > 0)
        {
            var streets = (from o in db.Vnd_Nsk
                           where o.formalname.Contains(TextBox1.Text)
                           select o).ToList();
            for (int i = 0; i < streets.Count(); i++)
            {
                streetDL.Items.Add(streets[i].shortname + " " + streets[i].formalname);
            }
        }
        TextBox1.Text = "";
        if (streetDL.Items.Count > 0)
        {
            streetDL.Visible = true;
        }
        else
        {
            streetDL.Visible = false;
        }

    }
}