<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeBonusDetails.aspx.cs" Inherits="AllProjectsBestPractices.EmployeeBonusDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Employees salaries bouncees </strong>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Years : :"></asp:Label>
        <asp:DropDownList ID="ddlFiscalYear" runat="server" Height="17px" Width="172px">
   <asp:ListItem Value="0" selected="True">2018 </asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="Label2" runat="server" Text="Bonus Type :"></asp:Label>
        <asp:DropDownList ID="dllpercentagetype" runat="server" Height="17px" Width="181px" AutoPostBack="true">
   <asp:ListItem >Percentage </asp:ListItem>
   <asp:ListItem >No of months </asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="Label3" runat="server" Text="Bonus value"></asp:Label>
        <asp:TextBox ID="txtperValue" runat="server"></asp:TextBox>
        <asp:Button ID="BtnApply" runat="server" Text="Apply" OnClick="BtnApply_Click" />
        <asp:GridView ID="GrdEmployees" runat="server" Width="600px" AutoGenerateColumns="false">
            <Columns>
                  <asp:TemplateField HeaderText="EMP NO">
                <ItemTemplate>
                    <asp:Label ID="lblempNo" runat="server" Text='<%#Bind("EMPNO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                     <asp:TemplateField HeaderText="EMP Name">
                <ItemTemplate>
                    <asp:Label ID="lblempname" runat="server" Text='<%#Bind("EMPNAME") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                       <asp:TemplateField HeaderText="EMP Designation">
                <ItemTemplate>
                    <asp:Label ID="lbldesignation" runat="server" Text='<%#Bind("Designation") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

                     <asp:TemplateField HeaderText="EMP Salary">
                <ItemTemplate>
                    <asp:Label ID="lblSal" runat="server" Text='<%#Bind("Salary") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                  <asp:TemplateField HeaderText="BonusValue">
                <ItemTemplate>
                    <asp:Label ID="lblBonusval" runat="server" Text='<%#Bind("BonusValue") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                         <asp:TemplateField HeaderText="BonusType">
                <ItemTemplate>
                    <asp:Label ID="lblbonustype" runat="server" Text='<%#Bind("BonusType") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                         <asp:TemplateField HeaderText="Amount">
                <ItemTemplate>
                    <asp:Label ID="lblAmnt" runat="server" Text='<%#Bind("Amount") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
    </form>
</body>
</html>
