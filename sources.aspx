<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sources.aspx.cs" Inherits="newsflippers.sources" %>

<%@ Register src="uc/SourceControlUC.ascx" tagname="SourceControlUC" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <p>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
            BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
            DataKeyNames="NPR_ID" DataSourceID="SqlDataSource1" GridLines="Vertical">
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" />
                <asp:BoundField DataField="NPR_PARENT_ID" HeaderText="NPR_PARENT_ID" 
                    SortExpression="NPR_PARENT_ID" />
                <asp:BoundField DataField="NPR_TITLE" HeaderText="NPR_TITLE" 
                    SortExpression="NPR_TITLE" />
                <asp:BoundField DataField="NPR_DESC" HeaderText="NPR_DESC" 
                    SortExpression="NPR_DESC" />
                <asp:BoundField DataField="NPR_URL" HeaderText="NPR_URL" 
                    SortExpression="NPR_URL" />
                <asp:CheckBoxField DataField="NPR_ACTIVE" HeaderText="NPR_ACTIVE" 
                    SortExpression="NPR_ACTIVE" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="#DCDCDC" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:con %>" 
            DeleteCommand="DELETE FROM SOURCES WHERE (NPR_ID = @npr_id)" 
            SelectCommand="SELECT NPR_ID, NPR_PARENT_ID, NPR_TITLE, NPR_DESC, NPR_URL, NPR_LANG, NPR_ACTIVE FROM SOURCES">
            <DeleteParameters>
                <asp:Parameter Name="npr_id" />
            </DeleteParameters>
        </asp:SqlDataSource>
    </p>
    <p>
        ParentId:
        <uc1:SourceControlUC ID="SourceControlUC1" runat="server" />
    </p>
    <p>
        Title:
        <asp:TextBox ID="txtTitle" runat="server" Width="557px"></asp:TextBox>
    </p>
    <p>
        Description:
        <asp:TextBox ID="txtDesc" runat="server" Width="561px"></asp:TextBox>
    </p>
    <p>
        Url:
        <asp:TextBox ID="txtUrl" runat="server" Width="665px"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Insert" onclick="Button1_Click" />
    </p>
    <asp:Label ID="Label1" runat="server"></asp:Label>
    </form>
</body>
</html>
