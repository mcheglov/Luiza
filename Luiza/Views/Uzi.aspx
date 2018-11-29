<%@ Page Title="" Language="C#" MasterPageFile="~/_Layout.master" AutoEventWireup="true" CodeFile="Uzi.aspx.cs" Inherits="Views_Uzi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="Server">
    ЛУИЗА - УЗИ
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <script src="../Scripts/jquery-3.0.0.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Scripts/jquery.maskedinput.min.js"></script>
    <div id="leftFrame" class="leftFrame" style="position: absolute; top: 0px; right: 0px; bottom: 0px; left: 0px">
        <div style="position: absolute; width: 200px; top: 0px; bottom: 0px; left: 0px">
            <div style="text-align: center; padding: 2px">
                <asp:Label ID="Label1" runat="server" Text="УЗИ" Font-Size="X-Large" ForeColor="#FF6A13"></asp:Label>
            </div>
            <div style="margin-bottom: 2px; padding-top: 2px; padding-right: 2px; padding-left: 2px;">
                Город
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                <asp:DropDownList ID="CityDL" class="form-control item" runat="server" Width="100%" AutoPostBack="True" Font-Size="Small" Height="20px">
                </asp:DropDownList>
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                МО
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                <asp:DropDownList ID="MoDL" class="form-control item" runat="server" Width="100%" AutoPostBack="True" Font-Size="Small" Height="20px">
                </asp:DropDownList>
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                Дата
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                <asp:DropDownList ID="DateDL" class="form-control item" runat="server" Width="100%" AutoPostBack="True" Font-Size="Small" Height="20px">
                </asp:DropDownList>
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                Фамилия
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                <asp:TextBox ID="FornameTB" class="form-control item" runat="server" TextMode="Search" Width="100%" Font-Size="Small" Height="20px"></asp:TextBox>
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                Имя
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                <asp:TextBox ID="NameTB" class="form-control item" runat="server" TextMode="Search" Width="100%" Font-Size="Small" Height="20px"></asp:TextBox>
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                Отчество
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                <asp:TextBox ID="MiddlenameTB" class="form-control item" runat="server" TextMode="Search" Width="100%" Font-Size="Small" Height="20px"></asp:TextBox>
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                Возраст
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                <asp:DropDownList ID="AgeDL" class="form-control item" runat="server" Width="100%" AutoPostBack="True" Font-Size="Small" Height="20px">
                </asp:DropDownList>
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                Пол
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                <asp:TextBox ID="SexTB" class="form-control item" runat="server" TextMode="Search" Width="100%" Font-Size="Small" Height="20px"></asp:TextBox>
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
                <asp:TextBox ID="PhoneTB" class="form-control masked" runat="server" TextMode="Search" Width="100%" Font-Size="Small" onkeypress="OnlyNumeric();" MaxLength="16" AutoPostBack="True" Height="20px"></asp:TextBox>
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                Комментарий
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                <asp:TextBox ID="CommentTB" class="form-control item" runat="server" TextMode="MultiLine" Width="100%" Font-Size="Small" Height="100px"></asp:TextBox>
            </div>
            <div>
                <br />
            </div>
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px; text-align: center;">
                <!-- Modal -->
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
                <asp:Label ID="uziStatus" runat="server" ForeColor="Red"></asp:Label>
            </div>
            <div id="settings" runat="server" class="settings" style="position: fixed; height: 30px; left: 450px; width: 200px; text-align: center; top: 20px;">
                <asp:Button ID="SettingsBT" runat="server" CssClass="Btn" Text="Настройки" Width="140px" OnClick="SettingsBT_Click" />
            </div>

        </div>
        <div id="right" class="right" style="border-width: 2px; border-color: #0097A9; position: absolute; top: 0px; right: 0px; bottom: 0px; left: 200px; padding: 4px 4px 4px 4px; border-left-style: solid; margin-left: 6px;">
            <div style="position: absolute; top: 0px; right: 0px; bottom: 0px; left: 0px; padding: 4px 4px 4px 4px;">

                <!--НАЧАЛО БЛОКА-->
                <div style="text-align: left; top: 0px; bottom: 0px; width: 20%; height: 100%; position: relative; float: left">
                    <div style="border: 1px solid #FF6A13; margin: 2px 4px 2px 4px; padding: 4px; top: 0px; right: 0px; bottom: 0px; left: 0px; position: absolute; text-align: left; border-radius: 5px 5px 5px 5px;">
                        <div id="block1" runat="server" style="top: 0px; right: 0px; bottom: 0px; left: 0px;">
                            <div style="position: absolute; top: 0px; right: 0px; left: 0px; height: 70px; padding: 6px; text-align: center;">
                                <asp:RadioButton ID="DoctorRB1" class="custom-radio" runat="server" Width="100%" Font-Italic="True" Font-Size="Larger" Font-Underline="True" ForeColor="#FF6A13" />
                            </div>
                            <div style="position: absolute; top: 70px; right: 0px; left: 0px; bottom: 270px; padding: 4px; text-align: center;">
                                <asp:ListBox ID="DoctorTimeLB1" runat="server" Height="100%" Width="100%" class="form-control item" Font-Size="Small">
                                    
                                </asp:ListBox>
                            </div>
                            <div style="position: absolute; bottom: 240px; right: 0px; left: 0px; height: 30px; padding: 2px; text-align: center;">
                                <div style="top: 0px; right: 0px; bottom: 0px; left: 0px">
                                    <div style="padding: 2px; width: 70%; top: 0px; bottom: 0px; float: left; position: relative;">
                                        <asp:TextBox ID="SearchTB1" runat="server" Width="100%" Height="100%"></asp:TextBox>
                                    </div>
                                    <div style="padding: 2px; width: 30%; top: 0px; bottom: 0px; float: left; position: relative;">
                                        <asp:Button ID="SearchBT1" runat="server" CssClass="Btn" Text="Найти" Width="100%" Height="100%" />
                                    </div>
                                </div>
                            </div>
                            <div style="position: absolute; bottom: 120px; right: 0px; left: 0px; height: 120px; padding: 4px; text-align: center;">
                                <asp:ListBox ID="TestLB1" runat="server" Height="100%" Width="100%" CssClass="form-control" Font-Size="Small"></asp:ListBox>
                            </div>
                            <div style="position: absolute; bottom: 90px; right: 0px; left: 0px; height: 30px; padding: 2px 4px 2px 4px; text-align: center;">
                                <asp:Button ID="AddBT1" runat="server" class="yesBtn" Text="Выбрать тест" Width="100%" Height="100%" />
                            </div>
                            <div style="position: absolute; bottom: 60px; right: 0px; left: 0px; height: 30px; padding: 6px; text-align: center;">
                                Выбранный тест:
                            </div>
                            <div style="position: absolute; bottom: 30px; right: 0px; left: 0px; height: 30px; padding: 6px; text-align: center;">
                                <asp:Label ID="TestLabel1" runat="server" ForeColor="#FF6A13"></asp:Label>
                            </div>
                            <div style="position: absolute; bottom: 0px; right: 0px; left: 0px; height: 30px; padding: 2px 4px 2px 4px; text-align: center;">
                                <button type="button" class="BtnMain" data-toggle="modal" data-target="#exampleModal" data-backdrop="false" style="width: 100%; background-color: #FF6A13; height: 100%;">
                                    Информация</button>
                            </div>
                        </div>
                    </div>
                </div>
                <!--КОНЕЦ БЛОКА-->
				<!--НАЧАЛО БЛОКА-->
                <div style="text-align: left; top: 0px; bottom: 0px; width: 20%; height: 100%; position: relative; float: left">
                    <div style="border: 1px solid #FF6A13; margin: 2px 4px 2px 4px; padding: 4px; top: 0px; right: 0px; bottom: 0px; left: 0px; position: absolute; text-align: left; border-radius: 5px 5px 5px 5px;">
                        <div id="block2" runat="server" style="top: 0px; right: 0px; bottom: 0px; left: 0px;">
                            <div style="position: absolute; top: 0px; right: 0px; left: 0px; height: 70px; padding: 6px; text-align: center;">
                                <asp:RadioButton ID="DoctorRB2" class="custom-radio" runat="server" Width="100%" Font-Italic="True" Font-Size="Larger" Font-Underline="True" ForeColor="#FF6A13" />
                            </div>
                            <div style="position: absolute; top: 70px; right: 0px; left: 0px; bottom: 270px; padding: 4px; text-align: center;">
                                <asp:ListBox ID="DoctorTimeLB2" runat="server" Height="100%" Width="100%" class="form-control item" Font-Size="Small">
                                    
                                </asp:ListBox>
                            </div>
                            <div style="position: absolute; bottom: 240px; right: 0px; left: 0px; height: 30px; padding: 2px; text-align: center;">
                                <div style="top: 0px; right: 0px; bottom: 0px; left: 0px">
                                    <div style="padding: 2px; width: 70%; top: 0px; bottom: 0px; float: left; position: relative;">
                                        <asp:TextBox ID="SearchTB2" runat="server" Width="100%" Height="100%"></asp:TextBox>
                                    </div>
                                    <div style="padding: 2px; width: 30%; top: 0px; bottom: 0px; float: left; position: relative;">
                                        <asp:Button ID="SearchBT2" runat="server" CssClass="Btn" Text="Найти" Width="100%" Height="100%" />
                                    </div>
                                </div>
                            </div>
                            <div style="position: absolute; bottom: 120px; right: 0px; left: 0px; height: 120px; padding: 4px; text-align: center;">
                                <asp:ListBox ID="TestLB2" runat="server" Height="100%" Width="100%" CssClass="form-control" Font-Size="Small"></asp:ListBox>
                            </div>
                            <div style="position: absolute; bottom: 90px; right: 0px; left: 0px; height: 30px; padding: 2px 4px 2px 4px; text-align: center;">
                                <asp:Button ID="AddBT2" runat="server" class="yesBtn" Text="Выбрать тест" Width="100%" Height="100%" />
                            </div>
                            <div style="position: absolute; bottom: 60px; right: 0px; left: 0px; height: 30px; padding: 6px; text-align: center;">
                                Выбранный тест:
                            </div>
                            <div style="position: absolute; bottom: 30px; right: 0px; left: 0px; height: 30px; padding: 6px; text-align: center;">
                                <asp:Label ID="TestLabel2" runat="server" ForeColor="#FF6A13"></asp:Label>
                            </div>
                            <div style="position: absolute; bottom: 0px; right: 0px; left: 0px; height: 30px; padding: 2px 4px 2px 4px; text-align: center;">
                                <button type="button" class="BtnMain" data-toggle="modal" data-target="#exampleModal" data-backdrop="false" style="width: 100%; background-color: #FF6A13; height: 100%;">
                                    Информация</button>
                            </div>
                        </div>
                    </div>
                </div>
                <!--КОНЕЦ БЛОКА-->
				<!--НАЧАЛО БЛОКА-->
                <div style="text-align: left; top: 0px; bottom: 0px; width: 20%; height: 100%; position: relative; float: left">
                    <div style="border: 1px solid #FF6A13; margin: 2px 4px 2px 4px; padding: 4px; top: 0px; right: 0px; bottom: 0px; left: 0px; position: absolute; text-align: left; border-radius: 5px 5px 5px 5px;">
                        <div id="block3" runat="server" style="top: 0px; right: 0px; bottom: 0px; left: 0px;">
                            <div style="position: absolute; top: 0px; right: 0px; left: 0px; height: 70px; padding: 6px; text-align: center;">
                                <asp:RadioButton ID="DoctorRB3" class="custom-radio" runat="server" Width="100%" Font-Italic="True" Font-Size="Larger" Font-Underline="True" ForeColor="#FF6A13" />
                            </div>
                            <div style="position: absolute; top: 70px; right: 0px; left: 0px; bottom: 270px; padding: 4px; text-align: center;">
                                <asp:ListBox ID="DoctorTimeLB3" runat="server" Height="100%" Width="100%" class="form-control item" Font-Size="Small">
                                    
                                </asp:ListBox>
                            </div>
                            <div style="position: absolute; bottom: 240px; right: 0px; left: 0px; height: 30px; padding: 2px; text-align: center;">
                                <div style="top: 0px; right: 0px; bottom: 0px; left: 0px">
                                    <div style="padding: 2px; width: 70%; top: 0px; bottom: 0px; float: left; position: relative;">
                                        <asp:TextBox ID="SearchTB3" runat="server" Width="100%" Height="100%"></asp:TextBox>
                                    </div>
                                    <div style="padding: 2px; width: 30%; top: 0px; bottom: 0px; float: left; position: relative;">
                                        <asp:Button ID="SearchBT3" runat="server" CssClass="Btn" Text="Найти" Width="100%" Height="100%" />
                                    </div>
                                </div>
                            </div>
                            <div style="position: absolute; bottom: 120px; right: 0px; left: 0px; height: 120px; padding: 4px; text-align: center;">
                                <asp:ListBox ID="TestLB3" runat="server" Height="100%" Width="100%" CssClass="form-control" Font-Size="Small"></asp:ListBox>
                            </div>
                            <div style="position: absolute; bottom: 90px; right: 0px; left: 0px; height: 30px; padding: 2px 4px 2px 4px; text-align: center;">
                                <asp:Button ID="AddBT3" runat="server" class="yesBtn" Text="Выбрать тест" Width="100%" Height="100%" />
                            </div>
                            <div style="position: absolute; bottom: 60px; right: 0px; left: 0px; height: 30px; padding: 6px; text-align: center;">
                                Выбранный тест:
                            </div>
                            <div style="position: absolute; bottom: 30px; right: 0px; left: 0px; height: 30px; padding: 6px; text-align: center;">
                                <asp:Label ID="TestLabel3" runat="server" ForeColor="#FF6A13"></asp:Label>
                            </div>
                            <div style="position: absolute; bottom: 0px; right: 0px; left: 0px; height: 30px; padding: 2px 4px 2px 4px; text-align: center;">
                                <button type="button" class="BtnMain" data-toggle="modal" data-target="#exampleModal" data-backdrop="false" style="width: 100%; background-color: #FF6A13; height: 100%;">
                                    Информация</button>
                            </div>
                        </div>
                    </div>
                </div>
                <!--КОНЕЦ БЛОКА-->
				<!--НАЧАЛО БЛОКА-->
                <div style="text-align: left; top: 0px; bottom: 0px; width: 20%; height: 100%; position: relative; float: left">
                    <div style="border: 1px solid #FF6A13; margin: 2px 4px 2px 4px; padding: 4px; top: 0px; right: 0px; bottom: 0px; left: 0px; position: absolute; text-align: left; border-radius: 5px 5px 5px 5px;">
                        <div id="block4" runat="server" style="top: 0px; right: 0px; bottom: 0px; left: 0px;">
                            <div style="position: absolute; top: 0px; right: 0px; left: 0px; height: 70px; padding: 6px; text-align: center;">
                                <asp:RadioButton ID="DoctorRB4" class="custom-radio" runat="server" Width="100%" Font-Italic="True" Font-Size="Larger" Font-Underline="True" ForeColor="#FF6A13" />
                            </div>
                            <div style="position: absolute; top: 70px; right: 0px; left: 0px; bottom: 270px; padding: 4px; text-align: center;">
                                <asp:ListBox ID="DoctorTimeLB4" runat="server" Height="100%" Width="100%" class="form-control item" Font-Size="Small">
                                    
                                </asp:ListBox>
                            </div>
                            <div style="position: absolute; bottom: 240px; right: 0px; left: 0px; height: 30px; padding: 2px; text-align: center;">
                                <div style="top: 0px; right: 0px; bottom: 0px; left: 0px">
                                    <div style="padding: 2px; width: 70%; top: 0px; bottom: 0px; float: left; position: relative;">
                                        <asp:TextBox ID="SearchTB4" runat="server" Width="100%" Height="100%"></asp:TextBox>
                                    </div>
                                    <div style="padding: 2px; width: 30%; top: 0px; bottom: 0px; float: left; position: relative;">
                                        <asp:Button ID="SearchBT4" runat="server" CssClass="Btn" Text="Найти" Width="100%" Height="100%" />
                                    </div>
                                </div>
                            </div>
                            <div style="position: absolute; bottom: 120px; right: 0px; left: 0px; height: 120px; padding: 4px; text-align: center;">
                                <asp:ListBox ID="TestLB4" runat="server" Height="100%" Width="100%" CssClass="form-control" Font-Size="Small"></asp:ListBox>
                            </div>
                            <div style="position: absolute; bottom: 90px; right: 0px; left: 0px; height: 30px; padding: 2px 4px 2px 4px; text-align: center;">
                                <asp:Button ID="AddBT4" runat="server" class="yesBtn" Text="Выбрать тест" Width="100%" Height="100%" />
                            </div>
                            <div style="position: absolute; bottom: 60px; right: 0px; left: 0px; height: 30px; padding: 6px; text-align: center;">
                                Выбранный тест:
                            </div>
                            <div style="position: absolute; bottom: 30px; right: 0px; left: 0px; height: 30px; padding: 6px; text-align: center;">
                                <asp:Label ID="TestLabel4" runat="server" ForeColor="#FF6A13"></asp:Label>
                            </div>
                            <div style="position: absolute; bottom: 0px; right: 0px; left: 0px; height: 30px; padding: 2px 4px 2px 4px; text-align: center;">
                                <button type="button" class="BtnMain" data-toggle="modal" data-target="#exampleModal" data-backdrop="false" style="width: 100%; background-color: #FF6A13; height: 100%;">
                                    Информация</button>
                            </div>
                        </div>
                    </div>
                </div>
                <!--КОНЕЦ БЛОКА-->
				<!--НАЧАЛО БЛОКА-->
                <div style="text-align: left; top: 0px; bottom: 0px; width: 20%; height: 100%; position: relative; float: left">
                    <div style="border: 1px solid #FF6A13; margin: 2px 4px 2px 4px; padding: 4px; top: 0px; right: 0px; bottom: 0px; left: 0px; position: absolute; text-align: left; border-radius: 5px 5px 5px 5px;">
                        <div id="block5" runat="server" style="top: 0px; right: 0px; bottom: 0px; left: 0px;">
                            <div style="position: absolute; top: 0px; right: 0px; left: 0px; height: 70px; padding: 6px; text-align: center;">
                                <asp:RadioButton ID="DoctorRB5" class="custom-radio" runat="server" Width="100%" Font-Italic="True" Font-Size="Larger" Font-Underline="True" ForeColor="#FF6A13" />
                            </div>
                            <div style="position: absolute; top: 70px; right: 0px; left: 0px; bottom: 270px; padding: 4px; text-align: center;">
                                <asp:ListBox ID="DoctorTimeLB5" runat="server" Height="100%" Width="100%" class="form-control item" Font-Size="Small">
                                    
                                </asp:ListBox>
                            </div>
                            <div style="position: absolute; bottom: 240px; right: 0px; left: 0px; height: 30px; padding: 2px; text-align: center;">
                                <div style="top: 0px; right: 0px; bottom: 0px; left: 0px">
                                    <div style="padding: 2px; width: 70%; top: 0px; bottom: 0px; float: left; position: relative;">
                                        <asp:TextBox ID="SearchTB5" runat="server" Width="100%" Height="100%"></asp:TextBox>
                                    </div>
                                    <div style="padding: 2px; width: 30%; top: 0px; bottom: 0px; float: left; position: relative;">
                                        <asp:Button ID="SearchBT5" runat="server" CssClass="Btn" Text="Найти" Width="100%" Height="100%" />
                                    </div>
                                </div>
                            </div>
                            <div style="position: absolute; bottom: 120px; right: 0px; left: 0px; height: 120px; padding: 4px; text-align: center;">
                                <asp:ListBox ID="TestLB5" runat="server" Height="100%" Width="100%" CssClass="form-control" Font-Size="Small"></asp:ListBox>
                            </div>
                            <div style="position: absolute; bottom: 90px; right: 0px; left: 0px; height: 30px; padding: 2px 4px 2px 4px; text-align: center;">
                                <asp:Button ID="AddBT5" runat="server" class="yesBtn" Text="Выбрать тест" Width="100%" Height="100%" />
                            </div>
                            <div style="position: absolute; bottom: 60px; right: 0px; left: 0px; height: 30px; padding: 6px; text-align: center;">
                                Выбранный тест:
                            </div>
                            <div style="position: absolute; bottom: 30px; right: 0px; left: 0px; height: 30px; padding: 6px; text-align: center;">
                                <asp:Label ID="TestLabel5" runat="server" ForeColor="#FF6A13"></asp:Label>
                            </div>
                            <div style="position: absolute; bottom: 0px; right: 0px; left: 0px; height: 30px; padding: 2px 4px 2px 4px; text-align: center;">
                                <button type="button" class="BtnMain" data-toggle="modal" data-target="#exampleModal" data-backdrop="false" style="width: 100%; background-color: #FF6A13; height: 100%;">
                                    Информация</button>
                            </div>
                        </div>
                    </div>
                </div>
                <!--КОНЕЦ БЛОКА-->

            </div>

        </div>

    </div>
</asp:Content>

