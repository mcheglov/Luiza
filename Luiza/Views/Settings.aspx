<%@ Page Title="" Language="C#" MasterPageFile="~/_LoginLayout.master" AutoEventWireup="true" CodeFile="Settings.aspx.cs" Inherits="Views_AddUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <div style="border: 1px solid #FF6A13; border-radius: 5px 5px 5px 5px; top: 0px; right: 0px; left: 0px; padding: 4px; margin: 4px">
        <table class="w-100">
            <tr>
                <td style="text-align: center;" colspan="6">
                    <asp:Label ID="Label1" runat="server" Font-Size="Large" ForeColor="#FF6A13" Text="Создание Нового Пользователя"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 17.5%">Фамилия:</td>
                <td style="width: 16.5%">Имя:</td>
                <td style="width: 16.5%">Права:</td>
                <td style="width: 16.5%">Логин:</td>
                <td style="width: 16.5%">Пароль:</td>
                <td style="width: 16.5%">&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 17.5%">
                    <asp:TextBox ID="FornameTB" runat="server" CssClass="form-control item" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 16.5%">
                    <asp:TextBox ID="NameTB" runat="server" CssClass="form-control item" Width="100%" AutoPostBack="True" OnTextChanged="NameTB_TextChanged"></asp:TextBox>
                </td>
                <td style="width: 16.5%">
                    <asp:DropDownList ID="RightsDL" runat="server" CssClass="form-control item">
                        <asp:ListItem Value="User">Сотрудник</asp:ListItem>
                        <asp:ListItem Value="Admin">Администратор</asp:ListItem>
                        <asp:ListItem Value="Logist">Логистика</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 16.5%">
                    <asp:Label ID="loginLabel" runat="server" ForeColor="#FF6A13"></asp:Label>
                </td>
                <td style="width: 16.5%">
                    <asp:Label ID="passwordLabel" runat="server" ForeColor="#FF6A13">1234567</asp:Label>
                </td>
                <td style="width: 16.5%">
                    <asp:Button ID="Button1" runat="server" CssClass="yesBtn" OnClick="Button1_Click" OnClientClick="return confirm('Нажмите ОК, если хотите создать пользователя');" Text="Создать пользователя" Width="100%" />
                </td>
            </tr>
            <tr>
                <td style="text-align: center;" colspan="6">
                    <asp:Label ID="errorLabel" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
      <div style="border: 1px solid #FF6A13; border-radius: 5px 5px 5px 5px; text-align: center; height:300px; right: 0px; left: 0px; padding: 4px; margin: 4px; overflow: scroll; overflow-x:hidden;">
          <asp:Label ID="Label2" runat="server" Font-Size="Large" ForeColor="#FF6A13" Text="Все пользователи"></asp:Label>
                    <asp:GridView ID="UsersGV" runat="server" AllowSorting="True" AutoGenerateColumns="False" BorderColor="#0097A9" BorderWidth="1px" CellPadding="2" Width="100%" DataSourceID="LinqDataSource1" HorizontalAlign="Left">
                        <Columns>
                            <asp:BoundField DataField="Username" HeaderText="Имя Пользователя" ReadOnly="True" SortExpression="Username" >
                            <ControlStyle Width="33%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Login" HeaderText="Логин" ReadOnly="True" SortExpression="Login" >
                            <ControlStyle Width="33%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Password" HeaderText="Пароль" ReadOnly="True" SortExpression="Password" >
                            <ControlStyle Width="33%" />
                            </asp:BoundField>
                        </Columns>
                        <HeaderStyle ForeColor="#FF6A13" />
                        <SelectedRowStyle BackColor="#FF6A13" Font-Bold="True" Font-Italic="True" ForeColor="White" />
                    </asp:GridView>
                <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="toSQLDataContext" EntityTypeName="" OrderBy="Username" Select="new (Login, Password, Username)" TableName="Users">
          </asp:LinqDataSource>
    </div>
        <div style="border: 1px solid #FF6A13; border-radius: 5px 5px 5px 5px; top: 0px; right: 0px; left: 0px; padding: 4px; margin: 4px">
            <table class="w-100">
                <tr>
                    <td colspan="3" style="text-align:center;">
          <asp:Label ID="Label3" runat="server" Font-Size="Large" ForeColor="#FF6A13" Text="Удалить пользователя"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 33.3%">Пользователь:</td>
                    <td>
                    <asp:DropDownList ID="UserToDelDL" runat="server" CssClass="form-control item" DataSourceID="LinqDataSource2" DataTextField="Username" DataValueField="Username">
                        <asp:ListItem Value="User">Сотрудник</asp:ListItem>
                        <asp:ListItem Value="Admin">Администратор</asp:ListItem>
                        <asp:ListItem Value="Logist">Логистика</asp:ListItem>
                    </asp:DropDownList>
                        <asp:LinqDataSource ID="LinqDataSource2" runat="server" ContextTypeName="toSQLDataContext" EntityTypeName="" OrderBy="Username" Select="new (Username)" TableName="Users">
                        </asp:LinqDataSource>
                    </td>
                    <td style="width: 33.3%; text-align:center">
                        <asp:Button ID="Button3" runat="server" Text="Удалить" CssClass="noBtn" OnClientClick="return confirm('Нажмите ОК, если хотите удалить пользователя');" Width="50%" OnClick="Button3_Click" />
                    </td>
                </tr>
            </table>
    </div>
    <div style="position: fixed; top:20px; right: 20px">
        <asp:Button ID="Button2" runat="server" Text="На главную страницу" cssclass="yesBtn" OnClick="Button2_Click" Width="150px" />
    </div>
</asp:Content>

