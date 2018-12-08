<%@ Page Title="" Language="C#" MasterPageFile="~/_LoginLayout.master" AutoEventWireup="true" CodeFile="UziSettings.aspx.cs" Inherits="Views_UziSettings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="Server">
    ЛУИЗА - УЗИ - Расписание
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
<div style="padding: 4px; top: 0px; right: 0px; bottom: 0px; left: 0px; position: absolute">
        <div style="margin: 4px; border: 1px solid #FF6A13; top: 100px; position: absolute; right: 300px; left: 300px; height: 600px; text-align: center; border-radius: 5px 5px 5px 5px;">
            <div style="top: 4px; left: 4px; width: 190px; height: 190px; position: absolute;">
                <asp:Calendar ID="uziCalendar" runat="server" Height="100%" Width="100%" OnSelectionChanged="uziCalendar_SelectionChanged">
                    <DayStyle BackColor="White" ForeColor="#FF6A13" />
                    <OtherMonthDayStyle ForeColor="#CCCCCC" />
                    <SelectedDayStyle BackColor="#FF6A13" ForeColor="White" />
                    <SelectorStyle BackColor="#FF6A13" ForeColor="White" />
                    <TitleStyle BackColor="#FF6A13" ForeColor="White" />
                </asp:Calendar>
            </div>
            <div style="top: 4px; left: 192px; bottom: 404px; right: 4px; position: absolute; padding: 4px;">

                <table style="width: 100%; height: 186px">
                    <tr>
                        <td style="width: 25%;">Город</td>
                        <td style="width: 25%;">
                            <asp:DropDownList ID="uziCity" class="form-control" runat="server" Width="100%" AutoPostBack="True" DataSourceID="uziCityDS" DataTextField="city" DataValueField="city">
                            </asp:DropDownList>
                            <asp:LinqDataSource ID="uziCityDS" runat="server" ContextTypeName="toSQLDataContext" EntityTypeName="" GroupBy="city" Select="new (key as city, it as Uzi_Cities)" TableName="Uzi_Cities">
                            </asp:LinqDataSource>
                        </td>
                        <td style="width: 25%;">Дата</td>
                        <td style="width: 25%;">
                            
                            <asp:TextBox ID="uziDate" class="form-control" runat="server" Width="100%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 25%;">МО</td>
                        <td style="width: 25%;">
                            <asp:DropDownList ID="uziMo" class="form-control" runat="server" Width="100%" AutoPostBack="True" DataSourceID="uziMODS" DataTextField="mo" DataValueField="mo">
                            </asp:DropDownList>
                            <asp:LinqDataSource ID="uziMODS" runat="server" ContextTypeName="toSQLDataContext" EntityTypeName="" GroupBy="mo" Select="new (key as mo, it as Uzi_Cities)" TableName="Uzi_Cities" Where="city == @city">
                                <WhereParameters>
                                    <asp:ControlParameter ControlID="uziCity" Name="city" PropertyName="SelectedValue" Type="String" />
                                </WhereParameters>
                            </asp:LinqDataSource>
                        </td>
                        <td style="width: 25%;">Время начала приема</td>
                        <td style="width: 25%;">
                            <asp:TextBox ID="doctorStart" class="form-control" runat="server" Width="100%" TextMode="Time"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 25%;">Врач</td>
                        <td style="width: 25%;">
                            <asp:DropDownList ID="uziDoctor" class="form-control" runat="server" Width="100%" AutoPostBack="True" DataSourceID="uziDoctorDS" DataTextField="DOCTOR" DataValueField="DOCTOR">
                            </asp:DropDownList>
                            <asp:LinqDataSource ID="uziDoctorDS" runat="server" ContextTypeName="toSQLDataContext" EntityTypeName="" GroupBy="DOCTOR" Select="new (key as DOCTOR, it as Uzi_Doctor)" TableName="Uzi_Doctor" Where="CITY == @CITY &amp;&amp; MO == @MO">
                                <WhereParameters>
                                    <asp:ControlParameter ControlID="uziCity" Name="CITY" PropertyName="SelectedValue" Type="String" />
                                    <asp:ControlParameter ControlID="uziMo" Name="MO" PropertyName="SelectedValue" Type="String" />
                                </WhereParameters>
                            </asp:LinqDataSource>
                        </td>
                        <td colspan="2">
                            <asp:Button ID="Button1" runat="server" CssClass="yesBtn" Text="Создать расписание" Width="200px" OnClick="Button1_Click" />
                            <asp:Button ID="Button3" runat="server" CssClass="noBtn" Text="Удалить расписание" Width="200px" OnClick="Button3_Click" OnClientClick="return confirm('Нажмите ОК, если хотите удалить расписание на день');" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:Label ID="errorLabel" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>

            </div>
            <div style="position: absolute; top: 200px; right: 0px; bottom: 0px; left: 0px; overflow: scroll; overflow-x: hidden;"> 

                    <asp:GridView ID="UziShedGV" runat="server" AutoGenerateColumns="False" BorderColor="#0097A9" BorderWidth="1px" CellPadding="2" Width="100%" DataSourceID="UziShedDS" DataKeyNames="ID" OnPreRender="UziShedGV_PreRender">
                        <Columns>
                            <asp:BoundField DataField="date" HeaderText="Дата" ReadOnly="True" SortExpression="date" />
                            <asp:BoundField DataField="time" HeaderText="Время" ReadOnly="True" SortExpression="time" />
                            <asp:BoundField DataField="doctor" HeaderText="Доктор" ReadOnly="True" SortExpression="doctor" />
                            <asp:BoundField DataField="city" HeaderText="Город" ReadOnly="True" SortExpression="city" />
                            <asp:BoundField DataField="mo" HeaderText="МО" ReadOnly="True" SortExpression="mo" />
                            <asp:BoundField DataField="name_1" HeaderText="Фамилия" ReadOnly="True" SortExpression="name_1" />
                            <asp:BoundField DataField="name_2" HeaderText="Имя" ReadOnly="True" SortExpression="name_2" />
                            <asp:BoundField DataField="name_3" HeaderText="Отчество" ReadOnly="True" SortExpression="name_3" />
                            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" InsertVisible="False" />
                            <asp:CheckBoxField DataField="hidden" HeaderText="Скрытое время" SortExpression="hidden" />
                            <asp:CommandField ShowEditButton="True" />
                        </Columns>
                        <HeaderStyle ForeColor="#FF6A13" />
                        <SelectedRowStyle BackColor="#FF6A13" Font-Bold="True" Font-Italic="True" ForeColor="White" />
                    </asp:GridView>

                    <asp:LinqDataSource ID="UziShedDS" runat="server" ContextTypeName="toSQLDataContext" EntityTypeName="" TableName="Uzi_Zapisi" Where="city == @city &amp;&amp; mo == @mo &amp;&amp; doctor == @doctor &amp;&amp; date == @date" EnableDelete="True" EnableInsert="True" EnableUpdate="True">
                        <WhereParameters>
                            <asp:ControlParameter ControlID="uziCity" Name="city" PropertyName="SelectedValue" Type="String" />
                            <asp:ControlParameter ControlID="uziMo" Name="mo" PropertyName="SelectedValue" Type="String" />
                            <asp:ControlParameter ControlID="uziDoctor" Name="doctor" PropertyName="SelectedValue" Type="String" />
                            <asp:ControlParameter ControlID="uziDate" Name="date" PropertyName="Text" Type="String" />
                        </WhereParameters>
                    </asp:LinqDataSource>

            </div>
        </div>
        <div style="position: fixed; width: 200px; height: 30px; bottom: 50px; right: 50%; margin-right: -100px">

            <asp:Button ID="Button2" runat="server" CssClass="BtnMain" Font-Size="Large" Height="100%" Text="Вернуться назад" Width="100%" OnClick="Button2_Click" />

        </div>
    </div>
</asp:Content>

