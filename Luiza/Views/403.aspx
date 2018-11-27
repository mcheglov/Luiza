<%@ Page Title="" Language="C#" MasterPageFile="~/_LoginLayout.master" AutoEventWireup="true" CodeFile="403.aspx.cs" Inherits="Views_403" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <div style="position: absolute; top: 0px; right: 0px; bottom: 0px; left: 0px">
        <div style="margin-right: -150px; margin-top: -75px; top: 50%; right: 50%; width: 300px; height: 150px; position: absolute; text-align: center;">
            <table style="width: 100%; height: 100px">
                <tr>
                    <td style="font-size: xx-large; font-weight: bold; font-family: Arial, Helvetica, sans-serif; color: #FF6A13">Доступ запрещен</td>
                </tr>
                <tr>
                    <td>Необходимо авторизоваться</td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Views/Login.aspx">Авторизация</asp:HyperLink>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

