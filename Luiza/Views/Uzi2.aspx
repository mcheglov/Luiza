<%@ Page Title="" Language="C#" MasterPageFile="~/_Layout.master" AutoEventWireup="true" CodeFile="Uzi2.aspx.cs" Inherits="Views_Uzi2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="Server">
    ЛУИЗА - УЗИ</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <script src="../Scripts/jquery-3.0.0.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Scripts/jquery.maskedinput.min.js"></script>
    <div id="leftFrame" class="leftFrame" style="position: absolute; top: 0px; right: 0px; bottom: 0px; left: 0px">
        <div style="position: absolute; width: 200px; top: 0px; bottom: 0px; left: 0px">
            <div style="text-align: center; padding: 2px">
                <asp:Label ID="Label1" runat="server" Text="УЗИ" Font-Size="X-Large" ForeColor="#FF6A13"></asp:Label>
                <br />
                <asp:Menu ID="adminMenu" runat="server" StaticSubMenuIndent="10px" Visible="False" BackColor="#0097A9" DynamicHorizontalOffset="2" Font-Names="Tahoma" ForeColor="White">
                    <DynamicHoverStyle BackColor="#FF6A13" ForeColor="White" />
                    <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                    <DynamicMenuStyle BackColor="#0097A9" />
                    <DynamicSelectedStyle BackColor="#FF6A13" />
                    <Items>
                        <asp:MenuItem Text="Администрирование" Value="Администрирование">
                            <asp:MenuItem NavigateUrl="~/Views/UziSettings.aspx" Text="Расписание" Value="Расписание"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/Views/UziAddDoctor.aspx" Text="Добавление врача" Value="Добавление врача"></asp:MenuItem>
                        </asp:MenuItem>
                    </Items>
                    <StaticHoverStyle BackColor="#FF6A13" ForeColor="White" />
                    <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                    <StaticSelectedStyle BackColor="#0097A9" />
                </asp:Menu>
            </div>
            <div style="margin-bottom: 2px; padding-top: 2px; padding-right: 2px; padding-left: 2px;">
                Город
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                <asp:DropDownList ID="CityDL" runat="server" Width="100%" AutoPostBack="True" Font-Size="Small" OnSelectedIndexChanged="CityDL_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                МО
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                <asp:DropDownList ID="MoDL" runat="server" Width="100%" AutoPostBack="True" Font-Size="Small" OnSelectedIndexChanged="MoDL_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                Дата
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                <asp:DropDownList ID="DateDL" runat="server" Width="100%" AutoPostBack="True" Font-Size="Small">
                </asp:DropDownList>
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                Фамилия
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                <asp:TextBox ID="FornameTB" runat="server" TextMode="Search" Width="100%" Font-Size="Small" Height="20px"></asp:TextBox>
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                Имя
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                <asp:TextBox ID="NameTB" runat="server" TextMode="Search" Width="100%" Font-Size="Small" Height="20px"></asp:TextBox>
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                Отчество
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                <asp:TextBox ID="MiddlenameTB" runat="server" TextMode="Search" Width="100%" Font-Size="Small" Height="20px"></asp:TextBox>
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                Возраст
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                <asp:DropDownList ID="AgeDL" runat="server" Width="100%" AutoPostBack="True" Font-Size="Small">
                    <asp:ListItem>До 1 года (0-11 месяцев)</asp:ListItem>
                    <asp:ListItem>1-2 года</asp:ListItem>
                    <asp:ListItem>3-7 лет</asp:ListItem>
                    <asp:ListItem>8-12 лет</asp:ListItem>
                    <asp:ListItem>13-16 лет</asp:ListItem>
                    <asp:ListItem>17-21 год</asp:ListItem>
                    <asp:ListItem>22-35 лет</asp:ListItem>
                    <asp:ListItem>36-60 лет</asp:ListItem>
                    <asp:ListItem>61-75 лет</asp:ListItem>
                    <asp:ListItem>76-90 лет</asp:ListItem>
                    <asp:ListItem>Более 91 года</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                Пол
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                <asp:DropDownList ID="SexDL" runat="server" Width="100%" AutoPostBack="True" Font-Size="Small">
                    <asp:ListItem>Мужской</asp:ListItem>
                    <asp:ListItem>Женский</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                Телефон
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                <script>
                    jQuery(function ($) {
                        $(".masked").mask("8(999) 999 99-99"); // use the class!
                        phone.focus();
                    });
                </script>
                <asp:TextBox ID="PhoneTB" class="masked" runat="server" TextMode="Search" Width="100%" Font-Size="Small" onkeypress="OnlyNumeric();" MaxLength="16" AutoPostBack="True" Height="20px"></asp:TextBox>
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                Комментарий
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                <asp:TextBox ID="CommentTB" runat="server" TextMode="MultiLine" Width="100%" Font-Size="Small" Height="100px"></asp:TextBox>
            </div>
            <div>
                <br />
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px; text-align: center;">
                <asp:Label ID="recordID" runat="server" ForeColor="White"></asp:Label>
                <br />
            </div>
            <div style="text-align: center; width: 200px; bottom: -1px; left: 0px; position: absolute;">
                <div style="padding: 2px">
                    <br />
                </div>
                <div style="padding: 2px">
                    <asp:Button ID="SubmitBT" runat="server" CssClass="Btn" Text="ЗАПИСАТЬ" Width="100%" Height="30px" Font-Size="Large" OnClick="SubmitBT_Click" />
                </div>
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px; text-align: center;">
                <asp:Label ID="uziStatus" runat="server" ForeColor="Red"></asp:Label>
            </div>

        </div>
        <div id="right" class="right" style="border-width: 2px; border-color: #0097A9; position: absolute; top: 0px; right: 0px; bottom: 0px; left: 200px; padding: 4px 4px 4px 4px; border-left-style: solid; margin-left: 6px;">
            <div style="position: absolute; top: 0px; right: 0px; bottom: 0px; left: 0px; padding: 4px 4px 4px 4px;">
            </div>
            <!--Расписание-->
            <div style="padding: 4px; position: absolute; right: 0px; left: 0px; top: 0px; bottom: 300px; float: right;  overflow: scroll; overflow-x: hidden;">
                    <asp:GridView ID="UziGV" runat="server" AutoGenerateColumns="False" BorderColor="#0097A9" BorderWidth="1px" CellPadding="2" Width="100%" DataSourceID="UziDS" OnRowDataBound="UziGV_RowDataBound">
                        <Columns>
                            <asp:CommandField SelectText="Выбрать" ShowSelectButton="True" />
                            <asp:BoundField DataField="time" HeaderText="Время" ReadOnly="True" SortExpression="time" />
                            <asp:BoundField DataField="name_1" HeaderText="Фамилия" ReadOnly="True" SortExpression="name_1" />
                            <asp:BoundField DataField="name_2" HeaderText="Имя" ReadOnly="True" SortExpression="name_2" />
                            <asp:BoundField DataField="name_3" HeaderText="Отчество" ReadOnly="True" SortExpression="name_3" />
                            <asp:BoundField DataField="age" HeaderText="Возраст" ReadOnly="True" SortExpression="age" />
                            <asp:BoundField DataField="sex" HeaderText="Пол" ReadOnly="True" SortExpression="sex" />
                            <asp:BoundField DataField="phone" HeaderText="Телефон" ReadOnly="True" SortExpression="phone" />
                            <asp:BoundField DataField="services" HeaderText="Услуга" ReadOnly="True" SortExpression="services" />
                            <asp:BoundField DataField="comment" HeaderText="Комментарий" ReadOnly="True" SortExpression="comment" />
                            <asp:BoundField DataField="accept" HeaderText="Подтверждение" SortExpression="accept" />
                            <asp:BoundField DataField="doctor" HeaderText="Доктор" ReadOnly="True" SortExpression="doctor" />
                            <asp:BoundField DataField="admin" HeaderText="Сотрудник" ReadOnly="True" SortExpression="admin" />
                            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
                        </Columns>
                        <HeaderStyle ForeColor="#FF6A13" Font-Size="Smaller" />
                        <RowStyle Font-Size="Smaller" />
                        <SelectedRowStyle BackColor="#FF6A13" Font-Bold="True" Font-Italic="True" ForeColor="White" />
                    </asp:GridView>
                <asp:LinqDataSource ID="UziDS" runat="server" ContextTypeName="toSQLDataContext" EntityTypeName="" Select="new (ID, time, age, sex, phone, doctor, services, admin, accept, comment, name_1, name_2, name_3)" TableName="Uzi_Zapisi" Where="city == @city &amp;&amp; mo == @mo &amp;&amp; date == @date &amp;&amp; hidden == @hidden">
                    <WhereParameters>
                        <asp:ControlParameter ControlID="CityDL" Name="city" PropertyName="SelectedValue" Type="String" />
                        <asp:ControlParameter ControlID="MoDL" Name="mo" PropertyName="SelectedValue" Type="String" />
                        <asp:ControlParameter ControlID="DateDL" Name="date" PropertyName="SelectedValue" Type="String" />
                        <asp:Parameter DefaultValue="False" Name="hidden" Type="Boolean" />
                    </WhereParameters>
                </asp:LinqDataSource>
            </div>
            <!--Расписание-->
            <!--Инфа-->
            <div style="background-color: #FF00FF; padding: 4px; position: absolute; right: 0px; bottom: 0px; left: 0px; float: left; height: 300px;">
            </div>
            <!--Инфа-->
        </div>

    </div>
</asp:Content>

