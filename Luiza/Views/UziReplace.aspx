<%@ Page Title="" Language="C#" MasterPageFile="~/_LoginLayout.master" AutoEventWireup="true" CodeFile="UziReplace.aspx.cs" Inherits="Views_UziReplace" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <div style="padding: 4px; position: absolute; top: 0px; right: 0px; bottom: 0px; left: 0px">
        <div>

            <table class="w-100">
                <tr>
                    <td style="width: 10%; height: 21px;">Фамилия</td>
                    <td style="width: 10%; height: 21px;">Имя</td>
                    <td style="width: 10%; height: 21px;">Отчество</td>
                    <td style="width: 10%; height: 21px;">Дата</td>
                    <td style="width: 10%; height: 21px;">Время</td>
                    <td style="width: 10%; height: 21px;">Город</td>
                    <td style="width: 10%; height: 21px;">МО</td>
                    <td style="width: 10%; height: 21px;">Врач</td>
                    <td style="width: 10%; height: 21px;">Тест</td>
                    <td style="width: 10%; height: 21px;">ID</td>
                </tr>
                <tr>
                    <td style="width: 10%">
                        <asp:Label ID="name_1LBL" runat="server" ForeColor="#FF6A13"></asp:Label>
                    </td>
                    <td style="width: 10%">
                        <asp:Label ID="name_2LBL" runat="server" ForeColor="#FF6A13"></asp:Label>
                    </td>
                    <td style="width: 10%">
                        <asp:Label ID="name_3LBL" runat="server" ForeColor="#FF6A13"></asp:Label>
                    </td>
                    <td style="width: 10%">
                        <asp:Label ID="dateLBL" runat="server" ForeColor="#FF6A13"></asp:Label>
                    </td>
                    <td style="width: 10%">
                        <asp:Label ID="timeLBL" runat="server" ForeColor="#FF6A13"></asp:Label>
                    </td>
                    <td style="width: 10%">
                        <asp:Label ID="citiLBL" runat="server" ForeColor="#FF6A13"></asp:Label>
                    </td>
                    <td style="width: 10%">
                        <asp:Label ID="moLBL" runat="server" ForeColor="#FF6A13"></asp:Label>
                    </td>
                    <td style="width: 10%">
                        <asp:Label ID="doctorLBL" runat="server" ForeColor="#FF6A13"></asp:Label>
                    </td>
                    <td style="width: 10%">
                        <asp:Label ID="testLBL" runat="server" ForeColor="#FF6A13"></asp:Label>
                    </td>
                    <td style="width: 10%">
                        <asp:Label ID="IDLBL" runat="server" ForeColor="#FF6A13"></asp:Label>
                    </td>
                </tr>
            </table>

        </div>
        <div style="padding: 4px; border: 1px solid #0097A9">

        </div>
    </div>
</asp:Content>

