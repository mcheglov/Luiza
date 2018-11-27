<%@ Page Title="" Language="C#" MasterPageFile="~/_LoginLayout.master" AutoEventWireup="true" CodeFile="SpermSettings.aspx.cs" Inherits="Views_SpermSettings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <div style="padding: 4px; top: 0px; right: 0px; bottom: 0px; left: 0px; position: absolute">
        <div style="margin: 4px; border: 1px solid #FF6A13; top: 100px; position: absolute; right: 300px; left: 300px; height: 200px; text-align: center; border-radius: 5px 5px 5px 5px;">
            <div style="top: 4px; left: 4px; width: 190px; height: 190px; position: absolute;">
                <asp:Calendar ID="spermCalendar" runat="server" Height="100%" Width="100%" OnSelectionChanged="spermCalendar_SelectionChanged">
                    <DayStyle BackColor="White" ForeColor="#FF6A13" />
                    <OtherMonthDayStyle ForeColor="#CCCCCC" />
                    <SelectedDayStyle BackColor="#FF6A13" ForeColor="White" />
                    <SelectorStyle BackColor="#FF6A13" ForeColor="White" />
                    <TitleStyle BackColor="#FF6A13" ForeColor="White" />
                </asp:Calendar>
            </div>
            <div style="top: 4px; left: 192px; bottom: 4px; right: 4px; position: absolute; padding: 4px;">

                <table style="width: 100%; height: 100%">
                    <tr>
                        <td style="width: 25%">Город</td>
                        <td style="width: 25%">
                            <asp:DropDownList ID="spermCity" class="form-control" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="spermCity_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 25%">Начало работы</td>
                        <td style="width: 25%">
                            <asp:TextBox ID="doctorStart" class="form-control" runat="server" Width="100%" TextMode="Time"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 25%">МО</td>
                        <td style="width: 25%">
                            <asp:DropDownList ID="spermMo" class="form-control" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="spermMO_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 25%">Конец работы</td>
                        <td style="width: 25%">
                            <asp:TextBox ID="doctorEnd" class="form-control" runat="server" Width="100%" TextMode="Time"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 25%">Врач</td>
                        <td style="width: 25%">
                            <asp:DropDownList ID="spermDoctor" class="form-control" runat="server" Width="100%" AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 25%">Время приема</td>
                        <td style="width: 25%">
                            <asp:TextBox ID="doctorTimespan" class="form-control" runat="server" Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 25%">Дата</td>
                        <td style="width: 25%">
                            <asp:TextBox ID="spermDate" class="form-control" runat="server" Width="100%"></asp:TextBox>
                        </td>
                        <td style="width: 25%">
                            <asp:Label ID="errorLabel" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                        <td style="width: 25%">
                            <asp:Button ID="Button1" runat="server" CssClass="yesBtn" Text="Создать расписание" Width="100%" OnClick="Button1_Click" />
                        </td>
                    </tr>
                </table>

            </div>
        </div>
        <div style="position: fixed; width: 200px; height: 30px; bottom: 100px; right: 50%; margin-right: -100px">

            <asp:Button ID="Button2" runat="server" CssClass="BtnMain" Font-Size="Large" Height="100%" OnClick="Button2_Click" Text="Вернуться назад" Width="100%" />

        </div>
    </div>
</asp:Content>

