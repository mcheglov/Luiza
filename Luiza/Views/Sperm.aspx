<%@ Page Title="" Language="C#" MasterPageFile="~/_Layout.master" AutoEventWireup="true" CodeFile="Sperm.aspx.cs" Inherits="Views_Sperm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="Server">
    ЛУИЗА - Спермограмма
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <script src="../Scripts/jquery-3.0.0.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Scripts/jquery.maskedinput.min.js"></script>
    <div id="leftFrame" class="leftFrame" style="position: absolute; top: 0px; right: 0px; bottom: 0px; left: 0px">
        <div style="position: absolute; width: 200px; top: 0px; bottom: 0px; left: 0px">
            <div style="text-align: center; padding: 2px">
                <asp:Label ID="Label1" runat="server" Text="Спермограмма" Font-Size="X-Large" ForeColor="#FF6A13"></asp:Label>
            </div>
            <div style="margin-bottom: 2px; padding-top: 2px; padding-right: 2px; padding-left: 2px;">
                Город
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                <asp:DropDownList ID="CityDL" class="form-control item" runat="server" Width="100%" AutoPostBack="True" Font-Size="Small" OnSelectedIndexChanged="CityDL_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                МО
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                <asp:DropDownList ID="MoDL" class="form-control item" runat="server" Width="100%" AutoPostBack="True" Font-Size="Small" OnSelectedIndexChanged="MoDL_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                Дата
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                <asp:DropDownList ID="DateDL" class="form-control item" runat="server" Width="100%" AutoPostBack="True" Font-Size="Small" OnSelectedIndexChanged="DateDL_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                Фамилия
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                <asp:TextBox ID="FornameTB" class="form-control item" runat="server" TextMode="Search" Width="100%" Font-Size="Small"></asp:TextBox>
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                Имя
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                <asp:TextBox ID="NameTB" class="form-control item" runat="server" TextMode="Search" Width="100%" Font-Size="Small"></asp:TextBox>
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                Отчество
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                <asp:TextBox ID="MiddlenameTB" class="form-control item" runat="server" TextMode="Search" Width="100%" Font-Size="Small"></asp:TextBox>
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
                <asp:TextBox ID="PhoneTB" class="form-control masked" runat="server" TextMode="Search" Width="100%" Font-Size="Small" onkeypress="OnlyNumeric();" MaxLength="16" AutoPostBack="True"></asp:TextBox>
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                Услуга
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                <asp:DropDownList ID="TestDL" class="form-control item" runat="server" Width="100%" DataSourceID="TestDS" DataTextField="Test_code" DataValueField="Test_code" Font-Size="Small">
                </asp:DropDownList>
                <asp:LinqDataSource ID="TestDS" runat="server" ContextTypeName="toSQLDataContext" EntityTypeName="" Select="new (Test_code)" TableName="Sperm_Price" Where="Test_city == @Test_city &amp;&amp; Test_mo == @Test_mo">
                    <WhereParameters>
                        <asp:ControlParameter ControlID="CityDL" Name="Test_city" PropertyName="SelectedValue" Type="String" />
                        <asp:ControlParameter ControlID="MoDL" Name="Test_mo" PropertyName="SelectedValue" Type="String" />
                    </WhereParameters>
                </asp:LinqDataSource>
                <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Button" />
                <br />
                <br />
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            </div>
            <div>
                <br />
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px; text-align: center;">
                <!-- Modal -->
                <button type="button" class="BtnMain" data-toggle="modal" data-target="#exampleModal" data-backdrop="false" style="width: 100%; background-color: #FF6A13;">
                    Подготовка</button>
                <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="exampleModalLabel" style="color: #FF6A13;">Подготовка</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body" style="text-align: left;">
                                Принимать материал на сперморграмму сданную вне офиса - запрещено.
Правила сбора б/м и подготовка:
                                <br />
                                Выдержать не менее 48 часового и не более 7-дневного полового воздержания.<br />
                                В период подготовки нельзя принимать алкоголь, лекарственные препараты, посещать баню или сауну, подвергаться воздействию УВЧ.
При повторном исследовании желательно устанавливать одинаковые периоды воздержания для снижения колебаний полученного результата
Эякулят получают путём мастурбации.<br />
                                Собирают в специальный контейнер, который предварительно необходимо получить в медицинском офисе.<br />
                                Запрещено использовать презерватив для сбора спермы (вещества, используемые при производстве презервативов, могут влиять на степень подвижности сперматозоидов).
Если мастурбация была успешной, но эякулят не получен, необходимо сразу помочиться и доставить на анализ всю полученную мочу.<br />
                                Во время транспортировки сперму сохранять при температуре +27°С...+37°С.<br />
                                На контейнере необходимо указать фамилию, дату и точное время получения эякулята.<br />
                                Исследования должно начинаться не позднее 1 часа после получения биоматериала
597 MAR-тест IgA и 598 MAR-тест, IgG могут быть выполнены на основании данных спермограммы, выполненной не более 3х месяцев назад.
                                <br />
                                Если концентрация сперматозоидов не менее 10 млн/мл, подвижность А+В не менее 20%.
                                <br />
                                Если по результатам спермограммы материал не соответствует данным условиям, пациенту Mar- тесты не делаем и возвращаем деньги.<br />
                            </div>
                            <div class="modal-footer" style="text-align: center;">
                                <button type="button" class="exitBtn" data-dismiss="modal">Закрыть</button>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Modal -->
                <br />
            </div>
            <div style="text-align: center; width: 200px; height: 30px; bottom: 0px; left: 0px; position: absolute;">
                <asp:Button ID="SubmitBT" runat="server" CssClass="Btn" Text="ЗАПИСАТЬ" Width="100%" Font-Size="Large" OnClick="SubmitBT_Click" />
            </div>
            &nbsp;
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px; text-align: center;">
                <asp:Label ID="spermStatus" runat="server" ForeColor="Red"></asp:Label>
            </div>
            <div id="settings" runat="server" class="settings" style="position: fixed; height: 30px; left: 450px; width: 200px; text-align: center; top: 20px;">
                <asp:Button ID="SettingsBT" runat="server" CssClass="Btn" Text="Настройки" Width="140px" OnClick="SettingsBT_Click" />
            </div>

        </div>
        <div id="right" class="right" style="border-width: 2px; border-color: #0097A9; position: absolute; top: 0px; right: 0px; bottom: 0px; left: 200px; padding: 4px 4px 4px 4px; border-left-style: solid; margin-left: 6px;">
            <div id="rightFrame" class="rightFrame">
                <div style="padding: 4px; top: 0px; right: 0px; bottom: 34px; left: 0px; position: absolute; overflow: scroll; overflow-x: hidden;">
                    <asp:GridView ID="SpermGV" runat="server" AllowSorting="True" AutoGenerateColumns="False" BorderColor="#0097A9" BorderWidth="1px" CellPadding="2" OnRowDataBound="SpermGV_RowDataBound" Width="100%" OnSelectedIndexChanged="SpermGV_SelectedIndexChanged">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" SelectText="Выбрать" />
                            <asp:BoundField DataField="time" HeaderText="Время" />
                            <asp:BoundField DataField="name_1" HeaderText="Фамилия" />
                            <asp:BoundField DataField="name_2" HeaderText="Имя" />
                            <asp:BoundField DataField="name_3" HeaderText="Отчество" />
                            <asp:BoundField DataField="phone" HeaderText="Телефон" />
                            <asp:BoundField DataField="usluga" HeaderText="Тест" />
                            <asp:BoundField DataField="doctor" HeaderText="Доктор" />
                            <asp:BoundField DataField="administrator" HeaderText="Сотрудник" />
                            <asp:BoundField DataField="visit" HeaderText="Подтверждение" />
                            <asp:BoundField DataField="id" HeaderText="ID" />
                        </Columns>
                        <HeaderStyle ForeColor="#FF6A13" />
                        <SelectedRowStyle BackColor="#FF6A13" Font-Bold="True" Font-Italic="True" ForeColor="White" />
                    </asp:GridView>
                </div>
            </div>
            <div style="text-align: right; padding: 2px; border: 1px solid #FF6A13; bottom: 0; left: 0; right: 0; height: 30px; position: absolute; margin: 0px 0px 0px 4px; border-radius: 5px 5px 5px 5px;">
                &nbsp;
                <button type="button" class="BtnMain" data-toggle="modal" data-target="#proveVisit" data-backdrop="false" style="width: 150px; height: 100%">
                    Подтвердить визит
                </button>
                <div class="modal fade" id="proveVisit" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="proveVisitLabel" style="color: #FF6A13;">Подтверждение Визита</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body" style="text-align: left;">
                                Клиент согласен прийти в назначенное время?
                            </div>
                            <div class="modal-footer" style="text-align: center;">
                                <asp:Button ID="AcceptBT" runat="server" Text="Да" OnClick="AcceptBT_Click" CssClass="yesBtn" />
                                <asp:Button ID="NotAcceptBT" runat="server" Text="Нет" CssClass="noBtn" />
                            </div>
                        </div>
                    </div>
                </div>
                &nbsp;
                <button type="button" class="BtnMain" data-toggle="modal" data-target="#delRecord" data-backdrop="false" style="width: 130px; height: 100%; background-color: #FF6A13;">
                    Удалить запись
                </button>
                <div class="modal fade" id="delRecord" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="delRecordLabel" style="color: #FF6A13;">Освободить запись</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body" style="text-align: left;">
                                Вы уверены, что хотите освободить текущее время?
                            </div>
                            <div class="modal-footer" style="text-align: center;">
                                <asp:Button ID="YesDelBT" runat="server" Text="Да" CssClass="yesBtn" OnClick="YesDelBT_Click" />
                                <asp:Button ID="NoBT" runat="server" Text="Нет" CssClass="noBtn" />
                            </div>
                        </div>
                    </div>
                </div>
                &nbsp;
                <button id="dayRemoverBT" type="button" class="BtnMain" data-toggle="modal" data-target="#delDay" data-backdrop="false" style="width: 200px; height: 100%; background-color: #FF6A13;" runat="server">
                    Удалить расписание на день
                </button>
                <div class="modal fade" id="delDay" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="delDayLabel" style="color: #FF6A13;">Удалить расписание на день</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body" style="text-align: left;">
                                Вы уверены, что хотите удалить расписание на день?
                            </div>
                            <div class="modal-footer" style="text-align: center;">
                                <asp:Button ID="YesDelDayBT" runat="server" Text="Да" CssClass="yesBtn" OnClick="YesDelDayBT_Click" />
                                <asp:Button ID="Button3" runat="server" Text="Нет" CssClass="noBtn" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>

</asp:Content>

