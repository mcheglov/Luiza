using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_AddUser : System.Web.UI.Page
{
    toSQLDataContext db = new toSQLDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["param1"] != "1")
        {
            Response.Redirect("/Views/NoRights.aspx?param1=1");
        }
    }

    public static string Translit(string str)
    {
        string[] lat_up = { "A", "B", "V", "G", "D", "E", "Yo", "Zh", "Z", "I", "Y", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "F", "Kh", "Ts", "Ch", "Sh", "Shch", "", "Y", "", "E", "Yu", "Ya" };
        string[] lat_low = { "a", "b", "v", "g", "d", "e", "yo", "zh", "z", "i", "y", "k", "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "kh", "ts", "ch", "sh", "shch", "", "y", "", "e", "yu", "ya" };
        string[] rus_up = { "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я" };
        string[] rus_low = { "а", "б", "в", "г", "д", "е", "ё", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я" };
        for (int i = 0; i <= 32; i++)
        {
            str = str.Replace(rus_up[i], lat_up[i]);
            str = str.Replace(rus_low[i], lat_low[i]);
        }
        return str;
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        errorLabel.Text = "";
        var valid = from o in db.Users
              where o.Login == (Translit((NameTB.Text.Substring(0, 1) + FornameTB.Text).ToUpper())).ToLower()
              select 0;
        if (valid.Count() >0)
        {
            errorLabel.Text = "Такой пользователь уже существует";
        }
        else
        {
            Users u = new Users();
            u.Login = (Translit((NameTB.Text.Substring(0, 1) + FornameTB.Text).ToUpper())).ToLower();
            u.Password = "1234567";
            u.Rights = RightsDL.SelectedValue;
            u.Username = NameTB.Text + " " + FornameTB.Text;
            db.GetTable<Users>().InsertOnSubmit(u);
            db.SubmitChanges();
            NameTB.Text = "";
            FornameTB.Text = "";
            loginLabel.Text = "";
            UsersGV.DataBind();
        }
    }

    protected void NameTB_TextChanged(object sender, EventArgs e)
    {
        loginLabel.Text = (Translit((NameTB.Text.Substring(0, 1) + FornameTB.Text).ToUpper())).ToLower();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Views/Default.aspx");
    }

    protected void SpermGV_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        var users = from o in db.Users
                  where o.Username == UserToDelDL.SelectedValue
                  select o;
        foreach (var user in users)
        {
            db.Users.DeleteOnSubmit(user);
            db.SubmitChanges();
        }
    }
}