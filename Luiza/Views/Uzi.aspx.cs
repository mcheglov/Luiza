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
    }

    protected void SettingsBT_Click(object sender, EventArgs e)
    {

    }

    protected void SubmitBT_Click(object sender, EventArgs e)
    {

    }
}