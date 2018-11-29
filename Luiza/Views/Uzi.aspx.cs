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
        DoctorTimeLB1.Items[0].Attributes.Add("style", "background-color: Lime; color: Red");
        DoctorTimeLB1.Items[1].Attributes.Add("style", "background-color: Yellow; color: Red");
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
}
