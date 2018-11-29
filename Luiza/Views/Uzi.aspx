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
                <asp:TextBox ID="MiddlenameTB" class="form-control item" runat="server" TextMode="Search" Width="100%" Font-Size="Small" Height="20px" OnTextChanged="MiddlenameTB_TextChanged"></asp:TextBox>
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
            <div style="margin-bottom: 2px; padding-right: 2px; padding-left: 2px;">
                Телефон
            </div>
                <asp:DropDownList ID="SexDL" class="form-control item" runat="server" Width="100%" AutoPostBack="True" Font-Size="Small" Height="20px">
                    <asp:ListItem>Мужской</asp:ListItem>
                    <asp:ListItem>Женский</asp:ListItem>
                </asp:DropDownList>
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
                                <asp:Label ID="currentDoctor" runat="server" Text="Выбранный доктор" Font-Size="Large" ForeColor="#FF6A13"></asp:Label>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body" style="text-align: left;">
                                <div style="height: 400px; position: inherit;">
                                    <div style="margin: 3px; padding: 2px; border: 1px solid #FF6A13; border-radius: 5px; width: 32%; height: 100px; position: relative; float: left;">
                                        <asp:Label ID="Label2" runat="server" Text="Ограничения" Height="20px"></asp:Label>
                                        <br />
                                        <asp:Label ID="restrictionLabel" runat="server" Text="Ограничения" Height="20px" ForeColor="Red"></asp:Label>
                                    </div>
                                    <div style="margin: 3px; padding: 2px; border: 1px solid #FF6A13; border-radius: 5px; width: 32%; height: 100px; position: relative; float: left;">
                                        <asp:Label ID="Label3" runat="server" Text="Длительность" Height="20px"></asp:Label>
                                        <br />
                                        <asp:Label ID="durationLabel" runat="server" Text="Длительность" Height="20px" ForeColor="Red"></asp:Label>
                                    </div>
                                    <div style="margin: 3px; padding: 2px; border: 1px solid #FF6A13; border-radius: 5px; width: 32%; height: 100px; position: relative; float: left;">
                                        <asp:Label ID="Label4" runat="server" Text="Цена" Height="20px"></asp:Label>
                                        <br />
                                        <asp:Label ID="priceLabel" runat="server" Text="Цена" Height="20px" ForeColor="Red"></asp:Label>

                                    </div>
                                    <div style="margin: 3px; padding: 2px; border: 1px solid #0097A9; border-radius: 5px; bottom: 0px; right: 0px; left: 0px; top: 106px; position: absolute; height: 300px;">
                                        <asp:Label ID="Label5" runat="server" Text="Подготовка" Height="20px"></asp:Label>
                                        <br />
                                        <asp:TextBox ID="PrepTB" сlass="form-control item" runat="server" Width="100%" Height="274px" TextMode="MultiLine" Font-Size="Small"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer" style="text-align: center;">
                                <button type="button" class="exitBtn" data-dismiss="modal">Закрыть</button>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Modal -->
                <asp:Label ID="recordID" runat="server" ForeColor="White"></asp:Label>
                <br />
            </div>
            <div style="text-align: center; width: 200px; bottom: 0px; left: 0px; position: absolute;">
                <div style="padding: 2px">
                    <asp:Button ID="ChangeBT" runat="server" CssClass="Btn" Text="Перенести запись" Width="100%" Height="30px" Font-Size="Medium" /><br />
                </div>
                <div style="padding: 2px">
                    <button type="button" id="delBT" runat="server" class="noBtn" data-toggle="modal" data-target="#delRecord" data-backdrop="false" style="width: 100%; height: 30px; font-size: medium; background-color: #FF6A13;">
                        Удалить запись</button>
                    <div class="modal fade" id="delRecord" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title" id="delRecordLabel" style="color: #FF6A13;">Освободить время</h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                                <div class="modal-body" style="text-align: left;">
                                    Вы уверены, что хотите освободить текущее время?
                                </div>
                                <div class="modal-footer" style="text-align: center;">
                                    <asp:Button ID="YesDelBT" runat="server" Text="Да" CssClass="yesBtn" />
                                    <asp:Button ID="NoBT" runat="server" Text="Нет" CssClass="noBtn" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div style="padding: 2px">
                    <asp:Button ID="ConfirmBT" runat="server" CssClass="yesBtn" Text="Подтвердить запись" Width="100%" Height="30px" Font-Size="Medium" /><br />
                </div>
                <div style="padding: 2px">
                    <asp:Button ID="SubmitBT" runat="server" CssClass="Btn" Text="ЗАПИСАТЬ" Width="100%" Height="30px" Font-Size="Large" OnClick="SubmitBT_Click" />
                </div>
            </div>
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
                <div id="block1" runat="server" style="text-align: left; top: 0px; bottom: 0px; width: 20%; height: 100%; position: relative; float: left">
                    <div style="border: 1px solid #FF6A13; margin: 2px 4px 2px 4px; padding: 4px; top: 0px; right: 0px; bottom: 0px; left: 0px; position: absolute; text-align: left; border-radius: 5px 5px 5px 5px;">
                        <div style="top: 0px; right: 0px; bottom: 0px; left: 0px;">
                            <div style="position: absolute; top: 0px; right: 0px; left: 0px; height: 70px; padding: 6px; text-align: center;">
                                <asp:RadioButton ID="DoctorRB1" class="custom-radio" runat="server" Width="100%" Font-Italic="True" Font-Size="Larger" Font-Underline="True" ForeColor="#FF6A13" AutoPostBack="True" OnCheckedChanged="DoctorRB1_CheckedChanged" GroupName="doctorGP" />
                            </div>
                            <div style="position: absolute; top: 70px; right: 0px; left: 0px; bottom: 270px; padding: 4px; text-align: center;">
                                <asp:ListBox ID="DoctorTimeLB1" runat="server" Height="100%" Width="100%" class="form-control item" Font-Size="Small" AutoPostBack="True" Font-Bold="True" ForeColor="#0097A9" OnSelectedIndexChanged="DoctorTimeLB1_SelectedIndexChanged" ViewStateMode="Enabled">
                                    <asp:ListItem>10:00 - Иванов</asp:ListItem>
                                    <asp:ListItem>10:30</asp:ListItem>
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
                                <asp:ListBox ID="TestLB1" runat="server" Height="100%" Width="100%" CssClass="form-control" Font-Size="Small" AutoPostBack="True"></asp:ListBox>
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
                    <div id="block1hide" runat="server" style="position: absolute; top: 30px; right: 0px; bottom: 0px; left: 0px"></div>
                </div>
                <!--КОНЕЦ БЛОКА-->
                <!--НАЧАЛО БЛОКА-->
                <div id="block2" runat="server" style="text-align: left; top: 0px; bottom: 0px; width: 20%; height: 100%; position: relative; float: left">
                    <div style="border: 1px solid #FF6A13; margin: 2px 4px 2px 4px; padding: 4px; top: 0px; right: 0px; bottom: 0px; left: 0px; position: absolute; text-align: left; border-radius: 5px 5px 5px 5px;">
                        <div style="top: 0px; right: 0px; bottom: 0px; left: 0px;">
                            <div style="position: absolute; top: 0px; right: 0px; left: 0px; height: 70px; padding: 6px; text-align: center;">
                                <asp:RadioButton ID="DoctorRB2" class="custom-radio" runat="server" Width="100%" Font-Italic="True" Font-Size="Larger" Font-Underline="True" ForeColor="#FF6A13" AutoPostBack="True" OnCheckedChanged="DoctorRB2_CheckedChanged" GroupName="doctorGP" />
                            </div>
                            <div style="position: absolute; top: 70px; right: 0px; left: 0px; bottom: 270px; padding: 4px; text-align: center;">
                                <asp:ListBox ID="DoctorTimeLB2" runat="server" Height="100%" Width="100%" class="form-control item" Font-Size="Small" AutoPostBack="True" Enabled="False" Font-Bold="True" ForeColor="#0097A9"></asp:ListBox>
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
                    <div id="block2hide" runat="server" style="position: absolute; top: 30px; right: 0px; bottom: 0px; left: 0px">
                    </div>
                </div>
                <!--КОНЕЦ БЛОКА-->
                <!--НАЧАЛО БЛОКА-->
                <div id="block3" runat="server" style="text-align: left; top: 0px; bottom: 0px; width: 20%; height: 100%; position: relative; float: left">
                    <div style="border: 1px solid #FF6A13; margin: 2px 4px 2px 4px; padding: 4px; top: 0px; right: 0px; bottom: 0px; left: 0px; position: absolute; text-align: left; border-radius: 5px 5px 5px 5px;">
                        <div style="top: 0px; right: 0px; bottom: 0px; left: 0px;">
                            <div style="position: absolute; top: 0px; right: 0px; left: 0px; height: 70px; padding: 6px; text-align: center;">
                                <asp:RadioButton ID="DoctorRB3" class="custom-radio" runat="server" Width="100%" Font-Italic="True" Font-Size="Larger" Font-Underline="True" ForeColor="#FF6A13" AutoPostBack="True" OnCheckedChanged="DoctorRB3_CheckedChanged" GroupName="doctorGP" />
                            </div>
                            <div style="position: absolute; top: 70px; right: 0px; left: 0px; bottom: 270px; padding: 4px; text-align: center;">
                                <asp:ListBox ID="DoctorTimeLB3" runat="server" Height="100%" Width="100%" class="form-control item" Font-Size="Small" AutoPostBack="True" Font-Bold="True" ForeColor="#0097A9"></asp:ListBox>
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
                                <asp:ListBox ID="TestLB3" runat="server" Height="100%" Width="100%" CssClass="form-control" Font-Size="Small" AutoPostBack="True"></asp:ListBox>
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
                    <div id="block3hide" runat="server" style="position: absolute; top: 30px; right: 0px; bottom: 0px; left: 0px"></div>
                </div>
                <!--КОНЕЦ БЛОКА-->
                <!--НАЧАЛО БЛОКА-->
                <div id="block4" runat="server" style="text-align: left; top: 0px; bottom: 0px; width: 20%; height: 100%; position: relative; float: left">
                    <div style="border: 1px solid #FF6A13; margin: 2px 4px 2px 4px; padding: 4px; top: 0px; right: 0px; bottom: 0px; left: 0px; position: absolute; text-align: left; border-radius: 5px 5px 5px 5px;">
                        <div style="top: 0px; right: 0px; bottom: 0px; left: 0px;">
                            <div style="position: absolute; top: 0px; right: 0px; left: 0px; height: 70px; padding: 6px; text-align: center;">
                                <asp:RadioButton ID="DoctorRB4" class="custom-radio" runat="server" Width="100%" Font-Italic="True" Font-Size="Larger" Font-Underline="True" ForeColor="#FF6A13" AutoPostBack="True" OnCheckedChanged="DoctorRB4_CheckedChanged" GroupName="doctorGP" />
                            </div>
                            <div style="position: absolute; top: 70px; right: 0px; left: 0px; bottom: 270px; padding: 4px; text-align: center;">
                                <asp:ListBox ID="DoctorTimeLB4" runat="server" Height="100%" Width="100%" class="form-control item" Font-Size="Small" AutoPostBack="True" Font-Bold="True" ForeColor="#0097A9"></asp:ListBox>
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
                                <asp:ListBox ID="TestLB4" runat="server" Height="100%" Width="100%" CssClass="form-control" Font-Size="Small" AutoPostBack="True"></asp:ListBox>
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
                    <div id="block4hide" runat="server" style="position: absolute; top: 30px; right: 0px; bottom: 0px; left: 0px"></div>
                </div>
                <!--КОНЕЦ БЛОКА-->
                <!--НАЧАЛО БЛОКА-->
                <div id="block5" runat="server" style="text-align: left; top: 0px; bottom: 0px; width: 20%; height: 100%; position: relative; float: left;">
                    <div style="border: 1px solid #FF6A13; margin: 2px 4px 2px 4px; padding: 4px; top: 0px; right: 0px; bottom: 0px; left: 0px; position: absolute; text-align: left; border-radius: 5px 5px 5px 5px;">
                        <div style="top: 0px; right: 0px; bottom: 0px; left: 0px;">
                            <div style="position: absolute; top: 0px; right: 0px; left: 0px; height: 70px; padding: 6px; text-align: center;">
                                <asp:RadioButton ID="DoctorRB5" class="custom-radio" runat="server" Width="100%" Font-Italic="True" Font-Size="Larger" Font-Underline="True" ForeColor="#FF6A13" AutoPostBack="True" OnCheckedChanged="DoctorRB5_CheckedChanged" GroupName="doctorGP" />
                            </div>
                            <div style="position: absolute; top: 70px; right: 0px; left: 0px; bottom: 270px; padding: 4px; text-align: center;">
                                <asp:ListBox ID="DoctorTimeLB5" runat="server" Height="100%" Width="100%" class="form-control item" Font-Size="Small" AutoPostBack="True" Font-Bold="True" ForeColor="#0097A9"></asp:ListBox>
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
                                <asp:ListBox ID="TestLB5" runat="server" Height="100%" Width="100%" CssClass="form-control" Font-Size="Small" AutoPostBack="True"></asp:ListBox>
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
                    <div id="block5hide" runat="server" style="position: absolute; top: 30px; right: 0px; bottom: 0px; left: 0px"></div>
                </div>
                <!--КОНЕЦ БЛОКА-->

            </div>

        </div>

    </div>
</asp:Content>

