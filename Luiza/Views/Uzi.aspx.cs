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
        block1.Style["background-color"] = "#C0C0C0";
    }

    protected void MiddlenameTB_TextChanged(object sender, EventArgs e)
    {

    }

    protected void DoctorRB1_CheckedChanged(object sender, EventArgs e)
    {
        if (DoctorRB1.Checked)
        {
            block1.Style["background-color"] = "#DADADA";
            block2.Style["background-color"] = "White";
            block3.Style["background-color"] = "White";
            block4.Style["background-color"] = "White";
            block5.Style["background-color"] = "White";
            DoctorRB1.Checked = true;
            DoctorRB2.Checked = false;
            DoctorRB3.Checked = false;
            DoctorRB4.Checked = false;
            DoctorRB5.Checked = false;
        }
    }

    protected void DoctorRB2_CheckedChanged(object sender, EventArgs e)
    {
        if (DoctorRB2.Checked)
        {
            block1.Style["background-color"] = "White";
            block2.Style["background-color"] = "#DADADA";
            block3.Style["background-color"] = "White";
            block4.Style["background-color"] = "White";
            block5.Style["background-color"] = "White";
            DoctorRB1.Checked = false;
            DoctorRB2.Checked = true;
            DoctorRB3.Checked = false;
            DoctorRB4.Checked = false;
            DoctorRB5.Checked = false;
        }
    }

    protected void DoctorRB3_CheckedChanged(object sender, EventArgs e)
    {
        if (DoctorRB3.Checked)
        {
            block1.Style["background-color"] = "White";
            block2.Style["background-color"] = "White";
            block3.Style["background-color"] = "#DADADA";
            block4.Style["background-color"] = "White";
            block5.Style["background-color"] = "White";
            DoctorRB1.Checked = false;
            DoctorRB2.Checked = false;
            DoctorRB3.Checked = true;
            DoctorRB4.Checked = false;
            DoctorRB5.Checked = false;
        }
    }

    protected void DoctorRB4_CheckedChanged(object sender, EventArgs e)
    {
        if (DoctorRB4.Checked)
        {
            block1.Style["background-color"] = "White";
            block2.Style["background-color"] = "White";
            block3.Style["background-color"] = "White";
            block4.Style["background-color"] = "#DADADA";
            block5.Style["background-color"] = "White";
            DoctorRB1.Checked = false;
            DoctorRB2.Checked = false;
            DoctorRB3.Checked = false;
            DoctorRB4.Checked = true;
            DoctorRB5.Checked = false;
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
            block5.Style["background-color"] = "#DADADA";
            DoctorRB1.Checked = false;
            DoctorRB2.Checked = false;
            DoctorRB3.Checked = false;
            DoctorRB4.Checked = false;
            DoctorRB5.Checked = false;
        }
    }
}