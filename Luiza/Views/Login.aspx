<%@ Page Title="" Language="C#" MasterPageFile="~/_LoginLayout.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Views_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <div id="loginBox" class="loginBox" style="top: 0px; right: 0px; bottom: 0px; left: 0px; position: absolute; text-align: center;">
        <div style="width: 300px; height: 200px; position: absolute; margin: -100px 0 0 -150px; left: 50%; top: 50%; border-radius: 5px 5px 5px 5px; border: 1px solid #0097A9" runat="server" id="lB">
            <table style="width: 100%; height: 100%">
                <tr>
                    <td colspan="2" style="font-family: Arial, Helvetica, sans-serif; font-size: large; font-weight: bold; color: #FF6A13;">Авторизация</td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 30%;">Логин:</td>
                    <td style="text-align: left">
                        <asp:TextBox ID="loginTextbox" runat="server" Width="90%" Class="form-control"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 30%;">Пароль:</td>
                    <td style="text-align: left">
                        <asp:TextBox ID="passwordTextbox" runat="server" TextMode="Password" Width="90%" Class="form-control"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="loginBtn" runat="server" CssClass="Btn" Text="Войти" OnClick="loginBtn_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="errorLabel" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

