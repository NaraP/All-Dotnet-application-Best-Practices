<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerGridFrom.aspx.cs" Inherits="AllProjectsBestPractices.CustomerGridFrom" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        table
        {
            border: 1px solid #ccc;
            margin-bottom: -1px;
        }
        table th
        {
            background-color: #F7F7F7;
            color: #333;
            font-weight: bold;
        }
        table th, table td
        {
            padding: 5px;
            border-color: #ccc;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Customer contact information details" Font-Bold="True" Font-Size="20pt"></asp:Label>
    <asp:GridView ID="GrdCustomer" runat="server" AutoGenerateColumns="false" DataKeyNames="CustomerId"
        OnRowDataBound="GrdCustomer_RowDataBound" OnRowEditing="GrdCustomer_RowEditing" OnRowCancelingEdit="GrdCustomer_RowCancelingEdit"
        OnRowUpdating="GrdCustomer_RowUpdating" OnRowDeleting="GrdCustomer_RowDeleting" EmptyDataText="No records has been added." Width="955px">
        <Columns>
              <asp:TemplateField HeaderText="Customer ID" ItemStyle-Width="150">
                <ItemTemplate>
                    <asp:Label ID="lblCustID" runat="server" Text='<%# Eval("CustomerID") %>'></asp:Label>
                </ItemTemplate>
            <%--    <EditItemTemplate>
                    <asp:TextBox ID="txtName" runat="server" Text='<%# Eval("Name") %>'></asp:TextBox>
                </EditItemTemplate>--%>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Name" ItemStyle-Width="150">
                <ItemTemplate>
                    <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtName" runat="server" Text='<%# Eval("Name") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Address" ItemStyle-Width="150">
                <ItemTemplate>
                    <asp:Label ID="lblAddress" runat="server" Text='<%# Eval("Address") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtAddress" runat="server" Text='<%# Eval("Address") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
                 <asp:TemplateField HeaderText="Mobile No" ItemStyle-Width="150">
                <ItemTemplate>
                    <asp:Label ID="lblMobileno" runat="server" Text='<%# Eval("Mobileno") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtMobileno" runat="server" Text='<%# Eval("Mobileno") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
                   <asp:TemplateField HeaderText="Email ID" ItemStyle-Width="150">
                <ItemTemplate>
                    <asp:Label ID="lblemailId" runat="server" Text='<%# Eval("EmailID") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtemailId" runat="server" Text='<%# Eval("EmailID") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true"
                ItemStyle-Width="150" />
        </Columns>
    </asp:GridView>
    <table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
        <tr>
            <td style="width: 100px">
                Customer ID: <br />
                <asp:TextBox ID="txtCustID" runat="server" Width="151px" />
            </td>
             <td style="width: 100px">
                Name:<br />
                <asp:TextBox ID="txtName" runat="server" Width="180px" />
            </td>
             <td style="width: 100px">
                 Address:<br />
                <asp:TextBox ID="txtAddress" runat="server" Width="154px" />
            </td>
             <td style="width: 100px">
                 Mobile No:<br />
                <asp:TextBox ID="txtMobile" runat="server" Width="122px" />
            </td>
            <td style="width: 100px">
                Email Id:<br />
                <asp:TextBox ID="txtEmailid" runat="server" Width="145px" style="margin-right: 0px" />
            </td>
            <td style="width: 100px">
                <asp:Button ID="btnAdd" runat="server" Text="Add New" OnClick="btnAdd_Click" Width="103px" Height="30px" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
