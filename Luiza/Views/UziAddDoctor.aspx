<%@ Page Title="" Language="C#" MasterPageFile="~/_LoginLayout.master" AutoEventWireup="true" CodeFile="UziAddDoctor.aspx.cs" Inherits="Views_UziAddDoctor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="Server">
    ЛУИЗА - УЗИ - Добавление доктора
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <div style="padding: 4px; position: absolute; top: 0px; right: 0px; bottom: 0px; left: 0px">
        <div style="position: absolute; top: 0px; right: 0px; left: 0px; height:360px;">
            <div style="margin: 4px; padding: 4px; border: 1px solid #0097A9; position: absolute; width: 200px; top: 0px; bottom: 0px; left: 0px; right: 0px;">
                <table class="w-100">
                    <tr>
                        <td>Город:</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="CityDL" runat="server" Width="100%" CssClass="form-control item" AutoPostBack="True" OnSelectedIndexChanged="CityDL_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>МО:</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="MODL" runat="server" Width="100%" CssClass="form-control item" AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>Врач:</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="DoctorTB" runat="server" TextMode="Search" Width="100%" CssClass="form-control item"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Ограничения:</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="RestTB" runat="server" TextMode="Search" Width="100%" CssClass="form-control item"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="errorLabel" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <div style="margin: 4px; padding: 4px; border: 1px solid #FF6A13; position: absolute; top: 0px; right: 0px; bottom: 0px; left: 208px">

                <table class="w-100">
                    <tr>
                        <td style="width: 70%">Тест:</td>
                        <td style="width: 30%">Длительность:</td>
                    </tr>
                    <tr>
                        <td style="width: 70%">
                            <asp:DropDownList ID="TestDL" runat="server" Width="100%" CssClass="form-control item" AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 30%">
                            <asp:DropDownList ID="DurDL" runat="server" Width="100%" CssClass="form-control item" AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 70%">
                            <asp:Button ID="AddBT" runat="server" CssClass="yesBtn" Text="Добавить" OnClick="AddBT_Click" />
                        </td>
                        <td style="width: 30%">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 70%">Добавленные исследования:</td>
                        <td style="width: 30%">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:ListBox ID="AddedLB" runat="server" Width="100%" CssClass="form-control item" Height="200px"></asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 70%">
                            <asp:Button ID="DellBT" runat="server" CssClass="noBtn" Text="Убрать" OnClick="DellBT_Click" />
                        </td>
                        <td style="width: 30%; text-align: right;">
                            <asp:Button ID="BackBT" runat="server" CssClass="yesBtn" Text="Вернуться назад" OnClick="Back_Click" Width="49%" />
                        &nbsp;<asp:Button ID="AddDocBT" runat="server" CssClass="yesBtn" Text="Добавить врача" OnClick="AddDocBT_Click" Width="49%" />
                        </td>
                    </tr>
                </table>

            </div>
        </div>

    </div>
</asp:Content>

