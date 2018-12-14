<%@ Page Title="" Language="C#" MasterPageFile="~/_LoginLayout.master" AutoEventWireup="true" CodeFile="UziReplace.aspx.cs" Inherits="Views_UziReplace" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <div style="padding: 4px; position: absolute; top: 0px; right: 0px; bottom: 0px; left: 0px">
        <div>

            <table class="w-100">
                <tr>
                    <td style="border: 1px solid #0097A9;">Фамилия</td>
                    <td style="border: 1px solid #0097A9;">Имя</td>
                    <td style="border: 1px solid #0097A9;">Отчество</td>
                    <td style="border: 1px solid #0097A9;">Дата</td>
                    <td style="border: 1px solid #0097A9;">Время</td>
                    <td style="border: 1px solid #0097A9;">Город</td>
                    <td style="border: 1px solid #0097A9;">МО</td>
                    <td style="border: 1px solid #0097A9;">Врач</td>
                    <td style="border: 1px solid #0097A9;">Тест</td>
                    <td style="border: 1px solid #0097A9;">Коментарий</td>
                    <td style="border: 1px solid #0097A9;">Телефон</td>
                    <td style="border: 1px solid #0097A9;">ID</td>
                </tr>
                <tr>
                    <td style="border: 1px solid #0097A9;">
                        <asp:Label ID="name_1LBL" runat="server" ForeColor="#FF6A13" Font-Size="X-Small"></asp:Label>
                    </td>
                    <td style="border: 1px solid #0097A9;">
                        <asp:Label ID="name_2LBL" runat="server" ForeColor="#FF6A13" Font-Size="X-Small"></asp:Label>
                    </td>
                    <td style="border: 1px solid #0097A9;">
                        <asp:Label ID="name_3LBL" runat="server" ForeColor="#FF6A13" Font-Size="X-Small"></asp:Label>
                    </td>
                    <td style="border: 1px solid #0097A9;">
                        <asp:Label ID="dateLBL" runat="server" ForeColor="#FF6A13" Font-Size="X-Small"></asp:Label>
                    </td>
                    <td style="border: 1px solid #0097A9;">
                        <asp:Label ID="timeLBL" runat="server" ForeColor="#FF6A13" Font-Size="X-Small"></asp:Label>
                    </td>
                    <td style="border: 1px solid #0097A9;">
                        <asp:Label ID="cityLBL" runat="server" ForeColor="#FF6A13" Font-Size="X-Small"></asp:Label>
                    </td>
                    <td style="border: 1px solid #0097A9;">
                        <asp:Label ID="moLBL" runat="server" ForeColor="#FF6A13" Font-Size="X-Small"></asp:Label>
                    </td>
                    <td style="border: 1px solid #0097A9;">
                        <asp:Label ID="doctorLBL" runat="server" ForeColor="#FF6A13" Font-Size="X-Small"></asp:Label>
                    </td>
                    <td style="border: 1px solid #0097A9;">
                        <asp:Label ID="testLBL" runat="server" ForeColor="#FF6A13" Font-Size="X-Small"></asp:Label>
                    </td>
                    <td style="border: 1px solid #0097A9;">
                        <asp:Label ID="commentLBL" runat="server" ForeColor="#FF6A13" Font-Size="X-Small"></asp:Label>
                    </td>
                    <td style="border: 1px solid #0097A9;">
                        <asp:Label ID="phoneLBL" runat="server" ForeColor="#FF6A13" Font-Size="X-Small"></asp:Label>
                    </td>
                    <td style="border: 1px solid #0097A9;">
                        <asp:Label ID="IDLBL" runat="server" ForeColor="#FF6A13" Font-Size="X-Small"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;" colspan="12"><br />
                        <asp:Button ID="Button1" runat="server" CssClass="yesBtn" OnClick="Button1_Click" Text="Подтвердить" Width="150px" OnClientClick="return confirm('Нажмите ОК, если хотите подтвердить запись');" />
                        &nbsp;<asp:Button ID="Button2" runat="server" CssClass="yesBtn" OnClick="Button2_Click" Text="Перенести" Width="150px" OnClientClick="return confirm('Нажмите ОК, если хотите перенести запись');" />
                        &nbsp;<asp:Button ID="Button4" runat="server" CssClass="noBtn" OnClick="Button4_Click" OnClientClick="return confirm('Нажмите ОК, если хотите удалить запись');" Text="Удалить" Width="150px" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button3" runat="server" CssClass="yesBtn" OnClick="Button3_Click" Text="Вернуться назад" Width="150px" />
                        <br />
                        <br />
                    </td>
                </tr>
            </table>

        </div>
        <div style="padding: 4px; border: 1px solid #0097A9">
        </div>
    </div>
</asp:Content>

