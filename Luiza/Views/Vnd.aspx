<%@ Page Title="" Language="C#" MasterPageFile="~/_Layout.master" AutoEventWireup="true" CodeFile="Vnd.aspx.cs" Inherits="Views_Vnd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <table class="w-100">
        <tr>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True" CssClass="form-check-label" OnTextChanged="TextBox1_TextChanged" Width="150px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="streetDL" runat="server" Width="150px">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

